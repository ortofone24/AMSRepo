using System;
using System.Collections.Generic;

#nullable disable

namespace Ams.Domain.Entities
{
    public partial class EmployeesView
    {
        public int EmpNo { get; set; }
        public DateTime BirthDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime HireDate { get; set; }
        public int Salary { get; set; }
        public string Title { get; set; }
    }
}
