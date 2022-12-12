using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComITProject.Dal.Model
{
    [Table("Diagnosis")]
    public class Diagnosis
    {
        [Key]
        public int Id { get; set; }
        
        [Required, MaxLength(10)]
        public string ICD10CACode { get; set; }

        [Required,MaxLength(50)]
        public string ShortDescription { get; set; }

        [Required, MaxLength(100)]
        public string LongDescription { get; set; }

        public List<PatientDiagnosis> PatientDiagnoses { get; set; }

    }
}
