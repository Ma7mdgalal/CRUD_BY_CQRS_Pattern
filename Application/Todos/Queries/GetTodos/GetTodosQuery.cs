using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Todos;
using FluentValidation;
using MediatR;

namespace Application.Todos.Queries.GetTodos;

public sealed class GetTodosQuery:IRequest<IReadOnlyList<Todo>>;
