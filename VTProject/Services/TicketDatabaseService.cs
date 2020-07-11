using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VTProject.DataContext;
using VTProject.Models.DatabaseModels;
using VTProject.Models.DomainModels;

namespace VTProject.Services
{
    public class TicketDatabaseService
    {
        private readonly Mapper _mapper;

        public TicketDatabaseService(Mapper mapper)
        {
            _mapper = mapper;
        }

        public List<Ticket> GetAll()
        {
            var db = new DatabaseContext();

            var tickets = db.Tickets;

            var res = _mapper.Map<List<Ticket>>(tickets);

            return res;
        }

        public Ticket Get(int id)
        {
            var db = new DatabaseContext();

            var tickets = db.Tickets.Find(id);

            var res = _mapper.Map<Ticket>(tickets);

            return res;
        }

        public async Task Add(Ticket ticket)
        {
            var db = new DatabaseContext();

            var ticketModel = _mapper.Map<TicketModel>(ticket);

            db.Tickets.Add(ticketModel);
            await db.SaveChangesAsync();
        }

        public async Task Update(int id, Ticket ticket)
        {
            var db = new DatabaseContext();

            var ticketModel = db.Tickets.Find(id);
            if (ticketModel != null)
            {
                var ticketEntry = db.Entry(ticketModel);
                var updatedTicketModel = _mapper.Map<TicketModel>(ticket);
                updatedTicketModel.Id = id;
                ticketEntry.CurrentValues.SetValues(updatedTicketModel);
                await db.SaveChangesAsync();
            }
        }

        public async Task Delete(int id)
        {
            var db = new DatabaseContext();

            var ticketModel = db.Tickets.Find(id);
            if (ticketModel != null)
            {
                db.Tickets.Remove(ticketModel);
                await db.SaveChangesAsync();
            }
        }
    }
}
