using BusinessEntities;
using BusinessServices;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Newtonsoft.Json;
namespace BiMental.Controllers
{
    public class GatepassController : ApiController
    {
        log4net.ILog logger4net = log4net.LogManager.GetLogger(typeof(GatepassController));
        HttpClient client = new HttpClient();

        [Route("GenerateGatepassNo")]
        [HttpPost]
        public GatepassEntities GenerateGatepassNo()
        {
            GatepassEntities ObjGatepass = new GatepassEntities();
            try
            {
                Stream data = this.Request.Content.ReadAsStreamAsync().Result;
                StreamReader reader = new StreamReader(data);
                string post_data = reader.ReadToEnd();
                ObjGatepass = (GatepassEntities)JsonConvert.DeserializeObject(post_data, ObjGatepass.GetType());
                ObjGatepass = GatepassBusiness.GenerateGatepassNo(ObjGatepass.Driver_VehicleNo, ObjGatepass.Driver_MobileNo, ObjGatepass.Login_GID);
                return ObjGatepass;

            }
            catch (Exception ex)
            {
                logger4net.Error(ex.ToString());
                return ObjGatepass;
            }
        }

        [Route("VerifyInvoiceNo")]
        [HttpPost]
        public GatepassEntities VerifyInvoiceNo()
        {
            GatepassEntities ObjGatepass = new GatepassEntities();
            try
            {
                Stream data = this.Request.Content.ReadAsStreamAsync().Result;
                StreamReader reader = new StreamReader(data);
                string post_data = reader.ReadToEnd();
                ObjGatepass = (GatepassEntities)JsonConvert.DeserializeObject(post_data, ObjGatepass.GetType());
                ObjGatepass = GatepassBusiness.VerifyInvoiceNo(ObjGatepass.Gatepass_GID, ObjGatepass.InvoiceNo, ObjGatepass.Login_GID);
                return ObjGatepass;
            }
            catch (Exception ex)
            {
                logger4net.Error(ex.ToString());
                return ObjGatepass;
            }
        }

        [Route("UpdateNetWeight")]
        [HttpPost]
        public GatepassEntities UpdateNetWeight()
        {
            GatepassEntities ObjGatepass = new GatepassEntities();
            try
            {
                Stream data = this.Request.Content.ReadAsStreamAsync().Result;
                StreamReader reader = new StreamReader(data);
                string post_data = reader.ReadToEnd();
                ObjGatepass = (GatepassEntities)JsonConvert.DeserializeObject(post_data, ObjGatepass.GetType());
                ObjGatepass = GatepassBusiness.UpdateNetWeight(ObjGatepass.Gatepass_GID, ObjGatepass.Netwieght,ObjGatepass.InvoiceNo,ObjGatepass.Login_GID);
                return ObjGatepass;
            }
            catch (Exception ex)
            {
                logger4net.Error(ex.ToString());
                return ObjGatepass;
            }
        }

        [Route("GetGatepassInvoiceDetails")]
        [HttpPost]
        public List<GatepassEntities> GetGatepassInvoiceDetails()
        {
            List<GatepassEntities> lstGatepassEntities = new List<GatepassEntities>();
            List<GatepassEntities> lstreturnGatepassEntities = new List<GatepassEntities>();
            GatepassEntities ObjGatepass = new GatepassEntities();
            try
            {
                Stream data = this.Request.Content.ReadAsStreamAsync().Result;
                StreamReader reader = new StreamReader(data);
                string post_data = reader.ReadToEnd();
                lstGatepassEntities = (List<GatepassEntities>)JsonConvert.DeserializeObject(post_data, lstGatepassEntities.GetType());
                foreach (GatepassEntities ObjGatepassloop in lstGatepassEntities)
                {
                    lstreturnGatepassEntities = GatepassBusiness.GetGatepassInvoiceDetails(ObjGatepassloop.Gatepass_GID, ObjGatepassloop.Action);
                }
                return lstreturnGatepassEntities;
            }
            catch (Exception ex)
            {
                logger4net.Error(ex.ToString());
                return lstreturnGatepassEntities;
            }
        }

        [Route("UpdateAirwayBillNo")]
        [HttpPost]
        public List<GatepassEntities> UpdateAirwayBillNo()
        {
            List<GatepassEntities> lstGatepassEntities = new List<GatepassEntities>();
            List<GatepassEntities> lstreturnGatepassEntities = new List<GatepassEntities>();
            GatepassEntities ObjGatepass = new GatepassEntities();
            try
            {
                Stream data = this.Request.Content.ReadAsStreamAsync().Result;
                StreamReader reader = new StreamReader(data);
                string post_data = reader.ReadToEnd();
                lstGatepassEntities = (List<GatepassEntities>)JsonConvert.DeserializeObject(post_data, lstGatepassEntities.GetType());
                foreach (GatepassEntities ObjGatepassloop in lstGatepassEntities)
                {
                    ObjGatepass = GatepassBusiness.UpdateAirwayBillNo(ObjGatepassloop.InvoiceNo,ObjGatepassloop.Gatepass_GID, ObjGatepassloop.AirwayBillNo, ObjGatepassloop.CurStatus);
                    lstreturnGatepassEntities.Add(ObjGatepass);
                }
                return lstreturnGatepassEntities;
            }
            catch (Exception ex)
            {
                logger4net.Error(ex.ToString());
                return lstreturnGatepassEntities;
            }
        }

