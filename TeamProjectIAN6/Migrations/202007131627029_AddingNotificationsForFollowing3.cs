namespace TeamProjectIAN6.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingNotificationsForFollowing3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Notification",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTime = c.DateTime(nullable: false),
                        Type = c.Int(nullable: false),
                        OriginalDateTime = c.DateTime(),
                        Restaurant_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Restaurant", t => t.Restaurant_ID, cascadeDelete: true)
                .Index(t => t.Restaurant_ID);
            
            CreateTable(
                "dbo.UserNotification",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        NotificationId = c.Int(nullable: false),
                        IsRead = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.NotificationId })
                .ForeignKey("dbo.Notification", t => t.NotificationId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.NotificationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserNotification", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserNotification", "NotificationId", "dbo.Notification");
            DropForeignKey("dbo.Notification", "Restaurant_ID", "dbo.Restaurant");
            DropIndex("dbo.UserNotification", new[] { "NotificationId" });
            DropIndex("dbo.UserNotification", new[] { "UserId" });
            DropIndex("dbo.Notification", new[] { "Restaurant_ID" });
            DropTable("dbo.UserNotification");
            DropTable("dbo.Notification");
        }
    }
}
