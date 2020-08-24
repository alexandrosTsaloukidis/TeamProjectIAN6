namespace TeamProjectIAN6.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingFollowAndFollowButtonToRestaurant : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Restaurant", "FollowButtonClass", c => c.String());
            AddColumn("dbo.Restaurant", "FollowButtonText", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Restaurant", "FollowButtonText");
            DropColumn("dbo.Restaurant", "FollowButtonClass");
        }
    }
}
