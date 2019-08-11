using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZipFileUploader.Core.Domain
{
    public class APIResultDataModel
    {
        public string ResponseCode { get; set; }
        public string ResponseTitle { get; set; }
        public string Message { get; set; }
    }
}
