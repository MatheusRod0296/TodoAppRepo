using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Commands;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Handlers;
using Todo.Domain.Tests.Repositories;

namespace Todo.Domain.Tests.HandlerTests
{
    [TestClass]
    public class CreateTodoHandlertests
    {
        [TestMethod]
        public void Dado_um_comando_invalido()
        {
            var command = new CreateTodoCommand("", DateTime.Now, "");
            var handler = new TodoHandler(new FakeTodoRepository());
            var result = (GenericCommandResult)handler.Handler(command);


            Assert.AreEqual(result.Sucess, false);
        }


        [TestMethod]
        public void Dado_um_comando_valido()
        {
            var command = new CreateTodoCommand("title", DateTime.Now, "usuario");
            var handler = new TodoHandler(new FakeTodoRepository());
            var result = (GenericCommandResult)handler.Handler(command);
            Assert.AreEqual(result.Sucess, true);
        }

    }
}