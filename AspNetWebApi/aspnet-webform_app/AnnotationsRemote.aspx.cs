using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DocuVieware_webform_app_demo
{
    public partial class AnnotationsRemote : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DocuVieware1.Timeout = Global.SESSION_TIMEOUT;
            if (!IsPostBack)
            {
                // Make sure the AspNetWebApi project is launched using port 44360
                string ppAPIpath = "https://localhost:44360/api/getimage";
                var client = new HttpClient();
                client.BaseAddress = new Uri(ppAPIpath);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var responseTask = client.GetStringAsync(ppAPIpath);
                responseTask.Wait();

                try
                {
                    string result = responseTask.Result.Replace("\"", "");
                    byte[] myarray = Convert.FromBase64String(result);
                    MemoryStream ms = new MemoryStream(myarray);
                    DocuVieware1.LoadFromStream(ms, true);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
            else
            {
                //var resultFile = "C:\\Code.DocuVieware\\Result\\ResultFile.pdf";
                //FileStream oFileStream = new FileStream(resultFile, FileMode.OpenOrCreate);      


                //try
                //{
                //    DocuVieware1.GetNativePDF(out GdPicturePDF oPDF);
                //    //DocuVieware1.SaveAsPDF(PdfConformance.PDF, oFileStream);
                //    //DocuVieware1.SaveAsPDF(PdfConformance.PDF1_7, oFileStream, "*", false);

                //    oPDF.SaveToStream(oFileStream);
                //    oFileStream.Dispose();

                //}
                //catch (Exception ex)
                //{
                //    Console.WriteLine(ex.Message);
                //}

            }
        }
    }
}