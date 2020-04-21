namespace TeamProjectIAN6.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingEducationAndOccupation : DbMigration
    {
        public override void Up()
        {
            Sql(@"SET IDENTITY_INSERT [dbo].[Education] ON
                    INSERT [dbo].[Education] ([Id], [Name]) VALUES (1, N'Zn Sxoli')
                    SET IDENTITY_INSERT [dbo].[Education] OFF
                    SET IDENTITY_INSERT [dbo].[Occupation] ON 
                    INSERT [dbo].[Occupation] ([Id], [Name]) VALUES (1, N'Programmer')
                    SET IDENTITY_INSERT [dbo].[Occupation] OFF");
        }
        
        public override void Down()
        {
        }
    }
}
