namespace TeamProjectIAN6.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingVisits : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO VISIT (RestaurantId, ApplicationUserId) VALUES (5, 'id_1')");
            Sql("INSERT INTO VISIT (RestaurantId, ApplicationUserId) VALUES (6, 'id_2')");
            Sql("INSERT INTO VISIT (RestaurantId, ApplicationUserId) VALUES (7, 'id_3')");
            Sql("INSERT INTO VISIT (RestaurantId, ApplicationUserId) VALUES (8, 'id_4')");
            Sql("INSERT INTO VISIT (RestaurantId, ApplicationUserId) VALUES (9, 'id_5')");
            Sql("INSERT INTO VISIT (RestaurantId, ApplicationUserId) VALUES (5, 'id_6')");
            Sql("INSERT INTO VISIT (RestaurantId, ApplicationUserId) VALUES (6, 'id_7')");
            Sql("INSERT INTO VISIT (RestaurantId, ApplicationUserId) VALUES (7, 'id_1')");
            Sql("INSERT INTO VISIT (RestaurantId, ApplicationUserId) VALUES (8, 'id_2')");
            Sql("INSERT INTO VISIT (RestaurantId, ApplicationUserId) VALUES (9, 'id_3')");
            Sql("INSERT INTO VISIT (RestaurantId, ApplicationUserId) VALUES (5, 'id_4')");
            Sql("INSERT INTO VISIT (RestaurantId, ApplicationUserId) VALUES (6, 'id_5')");
            Sql("INSERT INTO VISIT (RestaurantId, ApplicationUserId) VALUES (7, 'id_6')");
            Sql("INSERT INTO VISIT (RestaurantId, ApplicationUserId) VALUES (8, 'id_7')");
        }
        
        public override void Down()
        {
        }
    }
}
