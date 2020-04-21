namespace TeamProjectIAN6.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletingimages : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Restaurant", "LogoImage");
            DropColumn("dbo.AspNetUsers", "ProfileImage");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "ProfileImage", c => c.Binary());
            AddColumn("dbo.Restaurant", "LogoImage", c => c.Binary());
        }
    }
}
