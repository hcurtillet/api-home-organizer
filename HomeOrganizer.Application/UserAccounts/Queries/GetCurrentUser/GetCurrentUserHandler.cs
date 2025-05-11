using HomeOrganizer.Application.Common.Exceptions;
using HomeOrganizer.Application.Common.Interfaces;
using HomeOrganizer.Application.UserAccounts.Commands.CreateUserAccount;
using HomeOrganizer.Domain.Entities;
using MediatR;

namespace HomeOrganizer.Application.UserAccounts.Queries.GetCurrentUser;

public class GetCurrentUserHandler : IRequestHandler<GetCurrentUserRequest, GetCurrentUserResponse>
{
    private readonly IIdentityService _identityService;
    private readonly IMediator _mediator;

    public GetCurrentUserHandler(IIdentityService identityService, IMediator mediator)
    {
        _identityService = identityService;
        _mediator = mediator;
    }

    public async Task<GetCurrentUserResponse> Handle(GetCurrentUserRequest request, CancellationToken cancellationToken)
    {
        ICurrentUser? user;
        try
        {
            user = _identityService.GetCurrentUser();
        }
        catch (NoCurrentUserException _)
        {
            var currentUserEmail = _identityService.GetCurrentUserEmail();
            var createUserAccountRequest = new CreateUserAccountRequest(currentUserEmail);
            await _mediator.Send(createUserAccountRequest);
            _identityService.StoreCurrentUser(currentUserEmail);
            user = _identityService.GetCurrentUser();
        }
        catch (NoCurrentUserEmailException _)
        {
            throw new UnauthorizedAccessException();
        }
        return new GetCurrentUserResponse(user);
    }
}