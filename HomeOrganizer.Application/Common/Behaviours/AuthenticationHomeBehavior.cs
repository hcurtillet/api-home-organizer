using HomeOrganizer.Application.Common.Attributes;
using HomeOrganizer.Application.Common.Interfaces;
using MediatR;

namespace HomeOrganizer.Application.Common.Behaviours;

public class AuthenticationHomeBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : class
{
    private readonly IIdentityService _identityService;

    public AuthenticationHomeBehavior(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        var authenticatedHomeAttribute =
            request.GetType().GetCustomAttributes(true)
                    .FirstOrDefault(a => a.GetType() == typeof(AuthenticatedHome)) as AuthenticatedHome;

        if (authenticatedHomeAttribute != null)
        {
            var homeIdentifierPropertyInfo = request.GetType().GetProperties()
                .FirstOrDefault(p => p.CustomAttributes
                    .Any(a => a.AttributeType == typeof(HomeIdentifier)));
            if (homeIdentifierPropertyInfo == null)
            {
                throw new Exception("Unimplemented behavior");
            }

            var homeIdentifier = (Guid)homeIdentifierPropertyInfo.GetValue(request);
            var role = _identityService.GetCurrentUserRole(homeIdentifier);
            if (!authenticatedHomeAttribute.Roles.Contains(role))
            {
                throw new UnauthorizedAccessException();
            }
        }

        return await next();
    }
}