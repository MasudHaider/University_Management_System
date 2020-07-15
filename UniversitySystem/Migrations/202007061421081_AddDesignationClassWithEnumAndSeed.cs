namespace UniversitySystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDesignationClassWithEnumAndSeed : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Designations",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        DesignationName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Teachers", "DesignationId", c => c.Int(nullable: false));
            CreateIndex("dbo.Teachers", "DesignationId");
            AddForeignKey("dbo.Teachers", "DesignationId", "dbo.Designations", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Teachers", "DesignationId", "dbo.Designations");
            DropIndex("dbo.Teachers", new[] { "DesignationId" });
            DropColumn("dbo.Teachers", "DesignationId");
            DropTable("dbo.Designations");
        }
    }
}