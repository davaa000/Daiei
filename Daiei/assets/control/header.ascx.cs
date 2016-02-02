using System;
using System.Data;
using System.Web;
using System.Web.UI;
using Telerik.Web.UI;
using System.ComponentModel.DataAnnotations;

namespace Daiei.assets.control
{
    public partial class header : System.Web.UI.UserControl
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            if (!Page.IsPostBack)
            {
                setMenu();
                setUserInfo();
            }
            else
            {
                txtPassword.Text = "";
                txtEmail.Text = "";
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            setMenu();
            setUserInfo();
        }
        public header() { }

        public void setMenu()
        {
            string exChange = Database.ExchangeRate;

            string menuHtml = " <nav class='header-menu element-menu left'>" +
                    "<div class='menu'>" +
                        "<ul id='menu-main-menu' class='menu'>" +
                            "<li id='menu-item-1' class='menu-item menu-item-type-post_type menu-item-object-page current-menu-item'><a href='../Pages/Home.aspx'>"+Resources.Resource.Home+"</a></li>" +
                            "<li id='menu-item-2' class='menu-item menu-item-type-post_type menu-item-object-page'><a href='../Pages/Check.aspx'>"+Resources.Resource.PackageCheckStatus+"</a></li>" +
                            "<li id='menu-item-3' class='menu-item menu-item-type-custom menu-item-object-custom menu-item-has-children menu-item-146'><a href='#'>"+Resources.Resource.Package+"</a>" +
                                "<ul class='sub-menu' style='display: none; overflow: visible; width: 200px'>" +
                                    "<li id='menu-item-31' class='menu-item menu-item-type-post_type menu-item-object-page'><a href='../Pages/AddOrder.aspx'>"+Resources.Resource.PackageRegister+"</a></li>" +
                                    "<li id='menu-item-32' class='menu-item menu-item-type-post_type menu-item-object-page'><a href='../Pages/Orders.aspx'>"+Resources.Resource.PackageList+"</a></li>" +
                                    "<li id='menu-item-32' class='menu-item menu-item-type-post_type menu-item-object-page'><a href='../Pages/Calculate.aspx'>"+Resources.Resource.PackageCalc+"</a></li>" +
                                "</ul>" +
                            "</li>" +
                            "<li id='menu-item-4' class='menu-item menu-item-type-custom menu-item-object-custom menu-item-has-children menu-item-147'><a href='#'>"+Resources.Resource.Service+"</a>" +
                                "<ul class='sub-menu' style='display: none; overflow: visible; width: 200px'>" +
                                    "<li id='menu-item-41' class='menu-item menu-item-type-post_type menu-item-object-page'><a href='../Pages/Policy.aspx'>"+Resources.Resource.TermsOfService+"</a></li>" +
                                    "<li id='menu-item-42' class='menu-item menu-item-type-post_type menu-item-object-page'><a href='../Pages/Instruction.aspx'>"+Resources.Resource.Guideline+"</a></li>" +
                                "</ul>" +
                            "</li>" +
                        "</ul>" +
                    "</div>" +
                "</nav>" +
                "<div class='select-menu element-select redirect medium'>" +
                    "<span></span>" +
                    "<select>" +
                        "<option value='../Pages/Home.aspx'>" + Resources.Resource.Home + "</option>" +
                        "<option value='../Pages/Check.aspx'>" + Resources.Resource.PackageCheckStatus + "</option>" +
                        "<option value='../Pages/AddOrder.aspx'>" + Resources.Resource.PackageRegister + "</option>" +
                        "<option value='../Pages/Orders.aspx'>" + Resources.Resource.PackageList + "</option>" +
                        "<option value='../Pages/Calculate.aspx'>" + Resources.Resource.PackageCalc + "</option>" +
                        "<option value='../Pages/Policy.aspx'>" + Resources.Resource.TermsOfService + "</option>" +
                        "<option value='../Pages/Instruction.aspx'>" + Resources.Resource.Guideline + "</option>" +
                    "</select>" +
                "</div>" +
                "<!-- /menu -->" +
                "<div class='header-cart right'>" +
                    "<div class='cart-amount'>" +
                        "<span class='amount'>1¥ </span>" +
                        "<span class='fa fa-exchange'></span>" +
                        "<span class='amount'>" + exChange + "</span>" +
                    "</div>" +
                "</div>";
            this.lblMenu.Text = menuHtml;
        }

