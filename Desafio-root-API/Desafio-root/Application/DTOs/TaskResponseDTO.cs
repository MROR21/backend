using Desafio_root.Domain.ValueObject;
using System.Globalization;

namespace Desafio_root.Application.DTOs
{
    public record TaskResponseDTO
        (
        Guid Id,
        string Title,
        string Description,
        Priority Priority,
        DateTime DueDate,
        string Status
        )
    { }
}
