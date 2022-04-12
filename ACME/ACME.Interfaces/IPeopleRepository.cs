using ACME.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACME.Interfaces
{
    public interface IPeopleRepository : IRepository<Person>
    {
        IEnumerable<Hobby> Hobbies(Person p);
    }
}
