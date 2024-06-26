using Backend.DTOs;
using FluentValidation;

namespace Backend.Validators
{
    public class BeerInsertValidator : AbstractValidator<BeerInsertDto> //Indica que dto o que modelo va a validar
    {
        public BeerInsertValidator() {
            RuleFor(x => x.Name).NotEmpty().WithMessage("El nombre es obligatorio");//indica la validacion y modifica el mensaje de error
            RuleFor(x => x.Name).Length(2, 20).WithMessage("El nombre es debe medir de 2 a 20 caracteres");
            RuleFor(x => x.BrandId).NotNull().WithMessage(x => "La marca es obligatoria");
            RuleFor(x => x.BrandId).GreaterThan(0).WithMessage(x => "error con el valor enviado de la marca");
            RuleFor(x => x.Alcohol).GreaterThan(0).WithMessage(x => "El {PropertyName} debe ser mayor a 0");
        }
    }
}
