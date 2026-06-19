using Microsoft.AspNetCore.Mvc;
using TaskChallenge.Application.Exceptions;
using TaskChallenge.Application.UseCases.Tasks.Create;
using TaskChallenge.Application.UseCases.Tasks.Delete;
using TaskChallenge.Application.UseCases.Tasks.GetAll;
using TaskChallenge.Application.UseCases.Tasks.GetById;
using TaskChallenge.Application.UseCases.Tasks.Update;
using TaskChallenge.Communication.Requests;
using TaskChallenge.Communication.Responses;

namespace TaskChallenge.API.Controllers;

[ApiController]
[Route("api/tasks")]
public class TasksController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseTaskJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status400BadRequest)]
    public IActionResult Create([FromBody] RequestTaskJson request)
    {
        try
        {
            var response = new CreateTaskUseCase().Execute(request);
            return Created(string.Empty, response);
        }
        catch (ValidationException exception)
        {
            return BadRequest(new ResponseErrorsJson
            {
                Errors = [.. exception.Errors],
            });
        }
    }

    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(ResponseTaskJson), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status400BadRequest)]
    public IActionResult GetById([FromRoute] Guid id)
    {
        try
        {
            var response = new GetByIdTaskUseCase().Execute(id);
            return Ok(response);
        }catch(ValidationException exception)
        {
            return BadRequest(new ResponseErrorsJson
            {
                Errors = [.. exception.Errors],
            });
        }
    }

    [HttpGet]
    [ProducesResponseType(typeof(ResponseAllTasksJson), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status400BadRequest)]
    public IActionResult GetAll()
    {
        try
        {
            var response = new GetAllTasksUseCase().Execute();
            return Ok(response);
        }catch(ValidationException exception)
        {
            return BadRequest(new ResponseErrorsJson
            {
                Errors = [.. exception.Errors],
            });
        }
    }

    [HttpPut("{id}")]
    [ProducesResponseType(typeof(ResponseTaskJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status404NotFound)]
    public IActionResult Update([FromRoute] Guid id, [FromBody] RequestTaskJson request)
    {
        try
        {
            var response = new UpdateTaskUseCase().Execute(id, request);
            return Ok(response);
        }
        catch (ValidationException exception)
        {
            return BadRequest(new ResponseErrorsJson
            {
                Errors = [.. exception.Errors],
            });
        }
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResponseErrorsJson), StatusCodes.Status404NotFound)]
    public IActionResult Delete([FromRoute] Guid id)
    {
        try
        {
            new DeleteTaskUseCase().Execute(id);
            return NoContent();
        }
        catch (ValidationException exception)
        {
            return BadRequest(new ResponseErrorsJson
            {
                Errors = [.. exception.Errors],
            });
        }
    }
}
