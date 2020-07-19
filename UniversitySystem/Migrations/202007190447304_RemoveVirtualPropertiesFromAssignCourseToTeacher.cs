namespace UniversitySystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveVirtualPropertiesFromAssignCourseToTeacher : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AssignCourseToTeachers", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.AssignCourseToTeachers", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.AssignCourseToTeachers", "TeacherId", "dbo.Teachers");
            DropIndex("dbo.AssignCourseToTeachers", new[] { "DepartmentId" });
            DropIndex("dbo.AssignCourseToTeachers", new[] { "TeacherId" });
            DropIndex("dbo.AssignCourseToTeachers", new[] { "CourseId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.AssignCourseToTeachers", "CourseId");
            CreateIndex("dbo.AssignCourseToTeachers", "TeacherId");
            CreateIndex("dbo.AssignCourseToTeachers", "DepartmentId");
            AddForeignKey("dbo.AssignCourseToTeachers", "TeacherId", "dbo.Teachers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AssignCourseToTeachers", "DepartmentId", "dbo.Departments", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AssignCourseToTeachers", "CourseId", "dbo.Courses", "Id", cascadeDelete: true);
        }
    }
}
