namespace UniversitySystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRemainingCreditPropertyToTeacher : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Teachers", "RemainingCredit", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Teachers", "RemainingCredit");
        }
    }
}
