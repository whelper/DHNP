﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

using HomePage.m_master;

namespace HomePage.en.invest
{
    public partial class ir_info_view : PageBase
    {
        private string seqNo = "0";

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
            param.Append(SeqNo);

            // 실 데이터 조회
            SetDataTableList(1203, param.ToString());
        }

        #region GET-SET

        private string SeqNo
        {
            get
            {
                if (Request["seq_no"] != null)
                {
                    seqNo = Request["seq_no"].ToString();
                }

                return seqNo;
            }
        }

        #endregion
    }
}