namespace UniversitySystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeTeacherCreditToFloat : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Teachers", "TeacherCredits", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Teachers", "TeacherCredits", c => c.Single(nullable: false));
        }
    }
}
