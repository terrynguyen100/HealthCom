using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ComITProject.Dal.Model
{
    [Table("PrescribedMedication")]
    public class PrescribedMedication
    {
        [Key]
        public int Id { get; set; }

        [Required, ForeignKey("Medication")]
        public int MedicationId { get; set; }
        public Medication Medication { get; set; }

        [Required, ForeignKey("Patient")]
        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        [Required]
        public int Dosage { get; set; }

        [Required, ForeignKey("DosageUnit")]
        public int DosageUnitId { get; set; }
        public DosageUnit DosageUnit { get; set; }

        [Required, ForeignKey("Route")]
        public int RouteId { get; set; }
        public Route Route { get; set; }

        [Required, Column("Frequency By Hour")]
        public int FrequencyByHour { get; set; }

        [Required, Column("Start Datetime")]
        public DateTime StartDateTime { get; set; }

        [Required, Column("End Datetime")]
        public DateTime EndDateTime { get; set; }

        [Required, Column("Prescribed Datetime")]
        public DateTime PrescribedDateTime { get; set; }

        [Required, Column("Prescribed By"), ForeignKey("Staff")]
        public int PrescribedByStaffId { get; set; }
        public Staff Staff { get; set; }


    }
}
