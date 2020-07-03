namespace UniversitySystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDepartmentAndSemesterToCourse : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "DepartmentId", c => c.Int(nullable: false));
            AddColumn("dbo.Courses", "Semesters", c => c.Int(nullable: false));
            CreateIndex("dbo.Courses", "DepartmentId");
            AddForeignKey("dbo.Courses", "DepartmentId", "dbo.Departments", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.Courses", new[] { "DepartmentId" });
            DropColumn("dbo.Courses", "Semesters");
            DropColumn("dbo.Courses", "DepartmentId");
        }
    }
}
