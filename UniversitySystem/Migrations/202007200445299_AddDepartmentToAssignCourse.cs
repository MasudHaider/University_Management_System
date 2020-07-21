namespace UniversitySystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDepartmentToAssignCourse : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AssignCourseToTeachers", "DepartmentId", c => c.Int(nullable: false));
            CreateIndex("dbo.AssignCourseToTeachers", "DepartmentId");
            AddForeignKey("dbo.AssignCourseToTeachers", "DepartmentId", "dbo.Departments", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AssignCourseToTeachers", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.AssignCourseToTeachers", new[] { "DepartmentId" });
            DropColumn("dbo.AssignCourseToTeachers", "DepartmentId");
        }
    }
}
