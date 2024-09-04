using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace swagger_loundry.models
{
    public class Me
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public String Email { get; set; }
        public String Name { get; set; }
        public String Password { get; set; }
        public int Gender { get; set; }
        public DateTime DateOfBirth { get; set; } = DateTime.Now;
        public String PhoneNumber { get; set; }
        public String Address { get; set; }
        public int Role { get; set; }
        public String PhotoPath { get; set; }
      
    }
}
