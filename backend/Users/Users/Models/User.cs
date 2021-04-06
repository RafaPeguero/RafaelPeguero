using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Users.Models
{
    public class User
    {
        [Key]
        public string User_ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public DateTime Birthday { get; set; }
        [Required]
        public string position { get; set; }
        [Required]
        public string ImmediateSupervisor { get; set; }

        public int Department_ID { get; set; }
        [ForeignKey("Department_ID")]
        public Department Department { get; set; }


    }
}
