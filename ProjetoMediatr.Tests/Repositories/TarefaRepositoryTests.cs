//using System;
//using System.Threading.Tasks;
//using Xunit;
//using Microsoft.EntityFrameworkCore;
//using ProjetoMediatr.Models;
//using ProjetoMediatr.Repositories;

//public class TarefaRepositoryTests
//{
//    private readonly DbContextOptions<DbContext> _options;

//    public TarefaRepositoryTests()
//    {
//        _options = new DbContextOptionsBuilder<DbContext>()
//            .UseInMemoryDatabase("TestDb")
//            .Options;
//    }

//    [Fact]
//    public async Task AdicionarTarefa_DeveAdicionarCorretamente()
//    {
//        using (var context = new DbContext(_options))
//        {
//            // var repository = new TarefaRepository(context);

//            var tarefa = new Tarefa
//            {
//                Id = Guid.NewGuid(),
//                Descricao = "Nova tarefa",
//            };

//            // await repository.AdicionarTarefa(tarefa);

//            // var tarefaAdicionada = await context.Tarefa.FindAsync(tarefa.Id);

//            Assert.NotNull(tarefaAdicionada);
//            Assert.Equal("Nova tarefa", tarefaAdicionada.Descricao);
//        }
//    }

//    [Fact]
//    public async Task ObterTarefaPorId_DeveRetornarTarefaExistente()
//    {
//        using (var context = new DbContext(_options))
//        {
//            var tarefa = new Tarefa
//            {
//                Id = Guid.NewGuid(),
//                Descricao = "Tarefa existente",
//            };
//            context.Tarefa.Add(tarefa);
//            await context.SaveChangesAsync();

//            var repository = new TarefaRepository(context);

//            var tarefaObtida = await repository.ObterPorIdAsync(tarefa.Id);

//            Assert.NotNull(tarefaObtida);
//            Assert.Equal(tarefa.Descricao, tarefaObtida.Descricao);
//        }
//    }
//}
