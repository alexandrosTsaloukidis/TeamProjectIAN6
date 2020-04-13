namespace TeamProjectIAN6.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingDeleteFunctionalityToRestaurant : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Restaurant", "IsDeleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Restaurant", "IsDeleted");
        }
    }
}
