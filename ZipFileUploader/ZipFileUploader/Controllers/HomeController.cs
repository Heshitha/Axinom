using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ionic.Zip;
using ZipFileUploader.Models;
using System.Text;
using Newtonsoft.Json;
using ZipFileUploader.Business;
using ZipFileUploader.Core.Domain;

namespace ZipFileUploader.Controllers
{
    public class HomeController : Controller
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(HomePageViewModel vm)
        {
            APIResultDataModel result = new APIResultDataModel();
            try
            {
                if (System.IO.Path.GetExtension(vm.File.FileName).ToLower() == ".zip")
                {

                    string generatedFileName = System.IO.Path.GetRandomFileName() + ".zip";
                    string actualFileName = vm.File.FileName;
                    string savingPath = Server.MapPath("~/Uploads") + "\\" + generatedFileName;

                    vm.File.SaveAs(savingPath);
                    ZipManager zip = new ZipManager();
                    string jsonTree = zip.ReadZip(savingPath);
                    result = zip.SubmitZipWithUserDetails(jsonTree, vm.Username, vm.Password, actualFileName, generatedFileName);

                }
                else
                {
                    result.Message = "You have to upload a zip file only.";
                }
            }
            catch (Exception ex)
            {
                result.ResponseCode = ex.Message;
                log.Error(ex.Message, ex);
            }
            ViewBag.result = result;
            return View();
        }
    }
}