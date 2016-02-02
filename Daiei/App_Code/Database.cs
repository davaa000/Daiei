using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Data.SQLite;
using System.Configuration;
namespace Daiei
{
    public class Database
    {
        private static DataTable dtUser;

        

        public static DataTable DtUser
        {
            get
            {
                if (dtUser == null)
                {
                    dtUser = ExecuteQuery("select t.id ZIPCODE, lower(t.code) || ', ' || lower(t.lastname) || ' ' || lower(t.firstname) as ALLSTATE, t.* from t_user t");
                }

                return Database.dtUser;
            }
        }

        public static DataTable OrderItemTable
        {
            get
            {
                if (HttpContext.Current.Session[OrderItemTableName] != null)
                {
                    DataTable dt = HttpContext.Current.Session[OrderItemTableName] as DataTable;
                    if (dt != null)
                        return dt;
                    else return null;
                }
                else
                    return null;
            }
            set
            {
                if (value != null)
                    HttpContext.Current.Session[OrderItemTableName] = value;
            }
        }
        public static string OrderItemTableName
        {
            get
            {
                if (HttpContext.Current.Session["PIC" + UserID] != null)
                    return HttpContext.Current.Session["PIC" + UserID].ToString();
                else
                    return null;
            }
            set
            {
                if (value != null && value != "")
                    HttpContext.Current.Session["PIC" + UserID] = value;

            }
        }

        public static string ExchangeRate
        {
            get
            {
                if (HttpContext.Current.Session["ExchangeRate"] != null)
                    return HttpContext.Current.Session["ExchangeRate"].ToString();
                else
                {

                    string exchange = SelectFieldValue("t_exchange", "value", "date = (select max(date) from t_exchange)", "");
                    if (exchange != null)
                        HttpContext.Current.Session["ExchangeRate"] = exchange;
                    return exchange;

                }
            }
        }
        public static string UserID
        {
            get
            {
                if (HttpContext.Current.Session["user_id"] != null)
                    return HttpContext.Current.Session["user_id"].ToString();
                else
                    return null;

            }
            set
            {
                if (value != null)
                    HttpContext.Current.Session["user_id"] = value;
            }
        }

        public static string UserEmail
        {
            get
            {
                if (HttpContext.Current.Session["UserEmail"] != null)
                    return HttpContext.Current.Session["UserEmail"].ToString();
                else
                {
                    HttpContext.Current.Session["UserEmail"]=Database.SelectFieldValue("t_user", "email", "ID = '" + Database.UserID + "'", "ID");
                    return HttpContext.Current.Session["UserEmail"].ToString();
                }
            }
        }


        public static char[] TrimChar
        {
            get { return Database.trimChar; }
            set { Database.trimChar = value; }
        }

        private static char[] trimChar = { '\'', ']', '(', ')', '[' };

        //private static string ConnString = System.Configuration.ConfigurationManager.ConnectionStrings["connServer"].ConnectionString;
        private static string ConnString = ConfigurationManager.ConnectionStrings["sqliteConnString"].ConnectionString;

