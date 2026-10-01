using Application.Common.Interfaces;
using Domain.Todos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Todos.Queries.GetTodos;

// public class GetTodosQueryValidator : AbstractValidator<GetTodosQuery>
// {
//     public GetTodosQuery()
//     {


//     }

// }
public class GetTodosQueryHandler(IAppDbContext context) : IRequestHandler<GetTodosQuery, IReadOnlyList<Todo>>
{
    public async Task<IReadOnlyList<Todo>> Handle(GetTodosQuery request, CancellationToken cancellationToken)
    {
        IReadOnlyList<Todo> todos=await context.Todos.ToListAsync(cancellationToken);
        return todos.Count != 0 ? todos: throw new NotFiniteNumberException();
    
    }
}