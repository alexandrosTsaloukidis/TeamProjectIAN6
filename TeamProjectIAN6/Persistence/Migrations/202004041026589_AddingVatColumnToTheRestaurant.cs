namespace TeamProjectIAN6.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingVatColumnToTheRestaurant : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Restaurant", "Vat", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Restaurant", "Vat");
        }
    }
}
