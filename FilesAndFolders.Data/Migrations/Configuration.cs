namespace FilesAndFolders.Data.Migrations
{
    using FilesAndFolders.Data.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<FilesAndFolders.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(FilesAndFolders.Data.ApplicationDbContext db)
        {
            db.Folders.AddOrUpdate(
            o => o.FolderId,
             new Folder { Name = "Folder1", DateCreated = DateTime.UtcNow, DateUpdated = DateTime.UtcNow },
             new Folder { Name = "Folder2", DateCreated = DateTime.UtcNow, DateUpdated = DateTime.UtcNow },
             new Folder { Name = "Folder3", DateCreated = DateTime.UtcNow, DateUpdated = DateTime.UtcNow }
             );
            db.SaveChanges();
            db.Files.AddOrUpdate(
              f => f.FileId,
              new File { Name = "File1", Size = "54", Url = "www.happy.com", FolderId = 1, DateCreated = DateTime.UtcNow, DateUpdated = DateTime.UtcNow },
               new File { Name = "File2", Size = "812", Url = "www.grumpy.com", FolderId = 2, DateCreated = DateTime.UtcNow, DateUpdated = DateTime.UtcNow },
               new File { Name = "File3", Size = "15614", Url = "www.delusional.com", FolderId = 3, DateCreated = DateTime.UtcNow, DateUpdated = DateTime.UtcNow },
               new File { Name = "File4", Size = "16306", Url = "www.hungry.com", FolderId = 1, DateCreated = DateTime.UtcNow, DateUpdated = DateTime.UtcNow },
               new File { Name = "File5", Size = "24", Url = "www.cheeky.com", FolderId = 1, DateCreated = DateTime.UtcNow, DateUpdated = DateTime.UtcNow },
               new File { Name = "File6", Size = "534", Url = "www.sleepy.com", FolderId = 3, DateCreated = DateTime.UtcNow, DateUpdated = DateTime.UtcNow },
               new File { Name = "File7", Size = "55", Url = "www.coffee.com", FolderId = 2, DateCreated = DateTime.UtcNow, DateUpdated = DateTime.UtcNow }
               );
            db.SaveChanges();
        }
    }
}
