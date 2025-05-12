using AutoMapper;
using HomeOrganizer.API.Dto.Home;
using HomeOrganizer.Application.Common.Exceptions;
using HomeOrganizer.Application.Homes.Commands.AddUserAccountToHome;
using HomeOrganizer.Application.Homes.Commands.CreateHome;
using HomeOrganizer.Application.Homes.Commands.RemoveUserAccountToHome;
using HomeOrganizer.Application.Homes.Queries.GetCurrentUserHomes;
using HomeOrganizer.Application.Homes.Queries.GetHome;
using HomeOrganizer.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HomeOrganizer.API.Controllers;

[ApiController]
[Route("[controller]")]
public class HomeController: Controller
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public HomeController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetHomes()
    {
        try
        {
            var response = await _mediator.Send(new GetCurrentUserHomesRequest());

            return Ok(_mapper.Map<List<Home>, List<HomeDto>>(response.Homes));
        }
        catch(Exception e)
        {
            return BadRequest(e);
        }
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetHome([FromRoute] Guid id)
    {
        try
        {
            var response = await _mediator.Send(new GetHomeRequest(id));
            var result = _mapper.Map<Home, HomeDto>(response.Home);
            return Ok(result);
        }
        catch (CurrentUserNoHomeException e)
        {
            return new UnauthorizedObjectResult($"The user {e.UserId} does not have acces to the home {e.HomeId}");
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateHome([FromBody] CreateHomeDto createHomeDto)
    {
        try
        {
            var result = await _mediator.Send(new CreateHomeRequest(createHomeDto.Name));
            return Ok(_mapper.Map<Home, HomeDto>(result.Home));
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
    }
    
    [HttpPost("addUserAccount")]
    public async Task<IActionResult> AddUserAccountToHome(AddUserAccountToHomeDto addUserAccountToHomeDto)
    {
        try
        {
            var result = await _mediator.Send(new AddUserAccountToHomeRequest(addUserAccountToHomeDto.HomeId, addUserAccountToHomeDto.UserAccountId));
            return Ok(_mapper.Map<Home, HomeDto>(result.Home));
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
    }
    
    [HttpDelete("{id:guid}/userAccount/{userAccountId:guid}")]
    public async Task<IActionResult> RemoveUserAccountFromHome([FromRoute] Guid id, [FromRoute] Guid userAccountId)
    {
        try
        {
            await _mediator.Send(new RemoveUserAccountToHomeRequest(id, userAccountId));
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e);
        }
    }
}
