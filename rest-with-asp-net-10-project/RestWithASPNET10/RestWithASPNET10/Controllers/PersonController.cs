using Microsoft.AspNetCore.Mvc;
using RestWithASPNET10.Model;
using RestWithASPNET10.Services;

namespace RestWithASPNET10.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private IPersonServices _personServices;

        public PersonController(IPersonServices personServices)
        {
            _personServices = personServices;
        }

        [HttpGet]
        public IActionResult Get() 
        { 
            return Ok(_personServices.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var person = _personServices.FindById(id);
            if (person == null)
            {
                return NotFound();
            }

            return Ok(person);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {
            var CreatedPerson = _personServices.Create(person);

            if (CreatedPerson == null)
            { 
                return NotFound();
            }

            return Ok(CreatedPerson);
        }

        [HttpPut]
        public IActionResult Put([FromBody] Person person)
        {
            var UpdatePerson = _personServices.Update(person);

            if (UpdatePerson == null)
            {
                return NotFound();
            }

            return Ok(UpdatePerson);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _personServices.Delete(id);

            return NoContent();
        }

    }
}
