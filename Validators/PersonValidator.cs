using DockerAPI.Models;
using FluentValidation;

namespace DockerAPI.Validators
{
    public class PersonValidator : AbstractValidator<Person>
    {
        public PersonValidator()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.Age).InclusiveBetween(18,60);
            RuleSet("Names", () =>
            {
                RuleFor(x => x.Name).Length(0, 10);
                RuleFor(x => x.SurName).Length(3, 10);
            });
        }
    }
}
