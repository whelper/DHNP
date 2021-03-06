﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;

using CommonLib.Utils;
using AdminSite.m_master;

namespace AdminSite.pdt
{
    public partial class pdt_catalog_list : PageBase
    {
        //private const string LANG_CD = "KOR";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SearchData();

                InitControls();
            }
        }

        private void SearchData()
        {
            StringBuilder param = new StringBuilder();
            param.Append(Upr_catg_no);

            // 실 데이터 조회
            SetDataList(3231, param.ToString());
        }

        private void InitControls()
        {
            file_01.Attributes.Add("onchange", "document.getElementById('" + path_value_01.ClientID + "').value=document.getElementById('" + file_01.ClientID + "').value;");
            file_02.Attributes.Add("onchange", "document.getElementById('" + path_value_02.ClientID + "').value=document.getElementById('" + file_02.ClientID + "').value;");

            for (int i = 0; i < GetDataCount(); i++)
            {
                if ("KOR".Equals(GetData(i, "LANG_CD")))
                {
                    h_catal_path_01.Value = GetData(i, "CATAL_URL");
                }
                else if ("ENG".Equals(GetData(i, "LANG_CD")))
                {
                    h_catal_path_02.Value = GetData(i, "CATAL_URL");
                }
            }
        }

        private void SaveData()
        {
            if (CStringUtil.IsNullOrEmpty(Upr_catg_no) == false)
            {
                string repFile = CStringUtil.IsNullOrEmpty(path_value_01.Value) == false ? UploadFile(file_01, "DIR_PRODUCT") : "";
                string repFileEng = CStringUtil.IsNullOrEmpty(path_value_02.Value) == false ? UploadFile(file_02, "DIR_PRODUCT") : "";

                string[] result = null;

                if (CStringUtil.IsNullOrEmpty(repFile) == false)
                {
                    StringBuilder param = new StringBuilder();
                    param.Append(Upr_catg_no);
                    param.Append(CConst.DB_PARAM_DELIMITER).Append("KOR");
                    param.Append(CConst.DB_PARAM_DELIMITER).Append(repFile);
                    param.Append(CConst.DB_PARAM_DELIMITER).Append(Session["admin_id"]);

                    result = ExecuteQueryResult(3232, param.ToString());
                }

                if (CStringUtil.IsNullOrEmpty(repFileEng) == false)
                {
                    StringBuilder param = new StringBuilder();
                    param.Append(Upr_catg_no);
                    param.Append(CConst.DB_PARAM_DELIMITER).Append("ENG");
                    param.Append(CConst.DB_PARAM_DELIMITER).Append(repFileEng);
                    param.Append(CConst.DB_PARAM_DELIMITER).Append(Session["admin_id"]);

                    result = ExecuteQueryResult(3232, param.ToString());
                }

                if (result == null)
                {
                    CWebUtil.jsAlertAndRedirect(this, "시스템 오류가 발생 했습니다.", "pdt_catalog_list.aspx?upr_catg_no=" + Upr_catg_no);
                }
                else if (result[0].Equals("00") == false)
                {
                    CWebUtil.jsAlertAndRedirect(this, result[1], "pdt_catalog_list.aspx?upr_catg_no=" + Upr_catg_no);
                }
                else
                {
                    Response.Redirect("pdt_catalog_list.aspx?upr_catg_no=" + Upr_catg_no);
                }
            }
            else
            {
                CWebUtil.jsAlertAndRedirect(this, "카테고리가 선택되지 않았습니다.", "pdt_catalog_list.aspx?upr_catg_no=" + Upr_catg_no);
            }
        }

        #region GET-SET

        protected string Upr_catg_no
        {
            get
            {   
                return Request["upr_catg_no"];
            }
        }

        protected string PageName
        {
            get
            {
                string pagename = "";

                switch (Upr_catg_no)
                {
                    case "1":
                        pagename = "인체 의약품";
                        break;
                    case "2":
                        pagename = "동물 의약품";
                        break;
                    case "3":
                        pagename = "바이오 공정소재";
                        break;
                    case "4":
                        pagename = "수출 의약품(인체)";
                        break;
                    case "5":
                        pagename = "수출 의약품(동물)";
                        break;
                    case "10":
                        pagename = "수출 의약품(기타)";
                        break;
                    case "6":
                        pagename = "건강기능식품";
                        break;
                    case "7":
                        pagename = "의료기기";
                        break;
                
                }

                return pagename;
            }
        }

        protected List<Dictionary<string, string>> PageList
        {
            get
            {
                List<Dictionary<string, string>> pageList = new List<Dictionary<string, string>>();

                switch (Upr_catg_no)
                {
                    case "1":
                        Dictionary<string, string> dic11 = new Dictionary<string, string>();
                        dic11.Add("pagename", "인체 의약품");
                        dic11.Add("pageurl", "pdt_human_list.aspx");

                        pageList.Add(dic11);

                        Dictionary<string, string> dic12 = new Dictionary<string, string>();
                        dic12.Add("pagename", "제품변경정보");
                        dic12.Add("pageurl", "pdt_cha_info_list.aspx");

                        pageList.Add(dic12);

                        break;
                    case "2":
                        Dictionary<string, string> dic21 = new Dictionary<string, string>();
                        dic21.Add("pagename", "동물 의약품");
                        dic21.Add("pageurl", "pdt_ani_list.aspx");

                        pageList.Add(dic21);
                        break;
                    case "3":
                        Dictionary<string, string> dic31 = new Dictionary<string, string>();
                        dic31.Add("pagename", "배지/레진");
                        dic31.Add("pageurl", "pdt_bio_list.aspx");

                        pageList.Add(dic31);

                        Dictionary<string, string> dic32 = new Dictionary<string, string>();
                        dic32.Add("pagename", "카달로그");
                        dic32.Add("pageurl", "pdt_bioC_list.aspx");

                        pageList.Add(dic32);
                        break;
                    case "4":
                        Dictionary<string, string> dic41 = new Dictionary<string, string>();
                        dic41.Add("pagename", "수출의약품(인체)");
                        dic41.Add("pageurl", "pdt_ex_human_list.aspx");

                        pageList.Add(dic41);
                        break;
                    case "5":
                        Dictionary<string, string> dic51 = new Dictionary<string, string>();
                        dic51.Add("pagename", "수출의약품(동물)");
                        dic51.Add("pageurl", "pdt_ex_ani_list.aspx");

                        pageList.Add(dic51);

                        break;
                    case "6":
                        Dictionary<string, string> dic61 = new Dictionary<string, string>();
                        dic61.Add("pagename", "건강기능식품");
                        dic61.Add("pageurl", "pdt_health_list.aspx");

                        pageList.Add(dic61);
                        break;
                    case "7":
                        Dictionary<string, string> dic71 = new Dictionary<string, string>();
                        dic71.Add("pagename", "의료기기");
                        dic71.Add("pageurl", "pdt_device_list.aspx");

                        pageList.Add(dic71);
                        break;
                    case "10":
                        Dictionary<string, string> dic81 = new Dictionary<string, string>();
                        dic81.Add("pagename", "수출의약품(기타)");
                        dic81.Add("pageurl", "pdt_ex_etc_list.aspx");

                        pageList.Add(dic81);
                        break;
                }

                return pageList;
            }
        }

        /// <summary>
        /// 파일 삭제
        /// </summary>
        /// <param name="col"></param>
        /// <param name="path"></param>
        private void DelFile(string lang_cd)
        {
            StringBuilder param = new StringBuilder();
            param.Append(Upr_catg_no);
            param.Append(CConst.DB_PARAM_DELIMITER).Append(Session["admin_id"]);

            if (lang_cd.Equals("KOR"))
            {
                DeleteFile(3233, param.ToString(), h_catal_path_01.Value);
            }
            else if (lang_cd.Equals("ENG"))
            {
                DeleteFile(3233, param.ToString(), h_catal_path_02.Value);
            }

            SearchData();
        }

        #endregion

        protected string GetDataMat(string lang_cd, string col)
        {
            string result = "";

            for (int i = 0; i < GetDataCount(); i++)
            {
                if (lang_cd.Equals(GetData(i, "LANG_CD")))
                {
                    result = GetData(i, col);
                    break;
                }
            }

            return result;
        }

        #region 이벤트 메소드

        protected void btnSave_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        protected void btnDelCatal_Click(object sender, EventArgs e)
        {
            DelFile("KOR");
        }

        protected void btnDelCatal2_Click(object sender, EventArgs e)
        {
            DelFile("ENG");
        }

        #endregion
    }
}