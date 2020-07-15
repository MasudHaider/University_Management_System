namespace UniversitySystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ConfigurePropertyAndRelationshipOfTeacherTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Teachers", "DepartmentId", "dbo.Departments");
            AlterColumn("dbo.Teachers", "TeacherName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Teachers", "TeacherAddress", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Teachers", "TeacherEmail", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Teachers", "TeacherContactNumber", c => c.String(nullable: false, maxLength: 15));
            AddForeignKey("dbo.Teachers", "DepartmentId", "dbo.Departments", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Teachers", "DepartmentId", "dbo.Departments");
            AlterColumn("dbo.Teachers", "TeacherContactNumber", c => c.String());
            AlterColumn("dbo.Teachers", "TeacherEmail", c => c.String());
            AlterColumn("dbo.Teachers", "TeacherAddress", c => c.String());
            AlterColumn("dbo.Teachers", "TeacherName", c => c.String());
            AddForeignKey("dbo.Teachers", "DepartmentId", "dbo.Departments", "Id", cascadeDelete: true);
        }
    }
}
