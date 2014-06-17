using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesAndFolders.Data.Models
{
    public class Folder : InheritedObject
    {
        public int FolderId { get; set; }
        public string Name { get; set; }
        public List<File> Files { get; set; }
        public List<Folder> Folders { get; set; }
    }
}
