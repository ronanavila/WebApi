using FluentValidation;

namespace FastTech.Aplication.Services.ProductHandlers;

public class RegisterProductRequestValidator : AbstractValidator<RegisterProductRequest>
{
    public RegisterProductRequestValidator()
    {
        RuleFor(p => p.Nome).NotEmpty().WithMessage("O nome do produto é obrigatório.")
            .MinimumLength(3).WithMessage("O nome deve ter no mínimo {MinLength} caracteres.")
            .MaximumLength(200).WithMessage("O produto deve ter no máximo {MaxLength} caracteres.");

        RuleFor(p => p.Descricao).NotEmpty().WithMessage("A descrição do produto é obrigatória.")
            .MinimumLength(3).WithMessage("A descrição deve ter no mínimo {MinLength} caracteres.")
            .MaximumLength(700).WithMessage("A descrição deve ter no máximo {MaxLength} caracteres.");

        RuleFor(p => p.Valor)
            .NotEmpty().WithMessage("O valor do produto é obrigatório.")
            .GreaterThan(0).WithMessage("O valor do produto deve ser maior que {ComparisonValue}.");

        RuleFor(p => p.QuantidadeEstoque)
            .NotEmpty().WithMessage("A quantidade de estoque é obrigatória.")
            .GreaterThan(0).WithMessage("A quantidade de estoque deve ser maior que {ComparisonValue}.");

        RuleFor(p => p.Tipo)
             .NotNull().WithMessage("O tipo é obrigatório.");
    }
}
