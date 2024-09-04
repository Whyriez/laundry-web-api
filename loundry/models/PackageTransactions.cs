using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace swagger_loundry.models
{
    public class PackageTransactions
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public String Id { get; set; }
        public String UserEmail { get; set; }
        public String PackageId { get; set; }
        public float Price { get; set; }
        public float AvailableUnit { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime CompletedAt { get; set; } = DateTime.Now;
    }
}
