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

namespace HomePage.products
{
    public partial class bio_resin_list : PageBase
    {
        private const string LANG_CD = "KOR";
        private const string CATG_NO1 = "3";
        private const string PROD_TYPE_CD = "PROD_REGIN";
        private const int PAGE_SIZE = 9;

        private DataSet catgDs = null;

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
            param.Append(CConst.DB_PARAM_DELIMITER).Append(CATG_NO1);
            param.Append(CConst.DB_PARAM_DELIMITER).Append("");
            param.Append(CConst.DB_PARAM_DELIMITER).Append(PROD_TYPE_CD);
            param.Append(CConst.DB_PARAM_DELIMITER).Append("");
            param.Append(CConst.DB_PARAM_DELIMITER).Append("");
            param.Append(CConst.DB_PARAM_DELIMITER).Append("");
            param.Append(CConst.DB_PARAM_DELIMITER).Append(PAGE_SIZE);

            SetDataCount(1101, param.ToString());

            if (DataTotalCount > 0)
            {
                SetDataList(1102, param.ToString());
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
            StringBuilder param = new StringBuilder();
            param.Append(LANG_CD);
            param.Append(CConst.DB_PARAM_DELIMITER).Append(CATG_NO1);
            param.Append(CConst.DB_PARAM_DELIMITER).Append(PROD_TYPE_CD);
            param.Append(CConst.DB_PARAM_DELIMITER).Append("");
            param.Append(CConst.DB_PARAM_DELIMITER).Append("");
            param.Append(CConst.DB_PARAM_DELIMITER).Append("");

            catgDs = GetDataSet(1100, param.ToString());
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

        protected DataSet CatgDs
        {
            get
            {
                return catgDs;
            }
        }

        protected string RepCatal
        {
            get
            {
				return getCatalogURL(CATG_NO1, LANG_CD);
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