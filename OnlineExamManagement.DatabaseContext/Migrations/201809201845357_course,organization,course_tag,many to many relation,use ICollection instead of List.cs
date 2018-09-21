namespace OnlineExamManagement.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class courseorganizationcourse_tagmanytomanyrelationuseICollectioninsteadofList : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrganizationId = c.Int(nullable: false),
                        Name = c.String(),
                        Code = c.String(),
                        CourseDuration = c.String(nullable: false),
                        Credit = c.Int(nullable: false),
                        Outline = c.String(nullable: false, maxLength: 500),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Organizations", t => t.OrganizationId, cascadeDelete: true)
                .Index(t => t.OrganizationId);
            
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
                "dbo.Organizations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Code = c.String(nullable: false, maxLength: 5),
                        Address = c.String(nullable: false),
                        ContactNo = c.String(nullable: false),
                        ImgPath = c.String(),
                        About = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "OrganizationId", "dbo.Organizations");
            DropForeignKey("dbo.CourseTags", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.CourseTags", "TagId", "dbo.Tags");
            DropIndex("dbo.CourseTags", new[] { "TagId" });
            DropIndex("dbo.CourseTags", new[] { "CourseId" });
            DropIndex("dbo.Courses", new[] { "OrganizationId" });
            DropTable("dbo.Organizations");
            DropTable("dbo.Tags");
            DropTable("dbo.CourseTags");
            DropTable("dbo.Courses");
        }
    }
}
