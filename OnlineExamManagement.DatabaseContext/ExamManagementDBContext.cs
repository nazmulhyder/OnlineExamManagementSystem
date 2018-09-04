using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using OnlineExamManagementSystem.Models;

namespace OnlineExamManagement.DatabaseContext
{
    public class ExamManagementDBContext:DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Trainer> Trainers { get; set;}

    }
}
