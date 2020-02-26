using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Commands;

namespace Todo.Domain.Tests.commandsTests
{
    [TestClass]
    public class CreateTodoCommandTests
    {
        [TestMethod]
        public void Dado_um_command_invalido(){
            var command = new CreateTodoCommand("", DateTime.Now, "");
            command.Validate();

            Assert.AreEqual(command.Valid, false);
        }

        
        [TestMethod]
        public void Dado_um_command_valido(){
            var command = new CreateTodoCommand("titulo da tarefa", DateTime.Now, "Matheus Rodrigues");
            command.Validate();

            Assert.AreEqual(command.Valid, true);
        }


    }
}