using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

using CommonLib.Utils;
using AdminSite.m_master;


namespace AdminSite.main
{
    public partial class main_list_eng : PageBase
    {
        private const string LANG_CD = "ENG";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SearchData();
                InitControls();
            }
        }

        /// <summary>
        /// 데이터를 조회한다.
        /// </summary>
        private void SearchData()
        {
            StringBuilder param = new StringBuilder();
            param.Append(LANG_CD);

            SetDataTableList(3100, param.ToString());
        }

        /// <summary>
        /// 컨트롤 초기화
        /// </summary>
        private void InitControls()
        {
            // 각 이미지 업로드 컨트롤에 javascript 이벤트를 등록한다. (페이지단 서버 컨트롤에 삽입 불가하여 CS단에서 삽입)
            visual_text_01.Attributes.Add("onchange", "document.getElementById('" + visual_value_01.ClientID + "').value=document.getElementById('" + visual_text_01.ClientID + "').value;");
            visual_text_02.Attributes.Add("onchange", "document.getElementById('" + visual_value_02.ClientID + "').value=document.getElementById('" + visual_text_02.ClientID + "').value;");
            visual_text_03.Attributes.Add("onchange", "document.getElementById('" + visual_value_03.ClientID + "').value=document.getElementById('" + visual_text_03.ClientID + "').value;");
            visual_text_04.Attributes.Add("onchange", "document.getElementById('" + visual_value_04.ClientID + "').value=document.getElementById('" + visual_text_04.ClientID + "').value;");
            visual_text_05.Attributes.Add("onchange", "document.getElementById('" + visual_value_05.ClientID + "').value=document.getElementById('" + visual_text_05.ClientID + "').value;");

            quick_text_01.Attributes.Add("onchange", "document.getElementById('" + quick_value_01.ClientID + "').value=document.getElementById('" + quick_text_01.ClientID + "').value;");

            bottom_text_01.Attributes.Add("onchange", "document.getElementById('" + bottom_value_01.ClientID + "').value=document.getElementById('" + bottom_text_01.ClientID + "').value;");

            pdt_text_01.Attributes.Add("onchange", "document.getElementById('" + pdt_value_01.ClientID + "').value=document.getElementById('" + pdt_text_01.ClientID + "').value;");
            pdt_text_02.Attributes.Add("onchange", "document.getElementById('" + pdt_value_02.ClientID + "').value=document.getElementById('" + pdt_text_02.ClientID + "').value;");
            pdt_text_03.Attributes.Add("onchange", "document.getElementById('" + pdt_value_03.ClientID + "').value=document.getElementById('" + pdt_text_03.ClientID + "').value;");
            pdt_text_04.Attributes.Add("onchange", "document.getElementById('" + pdt_value_04.ClientID + "').value=document.getElementById('" + pdt_text_04.ClientID + "').value;");
            pdt_text_05.Attributes.Add("onchange", "document.getElementById('" + pdt_value_05.ClientID + "').value=document.getElementById('" + pdt_text_05.ClientID + "').value;");

            pop_text_21.Attributes.Add("onchange", "document.getElementById('" + pop_value_21.ClientID + "').value=document.getElementById('" + pop_text_21.ClientID + "').value;");

            visual_url_01.Value = GetData(0, 0, "LINK_URL");
            visual_url_02.Value = GetData(0, 1, "LINK_URL");
            visual_url_03.Value = GetData(0, 2, "LINK_URL");
            visual_url_04.Value = GetData(0, 3, "LINK_URL");
            visual_url_05.Value = GetData(0, 4, "LINK_URL");

            visual_use_yn_1.Checked = "Y".Equals(GetData(0, 0, "USE_YN")) ? true : false;
            visual_use_yn_2.Checked = "Y".Equals(GetData(0, 1, "USE_YN")) ? true : false;
            visual_use_yn_3.Checked = "Y".Equals(GetData(0, 2, "USE_YN")) ? true : false;
            visual_use_yn_4.Checked = "Y".Equals(GetData(0, 3, "USE_YN")) ? true : false;
            visual_use_yn_5.Checked = "Y".Equals(GetData(0, 4, "USE_YN")) ? true : false;

            hImgPath1.Value = GetData(0, 0, "FILE_PATH");
            hImgPath2.Value = GetData(0, 1, "FILE_PATH");
            hImgPath3.Value = GetData(0, 2, "FILE_PATH");
            hImgPath3.Value = GetData(0, 3, "FILE_PATH");
            hImgPath3.Value = GetData(0, 4, "FILE_PATH");

            quick_url_01.Value = GetData(1, 0, "LINK_URL");
            quick_banner_target_yn.Checked = "Y".Equals(GetData(1, 0, "TARGET_YN")) ? true : false;
            h_qk_img_path.Value = GetData(1, 0, "FILE_PATH");

            bottom_url_01.Value = GetData(2, 0, "LINK_URL");
            bottom_banner_target_yn.Checked = "Y".Equals(GetData(2, 0, "TARGET_YN")) ? true : false;
            h_btm_img_path.Value = GetData(2, 0, "FILE_PATH");

            prod_icon_gen.Checked = true; // 기본은 일반에 체크
            prod_icon_new.Checked = GetData(3, 0, "PROD_ICON").Equals("NEW") ? true : false;
            prod_icon_hot.Checked = GetData(3, 0, "PROD_ICON").Equals("HOT") ? true : false;

            pdt_url_01.Value = GetData(3, 0, "LINK_URL");
            pdt_url_02.Value = GetData(3, 1, "LINK_URL");
            pdt_url_03.Value = GetData(3, 2, "LINK_URL");
            pdt_url_04.Value = GetData(3, 3, "LINK_URL");
            pdt_url_05.Value = GetData(3, 4, "LINK_URL");

            h_prod_img1_path.Value = GetData(3, 0, "FILE_PATH");
            h_prod_img2_path.Value = GetData(3, 1, "FILE_PATH");
            h_prod_img3_path.Value = GetData(3, 2, "FILE_PATH");
            h_prod_img4_path.Value = GetData(3, 3, "FILE_PATH");
            h_prod_img5_path.Value = GetData(3, 4, "FILE_PATH");

            search_txt_01.Value = GetData(4, 0, "SRCH_TEXT");

            main_pop_use_yn.Checked = "Y".Equals(GetData(6, 0, "USE_YN")) ? true : false;
            main_pop_target_yn.Checked = "Y".Equals(GetData(6, 0, "TARGET_YN")) ? true : false;
            main_pop_link_url.Value = GetData(6, 0, "LINK_URL");
            main_pop_width.Value = GetData(6, 0, "WIDTH");
            main_pop_height.Value = GetData(6, 0, "HEIGHT");
        }

        /// <summary>
        /// 데이터를 저장한다.
        /// VISUAL: 메인 비주얼
        /// QK: 퀵배너
        /// BTM: 하단 배너
        /// PROD: 제품
        /// SRCH: 검색창 텍스트
        /// </summary>
        /// <param name="inputType">저장유형</param>
        private void SaveData(string inputType)
        {
            string result = "";

            if ("VISUAL".Equals(inputType))
            {
                StringBuilder param = new StringBuilder();

                // VISUAL 업데이트
                string vFile1 = CStringUtil.IsNullOrEmpty(visual_value_01.Value) == false ? UploadFile(visual_text_01, "DIR_MAIN") : "";
                string checkyn = visual_use_yn_1.Checked ? "Y" : "N";

                param.Append(LANG_CD);
                param.Append(CConst.DB_PARAM_DELIMITER).Append(inputType);
                param.Append(CConst.DB_PARAM_DELIMITER).Append("6");
                param.Append(CConst.DB_PARAM_DELIMITER).Append(vFile1);
                param.Append(CConst.DB_PARAM_DELIMITER).Append(visual_url_01.Value);
                param.Append(CConst.DB_PARAM_DELIMITER).Append(Session["admin_id"]);
                param.Append(CConst.DB_PARAM_DELIMITER).Append(""); // VISUAL 쪽 업데이트이므로 검색텍스트는 공백으로 줌
                param.Append(CConst.DB_PARAM_DELIMITER).Append(checkyn);
                param.Append(CConst.DB_PARAM_DELIMITER).Append("N");
                param.Append(CConst.DB_PARAM_DELIMITER).Append("");
				param.Append(CConst.DB_PARAM_DELIMITER).Append("0");
				param.Append(CConst.DB_PARAM_DELIMITER).Append("0");

				ExecuteQuery(3101, param.ToString());

                string vFile2 = CStringUtil.IsNullOrEmpty(visual_value_02.Value) == false ? UploadFile(visual_text_02, "DIR_MAIN") : "";
                checkyn = visual_use_yn_2.Checked ? "Y" : "N";
                param.Length = 0;
                param.Append(LANG_CD);
                param.Append(CConst.DB_PARAM_DELIMITER).Append(inputType);
                param.Append(CConst.DB_PARAM_DELIMITER).Append("7");
                param.Append(CConst.DB_PARAM_DELIMITER).Append(vFile2);
                param.Append(CConst.DB_PARAM_DELIMITER).Append(visual_url_02.Value);
                param.Append(CConst.DB_PARAM_DELIMITER).Append(Session["admin_id"]);
                param.Append(CConst.DB_PARAM_DELIMITER).Append("");
                param.Append(CConst.DB_PARAM_DELIMITER).Append(checkyn);
                param.Append(CConst.DB_PARAM_DELIMITER).Append("N");
                param.Append(CConst.DB_PARAM_DELIMITER).Append("");
				param.Append(CConst.DB_PARAM_DELIMITER).Append("0");
				param.Append(CConst.DB_PARAM_DELIMITER).Append("0");

				ExecuteQuery(3101, param.ToString());

                string vFile3 = CStringUtil.IsNullOrEmpty(visual_value_03.Value) == false ? UploadFile(visual_text_03, "DIR_MAIN") : "";
                checkyn = visual_use_yn_3.Checked ? "Y" : "N";
                param.Length = 0;
                param.Append(LANG_CD);
                param.Append(CConst.DB_PARAM_DELIMITER).Append(inputType);
                param.Append(CConst.DB_PARAM_DELIMITER).Append("8");
                param.Append(CConst.DB_PARAM_DELIMITER).Append(vFile3);
                param.Append(CConst.DB_PARAM_DELIMITER).Append(visual_url_03.Value);
                param.Append(CConst.DB_PARAM_DELIMITER).Append(Session["admin_id"]);
                param.Append(CConst.DB_PARAM_DELIMITER).Append("");
                param.Append(CConst.DB_PARAM_DELIMITER).Append(checkyn);
                param.Append(CConst.DB_PARAM_DELIMITER).Append("N");
                param.Append(CConst.DB_PARAM_DELIMITER).Append("");
				param.Append(CConst.DB_PARAM_DELIMITER).Append("0");
				param.Append(CConst.DB_PARAM_DELIMITER).Append("0");

				ExecuteQuery(3101, param.ToString());

                string vFile4 = CStringUtil.IsNullOrEmpty(visual_value_04.Value) == false ? UploadFile(visual_text_04, "DIR_MAIN") : "";
                checkyn = visual_use_yn_4.Checked ? "Y" : "N";
                param.Length = 0;
                param.Append(LANG_CD);
                param.Append(CConst.DB_PARAM_DELIMITER).Append(inputType);
                param.Append(CConst.DB_PARAM_DELIMITER).Append("9");
                param.Append(CConst.DB_PARAM_DELIMITER).Append(vFile4);
                param.Append(CConst.DB_PARAM_DELIMITER).Append(visual_url_04.Value);
                param.Append(CConst.DB_PARAM_DELIMITER).Append(Session["admin_id"]);
                param.Append(CConst.DB_PARAM_DELIMITER).Append("");
                param.Append(CConst.DB_PARAM_DELIMITER).Append(checkyn);
                param.Append(CConst.DB_PARAM_DELIMITER).Append("N");
                param.Append(CConst.DB_PARAM_DELIMITER).Append("");
				param.Append(CConst.DB_PARAM_DELIMITER).Append("0");
				param.Append(CConst.DB_PARAM_DELIMITER).Append("0");

				ExecuteQuery(3101, param.ToString());

                string vFile5 = CStringUtil.IsNullOrEmpty(visual_value_05.Value) == false ? UploadFile(visual_text_05, "DIR_MAIN") : "";
                checkyn = visual_use_yn_5.Checked ? "Y" : "N";
                param.Length = 0;
                param.Append(LANG_CD);
                param.Append(CConst.DB_PARAM_DELIMITER).Append(inputType);
                param.Append(CConst.DB_PARAM_DELIMITER).Append("10");
				param.Append(CConst.DB_PARAM_DELIMITER).Append(vFile5);
                param.Append(CConst.DB_PARAM_DELIMITER).Append(visual_url_05.Value);
                param.Append(CConst.DB_PARAM_DELIMITER).Append(Session["admin_id"]);
                param.Append(CConst.DB_PARAM_DELIMITER).Append("");
                param.Append(CConst.DB_PARAM_DELIMITER).Append(checkyn);
                param.Append(CConst.DB_PARAM_DELIMITER).Append("N");
                param.Append(CConst.DB_PARAM_DELIMITER).Append("");
                param.Append(CConst.DB_PARAM_DELIMITER).Append("0");
                param.Append(CConst.DB_PARAM_DELIMITER).Append("0");


				ExecuteQuery(3101, param.ToString());

                SearchData();

                visual_value_01.Value = "";
                visual_value_02.Value = "";
                visual_value_03.Value = "";
                visual_value_04.Value = "";
                visual_value_05.Value = "";

                visual_url_01.Value = GetData(0, 0, "LINK_URL");
                visual_url_02.Value = GetData(0, 1, "LINK_URL");
                visual_url_03.Value = GetData(0, 2, "LINK_URL");
                visual_url_04.Value = GetData(0, 3, "LINK_URL");
                visual_url_05.Value = GetData(0, 4, "LINK_URL");
            }
            else if ("QK".Equals(inputType))
            {
                StringBuilder param = new StringBuilder();

                // 퀵배너
                string qkFile1 = CStringUtil.IsNullOrEmpty(quick_value_01.Value) == false ? UploadFile(quick_text_01, "DIR_MAIN") : "";
                string checkyn = quick_banner_target_yn.Checked ? "Y" : "N";

                param.Append(LANG_CD);
                param.Append(CConst.DB_PARAM_DELIMITER).Append(inputType);
                param.Append(CConst.DB_PARAM_DELIMITER).Append("2");
                param.Append(CConst.DB_PARAM_DELIMITER).Append(qkFile1);
                param.Append(CConst.DB_PARAM_DELIMITER).Append(quick_url_01.Value);
                param.Append(CConst.DB_PARAM_DELIMITER).Append(Session["admin_id"]);
                param.Append(CConst.DB_PARAM_DELIMITER).Append("");
                param.Append(CConst.DB_PARAM_DELIMITER).Append("Y");
                param.Append(CConst.DB_PARAM_DELIMITER).Append(checkyn);
                param.Append(CConst.DB_PARAM_DELIMITER).Append("");
                param.Append(CConst.DB_PARAM_DELIMITER).Append("0");
                param.Append(CConst.DB_PARAM_DELIMITER).Append("0");

                ExecuteQuery(3101, param.ToString());

                SearchData();

                quick_value_01.Value = "";
                quick_url_01.Value = GetData(1, 0, "LINK_URL");
            }
            else if ("BTM".Equals(inputType))
            {
                // 하단 배너
                StringBuilder param = new StringBuilder();

                string btmFile1 = CStringUtil.IsNullOrEmpty(bottom_value_01.Value) == false ? UploadFile(bottom_text_01, "DIR_MAIN") : "";
                string checkyn = bottom_banner_target_yn.Checked ? "Y" : "N";

                param.Append(LANG_CD);
                param.Append(CConst.DB_PARAM_DELIMITER).Append(inputType);
                param.Append(CConst.DB_PARAM_DELIMITER).Append("2");
                param.Append(CConst.DB_PARAM_DELIMITER).Append(btmFile1);
                param.Append(CConst.DB_PARAM_DELIMITER).Append(bottom_url_01.Value);
                param.Append(CConst.DB_PARAM_DELIMITER).Append(Session["admin_id"]);
                param.Append(CConst.DB_PARAM_DELIMITER).Append("");
                param.Append(CConst.DB_PARAM_DELIMITER).Append("Y");
                param.Append(CConst.DB_PARAM_DELIMITER).Append(checkyn);
                param.Append(CConst.DB_PARAM_DELIMITER).Append("");
                param.Append(CConst.DB_PARAM_DELIMITER).Append("0");
                param.Append(CConst.DB_PARAM_DELIMITER).Append("0");

                ExecuteQuery(3101, param.ToString());

                SearchData();

                bottom_value_01.Value = "";
                bottom_url_01.Value = GetData(2, 0, "LINK_URL");
            }
            else if ("PROD".Equals(inputType))
            {
                // 상품
                string vFile1 = CStringUtil.IsNullOrEmpty(pdt_value_01.Value) == false ? UploadFile(pdt_text_01, "DIR_MAIN") : "";

                string prod_icon = "";
                prod_icon = prod_icon_new.Checked ? "NEW" : prod_icon;
                prod_icon = prod_icon_hot.Checked ? "HOT" : prod_icon;

                StringBuilder param = new StringBuilder();
                param.Append(LANG_CD);
                param.Append(CConst.DB_PARAM_DELIMITER).Append(inputType);
                param.Append(CConst.DB_PARAM_DELIMITER).Append("6");
                param.Append(CConst.DB_PARAM_DELIMITER).Append(vFile1);
                param.Append(CConst.DB_PARAM_DELIMITER).Append(pdt_url_01.Value);
                param.Append(CConst.DB_PARAM_DELIMITER).Append(Session["admin_id"]); // 로그인ID는 나중에 세션값 체크하여 가져오게 변경(일단 admin로 박음)
				param.Append(CConst.DB_PARAM_DELIMITER).Append("");
				param.Append(CConst.DB_PARAM_DELIMITER).Append("");
				param.Append(CConst.DB_PARAM_DELIMITER).Append("");
				param.Append(CConst.DB_PARAM_DELIMITER).Append(prod_icon);
				param.Append(CConst.DB_PARAM_DELIMITER).Append("0");
				param.Append(CConst.DB_PARAM_DELIMITER).Append("0");

				ExecuteQuery(3101, param.ToString());

                string vFile2 = CStringUtil.IsNullOrEmpty(pdt_value_02.Value) == false ? UploadFile(pdt_text_02, "DIR_MAIN") : "";
                param.Length = 0;
                param.Append(LANG_CD);
                param.Append(CConst.DB_PARAM_DELIMITER).Append(inputType);
                param.Append(CConst.DB_PARAM_DELIMITER).Append("7");
                param.Append(CConst.DB_PARAM_DELIMITER).Append(vFile2);
                param.Append(CConst.DB_PARAM_DELIMITER).Append(pdt_url_02.Value);
                param.Append(CConst.DB_PARAM_DELIMITER).Append(Session["admin_id"]);
                param.Append(CConst.DB_PARAM_DELIMITER).Append("");
                param.Append(CConst.DB_PARAM_DELIMITER).Append("");
                param.Append(CConst.DB_PARAM_DELIMITER).Append("");
                param.Append(CConst.DB_PARAM_DELIMITER).Append(prod_icon);
				param.Append(CConst.DB_PARAM_DELIMITER).Append("0");
				param.Append(CConst.DB_PARAM_DELIMITER).Append("0");

				ExecuteQuery(3101, param.ToString());

                string vFile3 = CStringUtil.IsNullOrEmpty(pdt_value_03.Value) == false ? UploadFile(pdt_text_03, "DIR_MAIN") : "";
                param.Length = 0;
                param.Append(LANG_CD);
                param.Append(CConst.DB_PARAM_DELIMITER).Append(inputType);
                param.Append(CConst.DB_PARAM_DELIMITER).Append("8");
                param.Append(CConst.DB_PARAM_DELIMITER).Append(vFile3);
                param.Append(CConst.DB_PARAM_DELIMITER).Append(pdt_url_03.Value);
                param.Append(CConst.DB_PARAM_DELIMITER).Append(Session["admin_id"]);
                param.Append(CConst.DB_PARAM_DELIMITER).Append("");
                param.Append(CConst.DB_PARAM_DELIMITER).Append("");
                param.Append(CConst.DB_PARAM_DELIMITER).Append("");
                param.Append(CConst.DB_PARAM_DELIMITER).Append(prod_icon);
				param.Append(CConst.DB_PARAM_DELIMITER).Append("0");
				param.Append(CConst.DB_PARAM_DELIMITER).Append("0");

				ExecuteQuery(3101, param.ToString());

                string vFile4 = CStringUtil.IsNullOrEmpty(pdt_value_04.Value) == false ? UploadFile(pdt_text_04, "DIR_MAIN") : "";
                param.Length = 0;
                param.Append(LANG_CD);
                param.Append(CConst.DB_PARAM_DELIMITER).Append(inputType);
                param.Append(CConst.DB_PARAM_DELIMITER).Append("9");
                param.Append(CConst.DB_PARAM_DELIMITER).Append(vFile4);
                param.Append(CConst.DB_PARAM_DELIMITER).Append(pdt_url_04.Value);
                param.Append(CConst.DB_PARAM_DELIMITER).Append(Session["admin_id"]);
                param.Append(CConst.DB_PARAM_DELIMITER).Append("");
                param.Append(CConst.DB_PARAM_DELIMITER).Append("");
                param.Append(CConst.DB_PARAM_DELIMITER).Append("");
                param.Append(CConst.DB_PARAM_DELIMITER).Append(prod_icon);
				param.Append(CConst.DB_PARAM_DELIMITER).Append("0");
				param.Append(CConst.DB_PARAM_DELIMITER).Append("0");

				ExecuteQuery(3101, param.ToString());

                string vFile5 = CStringUtil.IsNullOrEmpty(pdt_value_05.Value) == false ? UploadFile(pdt_text_05, "DIR_MAIN") : "";
                param.Length = 0;
                param.Append(LANG_CD);
                param.Append(CConst.DB_PARAM_DELIMITER).Append(inputType);
                param.Append(CConst.DB_PARAM_DELIMITER).Append("10");
                param.Append(CConst.DB_PARAM_DELIMITER).Append(vFile5);
                param.Append(CConst.DB_PARAM_DELIMITER).Append(pdt_url_05.Value);
                param.Append(CConst.DB_PARAM_DELIMITER).Append(Session["admin_id"]);
                param.Append(CConst.DB_PARAM_DELIMITER).Append("");
                param.Append(CConst.DB_PARAM_DELIMITER).Append("");
                param.Append(CConst.DB_PARAM_DELIMITER).Append("");
                param.Append(CConst.DB_PARAM_DELIMITER).Append(prod_icon);
				param.Append(CConst.DB_PARAM_DELIMITER).Append("0");
				param.Append(CConst.DB_PARAM_DELIMITER).Append("0");

				ExecuteQuery(3101, param.ToString());

                SearchData();

                pdt_value_01.Value = "";
                pdt_value_02.Value = "";
                pdt_value_03.Value = "";
                pdt_value_04.Value = "";
                pdt_value_05.Value = "";

                pdt_url_01.Value = GetData(3, 0, "LINK_URL");
                pdt_url_02.Value = GetData(3, 1, "LINK_URL");
                pdt_url_03.Value = GetData(3, 2, "LINK_URL");
                pdt_url_04.Value = GetData(3, 3, "LINK_URL");
                pdt_url_05.Value = GetData(3, 4, "LINK_URL");
            }
            else if ("SRCH".Equals(inputType))
            {
                // 검색 텍스트
                StringBuilder param = new StringBuilder();
                param.Append(LANG_CD);
                param.Append(CConst.DB_PARAM_DELIMITER).Append(inputType);
                param.Append(CConst.DB_PARAM_DELIMITER).Append("2");
                param.Append(CConst.DB_PARAM_DELIMITER).Append("");
                param.Append(CConst.DB_PARAM_DELIMITER).Append("");
                param.Append(CConst.DB_PARAM_DELIMITER).Append(Session["admin_id"]); // 로그인ID는 나중에 세션값 체크하여 가져오게 변경(일단 admin로 박음)
                param.Append(CConst.DB_PARAM_DELIMITER).Append(search_txt_01.Value); // VISUAL 쪽 업데이트이므로 검색텍스트는 공백으로 줌
                param.Append(CConst.DB_PARAM_DELIMITER).Append("");
                param.Append(CConst.DB_PARAM_DELIMITER).Append("");
                param.Append(CConst.DB_PARAM_DELIMITER).Append("");

                ExecuteQuery(3101, param.ToString());

                SearchData();

                search_txt_01.Value = GetData(4, 0, "SRCH_TEXT");
            }
            else if ("POP".Equals(inputType))
            {
                // 메인 팝업 배너 등록
                StringBuilder param = new StringBuilder();

                string vFile1 = CStringUtil.IsNullOrEmpty(pop_value_21.Value) == false ? UploadFile(pop_text_21, "DIR_MAIN") : "";
                string use_checkyn = main_pop_use_yn.Checked ? "Y" : "N";
                string target_checkyn = main_pop_target_yn.Checked ? "Y" : "N";

                param.Append(LANG_CD);
                param.Append(CConst.DB_PARAM_DELIMITER).Append(inputType);
                param.Append(CConst.DB_PARAM_DELIMITER).Append("2");
                param.Append(CConst.DB_PARAM_DELIMITER).Append(vFile1);
                param.Append(CConst.DB_PARAM_DELIMITER).Append(main_pop_link_url.Value);
                param.Append(CConst.DB_PARAM_DELIMITER).Append(Session["admin_id"]);
                param.Append(CConst.DB_PARAM_DELIMITER).Append("");
                param.Append(CConst.DB_PARAM_DELIMITER).Append(use_checkyn);
                param.Append(CConst.DB_PARAM_DELIMITER).Append(target_checkyn);
                param.Append(CConst.DB_PARAM_DELIMITER).Append("");
                param.Append(CConst.DB_PARAM_DELIMITER).Append(main_pop_width.Value);
                param.Append(CConst.DB_PARAM_DELIMITER).Append(main_pop_height.Value);

                ExecuteQuery(3101, param.ToString());

                SearchData();


                pop_value_21.Value = "";
            }

            if (CStringUtil.IsNullOrEmpty(result) == false)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "test", CWebUtil.MsgBox(result));
            }

            SearchData();
        }

        protected void DelFile(string inputType, string key, string path)
        {
            StringBuilder param = new StringBuilder();
            param.Append(LANG_CD);
            param.Append(CConst.DB_PARAM_DELIMITER).Append(inputType);
            param.Append(CConst.DB_PARAM_DELIMITER).Append(key);
            param.Append(CConst.DB_PARAM_DELIMITER).Append(Session["admin_id"]);

            DeleteFile(3103, param.ToString(), path);

            SearchData();
        }

        #region 이벤트 메소드

        protected void btnVisualSave_Click(object sender, EventArgs e)
        {
            SaveData("VISUAL");
        }

        protected void btnQKSave_Click(object sender, EventArgs e)
        {
            SaveData("QK");
        }

        protected void btnBTMSave_Click(object sender, EventArgs e)
        {
            SaveData("BTM");
        }

        protected void btnProdSave_Click(object sender, EventArgs e)
        {
            SaveData("PROD");
        }

        protected void btnSrctSave_Click(object sender, EventArgs e)
        {
            SaveData("SRCH");
        }

        protected void btnCatalSave_Click(object sender, EventArgs e)
        {
            SaveData("CATAL");
        }

        protected void btnPopSave_Click(object sender, EventArgs e)
        {
            SaveData("POP");
        }

        protected void btnDelVisualImg1_Click(object sender, EventArgs e)
        {
            DelFile("VISUAL", "6", hImgPath1.Value);
        }

        protected void btnDelVisualImg2_Click(object sender, EventArgs e)
        {
            DelFile("VISUAL", "7", hImgPath2.Value);
        }

        protected void btnDelVisualImg3_Click(object sender, EventArgs e)
        {
            DelFile("VISUAL", "8", hImgPath3.Value);
        }

        protected void btnDelVisualImg4_Click(object sender, EventArgs e)
        {
            DelFile("VISUAL", "9", hImgPath2.Value);
        }

        protected void btnDelVisualImg5_Click(object sender, EventArgs e)
        {
            DelFile("VISUAL", "10", hImgPath3.Value);
        }

        protected void btnDelQkImg_Click(object sender, EventArgs e)
        {
            DelFile("QK", "2", h_qk_img_path.Value);
        }

        protected void btnDelBtmImg_Click(object sender, EventArgs e)
        {
            DelFile("BTM", "2", h_btm_img_path.Value);
        }

        protected void btnDelProd1Img_Click(object sender, EventArgs e)
        {
            DelFile("PROD", "6", h_prod_img1_path.Value);
        }

        protected void btnDelProd2Img_Click(object sender, EventArgs e)
        {
            DelFile("PROD", "7", h_prod_img2_path.Value);
        }

        protected void btnDelProd3Img_Click(object sender, EventArgs e)
        {
            DelFile("PROD", "8", h_prod_img3_path.Value);
        }

        protected void btnDelProd4Img_Click(object sender, EventArgs e)
        {
            DelFile("PROD", "9", h_prod_img4_path.Value);
        }

        protected void btnDelProd5Img_Click(object sender, EventArgs e)
        {
            DelFile("PROD", "10", h_prod_img5_path.Value);
        }

        protected void btnDelPopImg_Click(object sender, EventArgs e)
        {
            DelFile("POP", "2", h_pop_img_path.Value);
        }

        #endregion
    }
}