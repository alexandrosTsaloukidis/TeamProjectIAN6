namespace TeamProjectIAN6.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovingAvAndCurrentCapacity : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Restaurant", "CurrentClientPopulation");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Restaurant", "CurrentClientPopulation", c => c.Int(nullable: false));
        }
    }
}
