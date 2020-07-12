using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VTProject.Models.DomainModels;
using VTProject.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VTProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly DatabaseService _databaseService;

        public PersonController(DatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        // GET: api/<PersonController>
        [HttpGet]
        public IEnumerable<Person> Get()
        {
            return _databaseService.Person.GetAll();
        }

        // GET api/<PersonController>/5
        [HttpGet("{id:int}")]
        public Person Get(int id)
        {
            return _databaseService.Person.Get(id);
        }

        // POST api/<PersonController>
        [HttpPost]
        public async Task Post([FromBody] Person person)
        {
            await _databaseService.Person.Add(person);
        }

        // PUT api/<PersonController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] Person person)
        {
            await _databaseService.Person.Update(id, person);
        }

        // DELETE api/<PersonController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _databaseService.Person.Delete(id);
        }
    }
}
