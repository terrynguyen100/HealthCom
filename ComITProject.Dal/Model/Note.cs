using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComITProject.Dal.Model
{
    [Table("Note")]
    public class Note
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime DateTimeCreated { get; set; }

        [Required, ForeignKey("Patient")]
        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        [Required]
        public string Content { get; set; }

        [Required, ForeignKey("Staff")]
        public int StaffId { get; set; }
        public Staff Staff { get; set; }


    }
}
