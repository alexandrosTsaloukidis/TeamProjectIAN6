namespace TeamProjectIAN6.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatingCapacityPropertiesAndManipulations : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Restaurant", "CurrentClientPopulation", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Restaurant", "CurrentClientPopulation");
        }
    }
}
