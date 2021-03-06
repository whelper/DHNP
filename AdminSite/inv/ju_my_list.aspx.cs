﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AdminSite.m_master;
using System.Text;
using CommonLib.Utils;

namespace AdminSite.inv
{
    public partial class ju_my_list : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SearchData();
            }
        }

        /// <summary>
        /// 데이터 조회
        /// </summary>
        private void SearchData()
        {
            StringBuilder param = new StringBuilder();
            param.Append("KOR");

            SetDataList(3461, param.ToString());
        }

         #region 이벤트 메소드

        /// <summary>
        /// 선택 삭제 버튼 클릭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            int loop = 1;
            if (eng_override.Checked == true)
            {
                // 영문 덮어쓰기를 한 경우에는 loop를 두번돈다.
                loop = 2;
            }

            string[] LANG_CD = { "KOR", "ENG" };

            for (int k = 0; k < loop; k++)
            {
                //유동 자산 데이터 열
                StringBuilder dparam = new StringBuilder();
                dparam.Append(LANG_CD[k]);
                ExecuteQueryResult(3463, dparam.ToString());

                String[] my_ju_cds = Request.Form.GetValues("my_ju_cd");
                String[] my_ju_cnts = Request.Form.GetValues("my_ju_cnt");
                String[] my_ju_ratios = Request.Form.GetValues("my_ju_ratio");
                String[] my_ju_stock_cnts = Request.Form.GetValues("my_ju_stock_cnt");
                String[] my_ju_stock_ratios = Request.Form.GetValues("my_ju_stock_ratio");
                String[] my_ju_remarks = Request.Form.GetValues("my_ju_remark");

                if (my_ju_cds != null && my_ju_cds.Length > 0)
                {
                    for (int i = 0; i < my_ju_cds.Length; i++)
                    {
                        string param1 = my_ju_cds[i];
                        string param2 = my_ju_cnts[i];
                        string param3 = my_ju_ratios[i];
                        string param4 = my_ju_stock_cnts[i];
                        string param5 = my_ju_stock_ratios[i];
                        string param6 = my_ju_remarks[i];

                        StringBuilder param = new StringBuilder();
                        param.Append(param1);
                        param.Append(CConst.DB_PARAM_DELIMITER).Append(param2);
                        param.Append(CConst.DB_PARAM_DELIMITER).Append(param3);
                        param.Append(CConst.DB_PARAM_DELIMITER).Append(param4);
                        param.Append(CConst.DB_PARAM_DELIMITER).Append(param5);
                        param.Append(CConst.DB_PARAM_DELIMITER).Append(param6);
                        param.Append(CConst.DB_PARAM_DELIMITER).Append(Session["admin_id"]);
                        param.Append(CConst.DB_PARAM_DELIMITER).Append(LANG_CD[k]);

                        ExecuteQueryResult(3462, param.ToString());
                    }
                }
            }
            
            SearchData();
        }

        #endregion
    }
}