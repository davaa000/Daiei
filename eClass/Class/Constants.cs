using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eClass
{
    public class Constants
    {
        public static ConstantService.Report Report
        {
            get
            {
                return Services.Constant.getReport();
            }
        }
        public static ConstantService.Patrol Patrol
        {
            get
            {
                return Services.Constant.getPatrol();
            }
        }
        public static ConstantService.ASAP ASAP
        {
            get
            {
                return Services.Constant.getASAP();
            }
        }
        public static ConstantService.Complaint Complaint
        {
            get
            {
                return Services.Constant.getComplaint();
            }
        }
        public static ConstantService.Crime Crime
        {
            get
            {
                return Services.Constant.getCrime();
            }
        }
        public static ConstantService.HR HR
        {
            get
            {
                return Services.Constant.getHR();
            }
        }
        public static ConstantService.ZTB ZTB
        {
            get
            {
                return Services.Constant.getZTB();
            }
        }
        public static ConstantService.Zurchil Zurchil
        {
            get
            {
                return Services.Constant.getZurchil();
            }
        }
        public static ConstantService.SystemUser SystemUser
        {
            get
            {
                return Services.Constant.getSystemUser();
            }
        }
        public static ConstantService.PoliceWebApp PoliceWebApp
        {
            get
            {
                return Services.Constant.getPoliceWebApp();
            }
        }

        public static ConstantService.Action Action
        {
            get
            {
                return Services.Constant.getAction();
            }
        }
        public static ConstantService.Roles Roles
        {
            get
            {
                return Services.Constant.getRoles();
            }
        }
        public static ConstantService.Formats Formats
        {
            get
            {
                return Services.Constant.getFormats();
            }
        }
        public static ConstantService.Messages Messages
        {
            get
            {
                return Services.Constant.getMessages();
            }
        }
        public static ConstantService.Globals Globals
        {
            get
            {
                return Services.Constant.getGlobals();
            }
        }
        public static ConstantService.Status Status
        {
            get
            {
                return Services.Constant.getStatus();
            }
        }
    }
}
