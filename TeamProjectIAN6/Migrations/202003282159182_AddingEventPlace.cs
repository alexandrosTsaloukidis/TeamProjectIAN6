namespace TeamProjectIAN6.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingEventPlace : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EventPlace",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        RestaurantId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Restaurant", t => t.RestaurantId)
                .Index(t => t.RestaurantId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EventPlace", "RestaurantId", "dbo.Restaurant");
            DropIndex("dbo.EventPlace", new[] { "RestaurantId" });
            DropTable("dbo.EventPlace");
        }
    }
}
