namespace DocDesckApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Activs",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CabNumber = c.String(nullable: false, maxLength: 50),
                        DepartmentId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .Index(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Documents",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        OrganizationId = c.Guid(),
                        Number = c.String(),
                        Date = c.DateTime(nullable: false),
                        ShortText = c.String(nullable: false, maxLength: 50),
                        Comment = c.String(nullable: false, maxLength: 200),
                        Status = c.Int(nullable: false),
                        Priority = c.Int(nullable: false),
                        ActivId = c.Guid(),
                        File = c.String(),
                        CategoryId = c.Guid(),
                        UserId = c.Guid(),
                        ExecutorID = c.Guid(),
                        LifecycleId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Activs", t => t.ActivId)
                .ForeignKey("dbo.Categories", t => t.CategoryId)
                .ForeignKey("dbo.Users", t => t.ExecutorID)
                .ForeignKey("dbo.Lifecycles", t => t.LifecycleId, cascadeDelete: true)
                .ForeignKey("dbo.Organizations", t => t.OrganizationId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.OrganizationId)
                .Index(t => t.ActivId)
                .Index(t => t.CategoryId)
                .Index(t => t.UserId)
                .Index(t => t.ExecutorID)
                .Index(t => t.LifecycleId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        Login = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 50),
                        Position = c.String(nullable: false, maxLength: 50),
                        DepartmentId = c.Guid(),
                        RoleId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DepartmentId)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.DepartmentId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Lifecycles",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Opened = c.DateTime(nullable: false),
                        Distributed = c.DateTime(),
                        Processing = c.DateTime(),
                        Checking = c.DateTime(),
                        Closed = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Organizations",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        ShortName = c.String(nullable: false, maxLength: 50),
                        FullName = c.String(nullable: false, maxLength: 100),
                        Index = c.String(nullable: false, maxLength: 6),
                        Adress = c.String(nullable: false, maxLength: 150),
                        Telefons = c.String(nullable: false, maxLength: 11),
                        Fax = c.String(nullable: false, maxLength: 11),
                        Email = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Documents", "UserId", "dbo.Users");
            DropForeignKey("dbo.Documents", "OrganizationId", "dbo.Organizations");
            DropForeignKey("dbo.Documents", "LifecycleId", "dbo.Lifecycles");
            DropForeignKey("dbo.Documents", "ExecutorID", "dbo.Users");
            DropForeignKey("dbo.Users", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.Users", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Documents", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Documents", "ActivId", "dbo.Activs");
            DropForeignKey("dbo.Activs", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.Users", new[] { "RoleId" });
            DropIndex("dbo.Users", new[] { "DepartmentId" });
            DropIndex("dbo.Documents", new[] { "LifecycleId" });
            DropIndex("dbo.Documents", new[] { "ExecutorID" });
            DropIndex("dbo.Documents", new[] { "UserId" });
            DropIndex("dbo.Documents", new[] { "CategoryId" });
            DropIndex("dbo.Documents", new[] { "ActivId" });
            DropIndex("dbo.Documents", new[] { "OrganizationId" });
            DropIndex("dbo.Activs", new[] { "DepartmentId" });
            DropTable("dbo.Organizations");
            DropTable("dbo.Lifecycles");
            DropTable("dbo.Roles");
            DropTable("dbo.Users");
            DropTable("dbo.Documents");
            DropTable("dbo.Categories");
            DropTable("dbo.Departments");
            DropTable("dbo.Activs");
        }
    }
}
