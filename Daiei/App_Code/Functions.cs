using System;
using System.Data;
using System.Web;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using Telerik.Web.UI;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Net;
//using System.Web.Mail;

namespace Daiei
{
    public class Functions
    {
        
        public static bool SendEmail(string subject, string content, string toMail)
        {
            // Create the msg object to be sent

            MailMessage msg = new MailMessage();
            try
            {
                // Add your email address to the recipients
                msg.To.Add(toMail);
                // Configure the address we are sending the mail from
                MailAddress address = new MailAddress("tabi@tabi.mn");
                msg.From = address;
                msg.Subject = subject;
                msg.Body = content;

                SmtpClient client = new SmtpClient();
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Host = "smtpout.asia.secureserver.net";
                client.Port = 3535;
                client.Credentials = new System.Net.NetworkCredential(
                    "tabi@tabi.mn", "tabiadmin");

                // Send the msg
                client.Send(msg);

                return true;
            }
            catch(Exception ex){
                throw ex;

            }

            
        }
        
        /*
        public static bool SendEmail(string subject, string content, string toMail)
        {

            MailMessage message = new MailMessage();
            SmtpClient smtpClient = new SmtpClient();
            string msg = string.Empty;
            try
            {
                MailAddress fromAddress = new MailAddress("chukaachukaa@gmail.com");
                message.From = fromAddress;
                message.To.Add(toMail);
                

                message.Subject = subject;
                message.IsBodyHtml = true;
                message.Body = content;
                // We use gmail as our smtp client
                smtpClient.Host = "smtp.gmail.com";
                smtpClient.Port = 25;
                smtpClient.EnableSsl = true;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.UseDefaultCredentials = true;
                smtpClient.Credentials = new System.Net.NetworkCredential(
                    "chukaachukaa@gmail.com", "adyajav23");

                smtpClient.Send(message);
                return true;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return false;
        }
        */
        /*
        public static bool SendEmail(string subject, string content, string toMail)
        {
            try
            {
                //Create the msg object to be sent
                MailMessage msg = new MailMessage();
                //Add your email address to the recipients
                msg.To.Add(toMail);
                //Configure the address we are sending the mail from
                MailAddress address = new MailAddress("chuluunsukh.b@kawano.mn");
                msg.From = address;
                msg.Subject = subject;
                msg.Body = content;

                //Configure an SmtpClient to send the mail.            
                SmtpClient client = new SmtpClient();
                //client.DeliveryMethod = SmtpDeliveryMethod.Network;
                //client.EnableSsl = true;
                //client.Host = "smtp.gmail.com";
                client.Port = 25;
                client.Host = "relay-hosting.secureserver.net";

                //Setup credentials to login to our sender email address ("UserName", "Password")
                NetworkCredential credentials = new NetworkCredential("chuluunsukh.b@kawano.mn", "Qbi7h41#");
                client.UseDefaultCredentials = true;
                client.Credentials = credentials;

                //Send the msg
                client.Send(msg);

                //Display some feedback to the user to let them know it was sent
                return true;
                //lblResult.Text = "Your message was sent!";
            }
            catch (Exception ex)
            {
                //If the message failed at some point, let the user know
                throw ex;
                return false;
                //lblResult.Text = ex.ToString();
                //"Your message failed to send, please try again."
            }
        }
         
        */
        /*
        public static bool SendEmail(string subject, string bodytext, string toMail)
        {
            try
            {

                MailMessage msg = new MailMessage();
                msg.Body = bodytext;


                
                string smtpServer = "mail.kawano.mn";
                string userName = "davaa.d@kawano.mn";
                string password = "n0Pkv4@9";
                int cdoBasic = 1;
                int cdoSendUsingPort = 2;
                if (userName.Length > 0)
                {
                    msg.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserver", smtpServer);
                    msg.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserverport", 25);
                    msg.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusing", cdoSendUsingPort);
                    msg.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", cdoBasic);
                    msg.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", userName);
                    msg.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", password);
                }
                msg.To = toMail;
                msg.From = "davaa.d@kawano.mn";
                msg.Subject = subject;
                msg.BodyEncoding = System.Text.Encoding.UTF8;
                SmtpMail.SmtpServer = smtpServer;
                SmtpMail.Send(msg);
                
                
                const string SERVER = "relay-hosting.secureserver.net";
                MailMessage oMail = new System.Web.Mail.MailMessage();
                oMail.From = "davaa.d@kawano.mn";
                oMail.To = toMail;
                oMail.Subject = subject;
                oMail.BodyFormat = MailFormat.Html;// enumeration
                oMail.Priority = MailPriority.High;// enumeration
                oMail.Body = "Sent at: " + DateTime.Now+"\r\n"+bodytext;
                SmtpMail.SmtpServer = SERVER;
                SmtpMail.Send(oMail);
                oMail = null;// free up resources
                
                return true;
            }
            catch(Exception ex) {
                throw ex;
                return false;
            }

        }
        
        */
        /*
        public static bool SendEmail(string subject, string content, string recipient)
        {
            if (recipient == null || recipient == "")
                throw new ArgumentException("recipients");

            var mailClient = new System.Net.Mail.SmtpClient
            {
                Host = "mail.kawano.mn",
                Port = 25,
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new System.Net.NetworkCredential("chuluunsukh.b@kawano.mn", "Qbi7h41#")
            };
            var msg = new System.Net.Mail.MailMessage("chuluunsukh.b@kawano.mn", recipient, subject, content);
            try
            {

                mailClient.Send(msg);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
                // TODO: Handle the exception
                return false;
            }
        }
        */

