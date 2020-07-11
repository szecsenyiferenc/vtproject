using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VTProject.Models.DomainModels
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Assigned { get; set; }
        public string Image { get; set; }
    }
}
