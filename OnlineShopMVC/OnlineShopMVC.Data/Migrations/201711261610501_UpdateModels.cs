namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateModels : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.About", "CreatedBy", c => c.Long(nullable: false));
            AlterColumn("dbo.About", "ModifiedBy", c => c.Long(nullable: false));
            AlterColumn("dbo.About", "Status", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Category", "CreatedBy", c => c.Long(nullable: false));
            AlterColumn("dbo.Category", "ModifiedBy", c => c.Long(nullable: false));
            AlterColumn("dbo.Category", "Status", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Contact", "Status", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Content", "CreatedBy", c => c.Long(nullable: false));
            AlterColumn("dbo.Content", "ModifiedBy", c => c.Long(nullable: false));
            AlterColumn("dbo.Content", "Status", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Feedback", "Status", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Footer", "Status", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Menu", "Status", c => c.Boolean(nullable: false));
            AlterColumn("dbo.ProductCategory", "CreatedBy", c => c.Long(nullable: false));
            AlterColumn("dbo.ProductCategory", "ModifiedBy", c => c.Long(nullable: false));
            AlterColumn("dbo.ProductCategory", "Status", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Product", "CreatedBy", c => c.Long(nullable: false));
            AlterColumn("dbo.Product", "ModifiedBy", c => c.Long(nullable: false));
            AlterColumn("dbo.Product", "Status", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Slide", "CreatedBy", c => c.Long(nullable: false));
            AlterColumn("dbo.Slide", "ModifiedBy", c => c.Long(nullable: false));
            AlterColumn("dbo.Slide", "Status", c => c.Boolean(nullable: false));
            AlterColumn("dbo.SystemConfig", "Status", c => c.Boolean(nullable: false));
            AlterColumn("dbo.User", "CreatedBy", c => c.Long(nullable: false));
            AlterColumn("dbo.User", "ModifiedBy", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.User", "ModifiedBy", c => c.String(maxLength: 50));
            AlterColumn("dbo.User", "CreatedBy", c => c.String(maxLength: 50));
            AlterColumn("dbo.SystemConfig", "Status", c => c.Boolean());
            AlterColumn("dbo.Slide", "Status", c => c.Boolean());
            AlterColumn("dbo.Slide", "ModifiedBy", c => c.String(maxLength: 50));
            AlterColumn("dbo.Slide", "CreatedBy", c => c.String(maxLength: 50));
            AlterColumn("dbo.Product", "Status", c => c.Boolean());
            AlterColumn("dbo.Product", "ModifiedBy", c => c.String(maxLength: 50));
            AlterColumn("dbo.Product", "CreatedBy", c => c.String(maxLength: 50));
            AlterColumn("dbo.ProductCategory", "Status", c => c.Boolean());
            AlterColumn("dbo.ProductCategory", "ModifiedBy", c => c.String(maxLength: 50));
            AlterColumn("dbo.ProductCategory", "CreatedBy", c => c.String(maxLength: 50));
            AlterColumn("dbo.Menu", "Status", c => c.Boolean());
            AlterColumn("dbo.Footer", "Status", c => c.Boolean());
            AlterColumn("dbo.Feedback", "Status", c => c.Boolean());
            AlterColumn("dbo.Content", "Status", c => c.Boolean());
            AlterColumn("dbo.Content", "ModifiedBy", c => c.String(maxLength: 50));
            AlterColumn("dbo.Content", "CreatedBy", c => c.String(maxLength: 50));
            AlterColumn("dbo.Contact", "Status", c => c.Boolean());
            AlterColumn("dbo.Category", "Status", c => c.Boolean());
            AlterColumn("dbo.Category", "ModifiedBy", c => c.String(maxLength: 50));
            AlterColumn("dbo.Category", "CreatedBy", c => c.String(maxLength: 50));
            AlterColumn("dbo.About", "Status", c => c.Boolean());
            AlterColumn("dbo.About", "ModifiedBy", c => c.String(maxLength: 50));
            AlterColumn("dbo.About", "CreatedBy", c => c.String(maxLength: 50));
        }
    }
}
