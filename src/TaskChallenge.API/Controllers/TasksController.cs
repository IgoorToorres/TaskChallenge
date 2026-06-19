using Microsoft.AspNetCore.Mvc;
using TaskChallenge.Application.Exceptions;
using TaskChallenge.Application.UseCases.Tasks.Create;
using TaskChallenge.Communication.Requests;
using TaskChallenge.Communication.Responses;

namespace TaskChallenge.API.Controllers;

[ApiController]
[Route("[controller]")]
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
}
