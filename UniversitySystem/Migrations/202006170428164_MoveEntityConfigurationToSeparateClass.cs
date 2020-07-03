namespace UniversitySystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MoveEntityConfigurationToSeparateClass : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Departments", "DepartmentCode", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Departments", "DepartmentName", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Departments", "DepartmentName", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Departments", "DepartmentCode", c => c.String(nullable: false, maxLength: 255));
        }
    }
}