        public static DataTable ReadDataTableFromSession(string sessionName)
        {
            if (sessionName != null && sessionName != "" && (HttpContext.Current.Session[sessionName] as DataTable) != null)
                return (DataTable)HttpContext.Current.Session[sessionName];
            else
                return null;
        }

        public static void SaveDataTableToSession(DataTable dt, string sessionName)
        {
            if (dt != null)
                HttpContext.Current.Session[sessionName] = dt;
        }

        public static string MD5(string password)
        {
            byte[] textBytes = System.Text.Encoding.Default.GetBytes(password);
            try
            {
                System.Security.Cryptography.MD5CryptoServiceProvider cryptHandler;
                cryptHandler = new System.Security.Cryptography.MD5CryptoServiceProvider();
                byte[] hash = cryptHandler.ComputeHash(textBytes);
                string ret = "";
                foreach (byte a in hash)
                {
                    if (a < 16)
                        ret += "0" + a.ToString("x");
                    else
                        ret += a.ToString("x");
                }
                return ret;
            }
            catch
            {
                throw;
            }
        }

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabsdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        /*public static string getSystemDate(string Ognoo)
        {
            string SQL = "Select To_Char(SysDate, 'YYYY') Year, To_Char(SysDate, 'YY') ShortYear, To_Char(Sysdate,'MM') Month, " +
                         "To_Char(SysDate,'DD') Day, To_Char(SysDate, 'HH24') Hour, To_Char(SysDate,'MI') Min, " +
                         "To_Char(SysDate,'SS') Sec, To_Char(SysDate, 'YYYY.MM.DD') Ognoo,  To_Char(SysDate, 'YYYY.MM.DD HH24:MI:SS') FullOgnoo " +
                         "From Dual";
            DataSet ds = Services.Database.ExecuteQuery(SQL);
            return ds.Tables[0].Rows[0][Ognoo].ToString();
        }  */
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

        public static string convertDateTime(DateTime date)
        {
            if (date != null)
            {
                string year = date.Year.ToString("0000");
                string month = date.Month.ToString("00");
                string day = date.Day.ToString("00");

                string hour = date.Hour.ToString();
                string minute = date.Minute.ToString();
                string second = date.Second.ToString();

                return "" + year + "." + month + "." + day + " " + hour + ":" + minute + ":" + second + "";

                //Oralce return "to_date('" + year + "." + month + "." + day + " " + hour + ":" + minute + ":" + second + "','yyyy.mm.dd HH24:MI:SS')";
            }
            else
                return "null";
        }

