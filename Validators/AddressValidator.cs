using DockerAPI.Models;
using FluentValidation;

namespace DockerAPI.Validators
{
    public class AddressValidator:AbstractValidator<Address>
    {
        public AddressValidator()
        {
            RuleFor(x => x.Postcode).NotNull();
        }
    }
}
