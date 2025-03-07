﻿
using FluentValidation;

namespace ECommerce.Application.Features.Products.Commands.Create;

public class ProductAddValidator : AbstractValidator<ProductAddCommand>
{
    public ProductAddValidator()
    {
        RuleFor(x => x.Name).NotNull().WithMessage("İsim alanı boş geçilemez.")
            .MinimumLength(3).WithMessage("Minimum 3 haneli olmalıdır.");
    }
}
