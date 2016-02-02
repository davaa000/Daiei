using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace Daiei
{
    public partial class Register : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Database.UserID != null)
                {
                    Response.Redirect("../Error/404.html");
                }
            }
        }

        protected void btnLLogin_Click(object sender, EventArgs e)
        {
            Functions.Login(this.txtLEmail, this.txtLPassword, this);
        }

        protected void btnRegister_Click(object sender, EventArgs e)
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
                    string isusername = Database.SelectFieldValue("t_user", "email", "lower(email) = '" + email.ToLower() + "'", "ID");
                    if (isusername == email)
                    {
                        isready = false;
                        messege = email + " имэйл хаягаар хэрэглэгч бүртгүүлсэн байна.";
                    }
                }
            }

            if (isready)
            {
                if (this.txtRPassword.Text == this.txtRPasswordValid.Text)
                    isready = true;
                else
                {
                    isready = false;
                    messege = "Нууц үг ижил биш байна.";
                }
            }

            if (password == "" || password == null)
                if (isready)
                {
                    if (this.txtRPassword.Text.Length > 5)
                        isready = true;
                    else
                    {
                        isready = false;
                        messege = "Нууц үг 6 болон түүнээс дээш тэмдэгтээс бүрдэх шаардлагатай.";
                    }
                }

            if (isready)
            {
                try
                {
                    string activelink = Functions.RandomString(50);

                    List<string> SQLList = new List<string>();
                    password = Functions.MD5(this.txtRPassword.Text.Trim());
                    string[] Fields = {"firstname", "lastname", "email", "password", "usertype_id", "phonemn", "phonejp", "addressmn", "addressjp", "archive", "activelink", 
                                       this.txtRFirstName.Text.ToLower().Trim(), this.txtRLastName.Text.ToLower().Trim(), this.txtREmail.Text.ToLower().Trim(), password, usertype_id, 
                                       this.txtRMNPhone.Text, this.txtRJPPhone.Text, this.txtRMNAddress.Text, this.txtRJPAddress.Text, "Y", activelink};
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
                    if (Functions.SendEmail("Таби.мн тавтай морилно уу ", "Та Японоос илгээмж авах үйлчилгээнд бүртгэгдлээ. \r\n Таны нэвтрэх нэр: " + email.ToLower() + " \r\n Нууц үг: " + this.txtRPassword.Text.Trim() + " \r\n Баталгаажуулах линк: http://www.tabi.mn/Pages/Login.aspx?a=" + activelink, this.txtREmail.Text.ToLower().Trim()))
                    {

                        if (Database.ExecuteNonQuery(SQLList.ToArray()))
                        {
                            RadAjaxManager manager = RadAjaxManager.GetCurrent(Page);
                            manager.ResponseScripts.Add(Functions.BootstrapMessageBoxScriptBuilder("success", "Таны имэйл хаяг руу идвэхжүүлэх линк явууллаа. Идвэхжүүлэх линк дээр дарж хэрэглэгчийн эрхээ баталгаажуулна уу. Та SPAM хавтасаа шалгаарай", "../Pages/Login.aspx"));
                        }
                    }
                }
                catch (Exception ex)
                {
                    RadAjaxManager manager = RadAjaxManager.GetCurrent(Page);
                    manager.ResponseScripts.Add(Functions.BootstrapMessageBoxScriptBuilder("alert", "Мэдээлэл хадгалахад алдаа гарлаа." + ex.Message, ""));
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