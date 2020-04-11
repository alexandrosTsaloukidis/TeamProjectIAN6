namespace TeamProjectIAN6.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingCurrentCapacityToTheRestaurant : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Restaurant", "CurrentCapacity", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Restaurant", "CurrentCapacity");
        }
    }
}
