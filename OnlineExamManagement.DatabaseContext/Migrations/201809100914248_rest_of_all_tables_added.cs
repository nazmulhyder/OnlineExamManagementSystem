namespace OnlineExamManagement.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rest_of_all_tables_added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CourseTags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        CourseTagId_Id = c.Int(),
                        CourseTags_Id = c.Int(),
                        CourseTags_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CourseTags", t => t.CourseTagId_Id)
                .ForeignKey("dbo.CourseTags", t => t.CourseTags_Id)
                .ForeignKey("dbo.CourseTags", t => t.CourseTags_Id1)
                .Index(t => t.CourseTagId_Id)
                .Index(t => t.CourseTags_Id)
                .Index(t => t.CourseTags_Id1);
            
            CreateTable(
                "dbo.Batches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BatchNumber = c.Int(nullable: false),
                        Description = c.String(),
                        StartDate = c.DateTime(),
                        EndDate = c.DateTime(),
                        Course_Id = c.Int(),
                        CourseId_Id = c.Int(),
                        Course_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.Course_Id)
                .ForeignKey("dbo.Courses", t => t.CourseId_Id)
                .ForeignKey("dbo.Courses", t => t.Course_Id1)
                .Index(t => t.Course_Id)
                .Index(t => t.CourseId_Id)
                .Index(t => t.Course_Id1);
            
            CreateTable(
                "dbo.Participants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        RegNo = c.String(nullable: false),
                        ContactNo = c.String(),
                        Email = c.String(nullable: false),
                        AddressLine1 = c.String(nullable: false),
                        AddressLine2 = c.String(),
                        City = c.String(),
                        PostalCode = c.String(nullable: false),
                        Country = c.String(),
                        Batch_Id = c.Int(),
                        BatchId_Id = c.Int(),
                        Batch_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Batches", t => t.Batch_Id)
                .ForeignKey("dbo.Batches", t => t.BatchId_Id)
                .ForeignKey("dbo.Batches", t => t.Batch_Id1)
                .Index(t => t.Batch_Id)
                .Index(t => t.BatchId_Id)
                .Index(t => t.Batch_Id1);
            
            CreateTable(
                "dbo.Exams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ExamType = c.String(nullable: false),
                        Code = c.String(nullable: false),
                        Topic = c.String(),
                        FullMarks = c.Int(nullable: false),
                        Duration = c.Time(nullable: false, precision: 7),
                        Course_Id = c.Int(),
                        CourseId_Id = c.Int(),
                        Course_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.Course_Id)
                .ForeignKey("dbo.Courses", t => t.CourseId_Id)
                .ForeignKey("dbo.Courses", t => t.Course_Id1)
                .Index(t => t.Course_Id)
                .Index(t => t.CourseId_Id)
                .Index(t => t.Course_Id1);
            
            CreateTable(
                "dbo.ExamSchedules",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ExamDateTime = c.DateTime(nullable: false),
                        Exam_Id = c.Int(),
                        ExamId_Id = c.Int(),
                        Exam_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Exams", t => t.Exam_Id)
                .ForeignKey("dbo.Exams", t => t.ExamId_Id)
                .ForeignKey("dbo.Exams", t => t.Exam_Id1)
                .Index(t => t.Exam_Id)
                .Index(t => t.ExamId_Id)
                .Index(t => t.Exam_Id1);
            
            AddColumn("dbo.Courses", "CourseTags_Id", c => c.Int());
            AddColumn("dbo.Courses", "CourseTags_Id1", c => c.Int());
            AddColumn("dbo.Courses", "CourseTagsId_Id", c => c.Int());
            AddColumn("dbo.Courses", "Tags_Id", c => c.Int());
            CreateIndex("dbo.Courses", "CourseTags_Id");
            CreateIndex("dbo.Courses", "CourseTags_Id1");
            CreateIndex("dbo.Courses", "CourseTagsId_Id");
            CreateIndex("dbo.Courses", "Tags_Id");
            AddForeignKey("dbo.Courses", "CourseTags_Id", "dbo.CourseTags", "Id");
            AddForeignKey("dbo.Courses", "CourseTags_Id1", "dbo.CourseTags", "Id");
            AddForeignKey("dbo.Courses", "CourseTagsId_Id", "dbo.CourseTags", "Id");
            AddForeignKey("dbo.Courses", "Tags_Id", "dbo.Tags", "Id");
            DropColumn("dbo.Courses", "Tags");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Courses", "Tags", c => c.String());
            DropForeignKey("dbo.Courses", "Tags_Id", "dbo.Tags");
            DropForeignKey("dbo.Exams", "Course_Id1", "dbo.Courses");
            DropForeignKey("dbo.ExamSchedules", "Exam_Id1", "dbo.Exams");
            DropForeignKey("dbo.ExamSchedules", "ExamId_Id", "dbo.Exams");
            DropForeignKey("dbo.ExamSchedules", "Exam_Id", "dbo.Exams");
            DropForeignKey("dbo.Exams", "CourseId_Id", "dbo.Courses");
            DropForeignKey("dbo.Exams", "Course_Id", "dbo.Courses");
            DropForeignKey("dbo.Batches", "Course_Id1", "dbo.Courses");
            DropForeignKey("dbo.Participants", "Batch_Id1", "dbo.Batches");
            DropForeignKey("dbo.Participants", "BatchId_Id", "dbo.Batches");
            DropForeignKey("dbo.Participants", "Batch_Id", "dbo.Batches");
            DropForeignKey("dbo.Batches", "CourseId_Id", "dbo.Courses");
            DropForeignKey("dbo.Batches", "Course_Id", "dbo.Courses");
            DropForeignKey("dbo.Courses", "CourseTagsId_Id", "dbo.CourseTags");
            DropForeignKey("dbo.Courses", "CourseTags_Id1", "dbo.CourseTags");
            DropForeignKey("dbo.Tags", "CourseTags_Id1", "dbo.CourseTags");
            DropForeignKey("dbo.Tags", "CourseTags_Id", "dbo.CourseTags");
            DropForeignKey("dbo.Tags", "CourseTagId_Id", "dbo.CourseTags");
            DropForeignKey("dbo.Courses", "CourseTags_Id", "dbo.CourseTags");
            DropIndex("dbo.ExamSchedules", new[] { "Exam_Id1" });
            DropIndex("dbo.ExamSchedules", new[] { "ExamId_Id" });
            DropIndex("dbo.ExamSchedules", new[] { "Exam_Id" });
            DropIndex("dbo.Exams", new[] { "Course_Id1" });
            DropIndex("dbo.Exams", new[] { "CourseId_Id" });
            DropIndex("dbo.Exams", new[] { "Course_Id" });
            DropIndex("dbo.Participants", new[] { "Batch_Id1" });
            DropIndex("dbo.Participants", new[] { "BatchId_Id" });
            DropIndex("dbo.Participants", new[] { "Batch_Id" });
            DropIndex("dbo.Batches", new[] { "Course_Id1" });
            DropIndex("dbo.Batches", new[] { "CourseId_Id" });
            DropIndex("dbo.Batches", new[] { "Course_Id" });
            DropIndex("dbo.Tags", new[] { "CourseTags_Id1" });
            DropIndex("dbo.Tags", new[] { "CourseTags_Id" });
            DropIndex("dbo.Tags", new[] { "CourseTagId_Id" });
            DropIndex("dbo.Courses", new[] { "Tags_Id" });
            DropIndex("dbo.Courses", new[] { "CourseTagsId_Id" });
            DropIndex("dbo.Courses", new[] { "CourseTags_Id1" });
            DropIndex("dbo.Courses", new[] { "CourseTags_Id" });
            DropColumn("dbo.Courses", "Tags_Id");
            DropColumn("dbo.Courses", "CourseTagsId_Id");
            DropColumn("dbo.Courses", "CourseTags_Id1");
            DropColumn("dbo.Courses", "CourseTags_Id");
            DropTable("dbo.ExamSchedules");
            DropTable("dbo.Exams");
            DropTable("dbo.Participants");
            DropTable("dbo.Batches");
            DropTable("dbo.Tags");
            DropTable("dbo.CourseTags");
        }
    }
}
