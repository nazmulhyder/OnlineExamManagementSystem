using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExamManagementSystem.Models
{
    public class Trainer
    {
        public int Id { get; set; }
        [Required]
        public int Batch { get; set; }
        public bool isLead { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public string ContactNumber { get; set; }
        [Required]
        [StringLength(100)]
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        [Required]
        public int PostalCode { get; set; }
        public string Country { get; set; }
        public string Image { get; set; }
        public virtual Organization Organizations { get; set; }
        public int OrganizationId { get; set; }
        public ICollection<CourseTrainer> CourseTrainers { get; set; } 



    }
}
