namespace TeamProjectIAN6.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingLogoToRestaurant : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Restaurant", "Logo", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Restaurant", "Logo");
        }
    }
}
