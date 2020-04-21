namespace TeamProjectIAN6.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingProfAndLogoImages : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Restaurant", "LogoImage", c => c.Binary());
            AddColumn("dbo.AspNetUsers", "ProfileImage", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "ProfileImage");
            DropColumn("dbo.Restaurant", "LogoImage");
        }
    }
}
