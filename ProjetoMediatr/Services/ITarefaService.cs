using ProjetoMediatr.Models;

namespace ProjetoMediatr.Services;

public interface ITarefaService
{
    Task<Guid> AdicionarTarefa(string descricao);
    Task<Tarefa> ObterTarefa(Guid id);
}
