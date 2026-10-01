using FluentValidation;

namespace Application.Todos.Commands.DeleteTodo;

public class DeleteTodoCommandValidator : AbstractValidator<DeleteTodoCommand>
{
    public DeleteTodoCommandValidator()
    {
        RuleFor(c=> c.Id).NotEmpty().WithMessage("Id should not be empty");
        
    }

    
    
}