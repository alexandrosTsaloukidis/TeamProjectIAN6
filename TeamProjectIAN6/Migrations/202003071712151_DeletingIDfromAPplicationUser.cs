namespace TeamProjectIAN6.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeletingIDfromAPplicationUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Firstname", c => c.String());
            AddColumn("dbo.AspNetUsers", "Lastname", c => c.String());
            AddColumn("dbo.AspNetUsers", "Gender", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Gender");
            DropColumn("dbo.AspNetUsers", "Lastname");
            DropColumn("dbo.AspNetUsers", "Firstname");
        }
    }
}
