namespace TeamProjectIAN6.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingPhoneNUmber : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Restaurant", "PhoneNumber", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Restaurant", "PhoneNumber");
        }
    }
}
