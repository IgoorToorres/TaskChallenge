using TaskChallenge.Application.Exceptions;
using TaskChallenge.Communication.Responses;

namespace TaskChallenge.Application.UseCases.Tasks.GetById;

public class GetByIdTaskUseCase
{
    public ResponseTaskJson Execute(Guid id)
    {
        var errors = Validate(id);

        if (errors.Count > 0)
        {
            throw new ValidationException(errors);
        }

        return new ResponseTaskJson
        {
            Id = id,
            Name = "Tarefa fictícia",
            Description = "Esta tarefa é retornada enquanto o banco de dados não está implementado.",
            DueDate = DateTime.Now.AddDays(7),
            Priority = "Medium",
            Status = "Pending",
        };
    }

    private static List<string> Validate(Guid id)
    {
        var errors = new List<string>();

        if (id == Guid.Empty)
        {
            errors.Add("O identificador da tarefa é obrigatório.");
        }

        return errors;
    }
}
