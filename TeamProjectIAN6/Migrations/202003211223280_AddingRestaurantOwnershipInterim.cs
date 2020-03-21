namespace TeamProjectIAN6.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingRestaurantOwnershipInterim : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RestaurantOwnership",
                c => new
                    {
                        ApplicationUserId = c.Int(nullable: false),
                        RestaurantId = c.Int(nullable: false),
                        StartOwnershipDateTime = c.DateTime(nullable: false),
                        QuitOwnershipDateTime = c.DateTime(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.ApplicationUserId, t.RestaurantId })
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.Restaurant", t => t.RestaurantId, cascadeDelete: true)
                .Index(t => t.RestaurantId)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RestaurantOwnership", "RestaurantId", "dbo.Restaurant");
            DropForeignKey("dbo.RestaurantOwnership", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.RestaurantOwnership", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.RestaurantOwnership", new[] { "RestaurantId" });
            DropTable("dbo.RestaurantOwnership");
        }
    }
}
