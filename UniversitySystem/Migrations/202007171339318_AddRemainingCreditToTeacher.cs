namespace UniversitySystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRemainingCreditToTeacher : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Teachers", "RemainingCredits", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Teachers", "RemainingCredits");
        }
    }
}
