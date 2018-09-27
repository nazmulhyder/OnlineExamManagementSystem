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
        [DisplayFormat(ApplyFormatInEditMode=true ,DataFormatString = "0:yyyy-MM-dd HH:mm")]
        public DateTime? ExamDateTime { get; set; }
        public virtual Exam Exam { get; set; }
        public int ExamId { get; set; }
        public virtual Batch Batches { get; set; }
        public int BatchId { get; set; }

    }
}
