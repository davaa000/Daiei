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
    public partial class Check : System.Web.UI.Page
    {
        public static string FormName
        {
            get { return "../Pages/CheckPackageStatus.aspx"; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string visibleCheckForm = Request.QueryString["vh"];
                if (visibleCheckForm != null && visibleCheckForm != "")
                {
                    if (visibleCheckForm == "checkreceive")
                    {
                        this.pnlCheckForm.Visible = false;
                    }
                }

                //Functions.SetDropDownLisValue(this.lstType, "c_constData", "NAME_MN", "ID", "id in (6,9,10)", "ID", true);
                //this.dtPublish.MaxDate = System.DateTime.Now;
                //this.dtPublish.SelectedDate = System.DateTime.Now;
                this.Page.Title = "Таби.мн » Илгээмжийн төлөв шалгах";
                setNull();
                fill();
            }
        }

        protected void setNull()
        {
            this.txtOrderNumber.Text = "";
            this.txtPackageNumber.Text = "";
            this.txtTrackingNumber.Text = "";

            this.lblDiscount.Text = "******";
            this.lblEzelhuun.Text = "******";
            this.lblFee.Text = "******";
            this.lblJin.Text = "******";
            this.lblOrderName.Text = "******";
            this.lblOrderNumber.Text = "******";
            this.lblReciveHuman.Text = "******";
            this.lblReviceAddress.Text = "******";
            this.lblRevicePhone.Text = "******";
            this.lblSale.Text = "******";
            this.lblShiping.Text = "******";
            this.lblSiteName.Text = "******";
            this.lblSumRate.Text = "******";
            this.lblTrackingNumber.Text = "******";
            this.lblCreatedUser.Text = "******";
            this.btnEditPackage.Visible = false;
            //this.btnRecivePackage.Visible = false;
            //this.pnlRevice.Visible = false;

            string tmpSQL1 = "SELECT t.Name as NAME, t.Brand as BRAND, t.ItemCount as ITEMCOUNT, t.ItemRate as ITEMRATE, t.SumRate as ITEMRATESUM, '1' as ISNEW FROM T_Items t Where t.Package_Id is null and user_id is null and id is null";
            DataTable tmpDT1 = Database.ExecuteQuery(tmpSQL1);
            this.grdListItems.DataSource = tmpDT1;
            this.grdListItems.DataBind();
        }

        protected void fill()
        {
            string id = Request.QueryString["v"];
            if (id != null && id != "")
            {
                if (Functions.IsInt(id))
                {
                    id = Database.SelectFieldValue("T_Package", "id", "MBno = '" + id + "' ", "id");
                    if (id != null && id != "")
                    {
                        RefreshGridPackage(id);
                    }
                    else
                    {
                        RadAjaxManager manager = RadAjaxManager.GetCurrent(Page);
                        manager.ResponseScripts.Add(Functions.BootstrapMessageBoxScriptBuilder("alert", "Илгээмжийн мэдээлэл олдсонгүй.", ""));
                    }
                }
                else
                {
                    RadAjaxManager manager = RadAjaxManager.GetCurrent(Page);
                    manager.ResponseScripts.Add(Functions.BootstrapMessageBoxScriptBuilder("alert", "Илгээмжийн мэдээлэл олдсонгүй.", ""));
                }
            }
        }

        protected void RefreshGridPackage(string id)
        {
            string user_id = "";
            if (Database.UserID != null)
                user_id = Database.UserID;

            string StatusID = "", messege = "", statusName = "", OrderUserName = "";
            bool isready = true;

            if (user_id != "" && user_id != null)
            {
                string sqlStr1 = "Select t.* from T_Package t " +
                      " Where t.id = '" + id + "'";
                DataTable DT = Database.ExecuteQuery(sqlStr1);
                if (DT.Rows.Count > 0)
                {
                    if (DT.Rows[0]["rOrderUser_Id"] != null)
                    {
                        string sqlStr3 = "Select t.lastname + ' ' + t.firstname OrderUserName from t_user t " +
                                         " Where t.id = '" + DT.Rows[0]["rOrderUser_Id"].ToString() + "'";
                        DataTable DT3 = Database.ExecuteQuery(sqlStr3);
                        if (DT3.Rows.Count > 0)
                        {
                            OrderUserName = DT3.Rows[0]["OrderUserName"].ToString();
                        }

                        string permission = Functions.CheckGerFormPermission(user_id, FormName);
                        if (permission != null && permission != "")
                        {
                            if (permission == "worker" || permission == "workermn")
                            {
                                this.lblCreatedUser.Text = OrderUserName;
                                this.lblOrderName.Text = DT.Rows[0]["rOrderName"].ToString();
                                this.lblOrderNumber.Text = DT.Rows[0]["rOrderNumber"].ToString();
                                this.lblReciveHuman.Text = DT.Rows[0]["getHumanName"].ToString();
                                this.lblReviceAddress.Text = DT.Rows[0]["getHumanAddress"].ToString();
                                this.lblRevicePhone.Text = DT.Rows[0]["getHumanPhone"].ToString();
                                this.lblSiteName.Text = DT.Rows[0]["rOrderSiteName"].ToString();
                                this.lblTrackingNumber.Text = DT.Rows[0]["rOrderTrackingNumber"].ToString();

                                this.lblSale.Text = DT.Rows[0]["rTaxRate"].ToString();
                                this.lblShiping.Text = DT.Rows[0]["rShippingRate"].ToString();
                                this.lblDiscount.Text = DT.Rows[0]["rDiscountRate"].ToString();
                                this.lblSumRate.Text = DT.Rows[0]["rSumRate"].ToString();

                                this.lblJin.Text = DT.Rows[0]["Mweight"].ToString() + "кг";
                                this.lblEzelhuun.Text = DT.Rows[0]["Mlenght"].ToString() + "см x " + DT.Rows[0]["Mheight"].ToString() + "см x " + DT.Rows[0]["Mwidth"].ToString() + "см";
                                this.lblFee.Text = DT.Rows[0]["MFee"].ToString() + "¥";
                                this.lblTabuOrderNumber.Text = DT.Rows[0]["MBNO"].ToString();

                                string status_Id = DT.Rows[0]["Status_Id"].ToString();

                                if (status_Id == "6" || status_Id == "9" || status_Id == "10")
                                {
                                    //this.lstType.SelectedValue = DT.Rows[0]["Status_Id"].ToString();
                                    string sqlStr5 = "Select TOP 1 t.* from T_PackageStatus t Where t.Package_id = '" + DT.Rows[0]["ID"].ToString() + "' and t.ID = '" + DT.Rows[0]["PackageStatus_Id"].ToString() + "' order by t.id desc";
                                    DataTable DT5 = Database.ExecuteQuery(sqlStr5);
                                    if (DT5.Rows.Count > 0)
                                    {
                                        //if (DT5.Rows[0]["StatusDate"] != null)
                                           // this.dtPublish.SelectedDate = Convert.ToDateTime(DT5.Rows[0]["StatusDate"]);
                                        //this.txtDescription.Text = DT5.Rows[0]["Description"].ToString();
                                    }
                                }
                                /*
                                this.txtjin.Text = DT.Rows[0]["Mweight"].ToString();
                                this.txtTugrug.Text = DT.Rows[0]["MFee"].ToString();
                                this.txtUndur.Text = DT.Rows[0]["Mheight"].ToString();
                                this.txtUrgun.Text = DT.Rows[0]["Mwidth"].ToString();
                                this.txtUrt.Text = DT.Rows[0]["Mlenght"].ToString();
                                this.txtPackageDescription.Text = DT.Rows[0]["Description"].ToString();
                                */
                                this.btnEditPackage.Visible = true;
                                this.btnEditPackage.Enabled = false;

                                string tmpSQL1 = "SELECT t.Name as NAME, t.Brand as BRAND, t.ItemCount as ITEMCOUNT, t.ItemRate as ITEMRATE, t.SumRate as ITEMRATESUM, '1' as ISNEW FROM T_Items t Where t.Package_Id = '" + id + "' ";
                                DataTable tmpDT1 = Database.ExecuteQuery(tmpSQL1);
                                this.grdListItems.DataSource = tmpDT1;
                                this.grdListItems.DataBind();
                                /*
                                this.btnRecivePackage.Visible = true;
                                this.btnRecivePackage.Enabled = true;
                                 * */
                                this.pnlPackageStatus.Visible = true;
                                this.pnlPackageInfo.Visible = true;
                                /*
                                this.pnlRevice.Visible = true;

                                if (permission == "workermn")
                                {
                                    this.btnEditPackage.Enabled = false;
                                    this.btnEditPackage.Visible = false;
                                    this.btnRecivePackage.Enabled = false;
                                    this.btnRecivePackage.Visible = false;
                                    txtjin.Enabled = false;
                                    txtUrt.Enabled = false;
                                    txtUrgun.Enabled = false;
                                    txtUndur.Enabled = false;
                                    dtPublish.Enabled = false;
                                    dtPublish.Visible = false;
                                    lbldtPublish.Visible = false;
                                    lstType.Enabled = false;
                                    lstType.Visible = false;
                                    lblType.Visible = false;
                                    txtTugrug.Enabled = false;
                                    txtDescription.Enabled = false;
                                    txtPackageDescription.Enabled = false;
                                }*/
                            }
                            else if (permission == "user")
                            {
                                if (DT.Rows[0]["rOrderUser_Id"].ToString() == user_id)
                                {
                                    this.lblCreatedUser.Text = OrderUserName;
                                    this.lblOrderName.Text = DT.Rows[0]["rOrderName"].ToString();
                                    this.lblOrderNumber.Text = DT.Rows[0]["rOrderNumber"].ToString();
                                    this.lblReciveHuman.Text = DT.Rows[0]["getHumanName"].ToString();
                                    this.lblReviceAddress.Text = DT.Rows[0]["getHumanAddress"].ToString();
                                    this.lblRevicePhone.Text = DT.Rows[0]["getHumanPhone"].ToString();
                                    this.lblSiteName.Text = DT.Rows[0]["rOrderSiteName"].ToString();
                                    this.lblTrackingNumber.Text = DT.Rows[0]["rOrderTrackingNumber"].ToString();

                                    this.lblSale.Text = DT.Rows[0]["rTaxRate"].ToString();
                                    this.lblShiping.Text = DT.Rows[0]["rShippingRate"].ToString();
                                    this.lblDiscount.Text = DT.Rows[0]["rDiscountRate"].ToString();
                                    this.lblSumRate.Text = DT.Rows[0]["rSumRate"].ToString();

                                    this.lblJin.Text = DT.Rows[0]["Mweight"].ToString() + "кг";
                                    this.lblEzelhuun.Text = DT.Rows[0]["Mlenght"].ToString() + "см x " + DT.Rows[0]["Mheight"].ToString() + "см x " + DT.Rows[0]["Mwidth"].ToString() + "см";
                                    this.lblFee.Text = DT.Rows[0]["MFee"].ToString() + "¥";
                                    this.lblTabuOrderNumber.Text = DT.Rows[0]["MBNO"].ToString();

                                    this.btnEditPackage.Visible = true;
                                    this.btnEditPackage.Enabled = true;
                                    this.pnlPackageStatus.Visible = true;
                                    this.pnlPackageInfo.Visible = true;

                                    string tmpSQL1 = "SELECT t.Name as NAME, t.Brand as BRAND, t.ItemCount as ITEMCOUNT, t.ItemRate as ITEMRATE, t.SumRate as ITEMRATESUM, '1' as ISNEW FROM T_Items t Where t.Package_Id = '" + id + "' and user_id = '" + user_id + "'";
                                    DataTable tmpDT1 = Database.ExecuteQuery(tmpSQL1);
                                    this.grdListItems.DataSource = tmpDT1;
                                    this.grdListItems.DataBind();
                                }
                            }
                        }
                    }
                }
                else
                {
                    RadAjaxManager manager = RadAjaxManager.GetCurrent(Page);
                    manager.ResponseScripts.Add(Functions.BootstrapMessageBoxScriptBuilder("danger", "Илгээмжийн мэдээлэл олдсонгүй.", ""));
                }
            }

            string sqlStr2 = "Select t.StatusDate, upper(c.name_mn) as StatusName, t.description from T_PackageStatus t left join c_constdata c on t.Status_Id = c.id " +
                  " Where t.Package_id = '" + id + "'";
            DataTable DT1 = Database.ExecuteQuery(sqlStr2);
            if (DT1.Rows.Count > 0)
            {
                this.lstPackageStatus.DataSource = DT1;
                this.lstPackageStatus.DataBind();
                this.pnlPackageStatus.Visible = true;
            }
        }

        protected void btnEditPackage_Click(object sender, EventArgs e)
        {
            string id = Request.QueryString["v"];
            if (id != null && id != "")
            {
                if (Functions.IsInt(id))
                {
                    id = Database.SelectFieldValue("T_Package", "id", "MBno = '" + id + "' ", "id");
                    if (id != null && id != "")
                    {
                        Response.Redirect("../Pages/AddOrder.aspx?id=" + id + "");
                    }
                }
            }
        }


        protected void btnCheckStatus_Click(object sender, EventArgs e)
        {
            string whereSQL = "", messege = "";
            bool isReady = true;

            if (this.txtOrderNumber.Text != null && this.txtOrderNumber.Text != "")
                whereSQL += " lower(rOrderNumber) = N'" + this.txtOrderNumber.Text.Trim().ToLower() + "' and ";
            if (this.txtTrackingNumber.Text != null && this.txtTrackingNumber.Text != "")
                whereSQL += " lower(rOrderTrackingNumber) = N'" + this.txtTrackingNumber.Text.Trim().ToLower() + "' and ";
            if (this.txtPackageNumber.Text != null && this.txtPackageNumber.Text != "")
                whereSQL += " lower(MBno) = '" + this.txtPackageNumber.Text.Trim().ToLower() + "' and ";

            if (whereSQL != "")
            {
                string id = Database.SelectFieldValue("T_Package", "MBno", "" + whereSQL + " id is not null ", "id");
                if (id != null && id != "")
                    Response.Redirect("../Pages/Check.aspx?v=" + id);
                else
                {
                    isReady = false;
                    messege = "Илгээмжийн мэдээлэл олдсонгүй.";
                }
            }
            else
            {
                isReady = false;
                messege = "Захиалгын #Order number, Тракын дугаар, Tabu-ны илгээмжийн дугаар 3-н аль нэг утгыг оруулж Төлөв шалгах товчийг дарна уу.";
            }

            if (!isReady)
            {
                RadAjaxManager manager = RadAjaxManager.GetCurrent(Page);
                manager.ResponseScripts.Add(Functions.BootstrapMessageBoxScriptBuilder("alert", messege, ""));
            }
        }
    }
}