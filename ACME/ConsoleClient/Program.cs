
using ACME.DAL;
using ACME.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Logging;

namespace ConsoleClient;

class Program
{
    private static string conStr = @"Server=.\sqlexpress;Database=MijnDatabase;Trusted_Connection=True;MultipleActiveResultSets=true";

    static void Main()
    {
        //CreateDatabase();
        //PopulateDatabase();

        //Lezen();
        Person p = GetPerson();
        p.Age = 120;
        Modify(p);

        Console.WriteLine("Done");
    }

    private static void Modify(Person p)
    {
        DbContextOptionsBuilder bld = new DbContextOptionsBuilder();
        bld.LogTo(msg => Console.WriteLine(msg), LogLevel.Information);
        bld.UseSqlServer(conStr, opts => { });
        MijnContext ctx = new MijnContext(bld.Options);

        Person dbPerson = ctx.People.Find(p.Id);
        ctx.Entry(dbPerson).CurrentValues.SetValues(p);
        //ctx.People.Attach(p);
        Console.WriteLine(ctx.Entry(dbPerson).State);
    }

    private static Person GetPerson()
    {
        DbContextOptionsBuilder bld = new DbContextOptionsBuilder();
        bld.LogTo(msg => Console.WriteLine(msg), LogLevel.Information);
        bld.UseSqlServer(conStr, opts => { });
        MijnContext ctx = new MijnContext(bld.Options);

        return ctx.People.FirstOrDefault();
    }

    private static void Lezen()
    {
        DbContextOptionsBuilder bld = new DbContextOptionsBuilder();
        bld.LogTo(msg => Console.WriteLine(msg), LogLevel.Information);
        bld.UseSqlServer(conStr, opts => { });

        MijnContext ctx = new MijnContext(bld.Options);

        var query = ctx.People
            .Where(p=>p.FirstName.StartsWith("M"))
            .OrderBy(p=>p.Age);

        var query2 = from p in ctx.People
                        .Include(p=>p.PersonHobbies)
                            .ThenInclude(ph=>ph.Hobby)
                     //where p.FirstName.StartsWith("M") 
                     orderby p.Age 
                     select p;

        foreach(Person p in query2.Skip(1).Take(5))
        {
            Console.WriteLine($"[{p.Id}] {p.FirstName} {p.LastName} ({p.Age})");
            //ctx.Entry(p).Collection(px=>px.PersonHobbies).Load();
            foreach(var ph in p.PersonHobbies)
            {
                //ctx.Entry(ph).Reference(px => px.Hobby).Load();
                Console.WriteLine($"\t{ph.Hobby?.Description}");
            }
        }
    }

    private static void PopulateDatabase()
    {
        Person p1 = new Person { FirstName = "Jan", LastName = "Peeters", Age = 28 };
        Person p2 = new Person { FirstName="Marieke", LastName="de Vries", Age=45 };

        Hobby h1 = new Hobby { Description = "Zeilen" };
        Hobby h2 = new Hobby { Description = "Sigarenbandjes" };

        p1.PersonHobbies.Add(new PersonHobby { Hobby = h1 });
        p2.PersonHobbies.Add(new PersonHobby { Hobby = h1 });
        p2.PersonHobbies.Add(new PersonHobby { Hobby = h2 });

        DbContextOptionsBuilder bld = new DbContextOptionsBuilder();
        bld.LogTo(msg => Console.WriteLine(msg), LogLevel.Information);
        bld.UseSqlServer(conStr, opts => { });

        MijnContext ctx = new MijnContext(bld.Options);

        ctx.People.AddRange(p1, p2);

        ctx.SaveChanges();
    }

    private static void CreateDatabase()
    {
        DbContextOptionsBuilder bld = new DbContextOptionsBuilder();
        bld.LogTo( msg => Console.WriteLine(msg), LogLevel.Information);
        bld.UseSqlServer(conStr, opts => {   });

        MijnContext ctx = new MijnContext(bld.Options);

        ctx.Database.EnsureCreated();
    }
}
