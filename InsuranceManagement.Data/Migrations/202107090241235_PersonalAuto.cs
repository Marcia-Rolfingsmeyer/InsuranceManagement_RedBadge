namespace InsuranceManagement.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PersonalAuto : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Auto", "PersonalAutoID", c => c.Int());
            AddColumn("dbo.Auto", "IsFullCoverage", c => c.Boolean());
            AddColumn("dbo.Auto", "IsLiability", c => c.Boolean());
            AddColumn("dbo.Auto", "IsUninsuredMotorist", c => c.Boolean());
            AddColumn("dbo.Auto", "IsCarRental", c => c.Boolean());
            AddColumn("dbo.Auto", "IsMedicalCoverage", c => c.Boolean());
            AddColumn("dbo.Auto", "Discriminator", c => c.String(nullable: false, maxLength: 128));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Auto", "Discriminator");
            DropColumn("dbo.Auto", "IsMedicalCoverage");
            DropColumn("dbo.Auto", "IsCarRental");
            DropColumn("dbo.Auto", "IsUninsuredMotorist");
            DropColumn("dbo.Auto", "IsLiability");
            DropColumn("dbo.Auto", "IsFullCoverage");
            DropColumn("dbo.Auto", "PersonalAutoID");
        }
    }
}
