using MediatR;

namespace Application.Todos.Commands.CreateTodo;
public sealed record CreateTodoCommand(string title): IRequest<Guid>;
