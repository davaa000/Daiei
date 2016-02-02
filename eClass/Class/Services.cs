using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;

namespace eClass
{
    public class Services
    {
        public static DataBaseService.Database Database
        {
            get
            {
                DataBaseService.Database Service = new DataBaseService.Database();
                Service.Timeout = 2140000000;
                Service.Url = "http://" + Variables.Service_IP + ":8082/Database.asmx";
                return Service;
            }
        }

        /*public static ConstDataService.ConstData1 ConstData
        {
            get
            {
                ConstDataService.ConstData1 Service = new ConstDataService.ConstData1();
                Service.Timeout = 2140000000;
                Service.Url = "http://" + Variables.Service_IP + ":8082/ConstData.asmx";
                return Service;
            }
        }*/

        public static ConstantService.Constant Constant
        {
            get
            {
                ConstantService.Constant Service = new ConstantService.Constant();
                Service.Url = "http://" + Variables.Service_IP + ":8082/Constant.asmx";
                return Service;

            }
        }
        
        public static OtherService.Other Other
        {
            get
            {
                OtherService.Other Service = new OtherService.Other();
                Service.Url = "http://" + Variables.Service_IP + ":8082/Other.asmx";
                return Service;
            }
        }

        public static SecurityService.Security Security
        {
            get
            {
                SecurityService.Security Service = new SecurityService.Security();
                Service.Url = "http://" + Variables.Service_IP + ":8082/Security.asmx";
                return Service;
            }
        }

        public static SecurityService._Exception error(Exception ex)
        {
            StackTrace st = new StackTrace();
            SecurityService._Exception _ex = new SecurityService._Exception();
            _ex.className = st.GetFrame(1).GetMethod().DeclaringType.FullName;
            _ex.functionName = st.GetFrame(1).GetMethod().Name;
            _ex.ExceptionTarget = ex.TargetSite.Name;
            _ex.ExceptionMessage = ex.Message;
            _ex.ExceptionStackTrace = ex.StackTrace;
            return _ex;
        }

        public static SecurityService._Log log()
        {
            SecurityService._Log _log = new SecurityService._Log();
            StackTrace st = new StackTrace();
            _log.className = st.GetFrame(1).GetMethod().DeclaringType.FullName;
            _log.functionName = st.GetFrame(1).GetMethod().Name;
            return _log;
        }
    }
}
