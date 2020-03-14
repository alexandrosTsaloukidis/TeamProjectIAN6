namespace TeamProjectIAN6.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddVisits : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO VISIT (RestaurantId, ApplicationUserId) VALUES (1, 'f89193b9-22c1-4dae-aed3-68331803fc81')");
            Sql("INSERT INTO VISIT (RestaurantId, ApplicationUserId) VALUES (2, 'id_1')");
            Sql("INSERT INTO VISIT (RestaurantId, ApplicationUserId) VALUES (3, 'id_2')");
            Sql("INSERT INTO VISIT (RestaurantId, ApplicationUserId) VALUES (4, 'id_3')");
            Sql("INSERT INTO VISIT (RestaurantId, ApplicationUserId) VALUES (5, 'id_4')");
            Sql("INSERT INTO VISIT (RestaurantId, ApplicationUserId) VALUES (1, 'id_5')");
            Sql("INSERT INTO VISIT (RestaurantId, ApplicationUserId) VALUES (2, 'id_6')");
            Sql("INSERT INTO VISIT (RestaurantId, ApplicationUserId) VALUES (3, 'id_7')");
            Sql("INSERT INTO VISIT (RestaurantId, ApplicationUserId) VALUES (4, 'id_1')");
            Sql("INSERT INTO VISIT (RestaurantId, ApplicationUserId) VALUES (5, 'id_2')");
            Sql("INSERT INTO VISIT (RestaurantId, ApplicationUserId) VALUES (1, 'id_3')");
            Sql("INSERT INTO VISIT (RestaurantId, ApplicationUserId) VALUES (2, 'id_4')");
            Sql("INSERT INTO VISIT (RestaurantId, ApplicationUserId) VALUES (3, 'id_5')");
            Sql("INSERT INTO VISIT (RestaurantId, ApplicationUserId) VALUES (4, 'id_6')");
            Sql("INSERT INTO VISIT (RestaurantId, ApplicationUserId) VALUES (5, 'id_7')");
        }
        
        public override void Down()
        {
        }
    }
}
