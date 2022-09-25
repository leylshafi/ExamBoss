using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamBoss
{
    internal class Guest:Human
    {
        public Guest(string name, string surname, string city, string phone, int age):base(name, surname, city, phone, age)
        {
        }

        public override string ToString()=>base.ToString();
    }
}
