namespace DocDesckApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AllowEmpty_Comment_and_File : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Documents", "File", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Documents", "File", c => c.String());
        }
    }
}
