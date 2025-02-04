using AjaxJSONTable1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AjaxJSONTable1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private static List<Person> people = new List<Person>
        {
            new Person { ime = "Janez", starost = 25 },
            new Person { ime = "Micka", starost = 24 },
            new Person { ime = "Polde", starost = 27 }
        };

        [HttpGet]
        public IActionResult GetData()
        {
            var result = new
            {
                st = people.Count,
                seznam = people
            };

            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddData([FromBody] Person newPerson)
        {
            if (newPerson == null)
            {
                return BadRequest("Invalid data.");
            }

            people.Add(newPerson);

            var result = new
            {
                st = people.Count,
                seznam = people
            };

            return Ok(result);
        }
    }
}