namespace TeamProjectIAN6.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingCurrentCapacityToLifeInfo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LifeInfo", "CurrentCapacity", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.LifeInfo", "CurrentCapacity");
        }
    }
}
