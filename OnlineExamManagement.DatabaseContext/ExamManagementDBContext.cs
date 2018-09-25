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
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Tags> Tagses { get; set; }
        public DbSet<CourseTag> CourseTagses { get; set; }
        public DbSet<Trainer> Trainers { get; set;}
        public DbSet<CourseTrainer> CourseTrainers { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<ExamSchedule> ExamSchedules { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<Batch> Batches { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>()
                .HasMany(c => c.CourseTrainers)
                .WithRequired(t => t.Course)
                .HasForeignKey(t => t.CourseId);

            modelBuilder.Entity<Trainer>()
                .HasMany(tr => tr.CourseTrainers)
                .WithRequired(t => t.Trainer)
                .HasForeignKey(t => t.TrainerId);

            modelBuilder.Entity<Course>()
                .HasMany(c => c.CourseTags)
                .WithRequired(t => t.Course)
                .HasForeignKey(t => t.CourseId);

            modelBuilder.Entity<Tags>()
                .HasMany(c => c.CourseTags)
                .WithRequired(t => t.Tags)
                .HasForeignKey(t => t.TagId);

            modelBuilder.Entity<Organization>()
                .HasMany<Trainer>(c=>c.Trainers)
                .WithRequired(s=>s.Organizations)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Exam>()
                .HasMany<ExamSchedule>(c =>c.ExamSchedules)
                .WithRequired(s =>s.Exam)
                .WillCascadeOnDelete(false);



        }
    }
}
