namespace UniversitySystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNullableCourseAndTeacherIdToDepartment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Departments", "CourseId", c => c.Int());
            AddColumn("dbo.Departments", "TeacherId", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Departments", "TeacherId");
            DropColumn("dbo.Departments", "CourseId");
        }
    }
}
