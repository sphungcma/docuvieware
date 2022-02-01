using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace DocuVieware_webform_app_demo
{
    public partial class AnnotationsDemo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DocuVieware1.Timeout = Global.SESSION_TIMEOUT;
            if (!IsPostBack)
            {
                string testDoc = "OnePage.pdf";
                string testDocPath = "C:\\Code.DocuVieware\\TestDoc\\JPEGFile.jpg";
                DocuVieware1.LoadFromStream(new FileStream(testDocPath, FileMode.Open, FileAccess.Read), true, testDoc);
            }
            else
            {

            }
        }

    }
}