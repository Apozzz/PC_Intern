using backend.DTOs.Requests;
using FluentValidation;

namespace backend.DTOs.Validators
{
    public class PizzaOrderRequestValidator : AbstractValidator<PizzaOrderRequestDto>
    {
        public PizzaOrderRequestValidator() 
        {
            RuleFor(x => x.SizeId).NotEmpty();
        }
    }
}
