using AutoMapper;
using HomeOrganizer.API.Dto;
using HomeOrganizer.API.Dto.UserAccount;
using HomeOrganizer.Application.Common.Interfaces;
using HomeOrganizer.Application.UserAccounts.Queries.GetCurrentUser;
using HomeOrganizer.Domain.Entities;
using HomeOrganizer.Infrastructure.Authentication;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HomeOrganizer.API.Controllers;

[ApiController]
[Route("[controller]")]
public class UserAccountController: Controller
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    public UserAccountController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet("me")]
    public async Task<IActionResult> GetUserAccount()
    {
        var userResponse = await _mediator.Send(new GetCurrentUserRequest());
        return Ok(_mapper.Map<CurrentUserDto>((CurrentUser)userResponse.CurrentUser));
    }
}