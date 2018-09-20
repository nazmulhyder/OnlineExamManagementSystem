namespace OnlineExamManagement.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class imgadd : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Organizations", "Code", c => c.String(nullable: false, maxLength: 5));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Organizations", "Code", c => c.String(nullable: false, maxLength: 3));
        }
    }
}
