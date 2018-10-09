namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BirthdayNullabal : DbMigration
    {
        public override void Up()
        {
            //AlterColumn("dbo.Customers", "BirthDay", c => c.DateTime());
            Sql("alter table Customers add Birthday datetime");
        }
        
        public override void Down()
        {
            //AlterColumn("dbo.Customers", "BirthDay", c => c.DateTime(nullable: false));
        }
    }
}
