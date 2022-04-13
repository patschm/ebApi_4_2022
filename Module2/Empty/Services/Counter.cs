using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Empty.Services
{
    public interface ICounter
    {
        void Increment();
    }

    public class Counter : ICounter
    {
        private int teller = 0;

        public void Increment()
        {
            System.Console.WriteLine(++teller);
        }
    }
}