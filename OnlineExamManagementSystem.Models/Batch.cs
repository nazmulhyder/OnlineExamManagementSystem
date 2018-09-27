using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace OnlineExamManagementSystem.Models
{
    public class Batch
    {
        public int Id { get; set; }

        [Required]
        public int BatchNumber { get; set; }
        [AllowHtml]
        public string Description { get; set; }
        [Display(Name="Start Date")]
        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; }
        [Display(Name = "End Date")]
        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }
        public virtual Course Course { get; set; }
        public int CourseId { get; set; }
        public ICollection<Participant> Participants { get; set; }
        public ICollection<ExamSchedule> ExamSchedules { get; set; }


    }
}
