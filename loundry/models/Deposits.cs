using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace swagger_loundry.models
{
    public class Deposits
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public String Id { get; set; }
        public String Customeremail { get; set; }
        public String EmployeeEmail { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime EstimationAt { get; set; } = DateTime.Now;
        public DateTime CompletedAt { get; set; } = DateTime.Now;
    }
}
