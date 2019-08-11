using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZipFileUploader.Core
{
    public class ZipArchiveDataModel
    {
        public string ArchiveName { get; set; }
        public string SavedFileName { get; set; }
        public byte[] ArchiveHirachy { get; set; }
    }
}
