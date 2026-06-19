using TaskChallenge.Communication.Responses;

namespace TaskChallenge.Application.UseCases.Tasks.GetAll;

public class GetAllTasksUseCase
{
    public ResponseAllTasksJson Execute()
    {
        return new ResponseAllTasksJson
        {
            Tasks = new List<ResponseShortTaskJson>
            {
                new ResponseShortTaskJson
                {
                    Id = Guid.NewGuid(),
                    Name = "Estudar C#",
                    Description = "Finalizar os casos de uso de tarefas.",
                },
                new ResponseShortTaskJson
                {
                    Id = Guid.NewGuid(),
                    Name = "Criar API",
                    Description = "Implementar endpoints de criação e consulta.",
                },
                new ResponseShortTaskJson
                {
                    Id = Guid.NewGuid(),
                    Name = "Configurar banco de dados",
                    Description = "Preparar a persistência das tarefas.",
                },
            },
        };
    }
}