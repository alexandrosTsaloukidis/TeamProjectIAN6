namespace TeamProjectIAN6.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameingNomosToNameInLocation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Location", "Name", c => c.String());
            DropColumn("dbo.Location", "Nomos");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Location", "Nomos", c => c.String());
            DropColumn("dbo.Location", "Name");
        }
    }
}
