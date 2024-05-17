using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Models
{
    public class Core
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int Points { get; set; }

        public Core()
        {
            Id = 0;
            FirstName = "";
            LastName = "";
            Age = 0;
            Points = 0;
        }

        public Core(int id, string firstName, string lastName, int age, int points)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Points = points;
        }

        public override string ToString()
        {
            return $"Id: {Id}, FirstName: {FirstName}, LastName: {LastName}, Age: {Age}, Points: {Points}";
        }
    }
}
