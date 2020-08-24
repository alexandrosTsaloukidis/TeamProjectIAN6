namespace TeamProjectIAN6.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingUfollowDateTime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FollowRestaurant", "UnfollowDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.FollowRestaurant", "UnfollowDate");
        }
    }
}
