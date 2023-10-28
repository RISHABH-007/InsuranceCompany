using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ClaimManagement.DAL.Entity
{
    public class User
    {
        [Key]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; } 
    }
}
