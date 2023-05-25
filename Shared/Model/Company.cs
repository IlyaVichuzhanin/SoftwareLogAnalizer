using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareLogAnalizer.Shared.Model
{
    public class Company 
    {
        [Key]
        public int Id { get; set; }
        [Required, Display(Name = "Название компании")]
        public string? CompanyName { get; set; }

        public virtual List<Employee>? Employees { get; set; }
        public override string ToString()
        {
            return CompanyName;
        }
    }
}

