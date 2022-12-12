using ComITProject.Dal.Model.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ComITProject.Dal.Model
{
    [Table("Patient")]
    public class Patient
    {
        [Key]
        public int Id { get; set; }

        [Column("Preferred Name"),MaxLength(50)]
        public string PreferredName { get; set; }
        
        [Required, MaxLength(10)]
        public string Gender { get; set; }

        [Required, ForeignKey("AppUser")]
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        

        //one-to-one relationship
        public Address Address { get; set; }

        public EmergencyContact EmergencyContact { get; set; }

        //one-to-many relationship

        public List<Input> Inputs { get; set; }
        public List<Note> Notes { get; set; }
        public List<PatientDiagnosis> PatientDiagnoses { get; set; }
        public List<PrescribedMedication> PrescribedMedications { get; set; }

    }
}
