namespace TeamProjectIAN6.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingLifeInfo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LifeInfo",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RestaurantID = c.Int(nullable: false),
                        DateTimeSaved = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Restaurant", t => t.RestaurantID, cascadeDelete: true)
                .Index(t => t.RestaurantID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LifeInfo", "RestaurantID", "dbo.Restaurant");
            DropIndex("dbo.LifeInfo", new[] { "RestaurantID" });
            DropTable("dbo.LifeInfo");
        }
    }
}
