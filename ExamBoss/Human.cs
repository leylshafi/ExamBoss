using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExamBoss
{
    internal class Human
    {
        
        public string Name { get;  }
        public string Surname { get; }
        public string City { get; }
        private string _phone;
        public string Phone {
            get
            {
                return _phone;
            }
            set
            {
                string pattern = "^05";
                Regex regex = new Regex(pattern);
                if (regex.IsMatch(value))
                    _phone = value;
                else
                {
                    Menu.GetLogger().Error("Error ocurred... Phone should start with 05");
                    throw new Exception("Phone should start with 05");
                }
            }
        }
        public int Age { get; }
        public Human(string name, string surname, string city, string phone, int age)
        {
            Name = name;
            Surname = surname;
            City = city;
            Phone = phone;
            Age = age;
        }
        public Human()
        {
            Name = default;
            Surname = default;
            City = default;
            Phone = default;
            Age = default;
        }


        public override string ToString() => ($@"
Name: {Name},
Surname: {Surname},
City: {City},
Phone: {Phone},
Age: {Age}");
    }
}
