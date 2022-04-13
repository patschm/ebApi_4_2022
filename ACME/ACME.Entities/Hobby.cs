﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACME.Entities
{
    public class Hobby
    {
        public int Id { get; set; }
        public string? Description { get; set; }

//public ICollection<PersonHobby> PersonHobbies { get; set; } = new HashSet<PersonHobby>();
        public ICollection<Person> Persons { get; set; } = new HashSet<Person>();
    }
}
