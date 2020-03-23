namespace TeamProjectIAN6.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingVisits : DbMigration
    {
        public override void Up()
        {
            Sql(@"SET IDENTITY_INSERT [dbo].[Visit] ON 
                    INSERT [dbo].[Visit] ([ID], [ApplicationUserId], [RestaurantId], [ArrivalDateTime], [DepartureDateTime]) VALUES (1, N'id_1', 5, NULL, NULL)
                    INSERT [dbo].[Visit] ([ID], [ApplicationUserId], [RestaurantId], [ArrivalDateTime], [DepartureDateTime]) VALUES (2, N'id_2', 6, NULL, NULL)
                    INSERT [dbo].[Visit] ([ID], [ApplicationUserId], [RestaurantId], [ArrivalDateTime], [DepartureDateTime]) VALUES (3, N'id_3', 7, NULL, NULL)
                    INSERT [dbo].[Visit] ([ID], [ApplicationUserId], [RestaurantId], [ArrivalDateTime], [DepartureDateTime]) VALUES (4, N'id_4', 8, NULL, NULL)
                    INSERT [dbo].[Visit] ([ID], [ApplicationUserId], [RestaurantId], [ArrivalDateTime], [DepartureDateTime]) VALUES (5, N'id_5', 9, NULL, NULL)
                    INSERT [dbo].[Visit] ([ID], [ApplicationUserId], [RestaurantId], [ArrivalDateTime], [DepartureDateTime]) VALUES (6, N'id_6', 5, NULL, NULL)
                    INSERT [dbo].[Visit] ([ID], [ApplicationUserId], [RestaurantId], [ArrivalDateTime], [DepartureDateTime]) VALUES (7, N'id_7', 6, NULL, NULL)
                    INSERT [dbo].[Visit] ([ID], [ApplicationUserId], [RestaurantId], [ArrivalDateTime], [DepartureDateTime]) VALUES (8, N'id_1', 7, NULL, NULL)
                    INSERT [dbo].[Visit] ([ID], [ApplicationUserId], [RestaurantId], [ArrivalDateTime], [DepartureDateTime]) VALUES (9, N'id_2', 8, NULL, NULL)
                    INSERT [dbo].[Visit] ([ID], [ApplicationUserId], [RestaurantId], [ArrivalDateTime], [DepartureDateTime]) VALUES (10, N'id_3', 9, NULL, NULL)
                    INSERT [dbo].[Visit] ([ID], [ApplicationUserId], [RestaurantId], [ArrivalDateTime], [DepartureDateTime]) VALUES (11, N'id_4', 5, NULL, NULL)
                    INSERT [dbo].[Visit] ([ID], [ApplicationUserId], [RestaurantId], [ArrivalDateTime], [DepartureDateTime]) VALUES (12, N'id_5', 6, NULL, NULL)
                    INSERT [dbo].[Visit] ([ID], [ApplicationUserId], [RestaurantId], [ArrivalDateTime], [DepartureDateTime]) VALUES (13, N'id_6', 7, NULL, NULL)
                    INSERT [dbo].[Visit] ([ID], [ApplicationUserId], [RestaurantId], [ArrivalDateTime], [DepartureDateTime]) VALUES (14, N'id_7', 8, NULL, NULL)
                    SET IDENTITY_INSERT [dbo].[Visit] OFF");
        }
        
        public override void Down()
        {
        }
    }
}
