using System.Security.Claims;
using HomeOrganizer.Application.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using FirebaseAdmin.Auth;

namespace HomeOrganizer.API.Filters;
public class FirebaseAuthenticationFilter : IAuthorizationFilter
{

    private readonly IIdentityService _identityService;
    public FirebaseAuthenticationFilter(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        #if DEBUG
        if (_identityService.StoreCurrentUser("hcurtillet@eneance.com"))
        {
            return;
        }
        #endif
        string authorizationHeader = context.HttpContext.Request.Headers["Authorization"];

        if (authorizationHeader != null && authorizationHeader.StartsWith("Bearer "))
        {
            var idToken = authorizationHeader.Substring("Bearer ".Length);

            try
            {
                var decodedTokenTask = FirebaseAuth.DefaultInstance.VerifyIdTokenAsync(idToken);
                decodedTokenTask.Wait();
                var decodedToken = decodedTokenTask.Result;
                var uid = decodedToken.Uid;

                var email = decodedToken.Claims["email"].ToString();
                // var email = firebaseUser.Email;
                _identityService.StoreCurrentUser(email);
                
            }
            catch (AggregateException ex) when (ex.InnerExceptions.Any(e => e is FirebaseAuthException))
            {
                var firebaseEx = ex.InnerExceptions.First(e => e is FirebaseAuthException) as FirebaseAuthException;
                if (firebaseEx?.AuthErrorCode == AuthErrorCode.InvalidIdToken ||
                    firebaseEx?.AuthErrorCode == AuthErrorCode.ExpiredIdToken)
                {
                    context.Result = new UnauthorizedResult();
                    return;
                }

                context.Result = new StatusCodeResult(500);
            }
            catch (Exception e)
            {
                context.Result = new StatusCodeResult(500);
            }
        }
    }
}