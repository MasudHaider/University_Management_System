namespace UniversitySystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeCourseAssignmentPropertiesToFloat : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AssignCourseToTeachers", "CourseAssignedCredit", c => c.Double(nullable: false));
            AlterColumn("dbo.AssignCourseToTeachers", "TeachersRemainingCredit", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AssignCourseToTeachers", "TeachersRemainingCredit", c => c.Single(nullable: false));
            AlterColumn("dbo.AssignCourseToTeachers", "CourseAssignedCredit", c => c.Single(nullable: false));
        }
    }
}
