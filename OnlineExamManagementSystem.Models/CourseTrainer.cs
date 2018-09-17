using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExamManagementSystem.Models
{
    public class CourseTrainer
    {
        public int Id { get; set; }

        public Course Course { get; set; }
        public int CourseId { get; set; }
        public Trainer Trainer { get; set; }
        public int TrainerId { get; set; }
    }
}
