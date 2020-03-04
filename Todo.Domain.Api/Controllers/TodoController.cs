using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Todo.Domain.Commands;
using Todo.Domain.Entities;
using Todo.Domain.Handlers;
using Todo.Domain.Repositories;

namespace Todo.Domain.Api.Controllers
{
    [ApiController]
    [Route("v1/Todos")]
    [Authorize]
    public class TodoController : ControllerBase
    {
        [Route("")]
        [HttpPost]
        public GenericCommandResult Create([FromBody] CreateTodoCommand commad, [FromServices]TodoHandler handler)
        {

            commad.User = User.Claims.FirstOrDefault( x => x.Type == "user_id" )?.Value;

            return (GenericCommandResult)handler.Handler(commad);
        }

        [Route("")]
        [HttpPut]
        public GenericCommandResult Update([FromBody] UpdateToDoCommand commad, [FromServices]TodoHandler handler)
        {

            commad.User = User.Claims.FirstOrDefault( x => x.Type == "user_id" )?.Value;;
            return (GenericCommandResult)handler.Handler(commad);
        }

        [Route("mark-as-done")]
        [HttpPut]
        public GenericCommandResult Update([FromBody] MarkTodoAsDoneCommand commad, [FromServices]TodoHandler handler)
        {

            commad.User = User.Claims.FirstOrDefault( x => x.Type == "user_id" )?.Value;;
            return (GenericCommandResult)handler.Handler(commad);
        }

        [Route("mark-as-undone")]
        [HttpPut]
        public GenericCommandResult Update([FromBody] MarkToDoAsUndoneCommand commad, [FromServices]TodoHandler handler)
        {

            commad.User = User.Claims.FirstOrDefault( x => x.Type == "user_id" )?.Value;;
            return (GenericCommandResult)handler.Handler(commad);
        }

        [Route("")]
        [HttpGet]
        public IEnumerable<TodoItem> GetAll([FromServices]ITodoRepository repository)
        {
            var user = User.Claims.FirstOrDefault( x => x.Type == "user_id" )?.Value;
            return repository.GetAll(user);
        }

        

        [Route("done")]
        [HttpGet]
        public IEnumerable<TodoItem> GetAllDone([FromServices]ITodoRepository repository)
        {
             var user = User.Claims.FirstOrDefault( x => x.Type == "user_id" )?.Value;
            return repository.GetAllDone(user);
        }

        [Route("undone")]
        [HttpGet]
        public IEnumerable<TodoItem> GetAllUnDone([FromServices]ITodoRepository repository)
        {
             var user = User.Claims.FirstOrDefault( x => x.Type == "user_id" )?.Value;
            return repository.GetAllUndone(user);
        }

        [Route("done/today")]
        [HttpGet]
        public IEnumerable<TodoItem> GetAllDoneToday([FromServices]ITodoRepository repository)
        {
             var user = User.Claims.FirstOrDefault( x => x.Type == "user_id" )?.Value;
            return repository.GetAllByPeriod(user, DateTime.Now.Date, true);
        }

         [Route("undone/today")]
        [HttpGet]
        public IEnumerable<TodoItem> GetAllUnDoneToday([FromServices]ITodoRepository repository)
        {
             var user = User.Claims.FirstOrDefault( x => x.Type == "user_id" )?.Value;
            return repository.GetAllByPeriod(user, DateTime.Now.Date, false);
        }

        [Route("done/tomorrow")]
        [HttpGet]
        public IEnumerable<TodoItem> GetAllDoneTomorrow([FromServices]ITodoRepository repository)
        {
             var user = User.Claims.FirstOrDefault( x => x.Type == "user_id" )?.Value;
            return repository.GetAllByPeriod(user, DateTime.Now.Date.AddDays(1), true);
        }

         [Route("uddone/tomorrow")]
        [HttpGet]
        public IEnumerable<TodoItem> GetAllUnDoneTomorrow([FromServices]ITodoRepository repository)
        {
             var user = User.Claims.FirstOrDefault( x => x.Type == "user_id" )?.Value;
            return repository.GetAllByPeriod(user, DateTime.Now.Date.AddDays(1), false);
        }

    }
}