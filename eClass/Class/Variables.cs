using System;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;

namespace eClass
{
    public class Variables
    {
        #region Variables

        private static string service_IP;

        private static string sariinEh;

        private static string today;        

        private static SecurityService.UserInfo userInfo;

        public static string Service_IP
        {
            get { return Variables.service_IP; }
            set { Variables.service_IP = value; }
        }

        public static string SariinEh
        {
            get { return Variables.sariinEh; }
            set { Variables.sariinEh = value; }
        }

        public static string Today
        {
            get { return Variables.today; }
            set { Variables.today = value; }
        }

        public static SecurityService.UserInfo UserInfo
        {
            get { return Variables.userInfo; }
            set { Variables.userInfo = value; }
        }

        public static DataTable PlaceDataTable = new DataTable();

        public static DataTable AANDataTable = new DataTable();

        #endregion

        public static string LocalIP()
        {
            string IP = null;

            // Resolves a host name or IP address to an IPHostEntry instance.
            // IPHostEntry - Provides a container class for Internet host address information.
            System.Net.IPHostEntry _IPHostEntry = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName());

            // IPAddress class contains the address of a computer on an IP network.
            foreach (System.Net.IPAddress _IPAddress in _IPHostEntry.AddressList)
            {
                // InterNetwork indicates that an IP version 4 address is expected
                // when a Socket connects to an endpoint
                if (_IPAddress.AddressFamily.ToString() == "InterNetwork")
                    IP = _IPAddress.ToString();
            }
            return IP;
        }
    }
}
