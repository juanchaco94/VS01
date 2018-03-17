namespace VS01.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class documentTypeRelation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.people", "documentType_IdDocumentType", "dbo.documentTypes");
            DropIndex("dbo.people", new[] { "documentType_IdDocumentType" });
            RenameColumn(table: "dbo.people", name: "documentType_IdDocumentType", newName: "IdDocumentType");
            AlterColumn("dbo.people", "IdDocumentType", c => c.Int(nullable: false));
            CreateIndex("dbo.people", "IdDocumentType");
            AddForeignKey("dbo.people", "IdDocumentType", "dbo.documentTypes", "IdDocumentType", cascadeDelete: true);
            DropColumn("dbo.people", "IdDocumetType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.people", "IdDocumetType", c => c.Int(nullable: false));
            DropForeignKey("dbo.people", "IdDocumentType", "dbo.documentTypes");
            DropIndex("dbo.people", new[] { "IdDocumentType" });
            AlterColumn("dbo.people", "IdDocumentType", c => c.Int());
            RenameColumn(table: "dbo.people", name: "IdDocumentType", newName: "documentType_IdDocumentType");
            CreateIndex("dbo.people", "documentType_IdDocumentType");
            AddForeignKey("dbo.people", "documentType_IdDocumentType", "dbo.documentTypes", "IdDocumentType");
        }
    }
}
