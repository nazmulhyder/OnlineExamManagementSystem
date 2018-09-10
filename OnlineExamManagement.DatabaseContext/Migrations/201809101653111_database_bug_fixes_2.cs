namespace OnlineExamManagement.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class database_bug_fixes_2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Courses", "Tags_Id", "dbo.Tags");
            DropIndex("dbo.Courses", new[] { "Tags_Id" });
            DropColumn("dbo.Courses", "Tags_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Courses", "Tags_Id", c => c.Int());
            CreateIndex("dbo.Courses", "Tags_Id");
            AddForeignKey("dbo.Courses", "Tags_Id", "dbo.Tags", "Id");
        }
    }
}
