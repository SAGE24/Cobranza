using FluentValidation;

namespace Service.EventHandler.Commands.Validators;
public class DebtorVal : AbstractValidator<Debtor>
{
    public DebtorVal()
    {
        RuleFor(p => p.Document).NotEmpty().Matches("^[0-9]+$").WithMessage("Error al ingresar número de documento");
        RuleFor(p => p.DocumentType).NotEmpty().NotNull();
        RuleFor(p => p.Name).NotEmpty().NotNull();
        RuleFor(p => p.UserName).NotEmpty().NotNull();
    }
}
