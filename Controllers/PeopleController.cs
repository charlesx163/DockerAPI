using DockerAPI.Extensions;
using DockerAPI.Models;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DockerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IValidator<Person> _validator;
        
        public PeopleController(IValidator<Person> validator)
        {
            _validator = validator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Person person)
        {
            ValidationResult result = await _validator.ValidateAsync(person);
            if (!result.IsValid)
            {
                result.AddToModelState(ModelState);
            }

            return result.IsValid ? (IActionResult)Ok(person) : BadRequest(ModelState);
        }
    }
}
