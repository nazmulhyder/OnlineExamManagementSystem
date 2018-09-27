namespace OnlineExamManagement.DatabaseContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tainermodelmodifiedforprocessingimg : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Trainers", "ImgPath", c => c.String());
            DropColumn("dbo.Trainers", "Image");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Trainers", "Image", c => c.String());
            DropColumn("dbo.Trainers", "ImgPath");
        }
    }
}
