using Application.Common.Interfaces;
using Domain.Todos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Todos.Queries.GetTodos;

public class GetTodosQueryHandler(IAppDbContext context) : IRequestHandler<GetTodosQuery, IReadOnlyList<Todo>>
{
    public async Task<IReadOnlyList<Todo>> Handle(GetTodosQuery request, CancellationToken cancellationToken)
    {
        return await context.Todos.ToListAsync(cancellationToken);
    }
}