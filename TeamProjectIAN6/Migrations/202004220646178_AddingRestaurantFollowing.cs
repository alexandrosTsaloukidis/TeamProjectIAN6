namespace TeamProjectIAN6.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingRestaurantFollowing : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FollowRestaurant",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        RestaurantId = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.Restaurant", t => t.RestaurantId, cascadeDelete: true)
                .Index(t => t.RestaurantId)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FollowRestaurant", "RestaurantId", "dbo.Restaurant");
            DropForeignKey("dbo.FollowRestaurant", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.FollowRestaurant", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.FollowRestaurant", new[] { "RestaurantId" });
            DropTable("dbo.FollowRestaurant");
        }
    }
}
