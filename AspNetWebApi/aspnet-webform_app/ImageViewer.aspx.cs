using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DocuVieware_webform_app_demo
{
    public partial class ImageViewer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string ppAPIpath = "https://localhost:44373/api/";
            string xApiKey = "AIzaSyCF114Bo7yo8mo5uGXyDIkKhAoEiVjOjq8";

            System.Drawing.Image respImage;

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

                respImage = System.Drawing.Image.FromStream(ms);
                Response.ContentType = "image/jpeg";

                respImage.Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //throw;
            }

        }
    }
}