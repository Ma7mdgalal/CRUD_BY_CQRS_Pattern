using Api.Requests;
using Application.Todos.Commands.CreateTodo;
using Application.Todos.Commands.DeleteTodo;
using Application.Todos.Commands.UpdateTodo;
using Application.Todos.Queries.GetTodoById;
using Application.Todos.Queries.GetTodos;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;
[ApiController]
[Route("api/[controller]")]
public class TodosController(IMediator mediator):ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await mediator.Send(new GetTodosQuery());
        return Ok(result);
    }
     [HttpGet("{todoId:guid}",Name="GetTodoById")]
    public async Task<IActionResult> Get(Guid todoId)
    {
        var result = await mediator.Send(new GetTodoByIdQuery(todoId));
        return  Ok(result);
    }
    [HttpPost]
    public async Task<IActionResult> Post(CreateTodoRequest request)
    {
        var Todo = new CreateTodoCommand(request.title);
        var result = await mediator.Send(Todo);
        return CreatedAtAction(nameof(Get), new { todoId = result }, null);
    }
    [HttpPut]
      public async Task<IActionResult> Put(UpdateTodoRequest request)
    {
        var Todo = new UpdateTodoCommand(request.Id,request.Title,request.Completed);
        await mediator.Send(Todo);
        return NoContent();
    }
    [HttpDelete("{todoId:guid}")]
    public async Task<IActionResult> Delete(Guid todoId)
    {
        var todo = new DeleteTodoCommand(todoId);
        await mediator.Send(todo);
        return NoContent();

    }
    

}
