using GdPicture14;
using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace DocuVieware_webform_app_demo
{
    public partial class annotationsStream : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DocuVieware1.Timeout = Global.SESSION_TIMEOUT;
            if (!IsPostBack)
            {
                //DocuVieware1.LoadFromStream(new FileStream(Global.GetDocumentsDirectory() + @"\st_exupery_le_petit_prince.pdf", FileMode.Open, FileAccess.Read), true, "st_exupery_le_petit_prince.pdf");

                //string testDoc = "OnePage.pdf";
                //string testDocPath = "C:\\Code.DocuVieware\\TestDoc\\JPEGFile.jpg";
                //DocuVieware1.LoadFromStream(new FileStream(testDocPath, FileMode.Open, FileAccess.Read), true, testDoc);

                string ppAPIpath = "https://localhost:44373/api/";
                string xApiKey = "AIzaSyCF114Bo7yo8mo5uGXyDIkKhAoEiVjOjq8";

                var client = new HttpClient();
                client.BaseAddress = new Uri(ppAPIpath);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Add("X-API-KEY", xApiKey);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var responseTask = client.GetStringAsync("documents/download?documentId=14122&userId=GKAMARAJ");

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

        void SavetoStream_Click(Object sender, EventArgs e)
        {

        }

    }
}