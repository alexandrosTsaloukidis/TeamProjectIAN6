namespace TeamProjectIAN6.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingOccupationAndEducation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Education",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.AspNetUsers", "EducationId", c => c.Int());
            AddColumn("dbo.AspNetUsers", "OccupationId", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "EducationId");
            CreateIndex("dbo.AspNetUsers", "OccupationId");
            AddForeignKey("dbo.AspNetUsers", "EducationId", "dbo.Education", "Id");
            AddForeignKey("dbo.AspNetUsers", "OccupationId", "dbo.Education", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "OccupationId", "dbo.Education");
            DropForeignKey("dbo.AspNetUsers", "EducationId", "dbo.Education");
            DropIndex("dbo.AspNetUsers", new[] { "OccupationId" });
            DropIndex("dbo.AspNetUsers", new[] { "EducationId" });
            DropColumn("dbo.AspNetUsers", "OccupationId");
            DropColumn("dbo.AspNetUsers", "EducationId");
            DropTable("dbo.Education");
        }
    }
}
