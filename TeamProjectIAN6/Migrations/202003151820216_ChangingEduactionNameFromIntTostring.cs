namespace TeamProjectIAN6.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangingEduactionNameFromIntTostring : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Education", "Name", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Education", "Name", c => c.Int(nullable: false));
        }
    }
}
