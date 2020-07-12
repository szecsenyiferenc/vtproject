using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VTProject.Models.DomainModels
{
    public class Person
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("tickets")]
        public List<Ticket> Tickets { get; set; }
    }
}
