using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComITProject.Dal.Model
{
    [Table("Input")]
    public class Input
    {
        [Key]
        public int Id { get; set; }

        [Required, ForeignKey("Patient")]
        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        [Required, ForeignKey("Staff")]
        public int StaffId { get; set; }
        public Staff Staff { get; set; }

        [Required, Column("Created Datetime")]
        public DateTime CreatedDateTime { get; set; }
        public int PulseRate { get; set; }
        public int SystolicBloodPressure { get; set; }
        public int DiastolicBloodPressure { get; set; }
        public int RespirationRate { get; set; }
        public int O2Saturation { get; set; }

        [Column(TypeName ="decimal(3,2)")]
        public decimal Temperature { get; set; }

        [Column("Height in cm)")]
        public int HeightInCm { get; set; }

        [Column("Weight in g)")]
        public int WeightInG { get; set; }

    }
}
