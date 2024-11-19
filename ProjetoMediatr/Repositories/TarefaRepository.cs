using ProjetoMediatr.Models;

namespace ProjetoMediatr.Repositories;

public class TarefaRepository : ITarefaRepository
{
    private readonly List<Tarefa> _tarefas = new();


    public Task<Guid> AdicionarTarefa(Tarefa tarefa)
    {
        _tarefas.Add(tarefa);
        return Task.FromResult(tarefa.Id);
    }

    public Task<Tarefa> ObterTarefa(Guid id)
    {
        var tarefa = _tarefas.FirstOrDefault(t => t.Id == id);
        return Task.FromResult(tarefa);
    }
}