        [Route("UpdateLLRNo")]
        [HttpPost]
        public List<GatepassEntities> UpdateLLRNo()
        {
            List<GatepassEntities> lstGatepassEntities = new List<GatepassEntities>();
            List<GatepassEntities> lstreturnGatepassEntities = new List<GatepassEntities>();
            GatepassEntities ObjGatepass = new GatepassEntities();
            try
            {
                Stream data = this.Request.Content.ReadAsStreamAsync().Result;
                StreamReader reader = new StreamReader(data);
                string post_data = reader.ReadToEnd();
                lstGatepassEntities = (List<GatepassEntities>)JsonConvert.DeserializeObject(post_data, lstGatepassEntities.GetType());
                foreach (GatepassEntities ObjGatepassloop in lstGatepassEntities)
                {
                    ObjGatepass = GatepassBusiness.UpdateLLRNo(ObjGatepassloop.InvoiceNo, ObjGatepassloop.Gatepass_GID, ObjGatepassloop.LLRNo, ObjGatepassloop.CurStatus);
                    lstreturnGatepassEntities.Add(ObjGatepass);
                }
                return lstreturnGatepassEntities;
            }
            catch (Exception ex)
            {
                logger4net.Error(ex.ToString());
                return lstreturnGatepassEntities;
            }
        }

        [Route("FetchGatepassSummary")]
        [HttpPost]
        public List<GatepassEntities> FetchGatepassSummary()
        {
            List<GatepassEntities> lstGatepassEntities = new List<GatepassEntities>();
            List<GatepassEntities> lstreturnGatepassEntities = new List<GatepassEntities>();
            GatepassEntities ObjGatepass = new GatepassEntities();
            try
            {
                Stream data = this.Request.Content.ReadAsStreamAsync().Result;
                StreamReader reader = new StreamReader(data);
                string post_data = reader.ReadToEnd();
                lstGatepassEntities = (List<GatepassEntities>)JsonConvert.DeserializeObject(post_data, lstGatepassEntities.GetType());
                foreach (GatepassEntities ObjGatepassloop in lstGatepassEntities)
                {
                    lstreturnGatepassEntities = GatepassBusiness.FetchGatepassSummary(ObjGatepassloop.Login_GID, ObjGatepassloop.CurStatus);
                }
                return lstreturnGatepassEntities;
            }
            catch (Exception ex)
            {
                logger4net.Error(ex.ToString());
                return lstreturnGatepassEntities;
            }
        }

        [Route("UpdateStatus")]
        [HttpPost]
        public List<GatepassEntities> UpdateStatus()
        {
            List<GatepassEntities> lstGatepassEntities = new List<GatepassEntities>();
            List<GatepassEntities> lstreturnGatepassEntities = new List<GatepassEntities>();
            GatepassEntities ObjGatepass = new GatepassEntities();
            try
            {
                Stream data = this.Request.Content.ReadAsStreamAsync().Result;
                StreamReader reader = new StreamReader(data);
                string post_data = reader.ReadToEnd();
                lstGatepassEntities = (List<GatepassEntities>)JsonConvert.DeserializeObject(post_data, lstGatepassEntities.GetType());
                foreach (GatepassEntities ObjGatepassloop in lstGatepassEntities)
                {
                    ObjGatepass = GatepassBusiness.UpdateStatus(ObjGatepassloop.Gatepass_GID, ObjGatepassloop.CurStatus);
                    lstreturnGatepassEntities.Add(ObjGatepass);
                }
                return lstreturnGatepassEntities;
            }
            catch (Exception ex)
            {
                logger4net.Error(ex.ToString());
                return lstreturnGatepassEntities;
            }
        }

        [Route("DeleteInvoice")]
        [HttpPost]
        public List<GatepassEntities> DeleteInvoice()
        {
            List<GatepassEntities> lstGatepassEntities = new List<GatepassEntities>();
            List<GatepassEntities> lstreturnGatepassEntities = new List<GatepassEntities>();
            GatepassEntities ObjGatepass = new GatepassEntities();
            try
            {
                Stream data = this.Request.Content.ReadAsStreamAsync().Result;
                StreamReader reader = new StreamReader(data);
                string post_data = reader.ReadToEnd();
                lstGatepassEntities = (List<GatepassEntities>)JsonConvert.DeserializeObject(post_data, lstGatepassEntities.GetType());
                foreach (GatepassEntities ObjGatepassloop in lstGatepassEntities)
                {
                    ObjGatepass = GatepassBusiness.DeleteInvoice(ObjGatepassloop.Gatepass_GID,ObjGatepassloop.InvoiceNo, ObjGatepassloop.CurStatus);
                    lstreturnGatepassEntities.Add(ObjGatepass);
                }
                return lstreturnGatepassEntities;
            }
            catch (Exception ex)
            {
                logger4net.Error(ex.ToString());
                return lstreturnGatepassEntities;
            }
        }

