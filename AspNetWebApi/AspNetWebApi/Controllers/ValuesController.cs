using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;

namespace AspNetWebApi.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet]
        [Route("api/getimage")]
        public string GetImage()
        {
            //var filePath = "C:\\Code.DocuVieware\\TestDoc\\JPEGFile.jpg";
            var filePath = HttpRuntime.AppDomainAppPath + "documents\\JPEGFile.jpg";

            byte[] data = File.ReadAllBytes(filePath);
            var result = Convert.ToBase64String(data);
            return result;
        }

        [HttpPost]
        [Route("api/saveimage")]
        public HttpResponseMessage SaveImage()
        {
            HttpResponseMessage result = null;
            var httpRequest = HttpContext.Current.Request;
            var randomFileName = Path.GetRandomFileName();

            if (httpRequest.Files.Count > 0)
            {
                var docfiles = new List<string>();

                try
                {
                    foreach (string file in httpRequest.Files)
                    {
                        var postedFile = httpRequest.Files[file];
                        var filePath = HttpRuntime.AppDomainAppPath + "documents\\" + postedFile.FileName;

                        postedFile.SaveAs(filePath);
                        docfiles.Add(filePath);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                } 
                result = Request.CreateResponse(HttpStatusCode.Created, docfiles);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }


    }
}
