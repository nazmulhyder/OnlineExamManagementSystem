using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineExamManagementSystem.Models
{
    public class Organization
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Code { get; set; }
        [Required]
        public  string Address { get; set; }
        [Required]
        public string ContactNumber { get; set; }
        public string About { get; set; }
        public string Logo { get; set; }
        public int CourseOrganizationId { get; set; }
        public CourseOrganization CourseOrganization { get; set; }

    }
}
