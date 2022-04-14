using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Security.Policy;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Geheim
{
    internal class Program
    {
        static void Main(string[] args)
        {
           AppDomain.CurrentDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);

            GenericIdentity id2 = new GenericIdentity("Sinterklaas");
            GenericPrincipal prin2 = new GenericPrincipal(id2,  new string[]{ "admin2"});
            
            Thread.CurrentPrincipal = prin2;



            IPrincipal principal = Thread.CurrentPrincipal;
            IIdentity identity = principal.Identity;

            principal.IsInRole("admin");
            Console.WriteLine(identity.Name);

            DoeIets();

            Console.ReadLine();
        }

        [PrincipalPermission(SecurityAction.Demand, Role = "admin")]
        private static void DoeIets()
        {
            Console.WriteLine("DoetIets");
        }
    }
}
