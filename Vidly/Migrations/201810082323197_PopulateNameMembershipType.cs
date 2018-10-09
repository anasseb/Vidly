namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateNameMembershipType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MembershipTypes", "Name", c => c.String(maxLength: 255));
            Sql("update MembershipTypes set Name = 'Pay As You Go' where id = 1");
            Sql("update MembershipTypes set Name = 'Monthly' where id = 2");
            Sql("update MembershipTypes set Name = 'Quarterly ' where id = 3");
            Sql("update MembershipTypes set Name = 'Annually' where id = 4");
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MembershipTypes", "Name", c => c.String());
        }
    }
}
