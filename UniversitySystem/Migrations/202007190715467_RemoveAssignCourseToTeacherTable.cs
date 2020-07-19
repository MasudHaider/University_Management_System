namespace UniversitySystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveAssignCourseToTeacherTable : DbMigration
    {
        public override void Up()
        {
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
            
        }
    }
}
