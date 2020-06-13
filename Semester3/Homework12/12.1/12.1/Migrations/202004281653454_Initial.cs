namespace _12._1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AssemblyInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TestInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Result = c.String(),
                        IgnoreReason = c.String(),
                        Time = c.Long(nullable: false),
                        AssemblyInfo_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AssemblyInfoes", t => t.AssemblyInfo_Id)
                .Index(t => t.AssemblyInfo_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TestInfoes", "AssemblyInfo_Id", "dbo.AssemblyInfoes");
            DropIndex("dbo.TestInfoes", new[] { "AssemblyInfo_Id" });
            DropTable("dbo.TestInfoes");
            DropTable("dbo.AssemblyInfoes");
        }
    }
}
