using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Entities;
using Todo.Domain.Queries;

namespace Todo.Domain.Tests.QueryTests
{
    [TestClass]
    public class TodoQueryTests
    {
        private List<TodoItem> _itens;

        public TodoQueryTests(){
            _itens = new List<TodoItem>();
            _itens.Add(new TodoItem("tefara 1", DateTime.Now, "userA"));
            _itens.Add(new TodoItem("tefara 1", DateTime.Now, "userA"));
            _itens.Add(new TodoItem("tefara 1", DateTime.Now, "userA"));
            _itens.Add(new TodoItem("tefara 1", DateTime.Now, "userA"));
            _itens.Add(new TodoItem("tefara 1", DateTime.Now, "Matheus"));
            _itens.Add(new TodoItem("tefara 1", DateTime.Now, "Matheus"));
        }

        [TestMethod]
        public void Dada_a_consulta_deve_restornar_tarefas_apenas_do_usuario()
        {
            var result = _itens.AsQueryable().Where(TodoQueries.GetAll("Matheus"));
         

            Assert.AreEqual(2, result.Count());

        }
    }
}