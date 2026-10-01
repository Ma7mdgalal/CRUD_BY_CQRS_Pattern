using FluentValidation;

namespace Application.Todos.Queries.GetTodoById;

public class GetTodoByIdQueryValidator : AbstractValidator<GetTodoByIdQuery>
{
    public GetTodoByIdQueryValidator()
    {
        RuleFor(T => T.Id).NotEmpty();
        
    }
}