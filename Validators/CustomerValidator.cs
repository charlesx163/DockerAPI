using DockerAPI.Models;
using FluentValidation;

namespace DockerAPI.Validators
{
    public class CustomerValidator: AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(c => c.Name).NotNull();
            //RuleFor(c => c.Address).SetValidator(new AddressValidator());
            RuleFor(c => c.Address.Postcode).NotNull().When(c => c.Address != null);
               
        }
    }
}
