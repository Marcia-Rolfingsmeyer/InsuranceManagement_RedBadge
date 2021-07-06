namespace InsuranceManagement.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedProperty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Client", "ModifiedUtc", c => c.DateTimeOffset(precision: 7));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Client", "ModifiedUtc");
        }
    }
}
