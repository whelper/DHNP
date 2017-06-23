﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;

using HomePage.m_master;
using CommonLib.Utils;

namespace HomePage.en.products
{
    public partial class bio_catalog_list : PageBase
    {
        private const string LANG_CD = "ENG";
        private const string CATG_NO1 = "3";
        private const string PROD_TYPE_CD = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SearchData();

                InitControls();

                SetControls();
            }
        }

        /// <summary>
        /// 데이터 조회
        /// </summary>
        private void SearchData()
        {
            StringBuilder param = new StringBuilder();
            param.Append(nowPageNo.Value);
            param.Append(CConst.DB_PARAM_DELIMITER).Append(LANG_CD);

            SetDataCount(1104, param.ToString());

            if (DataTotalCount > 0)
            {
                SetDataList(1105, param.ToString());
            }
        }

        /// <summary>
        /// 초기화 컨트롤들 (파라미터에 의한 셋팅)
        /// </summary>
        private void InitControls()
        {
        }

        /// <summary>
        /// DB를 통해 동적으로 셋팅해야 되는 컨트롤
        /// 분류관련 selectbox류들
        /// </summary>
        private void SetControls()
        {

        }

        #region GET-SET

        protected string ProdInitial
        {
            get
            {
                if (Request["prod_initial"] == null)
                {
                    return "";
                }
                else
                {
                    return Request["prod_initial"];
                }
            }
        }

        protected string CatgNo2
        {
            get
            {
                if (Request["catg_no2"] == null)
                {
                    return "0";
                }
                else
                {
                    return Request["catg_no2"];
                }
            }
        }

        protected string RepCatal
        {
            get
            {
                string catalog_url = "";

                StringBuilder param = new StringBuilder();
                param.Append(CATG_NO1);
                DataSet ds = GetDataSet(3231, param.ToString());

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    catalog_url = ds.Tables[0].Rows[0]["CATAL_URL"].ToString();
                }

                return catalog_url;
            }
        }

        #endregion

        #region 이벤트 메소드

        /// <summary>
        /// 조회 버튼 클릭
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            // 페이지는 1로 초기화
            nowPageNo.Value = "1";

            SearchData();
        }

        /// <summary>
        /// 페이지 번호 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void nowPageNo_ValueChanged(object sender, EventArgs e)
        {
            SearchData();
        }

        #endregion
    }
}