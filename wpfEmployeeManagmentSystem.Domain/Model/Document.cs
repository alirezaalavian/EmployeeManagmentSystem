using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Domain.Model
{
    public class Document
    {
        public int Id { get; set; }
        public required string FilePath { get; set; }
        public  int EmployeeId { get; set; }
        public virtual  required Employee Employee { get; set; }
    }
}
