using UniAdmin.Contracts.DTO;
using FluentValidation;

namespace UniAdmin.Core.Validators
{
    public class CreateDealDTOValidator : AbstractValidator<CreateDealDTO>
    {
        public CreateDealDTOValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Amount).NotEmpty().WithMessage("Provide the deal an amount");
        }
    }
}
