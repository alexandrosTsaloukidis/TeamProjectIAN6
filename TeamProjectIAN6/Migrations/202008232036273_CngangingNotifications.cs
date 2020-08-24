namespace TeamProjectIAN6.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CngangingNotifications : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Notification", "Restaurant_ID", "dbo.Restaurant");
            DropIndex("dbo.Notification", new[] { "Restaurant_ID" });
            AddColumn("dbo.Notification", "FollowRestaurant_ID", c => c.Int(nullable: false));
            CreateIndex("dbo.Notification", "FollowRestaurant_ID");
            AddForeignKey("dbo.Notification", "FollowRestaurant_ID", "dbo.FollowRestaurant", "ID", cascadeDelete: true);
            DropColumn("dbo.Notification", "Restaurant_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Notification", "Restaurant_ID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Notification", "FollowRestaurant_ID", "dbo.FollowRestaurant");
            DropIndex("dbo.Notification", new[] { "FollowRestaurant_ID" });
            DropColumn("dbo.Notification", "FollowRestaurant_ID");
            CreateIndex("dbo.Notification", "Restaurant_ID");
            AddForeignKey("dbo.Notification", "Restaurant_ID", "dbo.Restaurant", "ID", cascadeDelete: true);
        }
    }
}
