using HomeOrganizer.Application.Common.Attributes;
using HomeOrganizer.Application.Common.Interfaces;
using MediatR;

namespace HomeOrganizer.Application.Common.Behaviours;

public class AuthenticationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
{
    private readonly ICurrentUser _currentUser;

    public AuthenticationBehavior(ICurrentUser currentUser)
    {
        _currentUser = currentUser;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var authenticatedAttribute =
            request.GetType().GetCustomAttributes(true).Any(a => a.GetType() == typeof(Authenticated)|| a.GetType().IsSubclassOf(typeof(Authenticated)));

        if (authenticatedAttribute && !_currentUser.IsAuthenticated)
        {
            throw new UnauthorizedAccessException();
        }

        return await next(cancellationToken);
    }
}