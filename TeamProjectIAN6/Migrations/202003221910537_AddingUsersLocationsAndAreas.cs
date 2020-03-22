namespace TeamProjectIAN6.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingUsersLocationsAndAreas : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                    INSERT [dbo].[AspNetUsers] ([Id], [Firstname], [Lastname], [DateOfBirth], [Gender], [Email], [UserName], [EmailConfirmed], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnabled], [AccessFailedCount]) VALUES (N'id_1', N'Alexandros', N'Mark', CAST(N'2000-10-11T00:00:00.000' AS DateTime), 0, N'ioanna@ioanna.com', N'ioanna@ioanna.com', 1, 0, 0, 0, 0)
                    INSERT [dbo].[AspNetUsers] ([Id], [Firstname], [Lastname], [DateOfBirth], [Gender], [Email], [UserName], [EmailConfirmed], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnabled], [AccessFailedCount]) VALUES (N'id_2', N'Ioanna', N'Papadopoulou', CAST(N'1999-05-06T00:00:00.000' AS DateTime), 2, N'nikos@nikos.com', N'nikos@nikos.com',  1, 0, 0, 0, 0)
                    INSERT [dbo].[AspNetUsers] ([Id], [Firstname], [Lastname], [DateOfBirth], [Gender], [Email], [UserName], [EmailConfirmed], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnabled], [AccessFailedCount]) VALUES (N'id_3', N'Nikos', N'Lukos', CAST(N'1995-03-02T00:00:00.000' AS DateTime), 1, N'nikos@gmail.com', N'nikos@gmail.com', 1, 0, 0, 0, 0)
                    INSERT [dbo].[AspNetUsers] ([Id], [Firstname], [Lastname], [DateOfBirth], [Gender], [Email], [UserName], [EmailConfirmed], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnabled], [AccessFailedCount]) VALUES (N'id_4', N'Pakos', N'Sakos', CAST(N'1998-08-08T00:00:00.000' AS DateTime), 3, N'alex@alex.com',  N'alex@alex.com', 1, 0, 0, 0, 0)
                    INSERT [dbo].[AspNetUsers] ([Id], [Firstname], [Lastname], [DateOfBirth], [Gender], [Email], [UserName], [EmailConfirmed], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnabled], [AccessFailedCount]) VALUES (N'id_5', N'Giorgos', N'Georgiou', CAST(N'1956-05-06T00:00:00.000' AS DateTime), 2, N'alex@gmail.com',N'alex@gmail.com', 1, 0, 0, 0, 0)
                    INSERT [dbo].[AspNetUsers] ([Id], [Firstname], [Lastname], [DateOfBirth], [Gender], [Email], [UserName], [EmailConfirmed], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnabled], [AccessFailedCount]) VALUES (N'id_6', N'Stamatina', N'Stamatiou', CAST(N'2000-06-09T00:00:00.000' AS DateTime), 1, N'ioanna@yahoo.com', N'ioanna@yahoo.com', 1, 0, 0, 0, 0)
                    INSERT [dbo].[AspNetUsers] ([Id], [Firstname], [Lastname], [DateOfBirth], [Gender], [Email], [UserName], [EmailConfirmed], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnabled], [AccessFailedCount]) VALUES (N'id_7', N'Antonis', N'Papageorgiou', CAST(N'1980-05-03T00:00:00.000' AS DateTime), 2, N'nikos@yahoo.com', N'nikos@yahoo.com', 1, 0, 0, 0, 0)
                    ");


            Sql("Insert into LOCATION (NOMOS) VALUES ('ATTIKI')");
            Sql("Insert into LOCATION (NOMOS) VALUES ('THESSALONIKI')");
            Sql("Insert into LOCATION (NOMOS) VALUES ('PATRA')");
            Sql("Insert into LOCATION (NOMOS) VALUES ('HRAKLEIO')");

            Sql("Insert into AREA (NAME) VALUES ('ATHENS')");
            Sql("Insert into AREA (NAME) VALUES ('GlYFADA')");
            Sql("Insert into AREA (NAME) VALUES ('GAZI')");
            Sql("Insert into AREA (NAME) VALUES ('PETRALONA')");

        }
        


        public override void Down()
        {
        }
    }
}
