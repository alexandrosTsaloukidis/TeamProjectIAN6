namespace TeamProjectIAN6.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingRestaurants : DbMigration
    {
        public override void Up()
        {
            Sql(@"SET IDENTITY_INSERT [dbo].[Restaurant] ON 
                    INSERT [dbo].[Restaurant] ([ID], [Name], [Capacity], [Category], [LocationID], [StreetName], [StreetNumber], [Lattitude], [Longitude], [PostalCode], [IsOpened], [AreaID]) VALUES (5, N'Vasilainas', 456, NULL, 7, NULL, NULL, 10, 10, 1, 1, 3)
                    INSERT [dbo].[Restaurant] ([ID], [Name], [Capacity], [Category], [LocationID], [StreetName], [StreetNumber], [Lattitude], [Longitude], [PostalCode], [IsOpened], [AreaID]) VALUES (6, N'Efharis', 25, NULL, 8, NULL, NULL, 10, 10, 1, 1, 4)
                    INSERT [dbo].[Restaurant] ([ID], [Name], [Capacity], [Category], [LocationID], [StreetName], [StreetNumber], [Lattitude], [Longitude], [PostalCode], [IsOpened], [AreaID]) VALUES (7, N'Just Pita', 7852, NULL, 9, NULL, NULL, 10, 10, 1, 1, 5)
                    INSERT [dbo].[Restaurant] ([ID], [Name], [Capacity], [Category], [LocationID], [StreetName], [StreetNumber], [Lattitude], [Longitude], [PostalCode], [IsOpened], [AreaID]) VALUES (8, N'Julia of Athens', 35, NULL, 10, NULL, NULL, 10, 10, 1, 1, 6)
                    INSERT [dbo].[Restaurant] ([ID], [Name], [Capacity], [Category], [LocationID], [StreetName], [StreetNumber], [Lattitude], [Longitude], [PostalCode], [IsOpened], [AreaID]) VALUES (9, N'Ola stin kolla', 98, NULL, 7, NULL, NULL, 10, 10, 1, 1, 3)
                    SET IDENTITY_INSERT [dbo].[Restaurant] OFF");
        }
        
        public override void Down()
        {
        }
    }
}
