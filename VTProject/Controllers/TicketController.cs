using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VTProject.DataContext;
using VTProject.Models.DatabaseModels;
using VTProject.Models.DomainModels;
using VTProject.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VTProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly DatabaseService _databaseService;

        public TicketController(DatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        // GET: api/<TicketController>
        [HttpGet]
        public IEnumerable<Ticket> Get()
        {
            return _databaseService.Ticket.GetAll();
        }

        // GET api/<TicketController>/5
        [HttpGet("{id}")]
        public Ticket Get(int id)
        {
            return _databaseService.Ticket.Get(id);
        }

        // POST api/<TicketController>
        [HttpPost]
        public async Task Post([FromBody] Ticket ticket)
        {
            await _databaseService.Ticket.Add(ticket);
        }

        // PUT api/<TicketController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] Ticket ticket)
        {
            await _databaseService.Ticket.Update(id, ticket);
        }

        // DELETE api/<TicketController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _databaseService.Ticket.Delete(id);
        }
    }
}
