using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesAndFolders.Data.Models
{
    public class File : InheritedObject
    {
        public int FileId { get; set; }
        public string Name { get; set; }
        public string Size { get; set; }
        public string Url { get; set; }

        public int FolderId { get; set; } //foreign key
        public virtual Folder Folder { get; set; } 
    }
}
