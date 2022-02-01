using GdPicture14;
using System;
using System.IO;

namespace DocuVieware_webform_app_demo
{
    public partial class AnnotationsLocal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DocuVieware1.Timeout = Global.SESSION_TIMEOUT;
            if (!IsPostBack)
            {
                string testDoc = "OnePage.pdf";
                string testDocPath = "C:\\Code.DocuVieware\\TestDoc\\OnePage.pdf";
                DocuVieware1.LoadFromStream(new System.IO.FileStream(testDocPath, FileMode.Open, FileAccess.Read), true, testDoc);
            }
            else
            {
                try
                {
                    var outputFile = "C:\\Code.DocuVieware\\Result\\ResultFile.pdf";
                    FileStream ms = new FileStream(outputFile, FileMode.OpenOrCreate);

                    DocuVieware1.GetNativePDF(out GdPicturePDF oPDF);
                    oPDF.SaveToStream(ms);
                    ms.Dispose();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

        }


    }
}