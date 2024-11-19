using ProjetoMediatr.Models;

namespace ProjetoMediatr.Repositories;

public interface ITarefaRepository
{
    Task<Guid> AdicionarTarefa (Tarefa tarefa);
    Task<Tarefa> ObterTarefa (Guid id);
}
