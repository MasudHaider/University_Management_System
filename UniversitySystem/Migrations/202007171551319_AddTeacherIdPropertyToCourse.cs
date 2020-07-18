namespace UniversitySystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTeacherIdPropertyToCourse : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "TeacherId", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Courses", "TeacherId");
        }
    }
}
