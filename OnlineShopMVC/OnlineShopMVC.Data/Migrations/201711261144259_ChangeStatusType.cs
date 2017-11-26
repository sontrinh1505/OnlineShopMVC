namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeStatusType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.User", "Status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.User", "Status", c => c.Boolean());
        }
    }
}
