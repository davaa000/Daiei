using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace Daiei
{
    public partial class ChangeProfile : System.Web.UI.Page
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
                    fill();
                }
            }
        }

        private void fill()
        {
            string sqlStr = "Select t.* from t_user t " +
                                      " Where t.id = '" + Database.UserID + "' ";
            DataTable DT = Database.ExecuteQuery(sqlStr);
            if (DT.Rows.Count > 0)
            {
                this.lblUserID.Text = DT.Rows[0]["code"].ToString();
                this.txtUserCode.Text = DT.Rows[0]["code"].ToString();
                this.txtREmail.Text = DT.Rows[0]["email"].ToString();
                this.txtRFirstName.Text = DT.Rows[0]["firstname"].ToString();
                this.txtRLastName.Text = DT.Rows[0]["lastname"].ToString();
                this.txtRMNPhone.Text = DT.Rows[0]["phonemn"].ToString();
                this.txtRJPPhone.Text = DT.Rows[0]["phonejp"].ToString();
                this.txtRMNAddress.Text = DT.Rows[0]["addressmn"].ToString();
                this.txtRJPAddress.Text = DT.Rows[0]["addressjp"].ToString();
            }
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            string user_id = "", usertype_id = "3", password = "";
            Boolean isready = true;
            string messege = "", saveType = "new";
            string type = Request.QueryString["vh"];

            if (Database.UserID != null)
            {
                user_id = Database.UserID;
                if (Functions.IsInt(user_id))
                {
                    user_id = Database.SelectFieldValue("t_user", "id", "archive = 'N' and id = '" + user_id + "'", "id");
                    if (user_id != null && user_id != "")
                    {
                        usertype_id = Database.SelectFieldValue("t_user", "usertype_id", "archive = 'N' and id = '" + user_id + "'", "id");
                        password = Database.SelectFieldValue("t_user", "password", "archive = 'N' and id = '" + user_id + "'", "id");
                        saveType = "edit";
                    }
                }
                else
                    user_id = "";
            }
            string email = this.txtREmail.Text.ToLower().Trim();

            if (type == "new")
            {
                user_id = "";
            }

            if (isready)
            {
                if (user_id == "" || user_id == null)
                {
                    string isusername = Database.SelectFieldValue("t_user", "email", "email = '" + email + "' and archive = 'N'", "ID");
                    if (isusername == email)
                    {
                        isready = false;
                        messege = email + " имэйл хаягаар хэрэглэгч бүртгүүлсэн байна.";
                    }
                }
            }

            if (isready)
            {
                try
                {
                    List<string> SQLList = new List<string>();

                    string[] Fields = {"firstname", "lastname", "email", "password", "usertype_id", "phonemn", "phonejp", "addressmn", "addressjp", "archive", 
                                       this.txtRFirstName.Text.ToLower().Trim(), this.txtRLastName.Text.ToLower().Trim(), this.txtREmail.Text.ToLower().Trim(), password, usertype_id, 
                                       this.txtRMNPhone.Text, this.txtRJPPhone.Text, this.txtRMNAddress.Text, this.txtRJPAddress.Text, "N"};
                    SQLList.Add(Database.SaveTableData("t_user", "ID", ref user_id, user_id, Fields));
                    if (saveType == "new")
                    {
                        SQLList.Add("Update t_user set code = 'U" + System.DateTime.Now.ToString("yyyy") + user_id + "' WHERE Id = '" + user_id + "'");
                    }
                    else
                    {
                        string code = Database.SelectFieldValue("t_user", "CODE", "ID = '" + user_id + "'", "ID");
                        if (code == "" || code == null)
                            SQLList.Add("Update t_user set code = 'U" + System.DateTime.Now.ToString("yyyy") + user_id + "' WHERE Id = '" + user_id + "'");
                    }

                    if (Database.ExecuteNonQuery(SQLList.ToArray()))
                    {
                        RadAjaxManager manager = RadAjaxManager.GetCurrent(Page);
                        manager.ResponseScripts.Add(Functions.BootstrapMessageBoxScriptBuilder("success", "Амжилттай өөрчлөгдлөө.", "../Pages/Home.aspx"));
                    }
                }
                catch (Exception ex)
                {
                    RadAjaxManager manager = RadAjaxManager.GetCurrent(Page);
                    manager.ResponseScripts.Add(Functions.BootstrapMessageBoxScriptBuilder("alert", "Мэдээлэл хадгалахад алдаа гарлаа.", ""));
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
    }
}