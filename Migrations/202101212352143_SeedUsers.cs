namespace Course.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'15858e86-e6f0-4b5d-a160-f99e74344d87', N'visitor@email.com', 0, N'AM5SwoAnp1YnGssio3dLUeOttaYubzDOdo5fRvM3SQv2DzHqkdElw9aOdGnMwizW7Q==', N'b07648b7-df68-4754-a463-13431e39c5e8', NULL, 0, 0, NULL, 1, 0, N'visitor@email.com') " +
                "INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES(N'ce63b1ca-49f2-4fb6-a061-fe69fe87f870', N'admin@email.com', 0, N'AJJyDanX5xNUT/5fl+CQYmlUmj376C/pk5c2RjyxcHE1aWcfQO/2nrXYm7Kmj9Bb3w==', N'42d95d7a-ee8b-4110-a9d8-cd74ae89a2c1', NULL, 0, 0, NULL, 1, 0, N'admin@email.com')");

            Sql("INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'50bee068-64d0-4243-9e61-70c577780708', N'CanManagerMovies')");
            Sql("INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'ce63b1ca-49f2-4fb6-a061-fe69fe87f870', N'50bee068-64d0-4243-9e61-70c577780708')");
        }
        
        public override void Down()
        {
        }
    }
}
