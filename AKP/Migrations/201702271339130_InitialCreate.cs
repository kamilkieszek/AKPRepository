namespace AKP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ad",
                c => new
                    {
                        AdId = c.Int(nullable: false, identity: true),
                        PersonId = c.Int(nullable: false),
                        Content = c.String(),
                        AddTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.AdId)
                .ForeignKey("dbo.Person", t => t.PersonId, cascadeDelete: true)
                .Index(t => t.PersonId);
            
            CreateTable(
                "dbo.Person",
                c => new
                    {
                        PersonId = c.Int(nullable: false, identity: true),
                        HolidayId = c.Int(nullable: false),
                        SalaryId = c.Int(nullable: false),
                        MessageId = c.Int(nullable: false),
                        AdId = c.Int(nullable: false),
                        Admin = c.Boolean(nullable: false),
                        Name = c.String(nullable: false),
                        Surname = c.String(nullable: false),
                        IndividualNumber = c.Int(nullable: false),
                        City = c.String(nullable: false),
                        Street = c.String(nullable: false),
                        StreetNr = c.Int(nullable: false),
                        PostalCode = c.String(nullable: false),
                        TelNumber = c.Int(nullable: false),
                        Appointment = c.String(nullable: false),
                        Sex = c.String(nullable: false),
                        DateOfEmployment = c.DateTime(nullable: false),
                        IncomeGroup = c.Int(nullable: false),
                        Education = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.PersonId);
            
            CreateTable(
                "dbo.Holiday",
                c => new
                    {
                        HolidayId = c.Int(nullable: false, identity: true),
                        PersonId = c.Int(nullable: false),
                        NrOfDays = c.Int(nullable: false),
                        DaysToUse = c.Int(nullable: false),
                        DaysSpend = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.HolidayId)
                .ForeignKey("dbo.Person", t => t.PersonId, cascadeDelete: true)
                .Index(t => t.PersonId);
            
            CreateTable(
                "dbo.Message",
                c => new
                    {
                        MessageId = c.Int(nullable: false, identity: true),
                        AddresseeId = c.Int(nullable: false),
                        ReceiverId = c.Int(nullable: false),
                        Added = c.DateTime(nullable: false),
                        Content = c.String(),
                        Person_PersonId = c.Int(),
                    })
                .PrimaryKey(t => t.MessageId)
                .ForeignKey("dbo.Person", t => t.Person_PersonId)
                .Index(t => t.Person_PersonId);
            
            CreateTable(
                "dbo.Salary",
                c => new
                    {
                        SalaryId = c.Int(nullable: false, identity: true),
                        PersonId = c.Int(nullable: false),
                        HoursWorked = c.Int(nullable: false),
                        Rate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Month = c.String(),
                        Year = c.String(),
                    })
                .PrimaryKey(t => t.SalaryId)
                .ForeignKey("dbo.Person", t => t.PersonId, cascadeDelete: true)
                .Index(t => t.PersonId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Salary", "PersonId", "dbo.Person");
            DropForeignKey("dbo.Message", "Person_PersonId", "dbo.Person");
            DropForeignKey("dbo.Holiday", "PersonId", "dbo.Person");
            DropForeignKey("dbo.Ad", "PersonId", "dbo.Person");
            DropIndex("dbo.Salary", new[] { "PersonId" });
            DropIndex("dbo.Message", new[] { "Person_PersonId" });
            DropIndex("dbo.Holiday", new[] { "PersonId" });
            DropIndex("dbo.Ad", new[] { "PersonId" });
            DropTable("dbo.Salary");
            DropTable("dbo.Message");
            DropTable("dbo.Holiday");
            DropTable("dbo.Person");
            DropTable("dbo.Ad");
        }
    }
}
