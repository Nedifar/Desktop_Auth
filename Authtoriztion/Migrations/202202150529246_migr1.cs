namespace Authtoriztion.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migr1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        idEmployee = c.Int(nullable: false, identity: true),
                        login = c.String(),
                        pwd = c.String(),
                        idEmployeeType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idEmployee)
                .ForeignKey("dbo.EmployeeTypes", t => t.idEmployeeType, cascadeDelete: true)
                .Index(t => t.idEmployeeType);
            
            CreateTable(
                "dbo.EmployeeTypes",
                c => new
                    {
                        idEmployeeType = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.idEmployeeType);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "idEmployeeType", "dbo.EmployeeTypes");
            DropIndex("dbo.Employees", new[] { "idEmployeeType" });
            DropTable("dbo.EmployeeTypes");
            DropTable("dbo.Employees");
        }
    }
}
