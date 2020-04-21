namespace TeamProjectIAN6.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletingagain : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "ProfImage");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "ProfImage", c => c.String());
        }
    }
}
