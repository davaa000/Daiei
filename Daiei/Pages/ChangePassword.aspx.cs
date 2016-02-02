using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace Daiei
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Database.UserID == null)
                {
                    Response.Redirect("../Error/404.html");
                }
                else
                {
                    this.lblUserID.Text = Database.SelectFieldValue("t_user", "code", "ID = '" + Database.UserID + "'", "ID");
                }
            }
        }

        protected void save()
        {
            string user_id = Database.UserID;
            string Password = Functions.MD5(this.txtPass11.Text.Trim());
            string Password2 = Functions.MD5(this.txtPass22.Text.Trim());
            Boolean isready = true;
            string messege = "";
            string id = "";
            id = Database.SelectFieldValue("t_user", "id", "archive = 'N' and id = '" + user_id + "' and password = '" + Password + "'  ", "id");

            if (id == "" || id == null)
            {
                isready = false;
                messege = "Нууц үг буруу байна.!";
            }

            if (isready)
            {
                if (txtPass22.Text.Length < 6)
                {
                    isready = false;
                    messege = "Шинэ нууц үг 6 тэмдэгтээс дээш байна.!";
                }

                if (txtPass22.Text != txtPass33.Text)
                {
                    isready = false;
                    messege = "Шинэ нууц үгээ зөв давтан оруулна уу";
                }
            }

            if (isready)
            {
                try
                {
                    List<string> SQLList = new List<string>();
                    string[] Fields = { "password", Password2 };
                    SQLList.Add(Database.SaveTableData("t_user", "ID", ref id, user_id, Fields));
                    if (Database.ExecuteNonQuery(SQLList.ToArray()))
                    {
                        RadAjaxManager manager = RadAjaxManager.GetCurrent(Page);
                        manager.ResponseScripts.Add(Functions.BootstrapMessageBoxScriptBuilder("success", "Нууц үг амжилттай солигдсон.", "../Pages/Home.aspx"));
                    }
                }
                catch (Exception ex)
                {
                    RadAjaxManager manager = RadAjaxManager.GetCurrent(Page);
                    manager.ResponseScripts.Add(Functions.BootstrapMessageBoxScriptBuilder("alert", "Мэдээлэл хадгалахад алдаа гарлаа", ""));
                }
                finally
                {

                }
            }
            else
            {
                RadAjaxManager manager = RadAjaxManager.GetCurrent(Page);
                manager.ResponseScripts.Add(Functions.BootstrapMessageBoxScriptBuilder("alert", messege, ""));
            }
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            save();
        }
    }
}