        public static string convertDate(DateTime date)
        {
            if (date != null)
            {
                string year = date.Year.ToString("0000");
                string month = date.Month.ToString("00");
                string day = date.Day.ToString("00");
                return "dateTime(" + year + "." + month + "." + day + ")";
                //Oracle return "to_date('" + year + "." + month + "." + day + "','yyyy.mm.dd')";
            }
            else
                return "null";
        }

        public static string StripHtmlTags(string text, string mode)
        {
            string stringPattern = "";
            mode = mode.ToLower().Trim();
            if (mode == "default")
            {
                mode = "p|br|b|strong|ul|ol|li";
                stringPattern = @"</?(?(?=" + mode + @")notag|[a-zA-Z0-9]+)(?:\s[a-zA-Z0-9\-]+=?(?:(["",']?).*?\1?)?)*\s*/?>";
            }
            else if (mode == "all")
                stringPattern = @"<[^>]*>";
            return Regex.Replace(text, stringPattern, string.Empty);
        }

        public static void SetDropDownLisValue(System.Web.UI.WebControls.DropDownList ddl, string TableName, string TextField, string ValueField, string WhereSql, string OrderFldName, bool isVisibleNullRow)
        {
            string Sql = "";
            if (TextField.ToUpper() == ValueField.ToUpper())
                Sql = "Select " + ValueField + " From " + TableName;
            else
                Sql = "Select " + TextField + "," + ValueField + " From " + TableName;
            if (WhereSql != "")
                Sql += " Where " + WhereSql;
            Sql += " Order By " + OrderFldName;
            DataTable ds = Database.ExecuteQuery(Sql);
            ddl.DataTextField = TextField;
            ddl.DataValueField = ValueField;
            ddl.DataSource = ds;
            ddl.DataBind();

            if (isVisibleNullRow)
            {
                System.Web.UI.WebControls.ListItem li = new System.Web.UI.WebControls.ListItem(" ", "");
                ddl.Items.Add(li);
                li.Selected = true;
            }
        }

        public static void SetDropDownLisValueMergeField(System.Web.UI.WebControls.DropDownList ddl, string TableName, string MergeFields, string TextField, string ValueField, string WhereSql, string OrderFldName, bool isVisibleNullRow)
        {
            string Sql = "";
            if (TextField.ToUpper() == ValueField.ToUpper())
                Sql = "Select " + ValueField + " From " + TableName;
            else
                Sql = "Select " + MergeFields + "," + ValueField + " From " + TableName;
            if (WhereSql != "")
                Sql += " Where " + WhereSql;
            Sql += " Order By " + OrderFldName;
            DataTable ds = Database.ExecuteQuery(Sql);
            ddl.DataTextField = TextField;
            ddl.DataValueField = ValueField;
            ddl.DataSource = ds;
            ddl.DataBind();

            if (isVisibleNullRow)
            {
                System.Web.UI.WebControls.ListItem li = new System.Web.UI.WebControls.ListItem(" ", "");
                ddl.Items.Add(li);
                li.Selected = true;
            }
        }

        public static bool IsInt(string data)
        {
            bool result = true;
            if (!string.IsNullOrEmpty(data))
            {
                try
                {
                    Int64.Parse(data);
                }
                catch (FormatException)
                {
                    result = false;
                }
                return result;
            }
            else
            {
                result = false;
                return result;
            }
        }

