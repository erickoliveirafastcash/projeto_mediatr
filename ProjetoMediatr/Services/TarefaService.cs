using ProjetoMediatr.Models;
using ProjetoMediatr.Repositories;

namespace ProjetoMediatr.Services;

public class TarefaService : ITarefaService
{
    private readonly ITarefaRepository _repository;

    public TarefaService(ITarefaRepository repository)
    {
        _repository = repository;
    }

    public async Task<Guid> AdicionarTarefa(string descricao)
    {
        var tarefa = new Tarefa
        {
            Id = Guid.NewGuid(),
            Descricao = descricao
        };
        return await _repository.AdicionarTarefa(tarefa);
    }

    public async Task<Tarefa> ObterTarefa(Guid id)
    {
        return await _repository.ObterTarefa(id);
    }
}
