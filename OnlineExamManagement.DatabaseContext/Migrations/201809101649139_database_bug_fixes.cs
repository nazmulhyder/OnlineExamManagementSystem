namespace OnlineExamManagement.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class database_bug_fixes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Batches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BatchNumber = c.Int(nullable: false),
                        Description = c.String(),
                        StartDate = c.DateTime(),
                        EndDate = c.DateTime(),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Batch = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        Code = c.String(),
                        CourseDuration = c.String(nullable: false),
                        Credit = c.Int(nullable: false),
                        Outline = c.String(nullable: false, maxLength: 500),
                        CourseTrainerId = c.Int(nullable: false),
                        CourseOrganizationId = c.Int(nullable: false),
                        CourseTagsId = c.Int(nullable: false),
                        Tags_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CourseOrganizations", t => t.CourseOrganizationId, cascadeDelete: true)
                .ForeignKey("dbo.CourseTags", t => t.CourseTagsId, cascadeDelete: true)
                .ForeignKey("dbo.CourseTrainers", t => t.CourseTrainerId, cascadeDelete: true)
                .ForeignKey("dbo.Tags", t => t.Tags_Id)
                .Index(t => t.CourseTrainerId)
                .Index(t => t.CourseOrganizationId)
                .Index(t => t.CourseTagsId)
                .Index(t => t.Tags_Id);
            
            CreateTable(
                "dbo.CourseOrganizations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Organizations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Code = c.String(),
                        Address = c.String(nullable: false),
                        ContactNumber = c.String(nullable: false),
                        About = c.String(),
                        Logo = c.String(),
                        CourseOrganizationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CourseOrganizations", t => t.CourseOrganizationId, cascadeDelete: true)
                .Index(t => t.CourseOrganizationId);
            
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
                        CourseTagId = c.Int(nullable: false),
                        CourseTags_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CourseTags", t => t.CourseTags_Id)
                .Index(t => t.CourseTags_Id);
            
            CreateTable(
                "dbo.CourseTrainers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Trainers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Batch = c.Int(nullable: false),
                        isLead = c.Boolean(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        ContactNumber = c.String(),
                        Email = c.String(nullable: false, maxLength: 100),
                        Address = c.String(),
                        City = c.String(),
                        PostalCode = c.Int(nullable: false),
                        Country = c.String(),
                        CourseTrainerId = c.Int(nullable: false),
                        Organization_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CourseTrainers", t => t.CourseTrainerId, cascadeDelete: true)
                .ForeignKey("dbo.Organizations", t => t.Organization_Id, cascadeDelete: true)
                .Index(t => t.CourseTrainerId)
                .Index(t => t.Organization_Id);
            
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
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.ExamSchedules",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ExamDateTime = c.DateTime(nullable: false),
                        ExamId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Exams", t => t.ExamId, cascadeDelete: true)
                .Index(t => t.ExamId);
            
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
                        BatchId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Batches", t => t.BatchId, cascadeDelete: true)
                .Index(t => t.BatchId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Participants", "BatchId", "dbo.Batches");
            DropForeignKey("dbo.Courses", "Tags_Id", "dbo.Tags");
            DropForeignKey("dbo.ExamSchedules", "ExamId", "dbo.Exams");
            DropForeignKey("dbo.Exams", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Batches", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Trainers", "Organization_Id", "dbo.Organizations");
            DropForeignKey("dbo.Trainers", "CourseTrainerId", "dbo.CourseTrainers");
            DropForeignKey("dbo.Courses", "CourseTrainerId", "dbo.CourseTrainers");
            DropForeignKey("dbo.Tags", "CourseTags_Id", "dbo.CourseTags");
            DropForeignKey("dbo.Courses", "CourseTagsId", "dbo.CourseTags");
            DropForeignKey("dbo.Organizations", "CourseOrganizationId", "dbo.CourseOrganizations");
            DropForeignKey("dbo.Courses", "CourseOrganizationId", "dbo.CourseOrganizations");
            DropIndex("dbo.Participants", new[] { "BatchId" });
            DropIndex("dbo.ExamSchedules", new[] { "ExamId" });
            DropIndex("dbo.Exams", new[] { "CourseId" });
            DropIndex("dbo.Trainers", new[] { "Organization_Id" });
            DropIndex("dbo.Trainers", new[] { "CourseTrainerId" });
            DropIndex("dbo.Tags", new[] { "CourseTags_Id" });
            DropIndex("dbo.Organizations", new[] { "CourseOrganizationId" });
            DropIndex("dbo.Courses", new[] { "Tags_Id" });
            DropIndex("dbo.Courses", new[] { "CourseTagsId" });
            DropIndex("dbo.Courses", new[] { "CourseOrganizationId" });
            DropIndex("dbo.Courses", new[] { "CourseTrainerId" });
            DropIndex("dbo.Batches", new[] { "CourseId" });
            DropTable("dbo.Participants");
            DropTable("dbo.ExamSchedules");
            DropTable("dbo.Exams");
            DropTable("dbo.Trainers");
            DropTable("dbo.CourseTrainers");
            DropTable("dbo.Tags");
            DropTable("dbo.CourseTags");
            DropTable("dbo.Organizations");
            DropTable("dbo.CourseOrganizations");
            DropTable("dbo.Courses");
            DropTable("dbo.Batches");
        }
    }
}
