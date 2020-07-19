namespace UniversitySystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCollectionOfCoursesToTeacher : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Courses", "TeacherId");
            AddForeignKey("dbo.Courses", "TeacherId", "dbo.Teachers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "TeacherId", "dbo.Teachers");
            DropIndex("dbo.Courses", new[] { "TeacherId" });
        }
    }
}
