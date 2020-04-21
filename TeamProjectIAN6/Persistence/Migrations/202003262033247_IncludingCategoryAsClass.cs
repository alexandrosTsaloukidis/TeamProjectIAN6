namespace TeamProjectIAN6.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IncludingCategoryAsClass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Restaurant", "CategoryID", c => c.Int());
            CreateIndex("dbo.Restaurant", "CategoryID");
            AddForeignKey("dbo.Restaurant", "CategoryID", "dbo.Category", "Id");
            DropColumn("dbo.Restaurant", "Category");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Restaurant", "Category", c => c.String());
            DropForeignKey("dbo.Restaurant", "CategoryID", "dbo.Category");
            DropIndex("dbo.Restaurant", new[] { "CategoryID" });
            DropColumn("dbo.Restaurant", "CategoryID");
            DropTable("dbo.Category");
        }
    }
}
