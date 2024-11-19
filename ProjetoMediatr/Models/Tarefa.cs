using System.ComponentModel.DataAnnotations;

namespace ProjetoMediatr.Models;

public class Tarefa
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [StringLength(100)]
    public string? Descricao { get; set; }
}
