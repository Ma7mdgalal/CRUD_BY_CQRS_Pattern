using FluentValidation;

namespace Application.Todos.Commands.CreateTodo;

public class CreateTodoCommandValidator : AbstractValidator<CreateTodoCommand>
{
    public CreateTodoCommandValidator()
    {
        RuleFor(C => C.title).NotEmpty().WithMessage("The Title should not empty");
        
    }
    
}
