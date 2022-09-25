using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamBoss
{

    internal class Worker:Human
    {
        public CV CV { get; set; }

        public Worker(CV cv,string name, string surname, string city, string phone, int age):base(name, surname, city, phone, age)
        {
            CV=cv;
        }

        public override string ToString() => (base.ToString() + CV);

    }
}
