using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace crudinnetcore.Models
{
    public class Employee
    {
        [Required]
     
        public string name { get; set; }
       
        [Required]
    
        public int code { get; set; }

        [Required]
        public int id { get; set; }

        [DataType(DataType.Date)]
        public DateTime dob { get; set; }
        public string city { get; set; }
        public string gender { get; set; }
        public string active { get; set; }

        public string image { get; set; }

        public string dobStr { get; set; }
    }
}
