namespace TeamProjectIAN6.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChengingUserIdType : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Visit", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.Visit", "ApplicationUserId");
            RenameColumn(table: "dbo.Visit", name: "ApplicationUser_Id", newName: "ApplicationUserId");
            AlterColumn("dbo.Visit", "ApplicationUserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Visit", "ApplicationUserId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Visit", new[] { "ApplicationUserId" });
            AlterColumn("dbo.Visit", "ApplicationUserId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Visit", name: "ApplicationUserId", newName: "ApplicationUser_Id");
            AddColumn("dbo.Visit", "ApplicationUserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Visit", "ApplicationUser_Id");
        }
    }
}
