namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populateMovies : DbMigration
    {
        public override void Up()
        {
            Sql("insert into Movies (Name, ReleaseDate, DateAdded, NumberInStock, GenreId) values ('Red', '2001-02-12', '2018-10-09', 5, 2)");
            Sql("insert into Movies (Name, ReleaseDate, DateAdded, NumberInStock, GenreId) values ('Lord of the rings', '2004-06-22 00:00:00', '2017-09-01 00:00:00', 9, 2)");
            Sql("insert into Movies (Name, ReleaseDate, DateAdded, NumberInStock, GenreId) values ('Home alone', '1998-06-03 00:00:00', '2000-01-24 00:00:00', 0, 1)");
            Sql("insert into Movies (Name, ReleaseDate, DateAdded, NumberInStock, GenreId) values ('The mask', '2005-12-11 00:00:00', '2006-09-15 00:00:00', 1, 1)");
            Sql("insert into Movies (Name, ReleaseDate, DateAdded, NumberInStock, GenreId) values ('Fafty shades of gray', '2015-07-22 00:00:00', '2015-08-01 00:00:00', 7, 3)");
            Sql("insert into Movies (Name, ReleaseDate, DateAdded, NumberInStock, GenreId) values ('Saw', '2010-01-02 00:00:00', '2015-08-01 00:00:00', 20, 3)");

        }

        public override void Down()
        {
        }
    }
}
