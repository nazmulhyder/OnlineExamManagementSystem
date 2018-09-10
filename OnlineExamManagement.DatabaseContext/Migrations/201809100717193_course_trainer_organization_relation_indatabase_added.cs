namespace OnlineExamManagement.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class course_trainer_organization_relation_indatabase_added : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CourseOrganizations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
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
                        Tags = c.String(),
                        CourseOrganization_Id = c.Int(),
                        CourseOrganizationId_Id = c.Int(),
                        CourseTrainer_Id = c.Int(),
                        CourseTrainer_Id1 = c.Int(),
                        CourseTrainerId_Id = c.Int(),
                        Organization_Id = c.Int(nullable: false),
                        CourseOrganization_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CourseOrganizations", t => t.CourseOrganization_Id)
                .ForeignKey("dbo.CourseOrganizations", t => t.CourseOrganizationId_Id)
                .ForeignKey("dbo.CourseTrainers", t => t.CourseTrainer_Id)
                .ForeignKey("dbo.CourseTrainers", t => t.CourseTrainer_Id1)
                .ForeignKey("dbo.CourseTrainers", t => t.CourseTrainerId_Id)
                .ForeignKey("dbo.Organizations", t => t.Organization_Id, cascadeDelete: true)
                .ForeignKey("dbo.CourseOrganizations", t => t.CourseOrganization_Id1)
                .Index(t => t.CourseOrganization_Id)
                .Index(t => t.CourseOrganizationId_Id)
                .Index(t => t.CourseTrainer_Id)
                .Index(t => t.CourseTrainer_Id1)
                .Index(t => t.CourseTrainerId_Id)
                .Index(t => t.Organization_Id)
                .Index(t => t.CourseOrganization_Id1);
            
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
                        CourseTrainer_Id = c.Int(),
                        CourseTrainerId_Id = c.Int(),
                        Organization_Id = c.Int(nullable: false),
                        CourseTrainer_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CourseTrainers", t => t.CourseTrainer_Id)
                .ForeignKey("dbo.CourseTrainers", t => t.CourseTrainerId_Id)
                .ForeignKey("dbo.Organizations", t => t.Organization_Id, cascadeDelete: true)
                .ForeignKey("dbo.CourseTrainers", t => t.CourseTrainer_Id1)
                .Index(t => t.CourseTrainer_Id)
                .Index(t => t.CourseTrainerId_Id)
                .Index(t => t.Organization_Id)
                .Index(t => t.CourseTrainer_Id1);
            
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
                        CourseOrganization_Id = c.Int(),
                        CourseOrganizationId_Id = c.Int(),
                        CourseOrganization_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CourseOrganizations", t => t.CourseOrganization_Id)
                .ForeignKey("dbo.CourseOrganizations", t => t.CourseOrganizationId_Id)
                .ForeignKey("dbo.CourseOrganizations", t => t.CourseOrganization_Id1)
                .Index(t => t.CourseOrganization_Id)
                .Index(t => t.CourseOrganizationId_Id)
                .Index(t => t.CourseOrganization_Id1);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Organizations", "CourseOrganization_Id1", "dbo.CourseOrganizations");
            DropForeignKey("dbo.Courses", "CourseOrganization_Id1", "dbo.CourseOrganizations");
            DropForeignKey("dbo.Courses", "Organization_Id", "dbo.Organizations");
            DropForeignKey("dbo.Courses", "CourseTrainerId_Id", "dbo.CourseTrainers");
            DropForeignKey("dbo.Courses", "CourseTrainer_Id1", "dbo.CourseTrainers");
            DropForeignKey("dbo.Trainers", "CourseTrainer_Id1", "dbo.CourseTrainers");
            DropForeignKey("dbo.Trainers", "Organization_Id", "dbo.Organizations");
            DropForeignKey("dbo.Organizations", "CourseOrganizationId_Id", "dbo.CourseOrganizations");
            DropForeignKey("dbo.Organizations", "CourseOrganization_Id", "dbo.CourseOrganizations");
            DropForeignKey("dbo.Trainers", "CourseTrainerId_Id", "dbo.CourseTrainers");
            DropForeignKey("dbo.Trainers", "CourseTrainer_Id", "dbo.CourseTrainers");
            DropForeignKey("dbo.Courses", "CourseTrainer_Id", "dbo.CourseTrainers");
            DropForeignKey("dbo.Courses", "CourseOrganizationId_Id", "dbo.CourseOrganizations");
            DropForeignKey("dbo.Courses", "CourseOrganization_Id", "dbo.CourseOrganizations");
            DropIndex("dbo.Organizations", new[] { "CourseOrganization_Id1" });
            DropIndex("dbo.Organizations", new[] { "CourseOrganizationId_Id" });
            DropIndex("dbo.Organizations", new[] { "CourseOrganization_Id" });
            DropIndex("dbo.Trainers", new[] { "CourseTrainer_Id1" });
            DropIndex("dbo.Trainers", new[] { "Organization_Id" });
            DropIndex("dbo.Trainers", new[] { "CourseTrainerId_Id" });
            DropIndex("dbo.Trainers", new[] { "CourseTrainer_Id" });
            DropIndex("dbo.Courses", new[] { "CourseOrganization_Id1" });
            DropIndex("dbo.Courses", new[] { "Organization_Id" });
            DropIndex("dbo.Courses", new[] { "CourseTrainerId_Id" });
            DropIndex("dbo.Courses", new[] { "CourseTrainer_Id1" });
            DropIndex("dbo.Courses", new[] { "CourseTrainer_Id" });
            DropIndex("dbo.Courses", new[] { "CourseOrganizationId_Id" });
            DropIndex("dbo.Courses", new[] { "CourseOrganization_Id" });
            DropTable("dbo.Organizations");
            DropTable("dbo.Trainers");
            DropTable("dbo.CourseTrainers");
            DropTable("dbo.Courses");
            DropTable("dbo.CourseOrganizations");
        }
    }
}
