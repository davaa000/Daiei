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
    public partial class Orders : System.Web.UI.Page
    {
        public static string FormName
        {
            get { return "../Pages/Packages.aspx"; }
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!Page.IsPostBack)
            {
                if (Database.UserID != null)
                {
                    fill();
                }
                else
                {
                    try
                    {
                        RadAjaxManager manager = RadAjaxManager.GetCurrent(Page);
                        manager.ResponseScripts.Add(Functions.BootstrapMessageBoxScriptBuilder("danger", "Та системд нэвтрэх эсвэл бүртгүүлэх шаардлагатай.", "Register.aspx"));
                    }
                    catch (NullReferenceException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }
        protected void fill()
        {
            string user_id = Database.UserID;
            if (Functions.CheckFormPermission(user_id, FormName))
            {
                RefreshGrid();
            }
            else
                Response.Redirect("GuestHome.aspx");
        }

        protected void grdPackages_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            if (e.CommandName == Telerik.Web.UI.RadGrid.ExportToExcelCommandName ||
               e.CommandName == Telerik.Web.UI.RadGrid.ExportToWordCommandName ||
               e.CommandName == Telerik.Web.UI.RadGrid.ExportToCsvCommandName ||
               e.CommandName == Telerik.Web.UI.RadGrid.ExportToPdfCommandName)
            {
                ConfigureExport();
            }
            if (HttpContext.Current.Session[FormName + Database.UserID] != null)
            {
                this.grdPackages.DataSource = Functions.ReadDataTableFromSession(FormName + Database.UserID);
                this.grdPackages.DataBind();
            }
            else
                this.RefreshGrid();
        }

        public void ConfigureExport()
        {
            grdPackages.ExportSettings.ExportOnlyData = true;
            grdPackages.ExportSettings.IgnorePaging = true;
            grdPackages.ExportSettings.FileName = this.Page.Title.ToString() + System.DateTime.Now.ToString();
        }

        private void RefreshGrid()
        {
            if (Database.UserID != null)
            {
                string user_id = Database.UserID;
                string permission = Functions.CheckGerFormPermission(user_id, FormName);
                if (permission != null && permission != "")
                {
                    string SQL = "SELECT t.id, t.rOrderName, t.rOrderNumber, t.rOrderTrackingNumber, t.rItemsCount, t.MBno, t.MFee, t.rOrderUser_Id, t.MBox_id, t.active, t.CreatedUser, t.CreatedDate, t.UpdatedUser, t.UpdatedDate, t.Status_Id, upper(c.name_mn) StatusName, t.CreatedDate ";
                    SQL += " FROM T_Package t";
                    SQL += " Left join c_constData c on t.Status_Id = c.id";
                    SQL += " Where ";
                    if (permission == "worker")
                        SQL += " t.id is not null ";
                    else if (permission == "user")
                        SQL += " t.rOrderUser_Id = '" + user_id + "' ";

                    SQL += " and t.rOrderUser_Id is not null and t.Status_Id not in ('7') Order By t.CreatedDate Desc ";
                    DataTable dt = Database.ExecuteQuery(SQL);
                    this.grdPackages.DataSource = dt;
                    this.grdPackages.DataBind();

                    Functions.SaveDataTableToSession(dt, FormName + Database.UserID);
                }
            }
            else
            {

            }
        }
    }
}