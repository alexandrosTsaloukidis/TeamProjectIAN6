namespace TeamProjectIAN6.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UPdatingUserOccupationAndEducation : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE AspNetUsers SET EducationID = 2 WHERE Id = 'f89193b9-22c1-4dae-aed3-68331803fc81'");
            Sql("UPDATE AspNetUsers SET OccupationID = 2 WHERE Id = 'f89193b9-22c1-4dae-aed3-68331803fc81'");
        }
        
        public override void Down()
        {
        }
    }
}
