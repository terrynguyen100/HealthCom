using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComITProject.Dal.Model
{

    [Table("Route")]
    public class Route
    {
        [Key]
        public int Id { get; set; }

        [Required,MaxLength(50) ]
        public string RouteName { get; set; }

        public List<PrescribedMedication> PrescribedMedications { get; set; }
    }
}
