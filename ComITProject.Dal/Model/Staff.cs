using ComITProject.Dal.Model.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ComITProject.Dal.Model
{
    [Table("Staff")]
    public class Staff
    {
        [Key]
        public int Id { get; set; }

        [Required, ForeignKey("AppUser")]
        public int AppUserId { get; set; }
        public AppUser AppUser  { get; set; }


        public List<StaffSpecialty> StaffSpecialties { get; set; }
        public List<Input> Inputs { get; set; }
        public List<Note> Notes { get; set; }
        public List<PatientDiagnosis> PatientDiagnoses { get; set; }
        public List<PrescribedMedication> PrescribedMedications { get; set; }
    }
}
