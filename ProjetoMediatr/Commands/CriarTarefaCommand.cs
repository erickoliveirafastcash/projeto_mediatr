using MediatR;
using System.ComponentModel.DataAnnotations;

namespace ProjetoMediatr.Commands;

public class CriarTarefaCommand : IRequest<Guid>
{
    [Required(ErrorMessage = "A descrição é obrigatória.")]
    [MaxLength(100, ErrorMessage = "A descrição deve ter no máximo 100 caracteres.")]
    public string? Descricao { get; set; }
}
