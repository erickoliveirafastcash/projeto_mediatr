using System;
using System.Threading.Tasks;
using Xunit;
using Moq;
using ProjetoMediatr.Models;
using ProjetoMediatr.Repositories;
using ProjetoMediatr.Services;

public class TarefaServiceTests
{
    private readonly Mock<ITarefaRepository> _repositoryMock;
    private readonly TarefaService _service;

    public TarefaServiceTests()
    {
        _repositoryMock = new Mock<ITarefaRepository>();
        _service = new TarefaService(_repositoryMock.Object);
    }

    [Fact]
    public async Task ObterTarefaPorId_DeveRetornarTarefaQuandoExistir()
    {
        // Arrange
        var tarefaId = Guid.NewGuid();
        var tarefa = new Tarefa
        {
            Id = tarefaId,
            Descricao = "Tarefa mockada",
        };

        _repositoryMock.Setup(r => r.ObterTarefa(tarefaId))
                       .ReturnsAsync(tarefa);

        // Act
        var resultado = await _service.ObterTarefa(tarefaId);

        // Assert
        Assert.NotNull(resultado);
        Assert.Equal("Tarefa mockada", resultado.Descricao);
    }

    [Fact]
    public async Task ObterTarefaPorId_DeveRetornarNullQuandoNaoExistir()
    {
        // Arrange
        var tarefaId = Guid.NewGuid();
        _repositoryMock.Setup(r => r.ObterTarefa(tarefaId))
                       .ReturnsAsync((Tarefa)null);

        // Act
        var resultado = await _service.ObterTarefa(tarefaId);

        // Assert
        Assert.Null(resultado);
    }
}
