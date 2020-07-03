namespace UniversitySystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DepartmentCourseOneToManyRelationship : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Courses", "DepartmentId", "dbo.Departments");
            AddForeignKey("dbo.Courses", "DepartmentId", "dbo.Departments", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "DepartmentId", "dbo.Departments");
            AddForeignKey("dbo.Courses", "DepartmentId", "dbo.Departments", "Id", cascadeDelete: true);
        }
    }
}
