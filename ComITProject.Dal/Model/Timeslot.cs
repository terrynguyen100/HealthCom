using ComITProject.Dal.Model.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComITProject.Dal.Model
{
    //This table will store all the available timeslots (30 min each) that doctors have
    //Once the patient select a timeslot and book an appointment, it will create a 
    //new entry in the Appointment table
    [Table("Timeslot")]
    public class Timeslot
    {
        [Key]
        public int Id { get; set; }

        [Required, ForeignKey("Staff")]
        public int StaffId { get; set; }
        public Staff Staff { get; set; }


        [Required]
        public DateTime StartDateTime { get; set; }
        [Required]
        public DateTime EndDateTime { get; set; }
        
    }
}
