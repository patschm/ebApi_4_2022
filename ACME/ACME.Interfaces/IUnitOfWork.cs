using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACME.Interfaces
{
    public interface IUnitOfWork
    {
        IPeopleRepository People { get; }
        IHobbyRepository Hobby { get; }

        void Save();
    }
}