        public static DataTable ExecuteQuery(string queryString)
        {

            using (SQLiteConnection connection = new SQLiteConnection(ConnString))
            {
                try
                {
                    DataTable dt = new DataTable();

                    SQLiteDataAdapter adapter = new SQLiteDataAdapter();
                    adapter.SelectCommand = new SQLiteCommand(queryString, connection);
                    adapter.Fill(dt);
                    return dt;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public static bool ExecuteNonQuery(string[] SqlList)
        {
            using (SQLiteConnection connection = new SQLiteConnection(ConnString))
            {
                connection.Open();

                SQLiteCommand command = connection.CreateCommand();
                SQLiteTransaction transaction;

                transaction = connection.BeginTransaction();

                command.Connection = connection;
                command.Transaction = transaction;

                bool result = false;

                try
                {
                    int i = 0;
                    while (i <= SqlList.Length - 1)
                    {
                        if (SqlList[i] != null)
                        {
                            command.CommandText = SqlList[i];
                            command.ExecuteNonQuery();
                        }
                        i++;
                    }

                    result = true;
                    transaction.Commit();

                    Console.WriteLine("Records are written to database.");
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
                return result;
            }
        }

        public static bool ExecuteNonQueryStr(string SQL)
        {
            using (SQLiteConnection connection = new SQLiteConnection(ConnString))
            {
                connection.Open();

                SQLiteCommand command = connection.CreateCommand();
                SQLiteTransaction transaction;
                transaction = connection.BeginTransaction();
                command.Connection = connection;
                command.Transaction = transaction;
                bool result = false;
                try
                {
                    command.CommandText = SQL;
                    command.ExecuteNonQuery();
                    result = true;
                    transaction.Commit();
                    Console.WriteLine("Records are written to database.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Commit Exception Type: {0}", ex.GetType());
                    Console.WriteLine("  Message: {0}", ex.Message);
                    try
                    {
                        transaction.Rollback();
                    }
                    catch (Exception ex2)
                    {
                        Console.WriteLine("Rollback Exception Type: {0}", ex2.GetType());
                        Console.WriteLine("  Message: {0}", ex2.Message);
                    }
                }
                return result;
            }
        }

        public static string SelectFieldValue(string TableName, string FieldName, string WhereStr, string OrderbyField)
        {
            DataTable ds = null;
            string SQLStr = "";
            string orderBy = OrderbyField != null && OrderbyField != "" ? " Order by " + OrderbyField : "";

            try
            {
                if (!string.IsNullOrEmpty(WhereStr))
                    SQLStr = "Select " + FieldName + " d From " + TableName + " Where " + WhereStr;
                else
                    SQLStr = "Select " + FieldName + " d From " + TableName;
                ds = ExecuteQuery(SQLStr);
                if (ds.Rows.Count > 0)
                    return ds.Rows[0]["d"].ToString();
                else
                    return null;
            }
            catch (SQLiteException ex)
            {
                throw ex;
            }
            finally
            {
                ds = null;
            }
        }

        public static string SelectFieldValueMergeField(string TableName, string MergeFields, string TextField, string ValueField, string WhereSql, string OrderFldName)
        {
            DataTable ds = null;
            string SQLStr = "";
            try
            {
                string Sql = "";
                if (TextField.ToUpper() == ValueField.ToUpper())
                    Sql = "Select " + ValueField + " From " + TableName;
                else
                    Sql = "Select " + MergeFields + "," + ValueField + " From " + TableName;
                if (WhereSql != "")
                    Sql += " Where " + WhereSql;
                if (OrderFldName != null && OrderFldName != "")
                    Sql += " Order By " + OrderFldName;
                ds = Database.ExecuteQuery(Sql);
                if (ds.Rows.Count > 0)
                    return ds.Rows[0][TextField].ToString();
                else
                    return null;
            }
            catch (SQLiteException ex)
            {
                throw ex;
            }
            finally
            {
                ds = null;
            }
        }

        public static string SaveMain(string id, string active)
        {
            string result = "";
            /* string _id = SelectFieldValue("t_main", "id", "id = '" + id + "'");
             //string UserID = Variables.LoginUserInfo("id");
             string SQL = "";
             string result = "";


             if (!string.IsNullOrEmpty(_id))//Update
             {
                 SQL = "update t_main set " +
                     " active = '" + active + "' , updateduser_id = '" + UserID + "' , updateddate = getdate() " +
                     " where id= '" + _id + "'";
             }
             else//Insert
             {
                 SQL = "insert into t_main (active,createddate,createduser_id) values " +
                     "( '" + active + "',getdate(),'" + UserID + "')";
             }

             if (ExecuteNonQueryStr(SQL))
             {
                 SQL = "Select max(id) id from t_main";
                 result = ExecuteQuery(SQL).Rows[0]["id"].ToString();
                 //int idint = int.Parse(result) + 1;
                 //result = idint.ToString();
             }
             else
             {
                 result = null;
             }
               */
            return result = null;
        }

        public static string getSequenceValue(string TableName, string Old_ID)
        {
            if (TableName != null && TableName != "")
            {
                string id = SelectFieldValue(TableName, "max(id)+1", "", "");
                if (id == null || id == "")
                    id = "1";
                return id;
            }
            else
                return "";
        }

        public static string SaveFieldValue(string pTableName, string pFieldName, string pFieldValue, string pKeyFieldName, ref string pKeyFieldValue, string pUserName)
        {
            string sql = "";
            if (pKeyFieldValue == "" || pKeyFieldValue == null)
            {
                pKeyFieldValue = getSequenceValue(pTableName, "");
                sql = "Insert InTo " + pTableName + "(" + pKeyFieldName + ", CreatedUser, CreatedDate," + pFieldName + ") Values(" + pKeyFieldValue + ", '" + pUserName + "', datetime('now'),'" + pFieldValue + "')";
            }
            else
                sql = "Update " + pTableName + " Set UpdatedUser = '" + pUserName + "', UpdatedDate = datetime('now'), " + pFieldName + " = '" + pFieldValue + "' Where " + pKeyFieldName + " = '" + pKeyFieldValue + "'";

            return sql;
        }

        public static string SaveTableData(string pTableName, string pKeyFieldName, ref string pKeyFieldValue, string pUserName, params string[] pFields)
        {
            int FieldCount = pFields.Length - 1;

            if (pKeyFieldValue == "" || pKeyFieldValue == null)
            {
                pKeyFieldValue = getSequenceValue(pTableName, "");
                string fieldStr = "Insert Into " + pTableName + "(" + pKeyFieldName + ", " + pFields[0];
                string valueStr = "";

                //Эхний талбарын утга Date талбартай эсэх
                if (pFields[(int)Math.Floor(FieldCount / 2.0) + 1].ToLower().Contains("date") || pFields[(int)Math.Floor(FieldCount / 2.0) + 1].ToLower().Contains("datetime('now')"))
                    valueStr = " Values(" + pKeyFieldValue + ", " + pFields[(int)Math.Floor(FieldCount / 2.0) + 1];
                else
                    valueStr = " Values(" + pKeyFieldValue + ", '" + pFields[(int)Math.Floor(FieldCount / 2.0) + 1];

                int i = 1;
                while (i < FieldCount / 2.0)
                {
                    fieldStr = fieldStr + ", " + pFields[i];

                    //Тухайн талбарын утгатай Date төрөлтэй биш бол хэрэгцээгүй тэмдэгтийг цэвэрлэх
                    if (!(pFields[(int)Math.Floor(FieldCount / 2.0) + i + 1] == null) &&
                        !pFields[(int)Math.Floor(FieldCount / 2.0) + i + 1].ToLower().Contains("date"))
                        pFields[(int)Math.Floor(FieldCount / 2.0) + i + 1] = pFields[(int)Math.Floor(FieldCount / 2.0) + i + 1].Trim(TrimChar);
                    //Өмнөх болон тухай утга Date төрөлтэй бол
                    if ((pFields[(int)Math.Floor(FieldCount / 2.0) + i].ToLower().Contains("date")
                        || pFields[(int)Math.Floor(FieldCount / 2.0) + i].ToLower().Contains("datetime('now')"))
                        && (pFields[(int)Math.Floor(FieldCount / 2.0) + i + 1].ToLower().Contains("date")
                        || pFields[(int)Math.Floor(FieldCount / 2.0) + i + 1].ToLower().Contains("datetime('now')")))
                        valueStr = valueStr + ", " + pFields[(int)Math.Floor(FieldCount / 2.0) + i + 1];
                    //Өмнөх утга Date, тухай утга Date биш бол
                    if ((pFields[(int)Math.Floor(FieldCount / 2.0) + i].ToLower().Contains("date")
                        || pFields[(int)Math.Floor(FieldCount / 2.0) + i].ToLower().Contains("datetime('now')"))
                        && !pFields[(int)Math.Floor(FieldCount / 2.0) + i + 1].ToLower().Contains("date")
                        && !pFields[(int)Math.Floor(FieldCount / 2.0) + i + 1].ToLower().Contains("datetime('now')"))
                        valueStr = valueStr + ", '" + pFields[(int)Math.Floor(FieldCount / 2.0) + i + 1];
                    //Өмнөх утга Date биш болон тухайн утга Date төрөлтэй бол
                    if (!pFields[(int)Math.Floor(FieldCount / 2.0) + i].ToLower().Contains("date")
                        && !pFields[(int)Math.Floor(FieldCount / 2.0) + i].ToLower().Contains("datetime('now')")
                        && (pFields[(int)Math.Floor(FieldCount / 2.0) + i + 1].ToLower().Contains("date")
                        || pFields[(int)Math.Floor(FieldCount / 2.0) + i + 1].ToLower().Contains("datetime('now')")))
                        valueStr = valueStr + "', " + pFields[(int)Math.Floor(FieldCount / 2.0) + i + 1];
                    //Өмнөх утга тухай утга Date биш төрөлтэй бол
                    if (!pFields[(int)Math.Floor(FieldCount / 2.0) + i].ToLower().Contains("date")
                        && !pFields[(int)Math.Floor(FieldCount / 2.0) + i].ToLower().Contains("datetime('now')")
                        && !pFields[(int)Math.Floor(FieldCount / 2.0) + i + 1].ToLower().Contains("date")
                        && !pFields[(int)Math.Floor(FieldCount / 2.0) + i + 1].ToLower().Contains("datetime('now')"))
                        valueStr = valueStr + "', '" + pFields[(int)Math.Floor(FieldCount / 2.0) + i + 1];
                    //Console.WriteLine(fieldStr + valueStr);
                    i = i + 1;
                }
                fieldStr = fieldStr + ", CreatedUser, CreatedDate)";
                if (pFields[(int)Math.Floor(FieldCount / 2.0) + i].ToLower().Contains("date")
                    || pFields[(int)Math.Floor(FieldCount / 2.0) + i].ToLower().Contains("datetime('now')"))
                    valueStr = valueStr + ", '" + pUserName + "', datetime('now'))";
                else
                    valueStr = valueStr + "', '" + pUserName + "', datetime('now'))";

                return fieldStr + valueStr;
            }
            else
            {
                string SQL = "Update " + pTableName + " Set ";
                int i = 0;
                while (i < FieldCount / 2.0)
                {
                    //Тухайн талбарын утгатай Date төрөлтэй биш бол хэрэгцээгүй тэмдэгтийг цэвэрлэх
                    if (!(pFields[(int)Math.Floor(FieldCount / 2.0) + i + 1] == null) && !pFields[(int)Math.Floor(FieldCount / 2.0) + i + 1].ToLower().Contains("date"))
                        pFields[(int)Math.Floor(FieldCount / 2.0) + i + 1] = pFields[(int)Math.Floor(FieldCount / 2.0) + i + 1].Trim(TrimChar);

                    //Тухайн талбар нь Date төрөлтэй эсэх
                    if (pFields[(int)Math.Floor(FieldCount / 2.0) + i + 1].ToLower().Contains("date") || pFields[(int)Math.Floor(FieldCount / 2.0) + i + 1].ToLower().Contains("datetime('now')"))
                        SQL += pFields[i] + " = " + pFields[(int)Math.Floor(FieldCount / 2.0) + i + 1];
                    else
                        SQL += pFields[i] + " = '" + pFields[(int)Math.Floor(FieldCount / 2.0) + i + 1] + "' ";

                    if (i < (int)Math.Floor(FieldCount / 2.0))
                        SQL += ",";
                    i = i + 1;
                }
                SQL += ", UpdatedUser = '" + pUserName + "', UpdatedDate = datetime('now') Where " + pKeyFieldName + " = '" + pKeyFieldValue + "'";
                return SQL;
            }
        }
    }
}