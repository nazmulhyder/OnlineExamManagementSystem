using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExamManagementSystem.Models
{
    public class Batch
    {
        public int Id { get; set; }

        [Required]
        public int BatchNumber { get; set; }
        public string Description { get; set; }
        [Display(Name="Start Date")]
        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; }
        [Display(Name = "End Date")]
        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }
        public Course CourseId { get; set; }
        public Course Course { get; set; }
        public List<Participant> ListOfParticipants { get; set; }


    }
}
