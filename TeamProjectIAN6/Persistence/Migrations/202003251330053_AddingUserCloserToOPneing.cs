namespace TeamProjectIAN6.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingUserCloserToOPneing : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Opening", "UserCloserId", c => c.String(maxLength: 128));
          
            CreateIndex("dbo.Opening", "UserCloserId");

            AddForeignKey("dbo.Opening", "UserCloserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Opening", "UserCloserId", "dbo.AspNetUsers");
        
            DropIndex("dbo.Opening", new[] { "UserCloserId" });

            DropColumn("dbo.Opening", "UserCloserId");
        }
    }
}
