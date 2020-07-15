namespace UniversitySystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveDesignationTable : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Designations");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Designations",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        DesignationName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
