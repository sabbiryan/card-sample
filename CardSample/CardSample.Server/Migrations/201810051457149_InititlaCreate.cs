namespace CardSample.Server.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InititlaCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Department",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        DepartmentName = c.String(),
                        Location = c.String(),
                        DepartmentHead = c.String(),
                        CreationTime = c.DateTime(),
                        ModificationTime = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletionTime = c.DateTime(),
                        CratedBy = c.String(),
                        ModifiedBy = c.String(),
                        DeletedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Id, unique: true);
            
            CreateTable(
                "dbo.Employee",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Gender = c.Int(nullable: false),
                        Salary = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DepartmentId = c.String(maxLength: 128),
                        CreationTime = c.DateTime(),
                        ModificationTime = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletionTime = c.DateTime(),
                        CratedBy = c.String(),
                        ModifiedBy = c.String(),
                        DeletedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Department", t => t.DepartmentId)
                .Index(t => t.Id, unique: true)
                .Index(t => t.DepartmentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employee", "DepartmentId", "dbo.Department");
            DropIndex("dbo.Employee", new[] { "DepartmentId" });
            DropIndex("dbo.Employee", new[] { "Id" });
            DropIndex("dbo.Department", new[] { "Id" });
            DropTable("dbo.Employee");
            DropTable("dbo.Department");
        }
    }
}
