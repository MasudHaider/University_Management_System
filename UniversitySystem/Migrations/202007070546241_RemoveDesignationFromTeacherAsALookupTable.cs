namespace UniversitySystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveDesignationFromTeacherAsALookupTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Teachers", "DesignationId", "dbo.Designations");
            DropIndex("dbo.Teachers", new[] { "DesignationId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Teachers", "DesignationId");
            AddForeignKey("dbo.Teachers", "DesignationId", "dbo.Designations", "Id", cascadeDelete: true);
        }
    }
}
