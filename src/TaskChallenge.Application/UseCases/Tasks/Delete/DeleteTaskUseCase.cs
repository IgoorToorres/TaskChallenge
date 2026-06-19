using TaskChallenge.Application.Exceptions;

namespace TaskChallenge.Application.UseCases.Tasks.Delete;

public class DeleteTaskUseCase
{
    public void Execute(Guid id)
    {
        if (id == Guid.Empty)
        {
            throw new ValidationException(["O identificador da tarefa é obrigatório."]);
        }

        // Futuramente, a tarefa será buscada e removida do banco de dados.
    }
}