        public static bool CheckFormPermission(string user_id, string formName)
        {
            string sqlstring = "select t.id " +
                "from c_forms as t " +
                "left join c_permission p on t.id = p.form_id " +
                "left join t_user u on p.usertype_id = u.usertype_id " +
                "left join c_constData ut on p.usertype_id = ut.id " +
                "where u.id = '" + user_id + "' and lower(t.fname) = '" + formName.ToLower() + "' ";
            DataTable DT = Database.ExecuteQuery(sqlstring);
            if (DT.Rows.Count > 0)
                return true;
            else
                return false;
        }
        public static bool emailIsValid(string email)
        {
            string expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, string.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public static string CheckGerFormPermission(string user_id, string formName)
        {
            string sqlstring = "select p.permission " +
                "from c_forms as t " +
                "left join c_permission p on t.id = p.form_id " +
                "left join t_user u on p.usertype_id = u.usertype_id " +
                "left join c_constData ut on p.usertype_id = ut.id " +
                "where u.id = '" + user_id + "' and upper(t.fname) = '" + formName.ToUpper() + "' ";
            DataTable DT = Database.ExecuteQuery(sqlstring);
            if (DT.Rows.Count > 0)
                return DT.Rows[0]["permission"].ToString();
            else
                return "";
        }

        public static string ConvertAsciiToUTF(string word)
        {
            char newChar;
            int i = 0;
            int len;
            len = word.Length;
            System.Text.StringBuilder newWord = new System.Text.StringBuilder(len);
            for (i = 0; i < len; i++)
            {
                try
                {
                    int codestr = Convert.ToByte(word[i]);
                    switch (codestr)
                    {
                        case 184:
                            codestr = 1105;
                            break; // eo                    
                        case 168:
                            codestr = 1025;
                            break; // capital EO                    
                        case 175:
                            codestr = 1198;
                            break; // capital UE                    
                        case 191:
                            codestr = 1199;
                            break; // ue                    
                        case 170:
                            codestr = 1256;
                            break; // capital OE                    
                        case 186:
                            codestr = 1257;
                            break; // oe
                    }

                    if (256 > codestr && codestr > 191)
                        codestr = codestr + 848;

                    newChar = (char)codestr;
                    newWord.Append(newChar);
                }
                catch
                {
                    return word;
                }
            } // end for
            return newWord.ToString();
        }

        public string convert2utf(string word)
        {
            char newChar;
            int i = 0;
            int len;
            len = word.Length;
            System.Text.StringBuilder newWord = new System.Text.StringBuilder(len);
            for (i = 0; i < len; i++)
            {
                try
                {
                    int codestr = Convert.ToByte(word[i]);
                    switch (codestr)
                    {
                        case 184:
                            codestr = 1105;
                            break; // eo                    
                        case 168:
                            codestr = 1025;
                            break; // capital EO                    
                        case 175:
                            codestr = 1198;
                            break; // capital UE                    
                        case 191:
                            codestr = 1199;
                            break; // ue                    
                        case 170:
                            codestr = 1256;
                            break; // capital OE                    
                        case 186:
                            codestr = 1257;
                            break; // oe
                    }

                    if (256 > codestr && codestr > 191)
                        codestr = codestr + 848;

                    newChar = (char)codestr;
                    newWord.Append(newChar);
                }
                catch
                {
                    return word;
                }
            } // end for
            return newWord.ToString();
        }

        public static string BootstrapMessageBoxScriptBuilder(string type, string message, string url)
        {
            string scriptText = "";
            if (type == "alert")
            {
                scriptText = "bootbox.alert('" + message + "');";
                return scriptText;
            }
            else if (type == "danger")
            {
                scriptText = "bootbox.dialog({ " +
                              "closeButton: false, " +
                              "message: '" + message + "', " +
                              "title: 'Анхааруулга', " +
                              "buttons: { " +
                                "danger: { " +
                                  "label: 'Ок', " +
                                  "className: 'btn-danger', " +
                                  "callback: function() { " +
                                    "window.location='" + url + "'; " +
                                  "} " +
                                "}  " +
                              "} " +
                            "});";

                return scriptText;
            }
            else if (type == "success")
            {
                scriptText = "bootbox.dialog({ " +
                              "closeButton: false, " +
                              "message: '" + message + "', " +
                              "title: 'Амжилттай', " +
                              "buttons: { " +
                                "success: { " +
                                  "label: 'Ok', " +
                                  "className: 'btn-success', " +
                                  "callback: function() { " +
                                    "window.location='" + url + "'; " +
                                  "} " +
                                "}  " +
                              "} " +
                            "});";

                return scriptText;
            }
            else
                return "";
        }


        public static Boolean setBoxStatusChangeAccept(string CargoID, ref string messege)
        {
            bool status = true;
            try
            {
                if (CargoID != null && CargoID != "")
                {
                    List<string> SQLList = new List<string>();
                    SQLList.Add("Update T_Boxs set Cargo_Id = '" + CargoID + "', BoxStatus_Id = '13'  WHERE Id in (select box_id from T_CargoBoxs where cargo_id = '" + CargoID + "') ");
                    if (Database.ExecuteNonQuery(SQLList.ToArray()))
                    {
                        status = true;
                        /*RadAjaxManager manager = RadAjaxManager.GetCurrent(Page);
                        manager.ResponseScripts.Add(Functions.BootstrapMessageBoxScriptBuilder("success", "Карго амжилттай бүртгэгдсэн.", "../Default.aspx"));*/
                    }
                }
            }
            catch (Exception ex)
            {
                status = false;
                messege = "Ачааны төлөв өөрчлөхөд алдаа гарлаа.";
            }
            finally
            {

            }
            return status;
        }

        public static Boolean setPackageStatusChangeAccept(string CargoID, ref string messege, DateTime publish)
        {
            bool status = true;
            try
            {
                string user_id = Database.UserID;
                List<string> SQLList = new List<string>();

                if (CargoID != null && CargoID != "")
                {
                    string sqlStr1 = "Select t.Package_Id from T_BoxPackages t " +
                                 " left join T_Boxs c on t.Box_Id = c.id " +
                                 " Where c.id in (select l.box_id from T_CargoBoxs l where l.cargo_id = '" + CargoID + "')";
                    DataTable DT = Database.ExecuteQuery(sqlStr1);
                    if (DT.Rows.Count > 0)
                    {
                        string _ID = "";
                        for (int i = 0; i < DT.Rows.Count; i++)
                        {
                            _ID = "";
                            string[] Fields2 = { "Status_Id", "Package_id", "StatusDate", "User_Id", "Description", 
                                                 "13", DT.Rows[i]["Package_Id"].ToString(),
                                                 publish != null ? Functions.convertDate(Convert.ToDateTime(publish)) : "",
                                                 user_id, "Илгээмж агаарын ачаанд орсон" };
                            SQLList.Add(Database.SaveTableData("T_PackageStatus", "ID", ref _ID, user_id, Fields2));
                            SQLList.Add("Update T_Package set Status_Id = '13', PackageStatus_Id = '" + _ID + "' WHERE Id = '" + DT.Rows[i]["Package_Id"].ToString() + "' ");
                        }
                    }

                    if (Database.ExecuteNonQuery(SQLList.ToArray()))
                    {
                        status = true;
                        /*RadAjaxManager manager = RadAjaxManager.GetCurrent(Page);
                        manager.ResponseScripts.Add(Functions.BootstrapMessageBoxScriptBuilder("success", "Карго амжилттай бүртгэгдсэн.", "../Default.aspx"));*/
                    }
                }
            }
            catch (Exception ex)
            {
                status = false;
                messege = "Илгээмжийн төлөв өөрчлөхөд алдаа гарлаа.";
            }
            finally
            {

            }
            return status;
        }

        public static Boolean setBoxStatusChangeCancel(string CargoID, ref string messege)
        {
            bool status = true;
            try
            {
                if (CargoID != null && CargoID != "")
                {
                    List<string> SQLList = new List<string>();
                    SQLList.Add("Update T_Boxs set Cargo_Id = '" + CargoID + "', BoxStatus_Id = '12'  WHERE Id in (select box_id from T_CargoBoxs where cargo_id = '" + CargoID + "') ");
                    if (Database.ExecuteNonQuery(SQLList.ToArray()))
                    {
                        status = true;
                        /*RadAjaxManager manager = RadAjaxManager.GetCurrent(Page);
                        manager.ResponseScripts.Add(Functions.BootstrapMessageBoxScriptBuilder("success", "Карго амжилттай бүртгэгдсэн.", "../Default.aspx"));*/
                    }
                }
            }
            catch (Exception ex)
            {
                status = false;
                messege = "Ачааны төлөв өөрчлөхөд алдаа гарлаа.";
            }
            finally
            {

            }
            return status;
        }

        public static Boolean setPackageStatusChangeCancel(string CargoID, ref string messege, DateTime publish)
        {
            bool status = true;
            try
            {
                string user_id = Database.UserID;
                List<string> SQLList = new List<string>();

                if (CargoID != null && CargoID != "")
                {
                    string sqlStr1 = "Select t.Package_Id from T_BoxPackages t " +
                                 " left join T_Boxs c on t.Box_Id = c.id " +
                                 " Where c.id in (select l.box_id from T_CargoBoxs l where l.cargo_id = '" + CargoID + "')";
                    DataTable DT = Database.ExecuteQuery(sqlStr1);
                    if (DT.Rows.Count > 0)
                    {
                        string _ID = "";
                        for (int i = 0; i < DT.Rows.Count; i++)
                        {
                            _ID = "";
                            string[] Fields2 = { "Status_Id", "Package_id", "StatusDate", "User_Id", "Description", 
                                                 "10", DT.Rows[i]["Package_Id"].ToString(),
                                                 publish != null ? Functions.convertDate(Convert.ToDateTime(publish)) : "",
                                                 user_id, "Илгээмж агаарын ачаанаас буцаагдсан" };
                            SQLList.Add(Database.SaveTableData("T_PackageStatus", "ID", ref _ID, user_id, Fields2));
                            SQLList.Add("Update T_Package set Status_Id = '10', PackageStatus_Id = '" + _ID + "' WHERE Id = '" + DT.Rows[i]["Package_Id"].ToString() + "' ");
                        }
                    }

                    if (Database.ExecuteNonQuery(SQLList.ToArray()))
                    {
                        status = true;
                        /*RadAjaxManager manager = RadAjaxManager.GetCurrent(Page);
                        manager.ResponseScripts.Add(Functions.BootstrapMessageBoxScriptBuilder("success", "Карго амжилттай бүртгэгдсэн.", "../Default.aspx"));*/
                    }
                }
            }
            catch (Exception ex)
            {
                status = false;
                messege = "Илгээмжийн төлөв өөрчлөхөд алдаа гарлаа.";
            }
            finally
            {

            }
            return status;
        }

        public static void Login(RadTextBox email, RadTextBox password, Page page)
        {
            try
            {
                if (email.Text != "" & password.Text != "")
                {
                    string Username = email.Text.Trim().ToLower();
                    if (Username.Length < 60)
                    {
                        string Password = Functions.MD5(password.Text.Trim());
                        string sqlStr1 = "Select t.* from t_user t " +
                                         " Where t.email = '" + Username + "' and t.password = '" + Password + "' and t.archive = 'N' ";
                        DataTable DT = Database.ExecuteQuery(sqlStr1);
                        if (DT.Rows.Count > 0)
                        {
                            Database.UserID = DT.Rows[0]["ID"].ToString();
                            RadAjaxManager manager = RadAjaxManager.GetCurrent(page);
                            manager.ResponseScripts.Add(Functions.BootstrapMessageBoxScriptBuilder("success", "Тавтай морилно уу.", "Home.aspx"));
                        }
                        else
                        {
                            Database.UserID = null;
                            page.Session.Clear();
                            email.Text = "";
                            password.Text = "";
                            RadAjaxManager manager = RadAjaxManager.GetCurrent(page);
                            manager.ResponseScripts.Add(Functions.BootstrapMessageBoxScriptBuilder("alert", "Хэрэглэгчийн имэйл, нууц үг буруу байна", ""));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                RadAjaxManager manager = RadAjaxManager.GetCurrent(page);
                manager.ResponseScripts.Add(Functions.BootstrapMessageBoxScriptBuilder("alert", "Хэрэглэгчийн имэйл, нууц үг буруу байна", ""));
                email.Text = "";
                password.Text = "";
            }
            finally
            {

            }
        }
    }
}