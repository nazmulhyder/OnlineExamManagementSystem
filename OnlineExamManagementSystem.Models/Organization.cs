using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace OnlineExamManagementSystem.Models
{
    public class Organization
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [MaxLength(5,ErrorMessage = "Code should be 5 digit")]
        [MinLength(3,ErrorMessage = "Code should be 2 digit in minimum")]
       

        public string Code { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [Display(Name = "Contact")]
        public string ContactNo { get; set; }

        public string ImgPath { get; set; }
        [NotMapped]
        public HttpPostedFileBase  Logo { get; set; }
        [AllowHtml]
        public string About { get; set; }
        
        public ICollection<Course> Courses { get; set; }

        
        

        
    }
}
