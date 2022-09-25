using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamBoss
{
    internal class Vacancy
    {
        
        public string JobName { get; }
        public double Salary { get; }
        public string AgeRange { get;  }
        public string Education { get;}
        public string Content { get;}

        public Vacancy(string jobName, double salary, string ageRange, string education, string content)
        {
            JobName = jobName;
            Salary = salary;
            AgeRange = ageRange;
            Education = education;
            Content = content;
        }

        public override string ToString() => ($@"
Job name: {JobName},
Salary: {Salary},
Age range: {AgeRange},
Education: {Education},
Content: {Content}");
    }
}
