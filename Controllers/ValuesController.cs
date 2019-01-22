using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApI.DBServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApI.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
        // GET: api/<controller>
        [HttpGet]
        //Will only support json responses
        //[Produces("application/json")]
        //Will only support json requests
        //[Consumes("application/json")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        //? - specifies that the parameter is optional
        //[HttpGet("{id?}")]
        //Optional parameter with default value
        //[HttpGet("{id=123}")]
        //constrain the parameter as a type
        //[HttpGet("{id:int}")]
        //attribute that intializes a parameter as a querystring variable
        //[FromQuery]
        //[HttpGet("{id}")]
        //public string Get([FromQuery]int id,string query,int num)
        //{
        //    return $"ID value is {id} query = {query} number = {num}";
        //}

        [HttpGet("{id}")]
        public IActionResult Get(int id, string query)
        {
            return Ok(new Person { ID = id, FirstName = "id " + id });
        }

        // POST api/<controller>
        [HttpPost]
        //[Route("SavePerson")]
        public IActionResult Post([FromBody]Person value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //create implementation for DB
            return CreatedAtAction("Get", new { id = value.ID }, value);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}

        public class Person
        {
            public int ID { get; set; }

            //Attribute that specifies the minimum length of array or string data
            [MinLength(3)]
            public string FirstName { get; set; }
        }
    }
}
