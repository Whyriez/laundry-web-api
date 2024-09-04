using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace swagger_loundry.models
{
    public class Packages
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public String Id { get; set; }
        public String ServiceId { get; set; }
        public float Total { get; set; }
        public float Price { get; set; }
     
    }
}
