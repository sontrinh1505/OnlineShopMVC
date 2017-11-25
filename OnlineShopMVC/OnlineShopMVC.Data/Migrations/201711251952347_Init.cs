namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.About",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Name = c.String(maxLength: 10),
                        MetaTitle = c.String(maxLength: 250),
                        Image = c.String(maxLength: 250),
                        Description = c.String(maxLength: 500),
                        Detail = c.String(storeType: "ntext"),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.String(maxLength: 50),
                        MetaKeywords = c.String(maxLength: 250),
                        MetaDescriptions = c.String(maxLength: 10),
                        Status = c.Boolean(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Name = c.String(maxLength: 250),
                        MetaTilte = c.String(maxLength: 250),
                        ParentID = c.Long(),
                        DisplayOrder = c.Int(),
                        SeoTitle = c.String(maxLength: 250),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.String(maxLength: 50),
                        MetaKeywords = c.String(maxLength: 250),
                        MetaDescriptions = c.String(maxLength: 10),
                        Status = c.Boolean(),
                        ShowOnHome = c.Boolean(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Contact",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Content = c.String(storeType: "ntext"),
                        Status = c.Boolean(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Content",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Name = c.String(maxLength: 10),
                        MetaTitle = c.String(maxLength: 250),
                        Description = c.String(maxLength: 500),
                        Image = c.String(maxLength: 250),
                        CategoryID = c.Long(),
                        Detail = c.String(storeType: "ntext"),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.String(maxLength: 50),
                        MetaKeywords = c.String(maxLength: 250),
                        MetaDescriptions = c.String(maxLength: 10),
                        Status = c.Boolean(),
                        TopHot = c.DateTime(),
                        ViewCount = c.Int(),
                        Tags = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ContentTag",
                c => new
                    {
                        ContentID = c.Long(nullable: false),
                        TagID = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => new { t.ContentID, t.TagID });
            
            CreateTable(
                "dbo.Feedback",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Phone = c.String(maxLength: 50),
                        Email = c.String(maxLength: 50),
                        Content = c.String(maxLength: 500),
                        Address = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(),
                        Status = c.Boolean(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Footer",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 50),
                        Content = c.String(storeType: "ntext"),
                        Status = c.Boolean(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Menu",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Text = c.String(maxLength: 50),
                        Link = c.String(maxLength: 250),
                        DisplayOrde = c.Int(),
                        Target = c.String(maxLength: 50),
                        Status = c.Boolean(),
                        TypeID = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.MenuType",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ProductCategory",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Name = c.String(maxLength: 250),
                        MetaTilte = c.String(maxLength: 250),
                        ParentID = c.Long(nullable: false),
                        DisplayOrder = c.Int(),
                        SeoTitle = c.String(maxLength: 250),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.String(maxLength: 50),
                        MetaKeywords = c.String(maxLength: 250),
                        MetaDescriptions = c.String(maxLength: 10),
                        Status = c.Boolean(),
                        ShowOnHome = c.Boolean(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Name = c.String(maxLength: 10),
                        Code = c.String(maxLength: 50),
                        MetaTitle = c.String(maxLength: 250),
                        Description = c.String(maxLength: 500),
                        Image = c.String(maxLength: 250),
                        MoreImages = c.String(storeType: "xml"),
                        IncludeVAT = c.Boolean(),
                        PromotionPrice = c.Decimal(precision: 18, scale: 2),
                        Price = c.Decimal(precision: 18, scale: 2),
                        Quantity = c.Int(),
                        CategoryID = c.Long(),
                        Detail = c.String(storeType: "ntext"),
                        Waranty = c.Int(),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.String(maxLength: 50),
                        MetaKeywords = c.String(maxLength: 250),
                        MetaDescriptions = c.String(maxLength: 10),
                        Status = c.Boolean(),
                        TopHot = c.DateTime(),
                        ViewCount = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Slide",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Image = c.String(maxLength: 250),
                        DisplayOrder = c.Int(),
                        Link = c.String(maxLength: 250),
                        Description = c.String(maxLength: 500),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.String(maxLength: 50),
                        Status = c.Boolean(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.SystemConfig",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 50),
                        Name = c.String(nullable: false, maxLength: 250),
                        Type = c.String(maxLength: 50),
                        Value = c.String(maxLength: 250),
                        Status = c.Boolean(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Tag",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 50),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        UserName = c.String(maxLength: 50),
                        PassWord = c.String(maxLength: 32),
                        Name = c.String(maxLength: 50),
                        Address = c.String(maxLength: 50),
                        Email = c.String(maxLength: 50),
                        Phone = c.String(maxLength: 50),
                        CreatedDate = c.DateTime(),
                        CreatedBy = c.String(maxLength: 50),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.String(maxLength: 50),
                        Status = c.Boolean(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.User");
            DropTable("dbo.Tag");
            DropTable("dbo.SystemConfig");
            DropTable("dbo.Slide");
            DropTable("dbo.Product");
            DropTable("dbo.ProductCategory");
            DropTable("dbo.MenuType");
            DropTable("dbo.Menu");
            DropTable("dbo.Footer");
            DropTable("dbo.Feedback");
            DropTable("dbo.ContentTag");
            DropTable("dbo.Content");
            DropTable("dbo.Contact");
            DropTable("dbo.Category");
            DropTable("dbo.About");
        }
    }
}
