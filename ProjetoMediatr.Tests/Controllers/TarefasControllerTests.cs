using System;
using System.Threading.Tasks;
using Xunit;
using Moq;
using ProjetoMediatr.Controllers;
using ProjetoMediatr.Services;
using ProjetoMediatr.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using FluentAssertions;
using ProjetoMediatr.Models;

namespace ProjetoMediatr.Tests.Controllers;

public class TarefasControllerTests
{
    private readonly Mock<IMediator> _mediatorMock;
    private readonly Mock<ITarefaService> _serviceMock;
    private readonly TarefasController _controller;

    public TarefasControllerTests()
    {
        _mediatorMock = new Mock<IMediator>();
        _serviceMock = new Mock<ITarefaService>();
        _controller = new TarefasController(_mediatorMock.Object, _serviceMock.Object);
    }

    [Fact]
    public async Task Criar_DeveRetornarCreated_ComObjetoCriado()
    {
        // Arrange
        var command = new CriarTarefaCommand { Descricao = "Nova tarefa" };
        var tarefaId = Guid.NewGuid();

        _mediatorMock.Setup(m => m.Send(command, default))
                     .ReturnsAsync(tarefaId);

        // Act
        var result = await _controller.Criar(command) as CreatedAtActionResult;

        // Assert
        result.Should().NotBeNull();
        result.StatusCode.Should().Be(201); // Created
        result.Value.Should().BeEquivalentTo(new
        {
            Id = tarefaId,
            Descricao = "Nova tarefa",
        });
    }

    [Fact]
    public async Task Obter_DeveRetornarOk_ComTarefaExistente()
    {
        // Arrange
        var tarefaId = Guid.NewGuid();
        var tarefa = new Tarefa
        {
            Id = tarefaId,
            Descricao = "Tarefa existente",
        };

        _serviceMock.Setup(s => s.ObterTarefa(tarefaId))
                    .ReturnsAsync(tarefa);

        // Act
        var result = await _controller.Obter(tarefaId) as OkObjectResult;

        // Assert
        result.Should().NotBeNull();
        result.StatusCode.Should().Be(200); // OK
        result.Value.Should().BeEquivalentTo(tarefa);
    }

    [Fact]
    public async Task Obter_DeveRetornarNotFound_QuandoTarefaNaoExistir()
    {
        // Arrange
        var tarefaId = Guid.NewGuid();

        _serviceMock.Setup(s => s.ObterTarefa(tarefaId))
                    .ReturnsAsync((Tarefa)null);

        // Act
        var result = await _controller.Obter(tarefaId) as NotFoundObjectResult;

        // Assert
        result.Should().NotBeNull();
        result.StatusCode.Should().Be(404); // Not Found
    }
}
