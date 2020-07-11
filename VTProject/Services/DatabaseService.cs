using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VTProject.Services
{
    public class DatabaseService
    {
        public TicketDatabaseService Ticket { get; private set; }
        public DatabaseService(TicketDatabaseService ticketDatabaseService)
        {
            Ticket = ticketDatabaseService;
        }
    }
}
