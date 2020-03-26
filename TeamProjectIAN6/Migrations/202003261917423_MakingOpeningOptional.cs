namespace TeamProjectIAN6.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakingOpeningOptional : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Opening", new[] { "UserId" });
            AlterColumn("dbo.Opening", "UserId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Opening", "DateTimeOpen", c => c.DateTime());
            CreateIndex("dbo.Opening", "UserId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Opening", new[] { "UserId" });
            AlterColumn("dbo.Opening", "DateTimeOpen", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Opening", "UserId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Opening", "UserId");
        }
    }
}
