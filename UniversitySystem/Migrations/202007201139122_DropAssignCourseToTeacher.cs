namespace UniversitySystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DropAssignCourseToTeacher : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AssignCourseToTeachers", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.AssignCourseToTeachers", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.AssignCourseToTeachers", "TeacherId", "dbo.Teachers");
            DropIndex("dbo.AssignCourseToTeachers", new[] { "DepartmentId" });
            DropIndex("dbo.AssignCourseToTeachers", new[] { "TeacherId" });
            DropIndex("dbo.AssignCourseToTeachers", new[] { "CourseId" });
            DropTable("dbo.AssignCourseToTeachers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.AssignCourseToTeachers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DepartmentId = c.Int(nullable: false),
                        TeacherId = c.Int(nullable: false),
                        CourseAssignedCredit = c.Single(nullable: false),
                        TeachersRemainingCredit = c.Single(nullable: false),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.AssignCourseToTeachers", "CourseId");
            CreateIndex("dbo.AssignCourseToTeachers", "TeacherId");
            CreateIndex("dbo.AssignCourseToTeachers", "DepartmentId");
            AddForeignKey("dbo.AssignCourseToTeachers", "TeacherId", "dbo.Teachers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AssignCourseToTeachers", "DepartmentId", "dbo.Departments", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AssignCourseToTeachers", "CourseId", "dbo.Courses", "Id", cascadeDelete: true);
        }
    }
}
