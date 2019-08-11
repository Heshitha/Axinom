using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackendApp.Models
{
    public class ZipArchiveViewModel
    {
        public string ArchiveName { get; set; }
        public string SavedFileName { get; set; }
        public byte[] ArchiveHirachy { get; set; }
    }
}