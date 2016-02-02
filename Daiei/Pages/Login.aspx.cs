using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace Daiei.Pages
{
    public partial class Login : System.Web.UI.Page
    {
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!Page.IsPostBack)
            {
                string activeLink = Request.QueryString["a"];
                if (activeLink != null && activeLink != "")
                {
                    activeLink = activeLink.Replace("'", "").Replace("-", "");
                    string id = Database.SelectFieldValue("t_user", "id", "activelink = '" + activeLink + "'", "ID");
                    if (id != null && id != "")
                    {
                        RadAjaxManager manager = RadAjaxManager.GetCurrent(Page);
                        List<string> SQLList = new List<string>();
                        string[] Fields = { "archive", "activelink", "N", "" };
                        SQLList.Add(Database.SaveTableData("t_user", "ID", ref id, id, Fields));
                        if (Database.ExecuteNonQuery(SQLList.ToArray()))
                        {
                            manager.ResponseScripts.Add(Functions.BootstrapMessageBoxScriptBuilder("success", "Амжилттай баталгаажлаа.", "../Pages/Login.aspx"));
                        }
                        else
                            manager.ResponseScripts.Add(Functions.BootstrapMessageBoxScriptBuilder("alert", "Үйлдэл амжилтгүй боллоо.", "../Pages/Home.aspx"));
                    }
                }
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtLEmail.Text != "" & this.txtLPassword.Text != "")
                {
                    string Username = this.txtLEmail.Text.Trim().ToLower();
                    if (Username.Length < 60)
                    {
                        string Password = Functions.MD5(this.txtLPassword.Text.Trim());
                        string sqlStr1 = "Select t.* from t_user t " +
                                         " Where t.email = '" + Username + /*"' and t.password = '" + Password +*/ "'";
                        DataTable DT = Database.ExecuteQuery(sqlStr1);
                        if (DT.Rows.Count > 0)
                        {
                            Database.UserID = DT.Rows[0]["ID"].ToString();
                            RadAjaxManager manager = RadAjaxManager.GetCurrent(Page);
                            manager.ResponseScripts.Add(Functions.BootstrapMessageBoxScriptBuilder("success", "Тавтай морилно уу.", "Home.aspx"));
                        }
                        else
                        {
                            Database.UserID = null;
                            Session.Clear();
                            this.txtLEmail.Text = "";
                            this.txtLPassword.Text = "";
                            RadAjaxManager manager = RadAjaxManager.GetCurrent(Page);
                            manager.ResponseScripts.Add(Functions.BootstrapMessageBoxScriptBuilder("alert", "Хэрэглэгчийн имэйл, нууц үг буруу эсвэл бүртгэлээ баталгаажуулаагүй байна.", ""));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                RadAjaxManager manager = RadAjaxManager.GetCurrent(Page);
                manager.ResponseScripts.Add(Functions.BootstrapMessageBoxScriptBuilder("alert", ex.Message, ""));
                this.txtLPassword.Text = "";
                this.txtLEmail.Text = "";
            }
            finally
            {

            }
        }
    }
}