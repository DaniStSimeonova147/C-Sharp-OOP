﻿using E04.BorderControl.Constraints;

namespace E04.BorderControl.Models
{
    public class Citizen : Entered, IBirthable
    {
        public Citizen( string name, int age, string id, string birthdate) 
            : base(id)
        {
            this.Name = name;
            this.Age = age;
            this.Birthdate = birthdate;
        }

        public string Name { get; private set; }

        public int Age { get;private set; }

        public string Birthdate { get; private set; }
    }
}
