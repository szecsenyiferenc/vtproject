using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VTProject.DataContext;
using VTProject.Models.DatabaseModels;
using VTProject.Models.DomainModels;

namespace VTProject.Services.Database
{
    public class PersonDatabaseService
    {
        private readonly Mapper _mapper;

        public PersonDatabaseService(Mapper mapper)
        {
            _mapper = mapper;
        }

        public List<Person> GetAll()
        {
            var db = new DatabaseContext();

            var persons = db.Persons.Include(a => a.Tickets);

            var res = _mapper.Map<List<Person>>(persons);

            return res;
        }

        public Person Get(int id)
        {
            var db = new DatabaseContext();

            var persons = db.Persons.Find(id);

            var res = _mapper.Map<Person>(persons);

            return res;
        }

        public async Task Add(Person ticket)
        {
            var db = new DatabaseContext();

            var personModel = _mapper.Map<PersonModel>(ticket);

            db.Persons.Add(personModel);
            await db.SaveChangesAsync();
        }

        public async Task Update(int id, Person ticket)
        {
            var db = new DatabaseContext();

            var personModel = db.Persons.Find(id);
            if (personModel != null)
            {
                var ticketEntry = db.Entry(personModel);
                var updatedpersonModel = _mapper.Map<PersonModel>(ticket);
                updatedpersonModel.Id = id;
                ticketEntry.CurrentValues.SetValues(updatedpersonModel);
                await db.SaveChangesAsync();
            }
        }

        public async Task Delete(int id)
        {
            var db = new DatabaseContext();

            var personModel = db.Persons.Find(id);
            if (personModel != null)
            {
                db.Persons.Remove(personModel);
                await db.SaveChangesAsync();
            }
        }
    }
}
