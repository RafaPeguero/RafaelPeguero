using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Users.Models
{
    public class Department
    {
        [Key]
        public int Department_ID { get; set; }
        [Required]
        public string Department_Name { get; set; }

        public ICollection<User> Users { get; set; }

    }
}
