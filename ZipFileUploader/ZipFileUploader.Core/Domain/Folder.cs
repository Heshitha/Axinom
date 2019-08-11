using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZipFileUploader.Core
{
    public class Folder
    {
        public string Path { get; set; }
        public List<Folder> SubFolders { get; set; }
        public List<string> Files { get; set; }
        public Folder Parent { get; set; }
        public string Name { get; set; }

        public Folder()
        {
            SubFolders = new List<Folder>();
            Files = new List<string>();
        }
    }
}
