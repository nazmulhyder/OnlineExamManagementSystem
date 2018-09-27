namespace OnlineExamManagement.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class examdurationchange : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Exams", "Duration", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Exams", "Duration", c => c.Time(nullable: false, precision: 7));
        }
    }
}
