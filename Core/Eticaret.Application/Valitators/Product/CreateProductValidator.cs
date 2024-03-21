using Eticaret.Application.ViewModels.Products;
using FluentValidation;

namespace Eticaret.Application.Valitators.Product;

public class CreateProductValidator:AbstractValidator<VM_Create_Product>
{
    public CreateProductValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty()
            .NotNull()
                .WithMessage("Lütfen Ürün adını boş geçmeyizi")
            .MaximumLength(150)
            .MinimumLength(5)
                .WithMessage("ürün adını 5 ile 150 arasında giriniz");
        RuleFor(p => p.Stock)
            .NotEmpty()
            .NotNull()
                .WithMessage("Stok bilgisini boş bırakmyaıız")
            .Must(s => s > 0).WithMessage("stok bilgisi negatif olamaz");
        RuleFor(p => p.Price)
            .NotEmpty()
            .NotNull()
                .WithMessage("Fiyat bilgisini boş bırakmyaıız")
            .Must(s => s > 0).WithMessage("Fiyat bilgisi hegatif olamaz");
    }
}