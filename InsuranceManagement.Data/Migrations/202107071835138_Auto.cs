namespace InsuranceManagement.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Auto : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Auto",
                c => new
                    {
                        AutoID = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        Make = c.String(),
                        CarModel = c.String(),
                        Year = c.Int(nullable: false),
                        Mileage = c.Int(nullable: false),
                        VINNumber = c.Int(nullable: false),
                        CurrentCarrier = c.String(),
                        CurrentDeductible = c.Int(nullable: false),
                        PolicyNumber = c.Int(nullable: false),
                        PolicyStartDate = c.DateTimeOffset(precision: 7),
                        PolicyEndDate = c.DateTimeOffset(precision: 7),
                        LiabilityLimit = c.Int(nullable: false),
                        LossesLastFiveYears = c.Boolean(nullable: false),
                        YearOfLoss = c.Int(nullable: false),
                        ClaimsLastFiveYears = c.Boolean(nullable: false),
                        AmountOfClaim = c.Int(nullable: false),
                        YearOfClaim = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AutoID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Auto");
        }
    }
}