        public void setUserInfo()
        {
            string LoginPanelHtml = "";

            if (Database.UserID != null)
            {
                LoginPanelHtml = "<a href='../Pages/Home.aspx' class='element-button opaque'>" + Database.UserEmail + "</a>" +
                                 "<a href='../Pages/GuestHome.aspx' class='element-button primary'>"+Resources.Resource.Exit+"</a>";
            }
            else
            {
                LoginPanelHtml = "<a href='#login_form' class='element-button element-colorbox opaque'>"+Resources.Resource.Login+"</a>" +
                                 "<a href='../Pages/Register.aspx' class='element-button primary'>"+Resources.Resource.UserRegister+"</a>";
            }

            this.lblPanel.Text = LoginPanelHtml;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtEmail.Text != "" & this.txtPassword.Text != "")
                {
                    string Username = this.txtEmail.Text.Trim().ToLower();
                    if (Username.Length < 60)
                    {
                        string Password = Functions.MD5(this.txtPassword.Text.Trim());
                        string sqlStr1 = "Select t.* from t_user t " +
                                         " Where lower(t.email) = '" + Username.ToLower() + "' and t.password = '" + Password + "'";
                        DataTable DT = Database.ExecuteQuery(sqlStr1);
                        if (DT.Rows.Count > 0)
                        {
                            Database.UserID = DT.Rows[0]["ID"].ToString();
                            RadAjaxManager manager = RadAjaxManager.GetCurrent(Page);
                            manager.ResponseScripts.Add(Functions.BootstrapMessageBoxScriptBuilder("success", "Тавтай морилно уу.", "../Pages/Home.aspx"));
                        }
                        else
                        {
                            Database.UserID = null;
                            Session.Clear();
                            this.txtEmail.Text = "";
                            this.txtPassword.Text = "";
                            RadAjaxManager manager = RadAjaxManager.GetCurrent(Page);
                            manager.ResponseScripts.Add(Functions.BootstrapMessageBoxScriptBuilder("alert", "Хэрэглэгчийн имэйл, нууц үг буруу байна", "../Pages/Home.aspx"));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                RadAjaxManager manager = RadAjaxManager.GetCurrent(Page);
                manager.ResponseScripts.Add(Functions.BootstrapMessageBoxScriptBuilder("alert", ex.Message, "../Pages/GuestHome.aspx"));
                this.txtPassword.Text = "";
                this.txtEmail.Text = "";
            }
            finally
            {

            }
        }

        protected void btnResetPassword_Click(object sender, EventArgs e)
        {
            string user_id = Database.SelectFieldValue("t_user", "id", "lower(email)='" + txtResetEmail.Text.ToLower() + "'", "");
            if (user_id != null && user_id != "")
            {
                try
                {
                    string activelink = Functions.RandomString(50);
                    Functions.SendEmail("Таби.мн Нууц үг солих", "Нууц үгээ сэргээхдээ http://www.tabi.mn/Pages/ResetPassword.aspx?a=" + activelink + " орж сэргээнэ үү", txtResetEmail.Text.ToLower().Trim());
                    Database.ExecuteNonQueryStr(Database.SaveFieldValue("t_user", "activelink", activelink, "id", ref user_id, txtResetEmail.Text));
                    RadAjaxManager manager = RadAjaxManager.GetCurrent(Page);
                    manager.ResponseScripts.Add(Functions.BootstrapMessageBoxScriptBuilder("success", "Нууц үг сэргээх линкийг таны e-mail рүү явууллаа. Та Spam, Junk e-mail давхар шалгана уу", "../Pages/GuestHome.aspx"));
                }
                catch (Exception ex)
                {
                    RadAjaxManager manager = RadAjaxManager.GetCurrent(Page);
                    manager.ResponseScripts.Add(Functions.BootstrapMessageBoxScriptBuilder("success", "Алдаа гарлаа. "+ex.Message, "../Pages/GuestHome.aspx"));
                }
            }
            else
                RequiredFieldValidator3.Text = "Таны e-mail хаяг бүртгэлгүй байна.";

        }
    }
}