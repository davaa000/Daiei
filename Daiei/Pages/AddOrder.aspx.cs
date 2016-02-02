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
    public partial class AddOrder : BasePage
    {
        private const int ItemsPerRequest = 300;

        protected override void OnLoad(EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Database.UserID != null)
                {
                    //
                }
                else
                {
                    try
                    {
                        RadAjaxManager manager = RadAjaxManager.GetCurrent(Page);
                        manager.ResponseScripts.Add(Functions.BootstrapMessageBoxScriptBuilder("danger", "Та системд нэвтрэх эсвэл бүртгүүлэх шаардлагатай.", "../Pages/Register.aspx"));
                    }
                    catch (NullReferenceException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            base.OnLoad(e);

        }
        public static string FormName
        {
            get { return "../Pages/AddPackage.aspx"; }
        }

        public DataTable sessionTable
        {
            get
            {
                return Database.OrderItemTable;
            }
            set
            {
                Database.OrderItemTable = value;
                grdListItems.DataSource = Database.OrderItemTable;
                grdListItems.DataBind();
            }
        }
        protected void BuildpicSessTable()
        {
            DataTable tmpDT = new DataTable();
            tmpDT.Columns.Add("NAME", typeof(string));
            tmpDT.Columns.Add("BRAND", typeof(string));
            tmpDT.Columns.Add("ITEMCOUNT", typeof(int));
            tmpDT.Columns.Add("ITEMRATE", typeof(decimal));
            tmpDT.Columns.Add("ITEMRATESUM", typeof(decimal));
            tmpDT.Columns.Add("ISNEW", typeof(int));
            sessionTable = tmpDT;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Database.UserID != null)
                {
                    initValues();
                    setNull();
                    fill();
                }
                else
                {
                    RadAjaxManager manager = RadAjaxManager.GetCurrent(Page);
                    manager.ResponseScripts.Add(Functions.BootstrapMessageBoxScriptBuilder("danger", "Та системд нэвтрэх эсвэл бүртгүүлэх шаардлагатай.", "../Pages/Register.aspx"));
                }
            }
        }
        void initValues()
        {
            if (Database.DtUser.Rows.Count > 0)
            {
                if (Database.DtUser.Rows[0]["ZIPCODE"].ToString() != "")
                {
                    this.lstUserList.DataTextField = "allState";
                    this.lstUserList.DataValueField = "ZipCode";
                    this.lstUserList.DataSource = Database.DtUser;
                    this.lstUserList.DataBind();
                }
            }

        }
        protected void setNull()
        {
            this.txtItemBrand.Text = "";
            this.txtItemCount.Text = "";
            this.txtItemName.Text = "";
            this.txtItemRate.Text = "";

            this.txtPackageDiscount.Text = "0";
            this.txtPackageShipping.Text = "0";
            this.txtPackageSumRate.Text = "";
            this.txtPackageTax.Text = "0";
            this.txtReciveAddress.Text = "";
            this.txtReciveName.Text = "";
            this.txtReciveOrderName.Text = "";
            this.txtReciveOrderNumber.Text = "";
            this.txtReciveOrderSite.Text = "";
            this.txtReciveOrderTrack.Text = "";
            this.txtRecivePhone.Text = "";

            this.lblPackageStatus.Text = "Шинэ ачаа";
            fillOrderUser("");
        }

        /*Ashiglahgui cfunction hassan*/
        protected void setUserDefaultValue()
        {
            string user_id = Database.UserID;
            if (Functions.CheckFormPermission(user_id, FormName))
            {
                string sqlStr1 = "Select t.* from t_user t Where t.id = '" + user_id + "' ";
                DataTable DT = Database.ExecuteQuery(sqlStr1);
                if (DT.Rows.Count > 0)
                {
                    this.txtReciveName.Text = DT.Rows[0]["lastname"].ToString() + " " + DT.Rows[0]["firstname"].ToString();
                    this.txtRecivePhone.Text = DT.Rows[0]["phonemn"].ToString();
                    this.txtReciveAddress.Text = DT.Rows[0]["addressmn"].ToString();
                }
            }
        }

        protected void fillOrderUser(string ID)
        {
            string user_id = Database.UserID;
            string permission = Functions.CheckGerFormPermission(user_id, FormName);

            if (permission != null && permission != "")
            {
                if (permission == "worker")
                {
                    this.lstUserList.Enabled = true;
                    this.txtDescription.Enabled = true;
                    this.val_description.Enabled = true;

                    this.txtRecivePhone.Text = "";
                    this.txtReciveAddress.Text = "";
                    this.txtReciveName.Text = "";
                    if (ID != "" && ID != null)
                    {
                        string orderUserID = Database.SelectFieldValue("T_Package", "rOrderUser_Id", "ID = '" + ID + "'", "ID");
                        lstUserList.SelectedValue = orderUserID;
                    }
                }
                else
                {
                    DataTable dt = Database.DtUser.Copy();
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0]["ZipCode"].ToString() != "")
                        {
                            this.lstUserList.DataTextField = "allState";
                            this.lstUserList.DataValueField = "ZipCode";
                            this.lstUserList.DataSource = dt;
                            this.lstUserList.DataBind();
                            this.lstUserList.SelectedValue = dt.Rows[0]["ZipCode"].ToString();

                            this.txtReciveName.Text = dt.Rows[0]["lastname"].ToString() + " " + dt.Rows[0]["firstname"].ToString();
                            this.txtRecivePhone.Text = dt.Rows[0]["phonemn"].ToString();
                            this.txtReciveAddress.Text = dt.Rows[0]["addressmn"].ToString();
                        }
                    }
                    this.lstUserList.Enabled = false;
                    this.txtDescription.Enabled = false;
                    this.val_description.Enabled = false;
                }
            }
        }

        protected void fill()
        {
            string user_id = Database.UserID;
            string StatusID = "", messege = "", statusName = "";
            bool isready = true;
            if (Functions.CheckFormPermission(user_id, FormName))
            {
                BuildpicSessTable();
                string id = Request.QueryString["id"];
                if (id != "" && id != null)
                {
                    if (Functions.IsInt(id))
                    {
                        StatusID = Database.SelectFieldValue("T_Package", "Status_Id", "id = '" + id + "' and rOrderUser_Id = '" + user_id + "'", "id");
                        if (StatusID != "6")
                        {
                            statusName = Database.SelectFieldValue("c_constData", "NAME_MN", "id = '" + StatusID + "'", "id");
                            isready = false;
                            messege = "Таны илгээмжийн мэдээлэл <b style='text-transform:uppercase;'>" + statusName + "</b> төлөвт байгаа тул засварлах боломжгүй.";
                        }

                        if (isready)
                        {
                            string sqlStr1 = "Select t.* from T_Package t " +
                                  " Where t.id = '" + id + "' and t.rOrderUser_Id = '" + user_id + "'";
                            DataTable DT = Database.ExecuteQuery(sqlStr1);
                            if (DT.Rows.Count > 0)
                            {
                                fillOrderUser(id);
                                this.lblPageHeader.Text = "Илгээмжийн мэдээлэл засварлах";
                                this.txtPackageDiscount.Text = DT.Rows[0]["rDiscountRate"].ToString();
                                this.txtPackageShipping.Text = DT.Rows[0]["rShippingRate"].ToString();
                                this.txtPackageSumRate.Text = DT.Rows[0]["rSumRate"].ToString();
                                this.txtPackageTax.Text = DT.Rows[0]["rTaxRate"].ToString();
                                this.txtReciveAddress.Text = DT.Rows[0]["getHumanAddress"].ToString();
                                this.txtReciveName.Text = DT.Rows[0]["getHumanName"].ToString();
                                this.txtReciveOrderName.Text = DT.Rows[0]["rOrderName"].ToString();
                                this.txtReciveOrderNumber.Text = DT.Rows[0]["rOrderNumber"].ToString();
                                this.txtReciveOrderSite.Text = DT.Rows[0]["rOrderSiteName"].ToString();
                                this.txtReciveOrderTrack.Text = DT.Rows[0]["rOrderTrackingNumber"].ToString();
                                this.txtRecivePhone.Text = DT.Rows[0]["getHumanPhone"].ToString();
                                this.txtDescription.Text = DT.Rows[0]["Description"].ToString();

                                string tmpSQL1 = "SELECT t.Name as NAME, t.Brand as BRAND, t.ItemCount as ITEMCOUNT, t.ItemRate as ITEMRATE, t.SumRate as ITEMRATESUM, '1' as ISNEW FROM T_Items t Where t.Package_Id = '" + id + "' and user_id = '" + user_id + "'";
                                DataTable tmpDT1 = Database.ExecuteQuery(tmpSQL1);

                                for (int j = 0; j < tmpDT1.Rows.Count; j++)
                                {
                                    DataTable tmpDTbl1 = sessionTable;
                                    DataRow dr;
                                    dr = tmpDTbl1.NewRow();
                                    dr["NAME"] = tmpDT1.Rows[j]["NAME"].ToString();
                                    dr["BRAND"] = tmpDT1.Rows[j]["BRAND"].ToString();
                                    dr["ITEMCOUNT"] = Convert.ToInt32(tmpDT1.Rows[j]["ITEMCOUNT"].ToString());
                                    dr["ITEMRATE"] = Convert.ToDecimal(tmpDT1.Rows[j]["ITEMRATE"].ToString());
                                    dr["ITEMRATESUM"] = Convert.ToDecimal(tmpDT1.Rows[j]["ITEMRATESUM"].ToString());
                                    dr["ISNEW"] = tmpDT1.Rows[j]["ISNEW"].ToString();
                                    tmpDTbl1.Rows.Add(dr);
                                    tmpDTbl1.AcceptChanges();
                                    this.grdListItems.DataSource = null;
                                    sessionTable = tmpDTbl1;
                                }

                            }
                            else
                                setNull();
                        }
                        else
                        {
                            RadAjaxManager manager = RadAjaxManager.GetCurrent(Page);
                            manager.ResponseScripts.Add(Functions.BootstrapMessageBoxScriptBuilder("danger", messege, ""));
                        }
                    }
                    else
                        setNull();
                }
                else
                    setNull();
            }
            else
                Response.Redirect("../Pages/Home.aspx");
        }

        protected void btnUploadPic_Click(object sender, EventArgs e)
        {
            bool status = true;
            string messege = "";
            DataTable tmpDTable = sessionTable;

            if (tmpDTable.Rows.Count > 0)
            {
                DataRow[] result = tmpDTable.Select("NAME = '" + this.txtItemName.Text.Trim().ToUpper() + "'");
                foreach (DataRow row in result)
                {
                    if (row[0] != null && row[0] != null)
                    {
                        status = false;
                        messege = this.txtItemName.Text.Trim().ToUpper() + " нэртэй бараа бүртгэлтэй байна.";
                    }
                }
            }

            if (status)
            {
                DataRow dr;
                dr = tmpDTable.NewRow();
                dr["NAME"] = this.txtItemName.Text.Trim().ToUpper();
                dr["BRAND"] = this.txtItemBrand.Text.Trim().ToUpper();
                dr["ITEMCOUNT"] = Int32.Parse(this.txtItemCount.Text.Trim());
                dr["ITEMRATE"] = this.txtItemRate.Text;
                dr["ITEMRATESUM"] = Convert.ToDecimal(this.txtItemCount.Text) * Convert.ToDecimal(this.txtItemRate.Text);
                dr["ISNEW"] = "1";

                tmpDTable.Rows.Add(dr);
                tmpDTable.AcceptChanges();
                this.grdListItems.DataSource = null;
                sessionTable = tmpDTable.Copy();
                tmpDTable = null;

                this.txtItemName.Text = "";
                this.txtItemBrand.Text = "";
                this.txtItemCount.Text = "";
                this.txtItemRate.Text = "";
            }
            else
            {
                tmpDTable = null;
                RadAjaxManager manager = RadAjaxManager.GetCurrent(Page);
                manager.ResponseScripts.Add(Functions.BootstrapMessageBoxScriptBuilder("alert", messege, ""));
            }

            setSumRate();
        }

        protected void setSumRate()
        {
            DataTable tmpDTable = sessionTable;
            decimal sumOfItemsRate = 0;
            decimal rate = 0;
            for (int i = 0; i < tmpDTable.Rows.Count; i++)
            {
                rate = 0;
                if (Convert.ToDecimal(tmpDTable.Rows[i]["ITEMRATESUM"].ToString()) != null)
                    rate = Convert.ToDecimal(tmpDTable.Rows[i]["ITEMRATESUM"].ToString());
                else
                    rate = 0;

                sumOfItemsRate = sumOfItemsRate + rate;
            }
            this.txtPackageSumRate.Text = sumOfItemsRate.ToString();
        }

        protected void grdList_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                //string grid_id = e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["columnID Uni"];
                int grid_id = e.Item.ItemIndex;
                DataTable tmpDT = sessionTable;
                tmpDT.Rows[grid_id].Delete();
                tmpDT.AcceptChanges();
                this.grdListItems.DataSource = null;
                sessionTable = tmpDT.Copy();
                setSumRate();
            }
        }

        protected void save()
        {
            string user_id = Database.UserID;
            Boolean isready = true;
            string messege = "", statusID = "", saveType = "new";
            string id = Request.QueryString["id"];
            int CountItems = 0;
            if (id != "" && id != null)
                if (Functions.IsInt(id))
                {
                    id = Database.SelectFieldValue("t_package", "id", "id = '" + id + "' and rOrderUser_Id = '" + user_id + "'", "id");
                    if (id != null && id != "")
                    {
                        saveType = "edit";
                    }
                }
                else
                    id = "";

            if (Functions.CheckFormPermission(user_id, FormName))
            {
                if (isready)
                {
                    DataTable tmpDTable = sessionTable;
                    if (tmpDTable.Rows.Count == 0)
                    {
                        isready = false;
                        messege = "Барааны мэдээлэл оруулаагүй байна.";
                    }
                    else
                        CountItems = tmpDTable.Rows.Count;
                }

                if (isready)
                {
                    try
                    {
                        string orderUserID = "";
                        string permission = Functions.CheckGerFormPermission(user_id, FormName);
                        if (permission != null && permission != "")
                        {
                            if (permission == "worker")
                            {
                                orderUserID = this.lstUserList.SelectedValue.ToString();
                            }
                            else
                                orderUserID = user_id;
                        }

                        List<string> SQLList = new List<string>();
                        string[] Fields = {"rOrderTrackingNumber", "rOrderName", "rOrderNumber", "rOrderSiteName", "getHumanName", "getHumanAddress", 
                                           "getHumanPhone", "rTaxRate", "rShippingRate", "rDiscountRate", "rSumRate", "rItemsCount", "rOrderUser_Id", "active", "Status_Id", "Description", 
                                           this.txtReciveOrderTrack.Text, this.txtReciveOrderName.Text, this.txtReciveOrderNumber.Text, this.txtReciveOrderSite.Text, this.txtReciveName.Text, this.txtReciveAddress.Text,
                                           this.txtRecivePhone.Text, this.txtPackageTax.Text, this.txtPackageShipping.Text, this.txtPackageDiscount.Text, this.txtPackageSumRate.Text, CountItems.ToString(), orderUserID, "1", "6", this.txtDescription.Text };
                        SQLList.Add(Database.SaveTableData("T_Package", "ID", ref id,  user_id, Fields));

                        if (saveType == "new")
                        {
                            SQLList.Add("Update T_Package set MBno = '" + System.DateTime.Now.ToString("yyyy") + System.DateTime.Now.ToString("MM") + System.DateTime.Now.ToString("dd") + id + "' WHERE Id = '" + id + "'");
                            string[] Fields3 = {"Status_Id", "Package_id", "StatusDate", "User_Id", "Description",
                                                "6", id, "datetime('now')", user_id, "Хэрэглэгч өөрөө захиалсан" };
                            SQLList.Add(Database.SaveTableData("T_PackageStatus", "ID", ref statusID,  user_id, Fields3));
                        }
                        else
                        {
                            string mbno = Database.SelectFieldValue("T_Package", "MBno", "ID = '" + id + "'", "id");
                            if (mbno == "" || mbno == null)
                                SQLList.Add("Update T_Package set MBno = '" + System.DateTime.Now.ToString("yyyy") + System.DateTime.Now.ToString("MM") + System.DateTime.Now.ToString("dd") + id + "' WHERE Id = '" + id + "'");
                            SQLList.Add("DELETE FROM T_Items WHERE Package_Id = '" + id + "' and User_Id = '" + user_id + "'");

                        }

                        if (id != null && id != "")
                        {
                            DataTable tmpDTable = sessionTable;
                            string _ID = "";
                            for (int i = 0; i < tmpDTable.Rows.Count; i++)
                            {
                                _ID = "";
                                string[] Fields2 = {"Package_Id", "Name", "Brand", "ItemCount", 
                                                    "ItemRate", "SumRate", "User_Id",                                
                                                    id, tmpDTable.Rows[i]["NAME"].ToString(), tmpDTable.Rows[i]["BRAND"].ToString(), tmpDTable.Rows[i]["ITEMCOUNT"].ToString(),
                                                    tmpDTable.Rows[i]["ITEMRATE"].ToString(), tmpDTable.Rows[i]["ITEMRATESUM"].ToString(), user_id};
                                SQLList.Add(Database.SaveTableData("T_Items", "ID", ref _ID,  user_id, Fields2));
                            }
                        }

                        if (Database.ExecuteNonQuery(SQLList.ToArray()))
                        {
                            RadAjaxManager manager = RadAjaxManager.GetCurrent(Page);
                            manager.ResponseScripts.Add(Functions.BootstrapMessageBoxScriptBuilder("success", "Илгээмж амжилттай бүртгэгдсэн.", "../Pages/Orders.aspx"));
                        }
                    }
                    catch (Exception ex)
                    {
                        RadAjaxManager manager = RadAjaxManager.GetCurrent(Page);
                        manager.ResponseScripts.Add(Functions.BootstrapMessageBoxScriptBuilder("danger", "Илгээмжийн мэдээлэл хадгалахад алдаа гарлаа.", ""));
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
            else
                Response.Redirect("../Pages/Home.aspx");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            save();
        }

        protected void cancelPackage()
        {
            string user_id = Database.UserID;
            Boolean isready = true;
            string messege = "", statusID = "", saveType = "new";
            string id = Request.QueryString["id"];
            int CountItems = 0;
            if (id != "" && id != null)
                if (Functions.IsInt(id))
                {
                    id = Database.SelectFieldValue("t_package", "id", "id = '" + id + "' and rOrderUser_Id = '" + user_id + "'", "id");
                    if (id != null && id != "")
                    {
                        saveType = "edit";
                    }
                }
                else
                    id = "";

            if (Functions.CheckFormPermission(user_id, FormName))
            {
                if (saveType == "edit")
                {
                    try
                    {
                        List<string> SQLList = new List<string>();
                        string[] Fields = { "Status_Id", "7" };
                        SQLList.Add(Database.SaveTableData("T_Package", "ID", ref id, user_id, Fields));

                        string[] Fields3 = {"Status_Id", "Package_id", "StatusDate", "User_Id", "Description",
                                           "7", id, "datetime('now')", user_id, "Хэрэглэгч өөрөө цуцалсан." };
                        SQLList.Add(Database.SaveTableData("T_PackageStatus", "ID", ref statusID, user_id, Fields3));


                        if (Database.ExecuteNonQuery(SQLList.ToArray()))
                        {
                            RadAjaxManager manager = RadAjaxManager.GetCurrent(Page);
                            manager.ResponseScripts.Add(Functions.BootstrapMessageBoxScriptBuilder("success", "Илгээмжийн мэдээллийг цуцалсан.", "../Pages/Orders.aspx"));
                        }
                    }
                    catch (Exception ex)
                    {
                        RadAjaxManager manager = RadAjaxManager.GetCurrent(Page);
                        manager.ResponseScripts.Add(Functions.BootstrapMessageBoxScriptBuilder("danger", "Илгээмжийн мэдээлэл цуцлахад алдаа гарлаа.", ""));
                    }
                    finally
                    {

                    }
                }
                else
                {
                    RadAjaxManager manager = RadAjaxManager.GetCurrent(Page);
                    manager.ResponseScripts.Add(Functions.BootstrapMessageBoxScriptBuilder("alert", "Бүртгэгдээгүй илгээмжийн мэдээллийг цуцлах боломжгүй.", ""));
                }
            }
            else
                Response.Redirect("../Pages/Home.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            cancelPackage();
        }

        protected void lstUserList_ItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
        {
            if (e.Text != "" && e.Text != null && e.Text.Substring(0, 1) != "%")
            {
                /*  if ((e.Text.Length % 3) == 0) % huvaah, uldegdel ni 0*/
                if (e.Text.Length >= 4)
                {
                    DataRow[] rows = Database.DtUser.Copy().Select("ALLSTATE Like '" + e.Text + "%'");

                    int itemOffset = e.NumberOfItems;
                    int endOffset = Math.Min(itemOffset + ItemsPerRequest, rows.Count());
                    e.EndOfItems = endOffset == rows.Count();

                    for (int i = itemOffset; i < endOffset; i++)
                    {
                        lstUserList.Items.Add(new RadComboBoxItem(rows[i]["ALLSTATE"].ToString(), rows[i]["ZIPCODE"].ToString()));
                    }
                }
            }
            //e.Message = GetStatusMessage(endOffset, data.Rows.Count);
        }

        /*
         protected void lstAddressFill_PostBack(string stateName)
                {
                    if (stateName != "" && stateName != null)
                    {
                        DataTable data = GetData(stateName.ToLower());
                        for (int i = 0; i < data.Rows.Count; i++)
                        {
                            lstUserList.Items.Add(new RadComboBoxItem(data.Rows[i]["ALLSTATE"].ToString(), data.Rows[i]["ZIPCODE"].ToString()));
                        }
                    }
                }

                private DataTable GetData(string text)
                {
                    DataTable ZipCode = sessionZipCode;
                    DataTable data = new DataTable();
                    data.Columns.Add("ZIPCODE", typeof(Int64));
                    data.Columns.Add("ALLSTATE", typeof(string));

                    DataRow[] foundRows;
                    foundRows = ZipCode.Select("ALLSTATE Like '" + text + "%'");
                    foreach (DataRow _dr in foundRows)
                    {
                        DataRow dr = data.NewRow();
                        dr["ZIPCODE"] = (Int64)_dr["ZIPCODE"];
                        dr["ALLSTATE"] = (string)_dr["ALLSTATE"];
                        data.Rows.Add(dr);
                    }
                    return data;
                }
                */
        protected void lbCheckUser_Click(object sender, EventArgs e)
        {
            if (this.lstUserList.SelectedValue != "" && this.lstUserList.SelectedValue != null)
            {
                DataTable dt = new DataTable();
                string SQL = "Select t.* " +
                         "From t_user t where t.id = '" + this.lstUserList.SelectedValue + "'";
                dt = Database.ExecuteQuery(SQL);
                if (dt.Rows.Count > 0)
                {
                    this.txtReciveName.Text = dt.Rows[0]["lastname"].ToString() + " " + dt.Rows[0]["firstname"].ToString();
                    this.txtRecivePhone.Text = dt.Rows[0]["phonemn"].ToString();
                    this.txtReciveAddress.Text = dt.Rows[0]["addressmn"].ToString();
                }
            }
        }
    }
}