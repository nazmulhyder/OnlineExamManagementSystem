namespace OnlineExamManagement.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class database_update_with_fluentAPI : DbMigration
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
                        Name = c.String(nullable: false, maxLength: 50),
                        Code = c.String(),
                        CourseDuration = c.String(nullable: false),
                        Credit = c.Int(nullable: false),
                        Outline = c.String(nullable: false, maxLength: 500),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CourseOrganizations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CourseId = c.Int(nullable: false),
                        OrganizationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Organizations", t => t.OrganizationId, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .Index(t => t.CourseId)
                .Index(t => t.OrganizationId);
            
            CreateTable(
                "dbo.Organizations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Code = c.String(),
                        Address = c.String(nullable: false),
                        ContactNo = c.String(nullable: false),
                        About = c.String(),
                        Logo = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CourseTags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CourseId = c.Int(nullable: false),
                        TagId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tags", t => t.TagId, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .Index(t => t.CourseId)
                .Index(t => t.TagId);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CourseTrainers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CourseId = c.Int(nullable: false),
                        TrainerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Trainers", t => t.TrainerId, cascadeDelete: true)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .Index(t => t.CourseId)
                .Index(t => t.TrainerId);
            
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
                        Organization_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Organizations", t => t.Organization_Id, cascadeDelete: true)
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
                        Image = c.String(),
                        BatchId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Batches", t => t.BatchId, cascadeDelete: true)
                .Index(t => t.BatchId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Participants", "BatchId", "dbo.Batches");
            DropForeignKey("dbo.ExamSchedules", "ExamId", "dbo.Exams");
            DropForeignKey("dbo.Exams", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Batches", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.CourseTrainers", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Trainers", "Organization_Id", "dbo.Organizations");
            DropForeignKey("dbo.CourseTrainers", "TrainerId", "dbo.Trainers");
            DropForeignKey("dbo.CourseTags", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.CourseTags", "TagId", "dbo.Tags");
            DropForeignKey("dbo.CourseOrganizations", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.CourseOrganizations", "OrganizationId", "dbo.Organizations");
            DropIndex("dbo.Participants", new[] { "BatchId" });
            DropIndex("dbo.ExamSchedules", new[] { "ExamId" });
            DropIndex("dbo.Exams", new[] { "CourseId" });
            DropIndex("dbo.Trainers", new[] { "Organization_Id" });
            DropIndex("dbo.CourseTrainers", new[] { "TrainerId" });
            DropIndex("dbo.CourseTrainers", new[] { "CourseId" });
            DropIndex("dbo.CourseTags", new[] { "TagId" });
            DropIndex("dbo.CourseTags", new[] { "CourseId" });
            DropIndex("dbo.CourseOrganizations", new[] { "OrganizationId" });
            DropIndex("dbo.CourseOrganizations", new[] { "CourseId" });
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
