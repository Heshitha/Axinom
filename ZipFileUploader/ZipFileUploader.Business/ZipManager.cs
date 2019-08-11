using Ionic.Zip;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ZipFileUploader.Core;
using ZipFileUploader.Core.Domain;

namespace ZipFileUploader.Business
{
    public class ZipManager
    {
        public string ReadZip(string filePath)
        {
            try
            {
                Folder retVal = new Folder();

                string ExistingZipFile = filePath;

                string curPath = "/";
                Folder root = new Folder()
                {
                    Path = "/",
                    Name = "root"
                };
                Folder curFolder = root;

                using (ZipFile zip = ZipFile.Read(ExistingZipFile))
                {
                    foreach (ZipEntry e in zip)
                    {
                        string[] splittedPath = e.FileName.Split('/').Where(x => !string.IsNullOrEmpty(x)).ToArray();
                        StringBuilder sb = new StringBuilder();
                        for (int i = 0; i < splittedPath.Length - 1; i++)
                        {
                            sb.Append(splittedPath[i] + "/");
                        }
                        string fileName = splittedPath.Last();
                        string realPath = "/";
                        if (!string.IsNullOrEmpty(sb.ToString()))
                        {
                            realPath = sb.ToString();
                        }

                        while (!realPath.StartsWith(curPath))
                        {
                            curFolder = curFolder.Parent;
                            curPath = curFolder.Path;
                        }

                        if (e.IsDirectory)
                        {
                            Folder newFold = new Folder()
                            {
                                Path = e.FileName,
                                Name = fileName,
                                Parent = curFolder
                            };

                            curFolder.SubFolders.Add(newFold);

                            curPath = newFold.Path;
                            curFolder = newFold;
                        }
                        else
                        {
                            curFolder.Files.Add(fileName);
                        }
                    }
                }
                retVal = root;

                string json = JsonConvert.SerializeObject(retVal, Formatting.Indented, new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
                return json;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public APIResultDataModel SubmitZipWithUserDetails(string jsonString, string username, string password, string fileName, string savedName)
        {
            APIResultDataModel retVal = new APIResultDataModel();

            try
            {
                SecurityManager secMan = new SecurityManager();

                ZipArchiveDataModel mod = new ZipArchiveDataModel()
                {
                    ArchiveName = fileName,
                    SavedFileName = savedName,
                    ArchiveHirachy = secMan.Encrypt(jsonString)
                };

                var myContent = JsonConvert.SerializeObject(mod);
                var buffer = Encoding.UTF8.GetBytes(myContent);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.ASCII.GetBytes(string.Format("{0}:{1}", username, password))));
                    string backEndurl = ConfigurationManager.AppSettings["backendApp"];
                    var response = client.PostAsync(backEndurl + "api/ZipArchive", byteContent).Result;
                    var result = response.Content.ReadAsStringAsync().Result;

                    retVal.ResponseCode = response.StatusCode.ToString();
                    retVal.ResponseTitle = response.ReasonPhrase;

                    retVal.Message = result;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return retVal;
        }
    }
}
