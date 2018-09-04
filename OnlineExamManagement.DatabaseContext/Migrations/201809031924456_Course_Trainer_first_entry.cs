namespace OnlineExamManagement.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Course_Trainer_first_entry : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Organization = c.String(nullable: false),
                        Batch = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        Code = c.String(nullable: false),
                        CourseDuration = c.String(nullable: false),
                        Credit = c.Int(nullable: false),
                        Outline = c.String(nullable: false, maxLength: 500),
                        Tags = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Trainers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Organization = c.String(nullable: false),
                        Batch = c.Int(nullable: false),
                        isLead = c.Boolean(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        ContactNumber = c.String(),
                        Email = c.String(nullable: false, maxLength: 100),
                        Address = c.String(),
                        City = c.String(),
                        PostalCode = c.Int(nullable: false),
                        Country = c.String(),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .Index(t => t.CourseId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Trainers", "CourseId", "dbo.Courses");
            DropIndex("dbo.Trainers", new[] { "CourseId" });
            DropTable("dbo.Trainers");
            DropTable("dbo.Courses");
        }
    }
}
