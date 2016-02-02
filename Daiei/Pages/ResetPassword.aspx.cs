using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace Daiei.Pages
{
    public partial class ResetPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // base.OnLoad(e);
            string activeLink = Request.Params["a"];
            //string activeLink = HttpUtility.ParseQueryString(uri).Get("a");
            //string activeLink = Request.QueryString["a"];
            if (activeLink != null && activeLink != "")
            {
                RadAjaxManager manager = RadAjaxManager.GetCurrent(Page);
                activeLink = activeLink.Replace("'", "").Replace("-", "");
                string id = Database.SelectFieldValue("t_user", "id", "activelink = '" + activeLink + "'", "ID");
                if (id == null || id == "")
                {
                    Response.Redirect("GuestHome.aspx");
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (txtPass22.Text != "")
                if (txtPass22.Text == txtPass33.Text)
                {
                    RadAjaxManager manager = RadAjaxManager.GetCurrent(Page);
                    string activeLink = Request.QueryString["a"];
                    string user_id = Database.SelectFieldValue("t_user", "id", "activelink='" + activeLink + "'", "");
                    if (user_id != null && user_id != "")
                    {
                        Database.ExecuteNonQueryStr(Database.SaveFieldValue("t_user", "password", Functions.MD5(txtPass33.Text), "id", ref user_id, user_id));
                        Database.UserID = user_id;
                        manager.ResponseScripts.Add(Functions.BootstrapMessageBoxScriptBuilder("success", "Тавтай морилно уу.", "Home.aspx"));
                    }
                    else
                        manager.ResponseScripts.Add(Functions.BootstrapMessageBoxScriptBuilder("alert", "Алдаа гарлаа", ""));
                }
        }
    }
}