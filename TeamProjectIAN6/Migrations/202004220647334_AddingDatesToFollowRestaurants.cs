namespace TeamProjectIAN6.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingDatesToFollowRestaurants : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FollowRestaurant", "FollowDate", c => c.DateTime());
            AddColumn("dbo.FollowRestaurant", "UnfollowDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.FollowRestaurant", "UnfollowDate");
            DropColumn("dbo.FollowRestaurant", "FollowDate");
        }
    }
}
