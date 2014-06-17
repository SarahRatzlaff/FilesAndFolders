using FilesAndFolders.Data;
using FilesAndFolders.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FilesAndFolders.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            List<Folder> Folders = db.Folders.Include("Files").ToList();

            return View(Folders);
        }
        [HttpPost]
        public ActionResult Index(int id)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            Folder Folder = db.Folders.Where(x => x.FolderId == id).FirstOrDefault();

            return RedirectToAction("DeleteFolder", Folder.FolderId);
        }
        public ActionResult FolderDetails(int id)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            Folder folder = db.Folders.Where(x => x.FolderId == id).FirstOrDefault();
            return View(folder);
        }
        public ActionResult DeleteFolder(int id)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            while (db.Files.Where(x => x.FolderId == id).Count() != 0)
            {
                File file = db.Files.Where(x => x.FolderId == id).FirstOrDefault();
                db.Files.Remove(file);
                db.SaveChanges();
            }
            Folder folder = db.Folders.Where(x => x.FolderId == id).FirstOrDefault();
            db.Folders.Remove(folder);
            db.SaveChanges();


            return RedirectToAction("Index");

        }

        [HttpGet] //passing back folder Id so that the new file will have a matching folder id
        public ActionResult AddFile(int id)
        {
            File myFile = new File();
            myFile.FolderId = id; // kd

            return View(myFile);
        }
        [HttpPost]
        public ActionResult AddFile(File file)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            file.DateCreated = DateTime.UtcNow;
            file.DateUpdated = DateTime.UtcNow;
            db.Files.Add(file);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult AddNewFolder()
        {


            return View();
        }
        [HttpPost]
        public ActionResult AddNewFolder(Folder folder)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            folder.DateCreated = DateTime.Now;
            folder.DateUpdated = DateTime.Now;
            db.Folders.Add(folder);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult FileDetails(int id)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            File file = db.Files.Where(f => f.FileId == id).FirstOrDefault();
            return View(file);
        }
        [HttpPost]
        public ActionResult FileDetails(int id, string name, string url, string size)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            File file = db.Files.Where(x => x.FileId == id).FirstOrDefault();
            file.Name = name;
            file.Url = url;
            file.Size = size;
            file.DateUpdated = DateTime.UtcNow;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult DeleteFile(int id)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            File file = db.Files.Where(g => g.FileId == id).FirstOrDefault();
            db.Files.Remove(file);
            db.SaveChanges();


            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult AddNewFolderToFolder(int id)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            Folder thisFolder = db.Folders.Where(x => x.FolderId == id).FirstOrDefault();
            

            return View(thisFolder);
        }
        public ActionResult AddNewFolderToFolder(Folder folder)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            Folder newFolder = new Folder();
            Folder thisFolder = db.Folders.Where(f => f.FolderId == folder.FolderId).FirstOrDefault();
            thisFolder.Folders.Add(newFolder);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}