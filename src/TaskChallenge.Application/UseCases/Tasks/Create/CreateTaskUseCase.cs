using TaskChallenge.Application.Exceptions;
using TaskChallenge.Communication.Enums;
using TaskChallenge.Communication.Requests;
using TaskChallenge.Communication.Responses;

namespace TaskChallenge.Application.UseCases.Tasks.Create;

public class CreateTaskUseCase
{
    public ResponseTaskJson Execute(RequestTaskJson request)
    {
        var errors = Validate(request);

        if (errors.Count > 0)
        {
            throw new ValidationException(errors);
        }

        return new ResponseTaskJson
        {
            Id = Guid.NewGuid(),
            Name = request.Name.Trim(),
            Description = request.Description.Trim(),
            DueDate = request.DueDate,
            Priority = request.Priority.ToString(),
            Status = request.Status.ToString(),
        };
    }

    private static List<string> Validate(RequestTaskJson request)
    {
        var errors = new List<string>();

        if (string.IsNullOrWhiteSpace(request.Name))
        {
            errors.Add("O nome da tarefa é obrigatório.");
        }
        else if (request.Name.Trim().Length > 100)
        {
            errors.Add("O nome da tarefa deve ter no máximo 100 caracteres.");
        }

        if (string.IsNullOrWhiteSpace(request.Description))
        {
            errors.Add("A descrição da tarefa é obrigatória.");
        }
        else if (request.Description.Trim().Length > 500)
        {
            errors.Add("A descrição da tarefa deve ter no máximo 500 caracteres.");
        }

        if (request.DueDate <= DateTime.Now)
        {
            errors.Add("A data de vencimento deve estar no futuro.");
        }

        if (request.Priority == Priority.NotSpecified || !Enum.IsDefined(request.Priority))
        {
            errors.Add("A prioridade informada é inválida.");
        }

        if (request.Status == Status.NotSpecified || !Enum.IsDefined(request.Status))
        {
            errors.Add("O status informado é inválido.");
        }

        return errors;
    }
}
