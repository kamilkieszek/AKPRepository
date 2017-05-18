namespace AKP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeid : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Person", "HolidayId");
            DropColumn("dbo.Person", "SalaryId");
            DropColumn("dbo.Person", "MessageId");
            DropColumn("dbo.Person", "AdId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Person", "AdId", c => c.Int(nullable: false));
            AddColumn("dbo.Person", "MessageId", c => c.Int(nullable: false));
            AddColumn("dbo.Person", "SalaryId", c => c.Int(nullable: false));
            AddColumn("dbo.Person", "HolidayId", c => c.Int(nullable: false));
        }
    }
}
