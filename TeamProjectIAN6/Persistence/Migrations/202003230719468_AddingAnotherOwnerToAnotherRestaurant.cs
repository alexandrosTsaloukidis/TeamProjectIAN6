namespace TeamProjectIAN6.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingAnotherOwnerToAnotherRestaurant : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO RestaurantOwnership (ApplicationUserId, RestaurantId, StartOwnershipDateTime) VALUES ('38e145c0-b916-48ce-ac79-5cb919b0a7b7', 8, CAST(N'2000-10-11T00:00:00.000' AS DateTime))");

        }

        public override void Down()
        {
        }
    }
}
