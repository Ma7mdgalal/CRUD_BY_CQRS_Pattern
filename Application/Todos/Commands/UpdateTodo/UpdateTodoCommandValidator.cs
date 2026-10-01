using FluentValidation;

namespace Application.Todos.Commands.UpdateTodo;

public class UpdateTodoCommandValidator : AbstractValidator<UpdateTodoCommand>
{
    public UpdateTodoCommandValidator()
    {
        RuleFor(C => C.Title).NotEmpty().WithMessage("The Title should not empty");
        RuleFor(c=> c.Id).NotEmpty().WithMessage("Id should not be empty");
        
        // RuleFor(c=> c.Completed).b
        
    }
    
}
