namespace UniversitySystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TeacherCourseRelationship : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "TeacherId", c => c.Int());
            AlterColumn("dbo.AssignCourseToTeachers", "CourseAssignedCredit", c => c.Single(nullable: false));
            AlterColumn("dbo.AssignCourseToTeachers", "TeachersRemainingCredit", c => c.Single(nullable: false));
            CreateIndex("dbo.Courses", "TeacherId");
            AddForeignKey("dbo.Courses", "TeacherId", "dbo.Teachers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "TeacherId", "dbo.Teachers");
            DropIndex("dbo.Courses", new[] { "TeacherId" });
            AlterColumn("dbo.AssignCourseToTeachers", "TeachersRemainingCredit", c => c.Double(nullable: false));
            AlterColumn("dbo.AssignCourseToTeachers", "CourseAssignedCredit", c => c.Double(nullable: false));
            DropColumn("dbo.Courses", "TeacherId");
        }
    }
}
