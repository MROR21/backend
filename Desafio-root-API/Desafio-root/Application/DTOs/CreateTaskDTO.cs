using Desafio_root.Domain.ValueObject;
using System.ComponentModel.DataAnnotations;

namespace Desafio_root.Application.DTOs
{
    public record CreateTaskDTO
        (
        string Title,
        string Description, 
        [EnumDataType(typeof(Priority), 
        ErrorMessage = "A prioridade deve ser 1 (Baixa), 2 (Media) ou 3 (Alta).")] Priority Priority, 
        DateTime DueDate,
        Guid UserId
        )
    {

    }
}
