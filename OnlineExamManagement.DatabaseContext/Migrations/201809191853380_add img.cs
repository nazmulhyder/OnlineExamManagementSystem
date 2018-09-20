namespace OnlineExamManagement.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addimg : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Organizations", "ImgPath", c => c.String());
            AlterColumn("dbo.Organizations", "Code", c => c.String(nullable: false, maxLength: 3));
            DropColumn("dbo.Organizations", "Logo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Organizations", "Logo", c => c.Binary());
            AlterColumn("dbo.Organizations", "Code", c => c.String());
            DropColumn("dbo.Organizations", "ImgPath");
        }
    }
}
