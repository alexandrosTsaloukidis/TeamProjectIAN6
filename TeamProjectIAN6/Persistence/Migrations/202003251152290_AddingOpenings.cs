namespace TeamProjectIAN6.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingOpenings : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Opening",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        RestaurantId = c.Int(nullable: false),
                        DateTimeOpen = c.DateTime(nullable: false),
                        DateTimeClose = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Restaurant", t => t.RestaurantId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.RestaurantId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Opening", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Opening", "RestaurantId", "dbo.Restaurant");
            DropIndex("dbo.Opening", new[] { "RestaurantId" });
            DropIndex("dbo.Opening", new[] { "UserId" });
            DropTable("dbo.Opening");
        }
    }
}
