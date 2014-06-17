namespace FilesAndFolders.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedFolderList : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Folders", "Folder_FolderId", c => c.Int());
            CreateIndex("dbo.Folders", "Folder_FolderId");
            AddForeignKey("dbo.Folders", "Folder_FolderId", "dbo.Folders", "FolderId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Folders", "Folder_FolderId", "dbo.Folders");
            DropIndex("dbo.Folders", new[] { "Folder_FolderId" });
            DropColumn("dbo.Folders", "Folder_FolderId");
        }
    }
}
