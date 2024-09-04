using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace swagger_loundry.models
{
    public class Auth
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]


        public String Email { get; set; }
        public String Password { get; set; }

    }
}
