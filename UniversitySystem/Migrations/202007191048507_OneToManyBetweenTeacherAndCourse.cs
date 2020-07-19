namespace UniversitySystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OneToManyBetweenTeacherAndCourse : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AssignCourseToTeachers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TeacherId = c.Int(nullable: false),
                        CourseAssignedCredit = c.Single(nullable: false),
                        TeachersRemainingCredit = c.Single(nullable: false),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Teachers", t => t.TeacherId, cascadeDelete: true)
                .Index(t => t.TeacherId)
                .Index(t => t.CourseId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AssignCourseToTeachers", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.AssignCourseToTeachers", "CourseId", "dbo.Courses");
            DropIndex("dbo.AssignCourseToTeachers", new[] { "CourseId" });
            DropIndex("dbo.AssignCourseToTeachers", new[] { "TeacherId" });
            DropTable("dbo.AssignCourseToTeachers");
        }
    }
}
