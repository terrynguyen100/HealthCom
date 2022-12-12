using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComITProject.Dal.Model
{
    [Table("EmergencyContact")]
    public class EmergencyContact
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string FirstName { get; set; }
        [Required, MaxLength(50)]
        public string LastName { get; set; }
        [Required, MaxLength(15)]
        public string Telephone { get; set; }

        [Required, ForeignKey("Patient")]
        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        [Required, MaxLength(50), Column("Relationship To Patient")]
        public string RelationshipToPatient { get; set; }

    }
}
