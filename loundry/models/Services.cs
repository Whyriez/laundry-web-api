using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace swagger_loundry.models
{
    public class Services
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public String Id { get; set; }
        public String Name { get; set; }
        public int Category { get; set; }
        public int Unit { get; set; }
        public float Price { get; set; }
        public int EstimationDuration { get; set; }

    }
}
