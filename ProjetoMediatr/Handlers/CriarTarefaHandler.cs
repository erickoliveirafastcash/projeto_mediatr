using MediatR;
using ProjetoMediatr.Commands;
using ProjetoMediatr.Services;

namespace ProjetoMediatr.Handlers;

public class CriarTarefaHandler : IRequestHandler<CriarTarefaCommand, Guid>
{
    private readonly ITarefaService _service;

    public CriarTarefaHandler(ITarefaService service)
    {
        _service = service;
    }

    public async Task<Guid> Handle(CriarTarefaCommand request, 
                CancellationToken cancellationToken)
    {
        return await _service.AdicionarTarefa(request.Descricao);
    }
}
