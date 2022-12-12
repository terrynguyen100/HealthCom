using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComITProject.Dal.Model
{
    [Table("Address")]
    public class Address
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string Address1 { get; set; }

        [Required, MaxLength(50)]
        public string Address2 { get; set; }

        [Required, MaxLength(50)]
        public string City { get; set; }

        [Required, MaxLength(50)]
        public string Province { get; set; }

        [Required, MaxLength(15)]
        public string PostalCode { get; set; }

        [Required, MaxLength(50)]
        public string Country { get; set; }

        [Required, ForeignKey("Patient")]
        public int PatientID { get; set; }
        public Patient Patient { get; set; }

        
    }
}
