namespace TeamProjectIAN6.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CngangingNotificationsAddingFRid : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Notification", name: "FollowRestaurant_ID", newName: "FollowRestaurantId");
            RenameIndex(table: "dbo.Notification", name: "IX_FollowRestaurant_ID", newName: "IX_FollowRestaurantId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Notification", name: "IX_FollowRestaurantId", newName: "IX_FollowRestaurant_ID");
            RenameColumn(table: "dbo.Notification", name: "FollowRestaurantId", newName: "FollowRestaurant_ID");
        }
    }
}
