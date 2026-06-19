using TaskChallenge.Communication.Requests;
using TaskChallenge.Communication.Responses;

namespace TaskChallenge.Application.UseCases.Tasks.Create;

public class CreateTaskUseCase
{
    public ResponseTaskJson Execute(RequestTaskJson request)
    {
        return new ResponseTaskJson
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Description = request.Description,
            DueDate = request.DueDate,
            Priority = request.Priority,
            Status = request.Status,
        };
    }
}