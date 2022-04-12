using ACME.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACME.DAL;

namespace ACME.DAL.Repositories.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MijnContext _context;

        public UnitOfWork(MijnContext context)
        {
            _context = context;
        }

        public IPeopleRepository People => new PersonRepository(_context);

        public IHobbyRepository Hobby => throw new NotImplementedException();

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
