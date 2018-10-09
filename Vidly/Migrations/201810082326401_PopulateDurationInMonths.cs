namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateDurationInMonths : DbMigration
    {
        public override void Up()
        {
            Sql("update MembershipTypes set DurationInMonths = 0 where id = 1");
            Sql("update MembershipTypes set DurationInMonths = 1 where id = 2");
            Sql("update MembershipTypes set DurationInMonths = 4 where id = 3");
            Sql("update MembershipTypes set DurationInMonths = 12 where id = 4");
        }
        
        public override void Down()
        {
        }
    }
}
