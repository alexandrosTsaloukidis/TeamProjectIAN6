namespace TeamProjectIAN6.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class makingrestaurantidlessstrictinownerships : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RestaurantOwnership", "RestaurantId", "dbo.Restaurant");
            DropIndex("dbo.RestaurantOwnership", new[] { "RestaurantId" });
            AlterColumn("dbo.RestaurantOwnership", "RestaurantId", c => c.Int());
            CreateIndex("dbo.RestaurantOwnership", "RestaurantId");
            AddForeignKey("dbo.RestaurantOwnership", "RestaurantId", "dbo.Restaurant", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RestaurantOwnership", "RestaurantId", "dbo.Restaurant");
            DropIndex("dbo.RestaurantOwnership", new[] { "RestaurantId" });
            AlterColumn("dbo.RestaurantOwnership", "RestaurantId", c => c.Int(nullable: false));
            CreateIndex("dbo.RestaurantOwnership", "RestaurantId");
            AddForeignKey("dbo.RestaurantOwnership", "RestaurantId", "dbo.Restaurant", "ID", cascadeDelete: true);
        }
    }
}
