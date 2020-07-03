namespace UniversitySystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSemesterEnumToCourse : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "SemesterId", c => c.Int(nullable: false));
            DropColumn("dbo.Courses", "Semesters");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Courses", "Semesters", c => c.Int(nullable: false));
            DropColumn("dbo.Courses", "SemesterId");
        }
    }
}
