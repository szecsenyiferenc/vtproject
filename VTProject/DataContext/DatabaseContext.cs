using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VTProject.Models.DatabaseModels;

namespace VTProject.DataContext
{
    public class DatabaseContext : DbContext
    {
        public DbSet<TicketModel> Tickets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=../database/vtdatabase.db");

        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //=> options.UseSqlite(@"Data Source=D:\dockertest\vtdatabase.db");
    }
}
