namespace Course.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class InsertGenres : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Name) VALUES ('Action')");
            Sql("INSERT INTO Genres (Name) VALUES ('Comedy')");
            Sql("INSERT INTO Genres (Name) VALUES ('Romance')");
            Sql("INSERT INTO Genres (Name) VALUES ('Family')");
        }

        public override void Down()
        {
        }
    }
}
