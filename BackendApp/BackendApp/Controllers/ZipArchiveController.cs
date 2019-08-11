using BackendApp.Business;
using BackendApp.Core.Domain;
using BackendApp.Filters;
using BackendApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BackendApp.Controllers
{
    [BasicAuthentication]
    public class ZipArchiveController : ApiController
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        // POST api/values
        public IHttpActionResult Post([FromBody]ZipArchiveViewModel zipvm)
        {
            try
            {
                string retVal = "";

                SecurityManager secMgr = new SecurityManager();
                string decText = secMgr.Decrypt(zipvm.ArchiveHirachy);

                ZipArchive z = new ZipArchive()
                {
                    ArchiveHirachy = decText,
                    ArchiveName = zipvm.ArchiveName,
                    SavedFileName = zipvm.SavedFileName,
                    SavedDateTime = DateTime.Now
                };

                ZipArchiveManager mgr = new ZipArchiveManager();
                bool res = mgr.SaveZipArchive(z);
                if (res)
                {
                    retVal = "Successfully Uploaded.";
                    return Ok<string>(retVal);
                }
                else
                {
                    retVal = "File Upload Failed.";
                    return BadRequest(retVal);
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
                return BadRequest(ex.Message);
            }
            
        }
    }
}
