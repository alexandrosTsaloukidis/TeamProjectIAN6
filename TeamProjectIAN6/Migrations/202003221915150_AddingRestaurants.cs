namespace TeamProjectIAN6.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingRestaurants : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO RESTAURANT (NAME, CAPACITY, LOCATIONID, AREAID, Lattitude, Longitude, PostalCode, IsOpened) VALUES ('Vasilainas', 456, 7, 3, 10, 10, 1, 1)");
            Sql("INSERT INTO RESTAURANT (NAME, CAPACITY, LOCATIONID, AREAID, Lattitude, Longitude, PostalCode, IsOpened) VALUES ('Efharis', 25, 8, 4, 10, 10, 1, 1)");
            Sql("INSERT INTO RESTAURANT (NAME, CAPACITY, LOCATIONID, AREAID, Lattitude, Longitude, PostalCode, IsOpened) VALUES ('Just Pita', 7852, 9, 5, 10, 10, 1, 1)");
            Sql("INSERT INTO RESTAURANT (NAME, CAPACITY, LOCATIONID, AREAID, Lattitude, Longitude, PostalCode, IsOpened) VALUES ('Julia of Athens', 35, 10, 6, 10, 10, 1, 1)");
            Sql("INSERT INTO RESTAURANT (NAME, CAPACITY, LOCATIONID, AREAID, Lattitude, Longitude, PostalCode, IsOpened) VALUES ('Ola stin kolla', 98, 7, 3, 10, 10, 1, 1)");
        }
        
        public override void Down()
        {
        }
    }
}
