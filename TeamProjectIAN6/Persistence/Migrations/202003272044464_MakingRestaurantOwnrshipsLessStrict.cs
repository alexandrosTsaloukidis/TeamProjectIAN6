namespace TeamProjectIAN6.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakingRestaurantOwnrshipsLessStrict : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RestaurantOwnership", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.RestaurantOwnership", new[] { "ApplicationUserId" });
            DropPrimaryKey("dbo.RestaurantOwnership");
            AddColumn("dbo.RestaurantOwnership", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.RestaurantOwnership", "ApplicationUserId", c => c.String(maxLength: 128));
            AddPrimaryKey("dbo.RestaurantOwnership", "Id");
            CreateIndex("dbo.RestaurantOwnership", "ApplicationUserId");
            AddForeignKey("dbo.RestaurantOwnership", "ApplicationUserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RestaurantOwnership", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.RestaurantOwnership", new[] { "ApplicationUserId" });
            DropPrimaryKey("dbo.RestaurantOwnership");
            AlterColumn("dbo.RestaurantOwnership", "ApplicationUserId", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.RestaurantOwnership", "Id");
            AddPrimaryKey("dbo.RestaurantOwnership", new[] { "ApplicationUserId", "RestaurantId" });
            CreateIndex("dbo.RestaurantOwnership", "ApplicationUserId");
            AddForeignKey("dbo.RestaurantOwnership", "ApplicationUserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