        [Route("GetScannedCasesByGatePassGID")]
        [HttpPost]
        public GatepassEntities GetScannedCasesByGatePassGID()
        {
            GatepassEntities ObjGatepass = new GatepassEntities();
            try
            {
                Stream data = this.Request.Content.ReadAsStreamAsync().Result;
                StreamReader reader = new StreamReader(data);
                string post_data = reader.ReadToEnd();
                ObjGatepass = (GatepassEntities)JsonConvert.DeserializeObject(post_data, ObjGatepass.GetType());
                ObjGatepass = GatepassBusiness.GetScannedCasesByGatePassGID(ObjGatepass.Gatepass_GID);
                return ObjGatepass; 
            }
            catch (Exception ex)
            {
                logger4net.Error(ex.ToString());
                return ObjGatepass;
            }
        }


        [Route("SaveFileToServer")]
        [HttpPost]
        public IHttpActionResult SaveFileToServer()
        {
            GatepassEntities ObjGatepass = new GatepassEntities();

            try
            {
                Stream data = this.Request.Content.ReadAsStreamAsync().Result;
                StreamReader reader = new StreamReader(data);
                string post_data = reader.ReadToEnd();
                ObjGatepass = (GatepassEntities)JsonConvert.DeserializeObject(post_data, ObjGatepass.GetType());
                string FileStringinbytes = ObjGatepass.FileString;
                string FileName = ObjGatepass.FileName;
                string DocGroup = ObjGatepass.DocumentGroup;
                string DocName = ObjGatepass.DocumentName;
                string Extension = ObjGatepass.Extension;

                string filePath = System.Configuration.ConfigurationManager.AppSettings["Path"].ToString();
                string DocGroupName = filePath + DocGroup;
                //string ExistingfilePath = deptsModel.Filepathfrom;
                string DistinationFilepath = DocGroupName + "\\" + DocName + "\\";
                bool loggingDirectoryExists = false;
                DirectoryInfo ObjDirectoryInfo = new DirectoryInfo(DocGroupName);
                if (ObjDirectoryInfo.Exists)
                {
                    loggingDirectoryExists = true;
                    DirectoryInfo ObjSubDirectoryInfo = new DirectoryInfo(DocName);
                    if (ObjSubDirectoryInfo.Exists)
                    {
                        loggingDirectoryExists = true;
                    }
                    else
                    {
                        ObjSubDirectoryInfo = ObjDirectoryInfo.CreateSubdirectory(DocName);
                    }
                }
                else
                {
                    Directory.CreateDirectory(DocGroupName);
                    ObjDirectoryInfo = new DirectoryInfo(DocGroupName);
                    DirectoryInfo ObjSubDirectoryInfo = ObjDirectoryInfo.CreateSubdirectory(DocName);
                    loggingDirectoryExists = true;
                }

                if (loggingDirectoryExists == true)
                {
                    byte[] buf = Convert.FromBase64String(FileStringinbytes);

                    File.WriteAllBytes(string.Format(DistinationFilepath + "{0}", FileName,Extension), buf);
                    return Content(HttpStatusCode.OK, true);
                }
                else
                {
                    return Content(HttpStatusCode.NotAcceptable, true);
                }
            }
            catch (Exception ex)
            {
                logger4net.Error(ex.ToString());
                return Content(HttpStatusCode.NotAcceptable, true);
            }

        }

        //[HttpPost]
        //public IHttpActionResult FileSave(RequestData data)
        //{
        //    try
        //    {
        //        var path = System.Configuration.ConfigurationManager.AppSettings["FileUploadPath"];
        //        byte[] buf = Convert.FromBase64String(data.FileString);

        //        File.WriteAllBytes(string.Format(path + "{0}", data.FileName, data.Extension), buf);
        //        return Content(HttpStatusCode.OK, true);
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }

        //}
        //[HttpGet]
        //public IHttpActionResult FileGet(string filename)
        //{
        //    try
        //    {
        //        //UrlEncoder urlencode = new UrlEncoder();
        //        //filename = urlencode.Decrypt(filename);
        //        var path = WebConfigurationManager.AppSettings["FileUpload"];
        //        byte[] buf = File.ReadAllBytes(string.Format(path + "{0}", filename));
        //        string data1 = Convert.ToBase64String(buf);
        //        return Content(HttpStatusCode.OK, data1);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //}



    }
}
