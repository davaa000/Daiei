using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Daiei
{
    public partial class Home : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Database.UserID == null)
                {
                    Response.Redirect("../Pages/GuestHome.aspx");
                }
                else
                {
                    try
                    {
                        DataTable DT;
                        string sqlStr1 = "Select t.* from t_user t Where t.id = '" + Database.UserID + "'";
                        DT = Database.ExecuteQuery(sqlStr1);
                        if (DT.Rows.Count > 0)
                        {
                            lblUserID.Text = DT.Rows[0]["code"].ToString();
                            lblUserID2.Text = DT.Rows[0]["code"].ToString();
                            lblFirstName.Text = DT.Rows[0]["firstname"].ToString();
                            lblLastName.Text = DT.Rows[0]["lastname"].ToString();
                            lblEmail.Text = DT.Rows[0]["email"].ToString();
                            lblMNPhone.Text = DT.Rows[0]["phonemn"].ToString();
                            lblJPPhone.Text = DT.Rows[0]["phonejp"].ToString();
                            lblMNAddress.Text = DT.Rows[0]["addressmn"].ToString();
                            lblJPAddress.Text = DT.Rows[0]["addressjp"].ToString();
                        }
                        else
                        {

                        }

                        string sqlStr2 = "Select t.* from t_Package t Where t.CreatedUser = '" + Database.UserID + "'";
                        DT = Database.ExecuteQuery(sqlStr2);
                        lblOrderCount.Text = DT.Rows.Count.ToString();


                        string sqlStr3 = "Select upper(t.MBno) MBno, strftime('%d-%m-%Y %H:%M', t.CreatedDate) CreatedDate from T_Package t Where t.CreatedUser = '" + Database.UserID + "' Order By t.id Desc LIMIT 5";
                        DT = Database.ExecuteQuery(sqlStr3);
                        if (DT.Rows.Count > 0)
                        {
                            this.listPackages.DataSource = DT;
                            this.listPackages.DataBind();
                            this.listPackages.Visible = true;
                        }

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }
    }
}