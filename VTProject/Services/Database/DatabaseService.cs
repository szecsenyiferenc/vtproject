using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VTProject.Services.Database;

namespace VTProject.Services
{
    public class DatabaseService
    {
        public TicketDatabaseService Ticket { get; private set; }
        public PersonDatabaseService Person { get; private set; }
        public DatabaseService(TicketDatabaseService ticketDatabaseService, PersonDatabaseService personDatabaseService)
        {
            Ticket = ticketDatabaseService;
            Person = personDatabaseService;
        }
    }
}
