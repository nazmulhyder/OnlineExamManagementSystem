using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExamManagementSystem.Models
{
    public class CourseTag
    {
        public int Id { get; set; }
        public virtual Course Course { get; set; }
        public int CourseId { get; set; }
        public virtual Tags Tags { get; set; }
        public int TagId { get; set; }
       // public ICollection<Tags> Tagses { get; set; }
    }
}
