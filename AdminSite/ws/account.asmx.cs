﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

using CommonLib.Web;
using System.Xml;

namespace AdminSite.ws
{
    /// <summary>
    /// Summary description for account
    /// </summary>
    [WebService(Namespace = "http://www.dhnp.co.kr/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class account : System.Web.Services.WebService
    {
        [WebMethod]
        public XmlDocument GetMenuAuth(string adminId)
        {
            XmlDocument doc = new XmlDocument();

            CAccount account = new CAccount();
            doc.InnerXml = account.GetMenuAuth(adminId);

            return doc;
        }

        [WebMethod]
        public XmlDocument GetDutyAuth(string dutyNo)
        {
            XmlDocument doc = new XmlDocument();

            CAccount account = new CAccount();
            doc.InnerXml = account.GetDutyAuth(dutyNo);

            return doc;
        }
    }
}
