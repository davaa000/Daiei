using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace Daiei
{
    public partial class GuestHome : BasePage
    {
        protected override void OnInit(EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Session.Clear();
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Session.Clear();
                txtTrackingNumber.Text = "";
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string track = txtTrackingNumber.Text.Trim(new Char[] { ' ', '*', '.', ',', ';' });
            string id = "";
            id = Database.SelectFieldValue("T_Package", "MBno", "rOrderTrackingNumber = '" + track + "'", "ID");
            string url = "../Pages/Check.aspx?v=" + id;
            if (id != "")
                Response.Redirect(url);
            else
            {
                RadAjaxManager manager = RadAjaxManager.GetCurrent(Page);
                manager.ResponseScripts.Add(Functions.BootstrapMessageBoxScriptBuilder("alert", "Илгээмжийн мэдээлэл олдсонгүй", ""));
            }
        }
    }
}