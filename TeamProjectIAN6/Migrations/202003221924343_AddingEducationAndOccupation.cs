namespace TeamProjectIAN6.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingEducationAndOccupation : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO OCCUPATION (NAME) VALUES ('Programmer')");
            Sql("INSERT INTO EDUCATION (NAME) VALUES ('Zn Sxoli')");
        }
        
        public override void Down()
        {
        }
    }
}
