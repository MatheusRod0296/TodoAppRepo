using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Entities;

namespace Todo.Domain.Tests.EntityTests
{
    [TestClass]
    public class TodoItemTests
    {
        [TestMethod]
        public void Dado_um_novo_todo_o_mesmo_nao_pode_ser_cancelado(){
            var todo = new TodoItem("titulo",  DateTime.Now, "uhsus");
            Assert.AreEqual(todo.Done, false);
            

        }
        
    }
}