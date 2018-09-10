using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExamManagementSystem.Models
{
    public class ExamSchedule
    {

        public int Id { get; set; }
        [Required]
        [Display(Name = "Exam Date Time Edit")]
        [DisplayFormat(ApplyFormatInEditMode=true ,DataFormatString = "0:yyyy-MM-dd HH:mm")]
        public DateTime? ExamDateTime { get; set; }
        public Exam ExamId { get; set; }
        public Exam Exam { get; set; }
    }
}
