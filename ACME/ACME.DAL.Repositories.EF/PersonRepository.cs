using ACME.Entities;
using ACME.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ACME.DAL.Repositories.EF
{
    public class PersonRepository : IPeopleRepository
    {
        private readonly MijnContext _context;

        internal PersonRepository(MijnContext context)
        {
            _context = context;
        }

        public IQueryable<Person> All()
        {
            return _context.People;
        }

        public void Delete(Person entity)
        {
           Person db =  _context.People.Find(entity.Id);
            _context.People.Remove(db);
        }

        public IEnumerable<Hobby> Hobbies(Person p)
        {
            var dbP = _context.People
                .Include(px => px.PersonHobbies)
                    .ThenInclude(px => px.Hobby)
                .FirstOrDefault(px => px.Id == p.Id);
            return dbP.PersonHobbies.Select(ph=>ph.Hobby).ToList();
        }

        public void Insert(Person entity)
        {
            _context.People.Add(entity);
        }

    

        public void Update(Person entity)
        {
            var dbP = _context.People.Find(entity.Id);
            _context.Entry(dbP).CurrentValues.SetValues(entity);
        }
    }
}