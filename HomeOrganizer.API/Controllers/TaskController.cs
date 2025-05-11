using AutoMapper;
using HomeOrganizer.API.Dto.Task;
using HomeOrganizer.Application.Tasks.Commands.CreateTask;
using HomeOrganizer.Application.Tasks.Commands.UpdateTask;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HomeOrganizer.API.Controllers;

[ApiController]
[Route("[controller]")]
public class TaskController: Controller
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public TaskController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> CreateTask([FromBody] CreateTaskDto createTaskDto)
    {
        var response = await _mediator.Send(new CreateTaskRequest(
            createTaskDto.HomeId,
            createTaskDto.Description,
            createTaskDto.DueDt,
            createTaskDto.DueTm,
            createTaskDto.UserAccountIds
        ));
        return Ok(_mapper.Map<TaskDto>(response.Task));
    }

    [HttpPatch("{id:guid}")]
    public async Task<IActionResult> UpdateTask([FromRoute] Guid id, [FromBody] UpdateTaskDto updateTaskDto)
    {
        try
        {
            var response = await _mediator.Send(new UpdateTaskRequest(id, updateTaskDto.Description,
                updateTaskDto.DueDt, updateTaskDto.DueTm, updateTaskDto.TaskStatus, updateTaskDto.UserAccountIdsToAdd,
                updateTaskDto.UserAccountIdsToRemove));
            return Ok(_mapper.Map<TaskDto>(response.Task));
        }
        catch (UnauthorizedAccessException e)
        {
            return Unauthorized(e.Message);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}