namespace InsuranceManagement.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PropertyToString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Auto", "VINNumber", c => c.String());
            AlterColumn("dbo.Auto", "PolicyNumber", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Auto", "PolicyNumber", c => c.Int(nullable: false));
            AlterColumn("dbo.Auto", "VINNumber", c => c.Int(nullable: false));
        }
    }
}
