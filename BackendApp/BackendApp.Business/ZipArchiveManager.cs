using BackendApp.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendApp.Business
{
    public class ZipArchiveManager : BaseManager
    {
        public bool SaveZipArchive(ZipArchive zip)
        {
            bool retVal = false;
            try
            {
                UnitOfWork.ZipArchives.Add(zip);
                UnitOfWork.Complete();
                retVal = true;
            }
            catch (Exception)
            {

                throw;
            }
            return retVal;
        }
    }
}
