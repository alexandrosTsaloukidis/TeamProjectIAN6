namespace TeamProjectIAN6.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakingNullableCurrentCapacity : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.LifeInfo", "CurrentCapacity", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.LifeInfo", "CurrentCapacity", c => c.Int(nullable: false));
        }
    }
}
