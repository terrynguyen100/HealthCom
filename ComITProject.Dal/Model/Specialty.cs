using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComITProject.Dal.Model
{
    [Table("Specialty")]
    public class Specialty
    {
        [Key]
        public int Id { get; set; }

        [Required, Column("Specialty Name"), MaxLength(50)]
        public string Name { get; set; }

        public List<StaffSpecialty> StaffSpecialties { get; set; }

    }
}
