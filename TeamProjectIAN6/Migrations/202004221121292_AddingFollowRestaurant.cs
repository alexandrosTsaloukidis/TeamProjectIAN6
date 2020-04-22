namespace TeamProjectIAN6.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingFollowRestaurant : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.FollowRestaurant", "UnfollowDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FollowRestaurant", "UnfollowDate", c => c.DateTime());
        }
    }
}
