using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesLibrary
{
    public class Employee
    {
        public Int64 Id { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public Double Salary { get; set; }
        public Employee Manager { get; set; }

        public String FullName { get { return String.Format("{0} {1}", FirstName, LastName); } }

        public Employee()
        {
            Id = 0;
        }
    }
}
