namespace TeamProjectIAN6.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingRestaurant : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO RESTAURANT (NAME, CAPACITY, LOCATIONID) VALUES ('Vasilainas', 456, 1)");
            Sql("INSERT INTO RESTAURANT (NAME, CAPACITY, LOCATIONID) VALUES ('Efharis', 25, 2)");
            Sql("INSERT INTO RESTAURANT (NAME, CAPACITY, LOCATIONID) VALUES ('Just Pita', 7852, 3)");
            Sql("INSERT INTO RESTAURANT (NAME, CAPACITY, LOCATIONID) VALUES ('Julia of Athens', 35, 4)");
            Sql("INSERT INTO RESTAURANT (NAME, CAPACITY, LOCATIONID) VALUES ('Ola stin kolla', 98, 1)");
        }
        
        public override void Down()
        {
        }
    }
}
