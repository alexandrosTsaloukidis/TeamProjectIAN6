namespace TeamProjectIAN6.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeApplicationUserToUserInFollow : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.FollowRestaurant", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.FollowRestaurant", "UserId");
            RenameColumn(table: "dbo.FollowRestaurant", name: "ApplicationUser_Id", newName: "UserId");
            AlterColumn("dbo.FollowRestaurant", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.FollowRestaurant", "UserId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.FollowRestaurant", new[] { "UserId" });
            AlterColumn("dbo.FollowRestaurant", "UserId", c => c.String());
            RenameColumn(table: "dbo.FollowRestaurant", name: "UserId", newName: "ApplicationUser_Id");
            AddColumn("dbo.FollowRestaurant", "UserId", c => c.String());
            CreateIndex("dbo.FollowRestaurant", "ApplicationUser_Id");
        }
    }
}
