namespace UniversitySystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveCourseIdAndTeacherIdFromDepartmentTable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Departments", "CourseId");
            DropColumn("dbo.Departments", "TeacherId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Departments", "TeacherId", c => c.Int());
            AddColumn("dbo.Departments", "CourseId", c => c.Int());
        }
    }
}
