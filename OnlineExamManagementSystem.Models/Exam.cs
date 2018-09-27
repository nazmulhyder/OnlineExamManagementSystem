using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExamManagementSystem.Models
{
    public class Exam
    {
        public int Id { get; set; }
        [Required]
        public string ExamType { get; set; }
        [Required]
        public string Code { get; set; }
        public string Topic { get; set; }
        public int FullMarks { get; set; }
        [Required]
        public string Duration { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public ICollection<ExamSchedule> ExamSchedules { get; set; }


    }
}
