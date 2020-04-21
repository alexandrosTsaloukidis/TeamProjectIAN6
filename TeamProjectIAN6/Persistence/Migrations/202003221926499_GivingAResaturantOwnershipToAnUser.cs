namespace TeamProjectIAN6.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GivingAResaturantOwnershipToAnUser : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO RestaurantOwnership (ApplicationUserId, RestaurantId, StartOwnershipDateTime) VALUES ('id_1', 6, CAST(N'2000-10-11T00:00:00.000' AS DateTime))");
        }
        
        public override void Down()
        {
        }
    }
}
