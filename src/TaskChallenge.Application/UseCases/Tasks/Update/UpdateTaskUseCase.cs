using TaskChallenge.Application.Exceptions;
using TaskChallenge.Communication.Enums;
using TaskChallenge.Communication.Requests;
using TaskChallenge.Communication.Responses;

namespace TaskChallenge.Application.UseCases.Tasks.Update;

public class UpdateTaskUseCase
{
    public ResponseTaskJson Execute(Guid id, RequestTaskJson request)
    {
        var errors = Validate(id, request);

        if (errors.Count > 0)
        {
            throw new ValidationException(errors);
        }

        // Futuramente, a tarefa será buscada e atualizada no banco de dados.
        return new ResponseTaskJson
        {
            Id = id,
            Name = request.Name.Trim(),
            Description = request.Description.Trim(),
            DueDate = request.DueDate,
            Priority = request.Priority.ToString(),
            Status = request.Status.ToString(),
        };
    }

    private static List<string> Validate(Guid id, RequestTaskJson request)
    {
        var errors = new List<string>();

        if (id == Guid.Empty)
        {
            errors.Add("O identificador da tarefa é obrigatório.");
        }

        if (string.IsNullOrWhiteSpace(request.Name))
        {
            errors.Add("O nome da tarefa é obrigatório.");
        }

        if (string.IsNullOrWhiteSpace(request.Description))
        {
            errors.Add("A descrição da tarefa é obrigatória.");
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
