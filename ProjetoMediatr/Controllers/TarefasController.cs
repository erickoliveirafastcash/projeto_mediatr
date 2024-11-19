using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProjetoMediatr.Commands;
using ProjetoMediatr.Services;

namespace ProjetoMediatr.Controllers;

[ApiController]
[Route("api/tarefas")]
public class TarefasController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ITarefaService _tarefaService;

    public TarefasController(IMediator mediator, ITarefaService tarefaService)
    {
        _mediator = mediator;
        _tarefaService = tarefaService;
    }


    [HttpPost]
    public async Task<IActionResult> Criar([FromBody] CriarTarefaCommand command)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var id = await _mediator.Send(command);

        var resposta = new
        {
            Id = id,
            Descricao = command.Descricao,
        };

        return CreatedAtAction(nameof(Obter), new { id }, resposta);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Obter(Guid id)
    {
        var tarefa = await _tarefaService.ObterTarefa(id);
        if (tarefa == null)
            return NotFound(new { Mensagem = "Tarefa não encontrada." });

        return Ok(tarefa);
    }
}
