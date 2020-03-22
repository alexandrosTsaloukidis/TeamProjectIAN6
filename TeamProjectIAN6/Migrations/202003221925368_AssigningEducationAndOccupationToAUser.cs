namespace TeamProjectIAN6.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AssigningEducationAndOccupationToAUser : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE AspNetUsers SET EducationID = 1 WHERE Id = 'id_1'");
            Sql("UPDATE AspNetUsers SET OccupationID = 1 WHERE Id = 'id_1'");
        }
        
        public override void Down()
        {
        }
    }
}
