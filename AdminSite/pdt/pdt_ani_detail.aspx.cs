﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

using CommonLib.Utils;
using AdminSite.m_master;
using System.Data;

namespace AdminSite.pdt
{
    public partial class pdt_ani_detail : PageBase
    {
        //private const string LANG_CD = "KOR";
        private const string UPR_CATG_NO = "2";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SearchData();

                SetControls();

                InitControls();
            }
        }

        /// <summary>
        /// 데이터 조회
        /// </summary>
        private void SearchData()
        {
            if (CStringUtil.IsNullOrEmpty(ProdCd) == false)
            {
                StringBuilder param = new StringBuilder();
                param.Append(LANG_CD);
                param.Append(CConst.DB_PARAM_DELIMITER).Append(ProdCd);

                // DataSet타입으로 Set
                SetDataTableList(3203, param.ToString());
            }
        }

        /// <summary>
        /// 컨트롤 데이터 셋팅
        /// 제품 상세 조회 데이터와 무관한 컨트롤 셋팅(코드 컨트롤, 카테고리 컨트롤 등)
        /// </summary>
        private void SetControls()
        {
            // 2차 카테고리 컨트롤 셋팅
            StringBuilder param = new StringBuilder();
            param.Append(LANG_CD);
            param.Append(CConst.DB_PARAM_DELIMITER).Append(UPR_CATG_NO);
            param.Append(CConst.DB_PARAM_DELIMITER).Append("2");

            DataSet ds = GetDataSet(1, param.ToString());

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    catg_no2.Items.Add(new ListItem(ds.Tables[0].Rows[i]["CATG_NM"].ToString(), ds.Tables[0].Rows[i]["CATG_NO"].ToString()));
                }
            }
        }

        /// <summary>
        /// 제품 상세 조회 데이터를 기반으로 셋팅해야할 컨트롤들
        /// </summary>
        private void InitControls()
        {
            // 각 이미지 업로드 컨트롤에 javascript 이벤트를 등록한다. (페이지단 서버 컨트롤에 삽입 불가하여 CS단에서 삽입)
            upload_01.Attributes.Add("onchange", "document.getElementById('" + upload_path_01.ClientID + "').value=document.getElementById('" + upload_01.ClientID + "').value;");
            upload_02.Attributes.Add("onchange", "document.getElementById('" + upload_path_02.ClientID + "').value=document.getElementById('" + upload_02.ClientID + "').value;");
            upload_03.Attributes.Add("onchange", "document.getElementById('" + upload_path_03.ClientID + "').value=document.getElementById('" + upload_03.ClientID + "').value;");
            upload_04.Attributes.Add("onchange", "document.getElementById('" + upload_path_04.ClientID + "').value=document.getElementById('" + upload_04.ClientID + "').value;");
            upload_05.Attributes.Add("onchange", "document.getElementById('" + upload_path_05.ClientID + "').value=document.getElementById('" + upload_05.ClientID + "').value;");
            upload_file.Attributes.Add("onchange", "document.getElementById('" + upload_path_file.ClientID + "').value=document.getElementById('" + upload_file.ClientID + "').value;");

            pdt_org.Checked = true;
			open_yn1.Checked = true;
			reg_dt.Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
			if (GetDataTableCount(0) > 0)
            {

				// 신제품여부
				new_yn.Checked = (GetData(0, 0, "NEW_YN").Equals("Y")) ? true : false;
				if (GetData(0, 0, "OPEN_YN").Equals("Y"))
				{
					open_yn1.Checked = true;
				}
				else
				{
					open_yn2.Checked = true;
				}
				reg_dt.Value = Convert.ToDateTime(GetData(0, 0, "REG_DT")).ToString("yyyy-MM-dd hh:mm");

				new_start_dt.Value = GetData(0, 0, "NEW_START_DT");
				new_end_dt.Value = GetData(0, 0, "NEW_END_DT");

				prod_cd.Value = GetData(0, 0, "PROD_CD");
				prod_nm.Value = GetData(0, 0, "PROD_NM");

				// 기존제품, 신제품, 관납제품
				string prodType = GetData(0, 0, "PROD_TYPE");
                //pdt_new.Checked = prodType.Equals("PROD_NEW") ? true : false;
                pdt_godl.Checked = prodType.Equals("PROD_GODL") ? true : false;
                pdt_org.Checked = prodType.Equals("PROD_ORG") || prodType.Equals("") ? true : false;

                // 제품코드, 명
                prod_cd.Value = GetData(0, 0, "PROD_CD");
                prod_nm.Value = GetData(0, 0, "PROD_NM");

                // 분류
                for (int i = 0; i < catg_no2.Items.Count; i++)
                {
                    if (GetData(0, 0, "CATG_NO2").Equals(catg_no2.Items[i].Value))
                    {
                        catg_no2.SelectedIndex = i;
                    }
                }

                catg_no.Value = GetData(0, 0, "CATG_NO");
                ingredi.Value = GetData(0, 0, "INGREDI");
                //caveat.InnerText = GetData(0, 0, "CAVEAT");
                insu_cd.Value = GetData(0, 0, "INSU_CD");
                pmedi.Value = GetData(0, 0, "PMEDI");
                //domin.InnerText = GetData(0, 0, "DOMIN");
                usage.Text = GetData(0, 0, "USAGE");

                h_prod_img1_path.Value = GetData(0, 0, "PROD_IMG1");
                h_prod_img2_path.Value = GetData(0, 0, "PROD_IMG2");
                h_prod_img3_path.Value = GetData(0, 0, "PROD_IMG3");
                h_prod_img4_path.Value = GetData(0, 0, "PROD_IMG4");
                h_prod_img5_path.Value = GetData(0, 0, "PROD_IMG5");
                h_prod_menual_path.Value = GetData(0, 0, "MANUAL");

                int tb2Count = GetDataTableCount(1);

                if (tb2Count > 0) tag01.Value = GetData(1, 0, "TAG_NM");
                if (tb2Count > 1) tag02.Value = GetData(1, 1, "TAG_NM");
                if (tb2Count > 2) tag03.Value = GetData(1, 2, "TAG_NM");
                if (tb2Count > 3) tag04.Value = GetData(1, 3, "TAG_NM");
                if (tb2Count > 4) tag05.Value = GetData(1, 4, "TAG_NM");
                if (tb2Count > 5) tag06.Value = GetData(1, 5, "TAG_NM");

                clip_url.Value = GetData(0, 0, "CLIP_URL");

                if (GetData(0, 0, "PROD_CD") != null)
                {
                    prod_cd.Attributes.Add("readonly", "true");
                    prod_cd.Attributes.Add("style", "background-color:#C9C9C9");
                }
            }
        }

        /// <summary>
        /// 데이터를 저장한다. (추가 or 수정)
        /// </summary>
        private void SaveData()
        {
            string img1 = CStringUtil.IsNullOrEmpty(upload_path_01.Value) == false ? UploadFile(upload_01, "DIR_PROMOTION") : "";
            string img2 = CStringUtil.IsNullOrEmpty(upload_path_02.Value) == false ? UploadFile(upload_02, "DIR_PROMOTION") : "";
            string img3 = CStringUtil.IsNullOrEmpty(upload_path_03.Value) == false ? UploadFile(upload_03, "DIR_PROMOTION") : "";
            string img4 = CStringUtil.IsNullOrEmpty(upload_path_04.Value) == false ? UploadFile(upload_04, "DIR_PROMOTION") : "";
            string img5 = CStringUtil.IsNullOrEmpty(upload_path_05.Value) == false ? UploadFile(upload_05, "DIR_PROMOTION") : "";
            string menual = CStringUtil.IsNullOrEmpty(upload_path_file.Value) == false ? UploadFile(upload_file, "DIR_PROMOTION") : "";
			string open_yn = (open_yn1.Checked) ? "Y" : "N";

			StringBuilder param = new StringBuilder();
            param.Append(LANG_CD);
            param.Append(CConst.DB_PARAM_DELIMITER).Append(prod_cd.Value);
            string catgNo = catg_no.Value.Equals("") ? "0" : catg_no.Value;
            param.Append(CConst.DB_PARAM_DELIMITER).Append(catgNo);
            param.Append(CConst.DB_PARAM_DELIMITER).Append(UPR_CATG_NO);
            param.Append(CConst.DB_PARAM_DELIMITER).Append(catg_no2.SelectedValue); // 분류

			string db_new_yn = new_yn.Checked ? "Y" : "N";

			string prodType = string.Empty;
            prodType = pdt_org.Checked ? pdt_org.Value : prodType;
            //prodType = pdt_new.Checked ? pdt_new.Value : prodType;
            prodType = pdt_godl.Checked ? pdt_godl.Value : prodType;

            h_prod_img1_path.Value = GetData(0, 0, "PROD_IMG1");
            h_prod_img2_path.Value = GetData(0, 0, "PROD_IMG2");
            h_prod_img3_path.Value = GetData(0, 0, "PROD_IMG3");
            h_prod_img4_path.Value = GetData(0, 0, "PROD_IMG4");
            h_prod_img5_path.Value = GetData(0, 0, "PROD_IMG5");
            h_prod_menual_path.Value = GetData(0, 0, "MANUAL");

            param.Append(CConst.DB_PARAM_DELIMITER).Append(prodType); // PROD_TYPE 입력못함
            param.Append(CConst.DB_PARAM_DELIMITER).Append(Session["admin_id"]);
            param.Append(CConst.DB_PARAM_DELIMITER).Append(img1);
            param.Append(CConst.DB_PARAM_DELIMITER).Append(img2);
            param.Append(CConst.DB_PARAM_DELIMITER).Append(img3);
            param.Append(CConst.DB_PARAM_DELIMITER).Append(img4);
            param.Append(CConst.DB_PARAM_DELIMITER).Append(img5);
            param.Append(CConst.DB_PARAM_DELIMITER).Append(clip_url.Value); // 동영상
            param.Append(CConst.DB_PARAM_DELIMITER).Append(""); // 카달로그 - 동물 의약품 입력 안함
            param.Append(CConst.DB_PARAM_DELIMITER).Append(menual); // 설명서
            param.Append(CConst.DB_PARAM_DELIMITER).Append(""); // 썸네일 - 동물 의약품 입력 안함
            param.Append(CConst.DB_PARAM_DELIMITER).Append(prod_nm.Value); // 제품명
            param.Append(CConst.DB_PARAM_DELIMITER).Append(""); // EFT가 뭔지 모르겠음
            param.Append(CConst.DB_PARAM_DELIMITER).Append(ingredi.Value); // 주요성분(성분함량)
            param.Append(CConst.DB_PARAM_DELIMITER).Append(""); // 성상 - 동물 의약품 입력 안함
            param.Append(CConst.DB_PARAM_DELIMITER).Append(pmedi.Value); // 약가
            param.Append(CConst.DB_PARAM_DELIMITER).Append(hdnContent.Value.Replace("|", "&#124;")); // 스마트 에디터
            param.Append(CConst.DB_PARAM_DELIMITER).Append(insu_cd.Value); // 보험코드
            param.Append(CConst.DB_PARAM_DELIMITER).Append(""); // 포장단위 - 동물 의약품 입력 안함
            param.Append(CConst.DB_PARAM_DELIMITER).Append(""); // 주의사항
            param.Append(CConst.DB_PARAM_DELIMITER).Append(""); // 특장
            param.Append(CConst.DB_PARAM_DELIMITER).Append(""); // 개요 - 동물 의약품 입력 안함
            param.Append(CConst.DB_PARAM_DELIMITER).Append(""); // 보관 - 동물 의약품 입력 안함
            param.Append(CConst.DB_PARAM_DELIMITER).Append(""); // 규격 - 동물 의약품 입력 안함
            param.Append(CConst.DB_PARAM_DELIMITER).Append(""); // 비고 - 동물 의약품 입력 안함
            param.Append(CConst.DB_PARAM_DELIMITER).Append(""); // 구성 - 동물 의약품 입력 안함
            param.Append(CConst.DB_PARAM_DELIMITER).Append(""); // 정보 - 동물 의약품 입력 안함
            param.Append(CConst.DB_PARAM_DELIMITER).Append(""); // 구분
			param.Append(CConst.DB_PARAM_DELIMITER).Append(new_start_dt.Value); // 신제품 START
			param.Append(CConst.DB_PARAM_DELIMITER).Append(new_end_dt.Value); // 신제품 END
			param.Append(CConst.DB_PARAM_DELIMITER).Append(open_yn); // 노출여부
			param.Append(CConst.DB_PARAM_DELIMITER).Append(db_new_yn); // 신제품 여부
			param.Append(CConst.DB_PARAM_DELIMITER).Append(""); // 동의카테고리
			param.Append(CConst.DB_PARAM_DELIMITER).Append(reg_dt.Value); // 등록일

			string[] result = null;

            if (CStringUtil.IsNullOrEmpty(ProdCd) == false)
            {
                // 수정 모드
                result = ExecuteQueryResult(3205, param.ToString());
            }
            else
            {
                // 입력 모드
                result = ExecuteQueryResult(3204, param.ToString());
            }

            if (result == null)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "test", CWebUtil.MsgBox("시스템 오류가 발생 했습니다."));
            }
            else if (result[0].Equals("00") == false)
            {
                // 입력 or 수정 실패
                ClientScript.RegisterClientScriptBlock(this.GetType(), "test", CWebUtil.MsgBox(result[1]));
            }
            else
            {
                // 입력 성공 - 이어서 태그 입력
                AddTag();
            }
        }

        /// <summary>
        /// 태그를 입력한다.
        /// </summary>
        private void AddTag()
        {
            #region 태그 입력

            string prodCd = CStringUtil.IsNullOrEmpty(ProdCd) ? prod_cd.Value : ProdCd;

            StringBuilder param = new StringBuilder();

            // 제품 태그 clear
            param.Append(LANG_CD);
            param.Append(CConst.DB_PARAM_DELIMITER).Append(prodCd);
            ExecuteQueryResult(3208, param.ToString());

            if (CStringUtil.IsNullOrEmpty(tag01.Value) == false)
            {
                param.Length = 0;

                param.Append(LANG_CD);
                param.Append(CConst.DB_PARAM_DELIMITER).Append(prodCd);
                param.Append(CConst.DB_PARAM_DELIMITER).Append(tag01.Value);

                ExecuteQuery(3207, param.ToString());
            }

            if (CStringUtil.IsNullOrEmpty(tag02.Value) == false)
            {
                param.Length = 0;

                param.Append(LANG_CD);
                param.Append(CConst.DB_PARAM_DELIMITER).Append(prodCd);
                param.Append(CConst.DB_PARAM_DELIMITER).Append(tag02.Value);

                ExecuteQuery(3207, param.ToString());
            }

            if (CStringUtil.IsNullOrEmpty(tag03.Value) == false)
            {
                param.Length = 0;

                param.Append(LANG_CD);
                param.Append(CConst.DB_PARAM_DELIMITER).Append(prodCd);
                param.Append(CConst.DB_PARAM_DELIMITER).Append(tag03.Value);

                ExecuteQuery(3207, param.ToString());
            }

            if (CStringUtil.IsNullOrEmpty(tag04.Value) == false)
            {
                param.Length = 0;

                param.Append(LANG_CD);
                param.Append(CConst.DB_PARAM_DELIMITER).Append(prodCd);
                param.Append(CConst.DB_PARAM_DELIMITER).Append(tag04.Value);

                ExecuteQuery(3207, param.ToString());
            }

            if (CStringUtil.IsNullOrEmpty(tag05.Value) == false)
            {
                param.Length = 0;

                param.Append(LANG_CD);
                param.Append(CConst.DB_PARAM_DELIMITER).Append(prodCd);
                param.Append(CConst.DB_PARAM_DELIMITER).Append(tag05.Value);

                ExecuteQuery(3207, param.ToString());
            }

            if (CStringUtil.IsNullOrEmpty(tag06.Value) == false)
            {
                param.Length = 0;

                param.Append(LANG_CD);
                param.Append(CConst.DB_PARAM_DELIMITER).Append(prodCd);
                param.Append(CConst.DB_PARAM_DELIMITER).Append(tag06.Value);

                ExecuteQuery(3207, param.ToString());
            }
            #endregion
        }

        /// <summary>
        /// 데이터 삭제
        /// </summary>
        private void RemoveData()
        {
            if (CStringUtil.IsNullOrEmpty(ProdCd) == false)
            {
                StringBuilder param = new StringBuilder();
                param.Append(LANG_CD);
                param.Append(CConst.DB_PARAM_DELIMITER).Append(ProdCd);

                string[] result = ExecuteQueryResult(3206, param.ToString());

                if (result == null)
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "test", CWebUtil.MsgBox("시스템 오류가 발생 했습니다."));
                }
                else if (result[0].Equals("00") == false)
                {
                    // 삭제 실패
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "test", CWebUtil.MsgBox(result[1]));
                }
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "test", CWebUtil.MsgBox("입력모드에서는 지원하지 않습니다."));
            }
        }

        /// <summary>
        /// 파일 삭제
        /// </summary>
        /// <param name="col"></param>
        /// <param name="path"></param>
        private void DelFile(string col, string path)
        {
            StringBuilder param = new StringBuilder();
            param.Append(LANG_CD);
            param.Append(CConst.DB_PARAM_DELIMITER).Append(ProdCd);
            param.Append(CConst.DB_PARAM_DELIMITER).Append(col);
            param.Append(CConst.DB_PARAM_DELIMITER).Append(Session["admin_id"]);

            DeleteFile(3209, param.ToString(), path);

            SearchData();
        }

        #region GET-SET

        protected string ProdCd
        {
            get
            {
                return Request["prod_cd"];
            }
        }

        protected string LANG_CD
        {
            get
            {
                if (Request["LANG_CD"] == null)
                {
                    // 기본은 국문
                    return "KOR";
                }
                else
                {
                    return Request["LANG_CD"];
                }
            }
        }

        #endregion

        #region 이벤트 메소드

        protected void btnSave_Click(object sender, EventArgs e)
        {
            SaveData();

            Response.Redirect("./pdt_ani_list.aspx?prod_cd=" + ProdCd + "&LANG_CD=" + LANG_CD);
        }

        protected void btnDel_Click(object sender, EventArgs e)
        {
            RemoveData();

            Response.Redirect("./pdt_ani_list.aspx");
        }

        protected void btnProdImg1_Click(object sender, EventArgs e)
        {
            DelFile("PROD_IMG1", h_prod_img1_path.Value);
        }

        protected void btnProdImg2_Click(object sender, EventArgs e)
        {
            DelFile("PROD_IMG2", h_prod_img2_path.Value);
        }

        protected void btnProdImg3_Click(object sender, EventArgs e)
        {
            DelFile("PROD_IMG3", h_prod_img3_path.Value);
        }

        protected void btnProdImg4_Click(object sender, EventArgs e)
        {
            DelFile("PROD_IMG4", h_prod_img4_path.Value);
        }

        protected void btnProdImg5_Click(object sender, EventArgs e)
        {
            DelFile("PROD_IMG5", h_prod_img5_path.Value);
        }

        protected void btnProdMenual_Click(object sender, EventArgs e)
        {
            DelFile("MANUAL", h_prod_menual_path.Value);
        }

        #endregion
    }
}