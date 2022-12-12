using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComITProject.Dal.Model
{
    [Table("PatientDiagnosis")]
    public class PatientDiagnosis
    {
        [Required, ForeignKey("Patient")]
        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        [Required, ForeignKey("Diagnosis")]
        public int DiagnosisId { get; set; }
        public Diagnosis Diagnosis { get; set; }

        [Required, Column("Created Datetime")]
        public DateTime CreatedDateTime { get; set; }

        [Required, ForeignKey("Staff")]
        public int StaffId { get; set; }
        public Staff Staff { get; set; }

        [MaxLength(200), Column("Diagnosis Note")]
        public string? DiagnosisNote { get; set; }



    }
}
