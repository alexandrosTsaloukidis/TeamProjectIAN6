namespace TeamProjectIAN6.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newtypeimages : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "ProfImage", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "ProfImage");
        }
    }
}
