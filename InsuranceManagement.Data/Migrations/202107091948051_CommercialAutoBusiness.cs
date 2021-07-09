namespace InsuranceManagement.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CommercialAutoBusiness : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Business",
                c => new
                    {
                        BusinessID = c.Int(nullable: false, identity: true),
                        NameBusiness = c.String(),
                        LegalNameBusiness = c.String(),
                        BusinessMailingAddress = c.String(),
                        BusinessCity = c.String(),
                        BusinessState = c.String(),
                        BusinessZipCode = c.Int(nullable: false),
                        YearBusinessStarted = c.Int(nullable: false),
                        ServicesProvided = c.String(),
                    })
                .PrimaryKey(t => t.BusinessID);
            
            AddColumn("dbo.Auto", "CommercialAutoID", c => c.Int());
            AddColumn("dbo.Auto", "NumberInFleet", c => c.Int());
            AddColumn("dbo.Auto", "NumberOfDrivers", c => c.Int());
            AddColumn("dbo.Auto", "DOTNumber", c => c.Int());
            AddColumn("dbo.Auto", "RadiusOfOperation", c => c.Int());
            AddColumn("dbo.Auto", "CompDeductible", c => c.Int());
            AddColumn("dbo.Auto", "CollisionDeductible", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Auto", "CollisionDeductible");
            DropColumn("dbo.Auto", "CompDeductible");
            DropColumn("dbo.Auto", "RadiusOfOperation");
            DropColumn("dbo.Auto", "DOTNumber");
            DropColumn("dbo.Auto", "NumberOfDrivers");
            DropColumn("dbo.Auto", "NumberInFleet");
            DropColumn("dbo.Auto", "CommercialAutoID");
            DropTable("dbo.Business");
        }
    }
}
