using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Domain.Model
{
    public class Employee
    {
        public int Id { get; set; }
        public required string NationalID { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string FatherName { get; set; }
        public string? PersonalImage { get; set; }
        public string? Description { get; set; }
        public required int Score { get; set; }

        public List<Document> Documents { get; set; }

    }   
}
