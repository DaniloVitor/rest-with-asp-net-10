using Microsoft.AspNetCore.Mvc;
using RestWithASPNET10.Data.DTO;
using RestWithASPNET10.Model;
using RestWithASPNET10.Services;

namespace RestWithASPNET10.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private IPersonServices _personServices;
        private readonly ILogger<PersonController> _logger;

        public PersonController(IPersonServices personServices, ILogger<PersonController> logger)
        {
            _personServices = personServices;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get() 
        {
            _logger.LogInformation("Fetching all persons");
            return Ok(_personServices.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            _logger.LogInformation("Fetching person with ID {id}", id);
            var person = _personServices.FindById(id);
            if (person == null)
            {
                _logger.LogWarning("Fetching person with ID {id} não encontrado", id);
                return NotFound();
            }

            return Ok(person);
        }

        [HttpPost]
        public IActionResult Post([FromBody] PersonDTO person)
        {
            _logger.LogInformation("Creating new Person: {firstName}", person.FirstName);
            var CreatedPerson = _personServices.Create(person);

            if (CreatedPerson == null)
            {
                _logger.LogInformation("Failed to create person with name: {firstName}", person.FirstName);
                return NotFound();
            }

            return Ok(CreatedPerson);
        }

        [HttpPut]
        public IActionResult Put([FromBody] PersonDTO person)
        {
            _logger.LogInformation("Updating person with ID {id}", person.Id);
            var UpdatePerson = _personServices.Update(person);

            if (UpdatePerson == null)
            {
                _logger.LogError("Failed updating person with ID {id}", person.Id);
                return NotFound();
            }
            _logger.LogDebug("Person updated succesfully: {firstName}", UpdatePerson.FirstName);
            return Ok(UpdatePerson);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _logger.LogInformation("Fetching person with ID {id}", id);
            _personServices.Delete(id);

            return NoContent();
        }
    }
}
