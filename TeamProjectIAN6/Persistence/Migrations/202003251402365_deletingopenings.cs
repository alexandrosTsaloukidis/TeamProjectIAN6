namespace TeamProjectIAN6.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletingopenings : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Opening", "RestaurantId", "dbo.Restaurant");
            DropForeignKey("dbo.Opening", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Opening", "ApplicationUser_Id1", "dbo.AspNetUsers");
            DropForeignKey("dbo.Opening", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Opening", "UserCloserId", "dbo.AspNetUsers");
            DropIndex("dbo.Opening", new[] { "UserId" });
            DropIndex("dbo.Opening", new[] { "RestaurantId" });
            DropIndex("dbo.Opening", new[] { "UserCloserId" });
            DropIndex("dbo.Opening", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Opening", new[] { "ApplicationUser_Id1" });
            DropTable("dbo.Opening");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Opening",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        RestaurantId = c.Int(nullable: false),
                        DateTimeOpen = c.DateTime(nullable: false),
                        UserCloserId = c.String(maxLength: 128),
                        DateTimeClose = c.DateTime(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                        ApplicationUser_Id1 = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Opening", "ApplicationUser_Id1");
            CreateIndex("dbo.Opening", "ApplicationUser_Id");
            CreateIndex("dbo.Opening", "UserCloserId");
            CreateIndex("dbo.Opening", "RestaurantId");
            CreateIndex("dbo.Opening", "UserId");
            AddForeignKey("dbo.Opening", "UserCloserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Opening", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Opening", "ApplicationUser_Id1", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Opening", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Opening", "RestaurantId", "dbo.Restaurant", "ID", cascadeDelete: true);
        }
    }
}
