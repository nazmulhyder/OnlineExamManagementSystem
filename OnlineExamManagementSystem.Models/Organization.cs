﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace OnlineExamManagementSystem.Models
{
    public class Organization
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Code { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string ContactNo { get; set; }

        [AllowHtml]
        public string About { get; set; }
        public byte[] Logo { get; set; }
        public List<Course> ListOfCourses { get; set; }

        
        

        
    }
}
