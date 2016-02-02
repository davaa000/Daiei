using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Daiei
{
    public partial class Calculate : System.Web.UI.Page
    {
        protected void btnCalculate_Click(object sender, EventArgs e)
        {
            double payment = 0;

            try
            {
                double jin = Double.Parse(txtJin.Text);
                double undur = Double.Parse(txtUndur.Text);
                double urgun = Double.Parse(txtUrgun.Text);
                double urt = Double.Parse(txtUrt.Text);

                payment = jin * undur * urgun * urt - jin * undur * urgun * urt % 10;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            lblPayment.Text = payment.ToString();
        }
    }
}