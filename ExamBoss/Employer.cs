using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamBoss
{
    internal class Employer : Human
    {
        public List<Vacancy> Vacancies = new List<Vacancy>();

        public Employer(string name, string surname, string city, string phone, int age) : base(name, surname, city, phone, age)
        {

        }
        public override string ToString() => ($@"
Name: {Name},
Surname: {Surname},
City: {City},
Phone: {Phone},
Age: {Age}");
    }
}
