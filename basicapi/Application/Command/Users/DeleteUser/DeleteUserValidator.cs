using System.Data;
using FluentValidation;
public class DeleteUserValidator : AbstractValidator<DeleteUserCommand>
{
    public DeleteUserValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("User ID cannot be empty.");
    }
}