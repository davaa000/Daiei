using System;
using System.IO;
using System.Net;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;

namespace eClass
{
    public class Function
    {
        #region CreateForms

        public static bool CreateChildForm(System.Windows.Forms.Form childForm, System.Windows.Forms.Form parentForm)
        {
            try
            {
                if (childForm.Tag != null)
                {
                    if (Services.Security.checkForm(childForm.Tag.ToString().ToUpper(), Variables.UserInfo))
                    {
                        childForm.MdiParent = parentForm;
                        childForm.WindowState = FormWindowState.Maximized;
                        childForm.Show();
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Уучлаарай! Та хандах эрхгүй байна.", "Анхааруулга", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Уучлаарай! Энд хандах боломжгүй байна.", "Анхааруулга", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            catch (Exception Err)
            {
                MessageBox.Show("Дараахи алдаа гарлаа : " + Err.Message.ToString(), "Алдаа", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static bool CreateDialogForm(System.Windows.Forms.Form childForm)
        {
            try
            {
                if (childForm.Tag != null)
                {
                    if (Services.Security.checkForm(childForm.Tag.ToString().ToUpper(), Variables.UserInfo))
                    {
                        childForm.ShowInTaskbar = false;
                        childForm.ShowDialog();
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Уучлаарай! Та хандах эрхгүй байна.", "Анхааруулга", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Уучлаарай! Энд хандах боломжгүй байна.", "Анхааруулга", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            catch (Exception Err)
            {
                MessageBox.Show("Дараахи алдаа гарлаа : " + Err.Message.ToString(), "Алдаа", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        #endregion

        #region Set

        public static bool setLookupBoxItems(DevExpress.XtraEditors.LookUpEdit lookupEditBox, string tableName, string fieldName, string orderFieldName, string whereStr, string valueMember)
        {
            try
            {
                string SQL = "";
                SQL = "Select " + fieldName + ", " + valueMember + " From " + tableName;
                if (whereStr != "")
                    SQL += " Where " + whereStr;
                SQL += " Order By " + orderFieldName;
                DataSet ds = Services.Database.ExecuteQuery(SQL);
                ds.Tables[0].Rows.Add("");
                lookupEditBox.Properties.DataSource = ds.Tables[0];
                lookupEditBox.Properties.DisplayMember = fieldName;
                lookupEditBox.Properties.ValueMember = valueMember;
                return true;
            }
            catch (Exception Err)
            {
                MessageBox.Show("Дараахи алдаа гарлаа : " + Err.Message.ToString(), "Алдаа", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static void setLookupBoxItems(DevExpress.XtraEditors.ListBoxControl ListBox, string TableName, string FieldName, string OrderFieldName, string WhereStr, string ValueMember)
        {
            try
            {
                string SQL = "";
                SQL = "Select " + FieldName + " NAME," + ValueMember + " From " + TableName;
                if (WhereStr != "")
                    SQL += " Where " + WhereStr;
                SQL += " Order By " + OrderFieldName;
                DataSet ds = Services.Database.ExecuteQuery(SQL);
                ListBox.DataSource = ds.Tables[0];
                ListBox.DisplayMember = FieldName;
                ListBox.ValueMember = ValueMember;
                ListBox.Items.Add("");
            }
            catch (Exception Err)
            {
                MessageBox.Show("Дараахи алдаа гарлаа : " + Err.Message.ToString(), "Алдаа", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void setListbox(DevExpress.XtraEditors.ListBoxControl ListBox, string TableName, string FieldName, string OrderFieldName, string WhereStr, string ValueMember)
        {
            try
            {
                string SQL = "";
                SQL = "Select * From " + TableName;
                if (WhereStr != "")
                    SQL += " Where " + WhereStr;
                SQL += " Order By " + OrderFieldName;
                DataSet ds = Services.Database.ExecuteQuery(SQL);
                ListBox.DataSource = ds.Tables[0];
                ListBox.DisplayMember = FieldName;
                ListBox.ValueMember = ValueMember;
            }
            catch (Exception Err)
            {
                MessageBox.Show("Дараахи алдаа гарлаа : " + Err.Message.ToString(), "Алдаа", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void setComboBoxItems(DevExpress.XtraEditors.ComboBoxEdit ComboBox, string TableName, string FieldName, string OrderFieldName)
        {
            try
            {
                DataSet ds = Services.Database.ExecuteQuery("Select * From " + TableName + " Order By " + OrderFieldName);
                int i = 0;
                while (ds.Tables[0].Rows.Count > i)
                {
                    ComboBox.Properties.Items.Add(ds.Tables[0].Rows[i][FieldName].ToString());
                    i = i + 1;
                }
            }
            catch (Exception Err)
            {
                MessageBox.Show("Дараахи алдаа гарлаа : " + Err.Message.ToString(), "Алдаа", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void setCheckListBox(DevExpress.XtraEditors.CheckedListBoxControl CheckListBox, string TableName, string FieldName, string OrderFieldName, string ValueMember, string WhereStr)
        {
            try
            {
                string SQL = "Select * From " + TableName + " " + WhereStr +
                             " Order By " + OrderFieldName;
                CheckListBox.DataSource = Services.Database.ExecuteQuery(SQL).Tables[0];
                CheckListBox.DisplayMember = FieldName;
                CheckListBox.ValueMember = ValueMember;
            }
            catch (Exception Err)
            {
                MessageBox.Show("Дараахи алдаа гарлаа : " + Err.Message.ToString(), "Алдаа", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void setCheckListComboBox(DevExpress.XtraEditors.CheckedComboBoxEdit ChLstComboBox, string ConstTableName, string ConstFieldName, string ConstWhereStr, string TableName, string FieldName, string WhereStr)
        {
            string SQL = "Select " + ConstFieldName + " From " + ConstTableName;
            if (ConstWhereStr != "")
                SQL += " Where " + ConstWhereStr;
            SQL += " Order By " + ConstFieldName;
            DataSet ds = Services.Database.ExecuteQuery(SQL);
            int i = 0;
            ChLstComboBox.Properties.Items.Clear();
            ChLstComboBox.Text = "";
            while (ds.Tables[0].Rows.Count > i)
            {
                ChLstComboBox.Properties.Items.Add(ds.Tables[0].Rows[i][ConstFieldName].ToString());
                i++;
            }
            if (TableName != "")
            {
                SQL = "Select " + FieldName + " From " + TableName + " Where " + WhereStr;
                ds = Services.Database.ExecuteQuery(SQL);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    string tempName = Services.Database.SelectFieldValue(ConstTableName, ConstFieldName, "ID = " + ds.Tables[0].Rows[0][FieldName].ToString());
                    //chLstComboBox.Properties.Items[i, tempName];

                    /*if (chLstComboBox.Properties.Items[i, tempName].ToString().Trim(DelTem.ToCharArray()) == tempName)
                        chLstComboBox.Properties.Items[i].CheckState = CheckState.Checked;
                     */
                }
            }
        }

        #endregion

        #region Get

        public static string getAddress(string pAddress_ID)
        {
            string ReturnValue = "";
            try
            {
                if (pAddress_ID != null && pAddress_ID != "")
                {
                    string SQL = "Select ZipCode, General.getPlaceName(ID) PlaceName " +
                                 "From General.T_Place Where ID = '" + pAddress_ID + "'";
                    DataTable dt = Services.Database.ExecuteQuery(SQL).Tables[0];
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0]["ZipCode"].ToString() != "" && dt.Rows[0]["ZipCode"] != null)
                            ReturnValue += dt.Rows[0]["ZipCode"].ToString() + ";  ";
                        if (dt.Rows[0]["PlaceName"].ToString() != "" && dt.Rows[0]["PlaceName"] != null)
                            ReturnValue += dt.Rows[0]["PlaceName"].ToString() + ". ";
                        return ReturnValue;
                    }
                    else
                        return ReturnValue;
                }
                else
                    return ReturnValue;
            }
            catch (Exception Err)
            {
                MessageBox.Show("Дараахи алдаа гарлаа : " + Err.Message.ToString(), "Алдаа", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }
        }

        public static string getFormattedBNo(string pBNo)
        {
            if (pBNo != null && pBNo != "")
                return pBNo.Substring(0, 4) + "." + pBNo.Substring(4, 3) + "." + pBNo.Substring(7, 2) + "." + pBNo.Substring(9, 6);
            else
                return "";
        }

        public static string getFormattedDateTime(string pDate)
        {
            if (pDate != null && pDate != "")
            {
                DateTime vDate = Convert.ToDateTime(pDate);
                string year = vDate.Year.ToString("0000");
                string month = vDate.Month.ToString("00");
                string day = vDate.Day.ToString("00");

                if (month.Length == 1)
                    month = "0" + month;
                if (day.Length == 1)
                    day = "0" + day;

                string hour = vDate.Hour.ToString();
                string minute = vDate.Minute.ToString();
                string second = vDate.Second.ToString();

                if (hour.Length == 1)
                    hour = "0" + hour;
                if (minute.Length == 1)
                    minute = "0" + minute;
                if (second.Length == 1)
                    second = "0" + second;

                return year + "." + month + "." + day + " " + hour + ":" + minute + ":" + second;
            }
            else
                return "";
        }

        public static string getFormattedDate(string pDate)
        {
            if (pDate != null && pDate != "")
            {
                DateTime vDate = Convert.ToDateTime(pDate);
                string year = vDate.Year.ToString("0000");
                string month = vDate.Month.ToString("00");
                string day = vDate.Day.ToString("00");

                if (month.Length == 1)
                    month = "0" + month;
                if (day.Length == 1)
                    day = "0" + day;

                return year + "." + month + "." + day;
            }
            else
                return "";
        }

        public static string getFormattedTime(string pDate)
        {
            if (pDate != null && pDate != "")
            {
                DateTime vDate = Convert.ToDateTime(pDate);
                string hour = vDate.Hour.ToString();
                string minute = vDate.Minute.ToString();
                string second = vDate.Second.ToString();

                if (hour.Length == 1)
                    hour = "0" + hour;
                if (minute.Length == 1)
                    minute = "0" + minute;
                if (second.Length == 1)
                    second = "0" + second;

                return hour + ":" + minute + ":" + second;
            }
            else
                return "";
        }

        public static string getFormattedShortTime(string pDate)
        {
            if (pDate != null && pDate != "")
            {
                DateTime vDate = Convert.ToDateTime(pDate);
                string hour = vDate.Hour.ToString();
                string minute = vDate.Minute.ToString();

                if (hour.Length == 1)
                    hour = "0" + hour;
                if (minute.Length == 1)
                    minute = "0" + minute;

                return hour + ":" + minute;
            }
            else
                return "";
        }

        public static string getFormattedCurrency(string pCurrency)
        {
            if (pCurrency != "" && pCurrency != "0")
            {
                decimal Cur = Convert.ToDecimal(pCurrency);
                return string.Format("{0:#,#.00}", Cur);
            }
            else
                return "";
        }

        public static string getNewUserName(string Heltes_ID)
        {
            try
            {
                string NewUserName = Services.Database.SelectFieldValue("SystemUser.T_SystemUser", "Max(UserName)", "SubStr(UserName, 3, 5) = SubStr('" + Heltes_ID + "', 1, 5)");
                if (NewUserName != "")
                {
                    int Dugaar = Convert.ToInt16(Convert.ToString(NewUserName[9]) + Convert.ToString(NewUserName[10])) + 1;
                    string strDugaar = Dugaar.ToString();
                    if (strDugaar.Length == 1)
                        strDugaar = "0" + strDugaar;
                    NewUserName = "pu" + Heltes_ID + strDugaar;
                    return NewUserName;
                }
                else
                    return "pu" + Heltes_ID + "01";
            }
            catch (Exception ex)
            {
                Services.Security.setError(Services.error(ex), Variables.UserInfo, null);
                return "";
            }
        }

        public static string getPlaceName(DataTable Table, string Place_ID)
        {
            if (Place_ID != "")
            {
                if (Services.Database.SelectFieldValue("General.T_Place", "ID", "ID = " + Place_ID) != null)
                    return Services.Database.SelectFieldValue("Dual", "General.getPlaceName('" + Place_ID + "')", "");
                else
                    return getPlaceDataTable(Table, Place_ID);
            }
            else
                return "";
        }

        public static string getPlaceDataTable(DataTable Table, string Place_ID)
        {
            string Result = "";
            DataRow[] foundRows = Table.Select("ID = " + Place_ID);
            if (foundRows[0]["ZipCode"] != null && foundRows[0]["ZipCode"].ToString() != "")
            {
                Result = foundRows[0]["ZipCode"].ToString();
                Result += ", " + Services.Database.SelectFieldValue("Dual", "ConstData.getZipCodeState(" + foundRows[0]["ZipCode"].ToString() + ")", "").Trim();
            }
            if (foundRows[0]["Horoo"] != null && foundRows[0]["Horoo"].ToString() != "")
                Result += ", " + foundRows[0]["Horoo"].ToString() + "-р хороо";
            if (foundRows[0]["MicroDistrict"] != null && foundRows[0]["MicroDistrict"].ToString() != "")
                Result += ", " + foundRows[0]["MicroDistrict"].ToString();
            if (foundRows[0]["Apartment"] != null && foundRows[0]["Apartment"].ToString() != "")
                Result += ", " + foundRows[0]["Apartment"].ToString() + "-р байр";
            if (foundRows[0]["Entrance"] != null && foundRows[0]["Entrance"].ToString() != "")
                Result += ", " + foundRows[0]["Entrance"].ToString() + " орц";
            if (foundRows[0]["Floor"] != null && foundRows[0]["Floor"].ToString() != "")
                Result += ", " + foundRows[0]["Floor"].ToString() + " давхар";
            if (foundRows[0]["Door"] != null && foundRows[0]["Door"].ToString() != "")
                Result += ", " + foundRows[0]["Door"].ToString() + " тоот";
            if (foundRows[0]["ZamiinBairshil_ID"] != null && foundRows[0]["ZamiinBairshil_ID"].ToString() != "")
                Result += ", " + Services.Database.SelectFieldValue("ConstData.ZamiinBairshil", "Name", "ID = '" + foundRows[0]["ZamiinBairshil_ID"].ToString() + "'");

            if (foundRows[0]["Place_Type"] != null && foundRows[0]["Place_Type"].ToString() != "")
                Result += ", " + Services.Database.SelectFieldValue("General.C_Place_Type", "Name", "ID = '" + foundRows[0]["Place_Type"].ToString() + "'");

            if (foundRows[0]["Undefined"] != null && foundRows[0]["Undefined"].ToString() != "")
                Result += ", " + foundRows[0]["Undefined"].ToString();

            return Result;
        }

        public static string getAANDataTable(DataTable Table, string AAN_ID, DevExpress.XtraGrid.GridControl GridName)
        {
            string Result = "";
            GridName.DataSource = Table.DataSet;
            //DataRow[] foundRows = Table.Select("ID = " + AAN_ID);
            return Result;
        }

        public static string getComplaintInfoByBno(string BNo, ref string Complaint_ID)
        {
            string Result = "", Archive = "";

            string BNoHistory_ID = Services.Database.SelectFieldValue("Complaint.vw1100", "Max(BNoHistory_ID)", "BNo = '" + BNo.Replace("-", "") + "'");
            Archive = Services.Database.SelectFieldValue("Complaint.vw1100", "Archive", "BNoHistory_ID = '" + BNoHistory_ID + "'");

            if (Archive == "N")
            {
                if (BNo.Substring(0, 4) == "1100")
                {
                    Result = Services.Database.SelectFieldValue("Complaint.vw1100", "Worker ||', '|| To_Char(Recieved, 'yyyy.mm.dd') ||' '|| Content", "BNoHistory_ID = '" + BNoHistory_ID + "'");
                    Complaint_ID = Services.Database.SelectFieldValue("Complaint.vw1100", "ID", "BNoHistory_ID = '" + BNoHistory_ID + "'");
                }
            }
            else if (Archive == "Y")
                Result = "ARCHIVE";
            return Result;
        }

        #endregion

        #region Fill

        /*public static void FillMainBurtgel()
        {
            DataTable dt = DBService.ExecuteQuery("Select * From MainBurtgel.vwBNo Where ID = '" + BNo_ID + "'").Tables[0];
            if (dt.Rows.Count > 0)
            {
                this.txtBNo.Text = dt.Rows[0]["FormattedBNo"].ToString();
                this.txtTTBWorker.Text = dt.Rows[0]["TTBWorker"].ToString();
                this.txtBWorker.Text = dt.Rows[0]["BWorker"].ToString();
                this.txtWorker.Text = dt.Rows[0]["Worker"].ToString();
                this.txtTTBOgnoo.Text = dt.Rows[0]["TTBOgnoo"].ToString();
                this.txtBOgnoo.Text = dt.Rows[0]["BOgnoo"].ToString();
                this.txtWrited.Text = dt.Rows[0]["Writed"].ToString();
                this.txtReported.Text = dt.Rows[0]["Reported"].ToString();
                this.txtCreatedDate.Text = dt.Rows[0]["CreatedDate"].ToString();
                this.txtTTBDescription.Text = dt.Rows[0]["TTBDescription"].ToString();
                this.txtTuluv.Text = dt.Rows[0]["TTBStatus"].ToString();
            }
        }*/

        #endregion

        #region Refresh Patrol Grid

        public static void getPatrolListGrid(string FormName, DevExpress.XtraGrid.GridControl gridName, string ViewName, string WhereStr)
        {
            try
            {
                string SQL = "";
                SQL = "Select * From " + ViewName + " Where ";
                if (WhereStr != "" && WhereStr != null)
                    SQL += WhereStr;
                SQL += "(" + Services.Security.whereSqlAllPermission(FormName.ToUpper(), Variables.UserInfo) + ")";
                gridName.DataSource = Services.Database.ExecuteQuery(SQL).Tables[0];
            }
            catch (Exception Err)
            {
                MessageBox.Show("Алдаа гарлаа : " + Err.Message.ToString(), "Алдаа", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void getPatrolGrid(DevExpress.XtraGrid.GridControl pGridName, string pID)
        {
            try
            {
                string SQL = "";
                if (pID != "" && pGridName.Name != null && pGridName.Name.ToString() != "")
                {
                    if (pGridName.Name == "grdHuman")
                    {
                        SQL = "Select vwHuman.*, General.getPlaceName(Address_ID) Address From General.vwHuman Where ID = '" + pID + "'";
                        pGridName.DataSource = Services.Database.ExecuteQuery(SQL).Tables[0];
                    }

                    if (pGridName.Name == "grdLawImplement")
                    {
                        SQL = "Select * From Patrol.vwLawImplement Where Register = '" + pID + "'";
                        pGridName.DataSource = Services.Database.ExecuteQuery(SQL).Tables[0];
                    }

                    if (pGridName.Name == "Bayajilt")
                    {
                        SQL = "Select ID From Patrol.T_Bayajilt Where MainBurtgel_ID = '" + pID + "'";
                        DataSet dsBayajilt = Services.Database.ExecuteQuery(SQL);
                        if (dsBayajilt.Tables[0].Rows.Count > 0)
                        {
                            //this.btnListBayajilt.Visible = true;
                        }
                    }
                }
            }
            catch (Exception Err)
            {
                MessageBox.Show("Алдаа гарлаа : " + Err.Message.ToString(), "Алдаа", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void getGridAAN(DevExpress.XtraGrid.GridControl pGridName, string pID)
        {
            try
            {
                string SQL = "";
                if (pID != "")
                {
                    if (pGridName.Name == "grdAAN")
                    {
                        if (Services.Database.SelectFieldValue("Patrol.vwAAN", "ID", "ID = " + pID) != null)
                        {
                            SQL = "Select * From Patrol.vwAAN Where ID = " + pID;
                            pGridName.DataSource = Services.Database.ExecuteQuery(SQL).Tables[0];
                        }
                        /*else
                            Function.getAANDataTable(LocalValues.AANDataTable, pID, pGridName);*/
                    }

                    if (pGridName.Name == "grdStandartZuvshuurul")
                    {
                        SQL = "Select * From Patrol.vwStandart Where ID = " + pID;
                        pGridName.DataSource = Services.Database.ExecuteQuery(SQL).Tables[0];
                    }

                    if (pGridName.Name == "Bayajilt")
                    {
                        SQL = "Select ID From Patrol.T_Bayajilt Where MainBurtgel_ID = " + pID;
                        DataSet dsBayajilt = Services.Database.ExecuteQuery(SQL);
                        if (dsBayajilt.Tables[0].Rows.Count > 0)
                        {
                            //this.btnListBayajilt.Visible = true;
                        }
                    }
                }
            }
            catch (Exception Err)
            {
                MessageBox.Show("Алдаа гарлаа : " + Err.Message.ToString(), "Алдаа", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void getGridCrime(DevExpress.XtraGrid.GridControl pGridName, string pID)
        {
            string SQL = "Select * From Patrol.vwCrime Where Human_ID = " + pID;
            pGridName.DataSource = Services.Database.ExecuteQuery(SQL).Tables[0];
        }

        #endregion

        public static void SaveCheckListBox(DevExpress.XtraEditors.CheckedListBoxControl CheckListBox, string Tablename, string LinkFieldvalue, string LinkFieldName, string FieldName, string KeyFieldName, string SeqName, SecurityService.UserInfo userInfo, ref List<string> SqlList)
        {
            try
            {
                if (LinkFieldvalue != null)
                {
                    SqlList.Add("Delete " + Tablename + " Where " + LinkFieldName + " = '" + LinkFieldvalue + "'");
                    int i = 0;

                    while (i < CheckListBox.ItemCount)
                    {
                        if (CheckListBox.GetItemCheckState(i) == CheckState.Checked)
                        {
                            string ID = "";
                            string[] fields = { LinkFieldName, FieldName, LinkFieldvalue, CheckListBox.GetItemValue(i).ToString() };

                            SqlList.Add(Services.Database.SaveTableData(Tablename, KeyFieldName, ref ID, SeqName, userInfo.LoginUserName, fields));
                        }
                        i = i + 1;
                    }
                }
            }
            catch (Exception Err)
            {
                MessageBox.Show("Дараахи алдаа гарлаа : " + Err.Message.ToString(), "Алдаа", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static bool SaveCheckComboBox(DevExpress.XtraEditors.CheckedComboBoxEdit chLstComboBox, string TableName, string LinkFieldValue, string LinkFieldName, string SeqName, string ConstTableName, string ConstFieldName, SecurityService.UserInfo userInfo, ref List<string> SqlList)
        {
            try
            {
                if (LinkFieldValue != null)
                {
                    SqlList.Add("Delete " + TableName + " Where " + LinkFieldName + " = '" + LinkFieldValue + "'");
                    string TempName = "", Temp_ID = "", DelTem = ",", ID = "";
                    for (int i = 0; i < chLstComboBox.Properties.Items.Count; i++)
                        if (chLstComboBox.Properties.Items[i].CheckState == CheckState.Checked)
                        {
                            TempName = chLstComboBox.Properties.Items[i].ToString().Trim(DelTem.ToCharArray());
                            Temp_ID = Services.Database.SelectFieldValue(ConstTableName, "ID", "Name = '" + TempName + "'");
                            string[] Fields = { LinkFieldName, ConstFieldName, LinkFieldValue, Temp_ID };
                            SqlList.Add(Services.Database.SaveTableData(TableName, "ID", ref ID, SeqName, userInfo.LoginUserName, Fields));
                        }
                    return true;
                }
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        public static bool FindRegister(DevExpress.XtraEditors.TextEdit Register, DevExpress.XtraEditors.TextEdit FamilyName, DevExpress.XtraEditors.TextEdit LastName, DevExpress.XtraEditors.TextEdit FirstName, DevExpress.XtraEditors.TextEdit Age, DevExpress.XtraEditors.DateEdit BOD, DevExpress.XtraEditors.ComboBoxEdit Sex)
        {
            try
            {
                if (Register.Text != "__________" && Register.Text != "")
                {
                    string SQL = null;
                    SQL = "Select ForeName, SurName, Given_Name GivenName, Sex_Name, Age, To_Char(BirthDate, 'yyyy.mm.dd') bDay " +
                          "From Register.TBL_Register " +
                          "Where Register_Num = '" + Register.Text + "'";
                    DataSet dsRegister = Services.Database.ExecuteQuery(SQL);
                    if (dsRegister.Tables[0].Rows.Count > 0)
                    {
                        FamilyName.Text = dsRegister.Tables[0].Rows[0]["ForeName"].ToString();
                        LastName.Text = dsRegister.Tables[0].Rows[0]["SurName"].ToString();
                        FirstName.Text = dsRegister.Tables[0].Rows[0]["GivenName"].ToString();
                        Age.Text = dsRegister.Tables[0].Rows[0]["Age"].ToString();
                        BOD.Text = dsRegister.Tables[0].Rows[0]["bDay"].ToString();
                        Sex.Text = dsRegister.Tables[0].Rows[0]["Sex_Name"].ToString();
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Регистр олдсонгүй.", "Мэдээлэл", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                }
                return false;
            }
            catch (Exception Err)
            {
                MessageBox.Show("Дараахи алдаа гарлаа : " + Err.Message.ToString(), "Алдаа", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static void CopyList(ref List<string> MainList, List<string> LocalList)
        {
            if (LocalList.Count > 0)
                for (int i = 0; LocalList.Count - 1 >= i; i++)
                    MainList.Add(LocalList[i]);
        }

        public static void CreatePlaceDataTable(DataTable Table)
        {
            Table.Columns.Add("ID", typeof(string));
            Table.Columns.Add("ZipCode", typeof(string));
            Table.Columns.Add("Horoo", typeof(string));
            Table.Columns.Add("MicroDistrict", typeof(string));
            Table.Columns.Add("Apartment", typeof(string));
            Table.Columns.Add("Entrance", typeof(string));
            Table.Columns.Add("Floor", typeof(string));
            Table.Columns.Add("Door", typeof(string));
            Table.Columns.Add("ZamiinBairshil_ID", typeof(string));
            Table.Columns.Add("Place_Type", typeof(string));
            Table.Columns.Add("Undefined", typeof(string));
            Table.Columns.Add("Longitude", typeof(string));
            Table.Columns.Add("Latitude", typeof(string));
        }

        public static void CreateAANDataTable(DataTable Table)
        {
            Table.Columns.Add("ID", typeof(string));
            Table.Columns.Add("DUGAAR", typeof(string));
            Table.Columns.Add("BAIGUULAGDSAN", typeof(DateTime));
            Table.Columns.Add("NAME", typeof(string));
            Table.Columns.Add("ADDRESS", typeof(string));
            Table.Columns.Add("ZAHIRALFULLNAME", typeof(string));
            Table.Columns.Add("COUNTRY_ID", typeof(string));
            Table.Columns.Add("HURUNGUORUULALT", typeof(string));
            Table.Columns.Add("DESCRIPTION", typeof(string));
        }

        public static void InsertPlaceDataTable(DataTable Table, string Place_ID, string ZipCode, string Horoo, string MicroDistrict, string Apartment, string Entrance, string Floor, string Door, string ZamiinBairshil_ID, string PlaceType, string Undefined, string Longitude, string Latitude)
        {
            DataRow[] foundRows = Table.Select("ID = " + Place_ID);
            if (foundRows.Length > 0)
            {
                foundRows[0]["ID"] = Place_ID;
                foundRows[0]["ZipCode"] = ZipCode;
                foundRows[0]["Horoo"] = Horoo;
                foundRows[0]["MicroDistrict"] = MicroDistrict;
                foundRows[0]["Apartment"] = Apartment;
                foundRows[0]["Entrance"] = Entrance;
                foundRows[0]["Floor"] = Floor;
                foundRows[0]["Door"] = Door;
                foundRows[0]["ZamiinBairshil_ID"] = ZamiinBairshil_ID;
                foundRows[0]["Place_Type"] = PlaceType;
                foundRows[0]["Undefined"] = Undefined;
                foundRows[0]["Longitude"] = Longitude;
                foundRows[0]["Latitude"] = Latitude;
            }
            else
            {
                DataRow dtRow = Table.NewRow();
                dtRow["ID"] = Place_ID;
                dtRow["ZipCode"] = ZipCode;
                dtRow["Horoo"] = Horoo;
                dtRow["MicroDistrict"] = MicroDistrict;
                dtRow["Apartment"] = Apartment;
                dtRow["Entrance"] = Entrance;
                dtRow["Floor"] = Floor;
                dtRow["Door"] = Door;
                dtRow["ZamiinBairshil_ID"] = ZamiinBairshil_ID;
                dtRow["Place_Type"] = PlaceType;
                dtRow["Undefined"] = Undefined;
                dtRow["Longitude"] = Longitude;
                dtRow["Latitude"] = Latitude;
                Table.Rows.Add(dtRow);
            }
        }

        public static void InsertAANDataTable(DataTable Table, string AAN_ID, DateTime Baiguulagdsan, string Dugaar, string AANName, string Address_ID, string Director_ID, string Country_ID, string HurunguOruulalt, string Description)
        {
            DataRow dtRow = Table.NewRow();

            dtRow["ID"] = AAN_ID;
            dtRow["DUGAAR"] = Dugaar;
            dtRow["BAIGUULAGDSAN"] = Baiguulagdsan;
            dtRow["NAME"] = AANName;
            dtRow["ADDRESS"] = Address_ID;
            dtRow["ZAHIRALFULLNAME"] = Director_ID;
            dtRow["COUNTRY_ID"] = Country_ID;
            dtRow["HURUNGUORUULALT"] = HurunguOruulalt;
            dtRow["DESCRIPTION"] = Description;

            Table.Rows.Add(dtRow);
        }

        public static void CheckCheckListBox(DevExpress.XtraEditors.CheckedListBoxControl checkListBox, string tableName, string fieldName, string whereStr)
        {
            int i = 0;
            while (i < checkListBox.ItemCount)
            {
                checkListBox.SetItemCheckState(i, ((Services.Database.SelectFieldValue(tableName, fieldName, whereStr + checkListBox.GetItemValue(i).ToString() + "'") != null) ? CheckState.Checked : CheckState.Unchecked));
                i = i + 1;
            }
        }

        public static bool CheckComplaintShiidOgnoo(string M1100_ID, DateTime Date, ref string Message, string WorkHistoryID)
        {
            if (M1100_ID != "" && M1100_ID != null)
            {
                if (Date != null && Services.Database.SelectFieldValue("Complaint.vw1100", "ID", "ID = '" + M1100_ID + "' And Recieved < " + Services.Other.convertDate(Date) + " + 1 And WorkHistory_ID = '" + WorkHistoryID + "'") != null)
                    return true;
                else
                {
                    string Recieved = Services.Database.SelectFieldValue("Complaint.vw1100", "To_Char(Recieved, 'yyyy.mm.dd')", "ID = '" + M1100_ID + "'");
                    if (Date != null && Services.Database.SelectFieldValue("Complaint.vw1100", "ID", "ID = '" + M1100_ID +
                     "' And Recieved < " + Services.Other.convertDate(Date) + "+1") == null)
                        Message = "Өргөдөл гомдлыг " + Recieved + "-нд хүлээн авсан байна. Та эрүүгийн хэрэг үүсгэсэн огноо эсэхүл Захиргаан зөрчил шийдвэрлэсэн эсэхүл торгосон огноог шалгана уу";
                    else
                        Message = "Өргөдөл гомдлыг шийдвэрлэж буй ажилтан шалгаж буй ажилтан биш байна.";
                    return false;
                }
            }
            else
                return true;
        }

        public static bool DelMainBurtgel(DevExpress.XtraGrid.Views.Grid.GridView grd)
        {
            bool ReturnValue = false;
            try
            {
                if (Services.Security.checkForm("DELETE_CARD", Variables.UserInfo))
                {
                    if (grd.SelectedRowsCount > 0)
                    {
                        if (MessageBox.Show("Мэдээллийг устгах уу?", "Анхааруулга", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            DataRow Row = grd.GetDataRow(grd.FocusedRowHandle);
                            if (Row["BNoHistory_ID"] != null && Row["BNoHistory_ID"].ToString() != "")
                            {
                                string SQL = "Update MainBurtgel.T_BNoHistory Set Archive = 'Y' Where ID = '" + Row["BNoHistory_ID"].ToString() + "'";
                                if (Services.Database.ExecuteNonQueryStr(SQL))
                                    ReturnValue = true;
                                else
                                    ReturnValue = false;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Мэдээлэл сонгоно уу!", "Алдаа", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        ReturnValue = false;
                    }
                }
                else
                    MessageBox.Show("Уучлаарай! Та хандах эрхгүй байна.", "Анхааруулга", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception Err)
            {
                MessageBox.Show("Дараахи алдаа гарлаа : " + Err.Message.ToString(), "Алдаа", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ReturnValue = false;
            }
            return ReturnValue;
        }

        public static void getReport(string SQL, string AliasName, string FolderName, string FileName)
        {
            FastReport.Report report = new FastReport.Report();
            try
            {
                if (Function.FTPDownload(@"C:\Report/" + FolderName, FolderName, FileName))
                {
                    DataTable dt = Services.Database.ExecuteQuery(SQL).Tables[0];

                    report.RegisterData(dt, AliasName);
                    report.GetDataSource(AliasName).Enabled = true;
                    report.Load(@"C:\Report/" + FolderName + "/" + FileName);
                    report.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Дараахи алдаа гарлаа. " + ex.Message.ToString(), "Алдаа", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                report.Dispose();
            }
        }

        public static bool FTPDownload(string filePath, string folderName, string fileName)
        {
            FtpWebRequest reqFTP;
            try
            {
                if (System.IO.Directory.Exists(filePath) == false)
                    System.IO.Directory.CreateDirectory(filePath);

                FileStream outputStream = new FileStream(filePath + "\\" + fileName, FileMode.Create);

                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://10.10.20.10/Report/" + folderName + "/" + fileName));
                reqFTP.Method = WebRequestMethods.Ftp.DownloadFile;
                reqFTP.UseBinary = true;
                reqFTP.Credentials = new NetworkCredential("ftpuser", "allforyou");
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                Stream ftpStream = response.GetResponseStream();
                long cl = response.ContentLength;
                int bufferSize = 2048;
                int readCount;
                byte[] buffer = new byte[bufferSize];

                readCount = ftpStream.Read(buffer, 0, bufferSize);
                while (readCount > 0)
                {
                    outputStream.Write(buffer, 0, readCount);
                    readCount = ftpStream.Read(buffer, 0, bufferSize);
                }
                ftpStream.Close();
                outputStream.Close();
                response.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
    }
}
