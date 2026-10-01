using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace Application.Todos.Commands.DeleteTodo;

public sealed record DeleteTodoCommand(Guid Id):IRequest;