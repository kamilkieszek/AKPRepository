namespace AKP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class salaryedit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Salary", "TotalLoan", c => c.Double(nullable: false));
            AlterColumn("dbo.Salary", "Rate", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Salary", "Rate", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Salary", "TotalLoan");
        }
    }
}
