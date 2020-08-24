namespace TeamProjectIAN6.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeletingOriginalDateTImeFRomNotifications : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Notification", "OriginalDateTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Notification", "OriginalDateTime", c => c.DateTime());
        }
    }
}
