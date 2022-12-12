using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ComITProject.Dal.Model
{
    [Table("Medication")]
    public class Medication
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(50), Column("Generic Name")]
        public string GenericName { get; set; }

        [MaxLength(100), Column("Trade Name")]    
        public string? TradeName { get; set; }

        public List<PrescribedMedication> PrescribedMedications { get; set; }
    }
}
