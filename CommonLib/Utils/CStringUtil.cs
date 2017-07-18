using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Configuration;
using System.Data;

namespace CommonLib.Utils
{
    /// <summary>
    /// String 변환 유틸
    /// </summary>
    public static class CStringUtil
    {
        /// <summary>
        /// 공백이거나 NULL인지 확인
        /// </summary>
        /// <param name="str">확인할 스트링</param>
        /// <returns>공백orNULL여부</returns>
        public static bool IsNullOrEmpty(string str)
        {
            bool result = false;
            try
            {
                if (str == null || "".Equals(str.Trim()))
                {
                    result = true;
                }
            }
            catch
            {
                result = true;
            }

            return result;
        }

        /// <summary>
        /// 널이면 공백을 리턴
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static string ConvertNullToBlank(string src)
        {
            if (IsNull(src) || src == "")
            {
                return "";
            }

            return Convert.ToString(src);
        }

        /// <summary>
        /// Null or Empty이면 ret리턴
        /// Null or Empty가 아니면 src를 그대로 리턴
        /// </summary>
        /// <param name="src">String원본</param>
        /// <param name="ret">Null or Empty일때 리턴할 스트링</param>
        /// <returns></returns>
        public static string ConvertNullOrEmpty(string src, string ret)
        {
            if (IsNullOrEmpty(src))
            {
                return ret;
            }
            else
            {
                return src;
            }
        }

        /// <summary>
        /// Null or Empty or 숫자가 아니면 정수 0을 리턴
        /// 그 외에는 src를 숫자로 변환해서 리턴
        /// </summary>
        /// <param name="src">string원본</param>
        /// <returns></returns>
        public static int ConvertNullOrEmptyToZero(string src)
        {
            int result = 0;

            if (IsNullOrEmpty(src) || IsNumber(src) == false)
            {
                // Null or Empty이거나 숫자가 아니면 0을 리턴
                result = 0;
            }
            else
            {
                result = Convert.ToInt32(src);
            }

            return result;
        }

        /// <summary>
        /// Null 확인
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static bool IsNull(string src)
        {
            bool result = false;

            if (src == null)
            {
                result = true;
            }

            return result;
        }

        /// <summary>
        /// 숫자인지 판별
        /// </summary>
        /// <param name="src">숫자인지 확인할 값</param>
        /// <returns>숫자 true/false</returns>
        public static bool IsNumber(string src)
        {
            bool result = false;

            try
            {
                Convert.ToInt32(src);

                result = true;
            }
            catch
            {
                result = false;
            }

            return result;
        }

        /// <summary>
        /// 특수문자 제거
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string RemoveSpecialChar(string src)
        {
            string temp = System.Text.RegularExpressions.Regex.Replace(src, @"[^a-zA-Z0-9가-힣  ]", "", RegexOptions.Singleline);

            // string tt = "[홍상수특별展] <북촌방향> 프리미어";
            temp.Replace("[", "");
            temp.Replace("]", "");
            temp.Replace("<", "");
            temp.Replace(">", "");

            return temp;
        }

        public static string ConvertStartDate(string src)
        {
            if (src.Equals(""))
            {
                return "";
            }
            else
            {
                return src + " 00:00:00.000";
            }
        }

        /// <summary>
        /// 날짜에 시간을 더해서 반환
        /// DB에 저장 시 다음날짜로 저장됨 (의도한 사항인지는 모르겠음)
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static string ConvertEndDate(string src)
        {
            if (IsNullOrEmpty(src))
            {
                return "";
            }
            else
            {
                return src + " 23:59:59.000";
            }
        }

        /// <summary>
        /// HTML 표기값을 공백으로 변경 리턴한다
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string GetInnerHtmltext(this string data)
        {

            string decode = data;// System.Web.HttpUtility.HtmlDecode(data);
            Regex objRegExp = new Regex("<(.|\n)+?>");
            string replace = objRegExp.Replace(decode, "");
            return replace.Trim("\t\r\n ".ToCharArray());

        }

        /// <summary>
        /// 오늘 요일에 해당하는 숫자를 가져온다.
        /// 일:1, 월:2 ... 토:7
        /// </summary>
        /// <returns></returns>
        public static string GetNowDayOfWeek()
        {
            string[,] dayOfWeek = { { "Sunday", "1" }
                                      , { "Monday", "2" }                                      
                                      , { "Tuesday", "3" }
                                      , { "Wednesday", "4" }
                                      , { "Thursday", "5" }
                                      , { "Friday", "6" }
                                      , { "Saturday", "7" }
                                  };

            string result = "";

            for (int i = 0; i < dayOfWeek.GetLength(0); i++)
            {
                //System.Diagnostics.Debug.WriteLine(DateTime.Now.DayOfWeek + "..." + dayOfWeek[i, 0]);
                if (DateTime.Now.DayOfWeek.ToString().Equals(dayOfWeek[i, 0]))
                {
                    result = dayOfWeek[i, 1];
                    break;
                }
            }

            return result;
        }

        /// <summary>
        /// 원본파일명_yyyyMMddHHmmssfff.확장자로 구성된 새로운 파일명을 리턴
        /// </summary>
        /// <param name="filename">원본 파일명</param>
        /// <returns>원본파일명_yyyyMMddHHmmssfff.확장자</returns>
        public static string GetNewFileName(string filename)
        {
            string result = filename;

            try
            {   
                string tempFilename = filename.Substring(0, filename.LastIndexOf(".")) + "_" + CDateUtil.GetFullNowDate();
                string ext = filename.Substring(filename.LastIndexOf("."), filename.Length - filename.LastIndexOf("."));
                result = tempFilename + ext;
            }
            catch
            {
            }

            return result;
        }

        /// <summary>
        /// 파일 이름내에 ; 문자 및 확장자 검사
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static bool CheckCSVFile(string fileName)
        {
            bool result = true;

            if (fileName.Length < 4 || !fileName.Substring(fileName.Length - 4, 4).ToUpper().Equals(".CSV"))
            {
                result = false;
            }

            if (fileName.IndexOf(';') > -1)
            {
                result = false;
            }

            return result;
        }

        /// <summary>
        /// DataTable의 특정 col을 delemeter 기준으로 변환하는 메소드
        /// </summary>
        /// <param name="dt">데이터 원본 테이블</param>
        /// <param name="col">대상 컬럼</param>
        /// <param name="delemeter">각 데이터의 구분자</param>
        /// <returns>delemeter로 구분된 String</returns>
        public static string GetDelemeterStr(DataTable dt, string col, string delemeter)
        {
            StringBuilder sb = new StringBuilder();

            if (dt != null && dt.Rows.Count > 0)
            {
                for(int i=0; i < dt.Rows.Count; i++)
                {
                    sb.Append(dt.Rows[i][col]).Append(delemeter);
                }

                sb.Length = sb.Length - 1;
            }

            return sb.ToString();
        }

        /// <summary>
        /// DIR 유형에 따라 디렉토리+filename을 조합해서 리턴함
        /// </summary>
        /// <param name="filename">파일명</param>
        /// <param name="dirType">디렉토리 유형(메인, 상품, 홍보, 투자 ...)</param>
        /// <returns></returns>
        public static string GetRootDir(string filename, CConst.DIR_TYPE dirType)
        {
            string dir = string.Empty;

            if (CConst.DIR_TYPE.DIR_MAIN.Equals(dirType))
            {
                dir = CConst.DIR_MAIN + filename;
            }
            else if (CConst.DIR_TYPE.DIR_PRODUCT.Equals(dirType))
            {
                dir = CConst.DIR_PRODUCT + filename;
            }
            else if (CConst.DIR_TYPE.DIR_PROMOTION.Equals(dirType))
            {
                dir = CConst.DIR_PROMOTION + filename;
            }
            else if (CConst.DIR_TYPE.DIR_INVESTMENT.Equals(dirType))
            {
                dir = CConst.DIR_INVESTMENT + filename;
            }
            else if (CConst.DIR_TYPE.DIR_RECRUITMENT.Equals(dirType))
            {
                dir = CConst.DIR_RECRUITMENT + filename;
            }
            else if (CConst.DIR_TYPE.DIR_RECRUITMENT_USER.Equals(dirType))
            {
                dir = CConst.DIR_RECRUITMENT_USER + filename;
            }
            else if (CConst.DIR_TYPE.DIR_CUSTOMER.Equals(dirType))
            {
                dir = CConst.DIR_CUSTOMER + filename;
            }
            else
            {
                dir = filename;
            }

            return dir;
        }

        /// <summary>
        /// 한글 초성 범위를 가져온다.
        /// </summary>
        /// <param name="langCd">언어코드(KOR, ENG)</param>
        /// <param name="type">S(시작), E(종료)</param>
        /// <returns></returns>
        public static string GetInitial(string langCd, string type, string exp)
        {
            string result = exp;

            if ("KOR".Equals(langCd))
            {
                if ("S".Equals(type))
                {
                    #region 한글 시작 범위
                    switch (exp)
                    {
                        case "INIT_1":
                            result = "가";
                            break;
                        case "INIT_2":
                            result = "나";
                            break;
                        case "INIT_3":
                            result = "다";
                            break;
                        case "INIT_4":
                            result = "라";
                            break;
                        case "INIT_5":
                            result = "마";
                            break;
                        case "INIT_6":
                            result = "바";
                            break;
                        case "INIT_7":
                            result = "사";
                            break;
                        case "INIT_8":
                            result = "아";
                            break;
                        case "INIT_9":
                            result = "자";
                            break;
                        case "INIT_10":
                            result = "차";
                            break;
                        case "INIT_11":
                            result = "카";
                            break;
                        case "INIT_12":
                            result = "타";
                            break;
                        case "INIT_13":
                            result = "파";
                            break;
                        case "INIT_14":
                            result = "하";
                            break;
                    }
                    #endregion
                }
                else if ("E".Equals(type))
                {
					#region 한글 종료 범위
					switch (exp)
					{
						case "INIT_1":
							result = "나";
							break;
						case "INIT_2":
							result = "다";
							break;
						case "INIT_3":
							result = "라";
							break;
						case "INIT_4":
							result = "마";
							break;
						case "INIT_5":
							result = "바";
							break;
						case "INIT_6":
							result = "사";
							break;
						case "INIT_7":
							result = "아";
							break;
						case "INIT_8":
							result = "자";
							break;
						case "INIT_9":
							result = "차";
							break;
						case "INIT_10":
							result = "카";
							break;
						case "INIT_11":
							result = "타";
							break;
						case "INIT_12":
							result = "파";
							break;
						case "INIT_13":
							result = "하";
							break;
						case "INIT_14":
							result = "힣";
							break;
					}
					//switch (exp)
					//{
					//    case "INIT_1":
					//        result = "낗";
					//        break;
					//    case "INIT_2":
					//        result = "닣";
					//        break;
					//    case "INIT_3":
					//        result = "띻";
					//        break;
					//    case "INIT_4":
					//        result = "맇";
					//        break;
					//    case "INIT_5":
					//        result = "밓";
					//        break;
					//    case "INIT_6":
					//        result = "삫";
					//        break;
					//    case "INIT_7":
					//        result = "앃";
					//        break;
					//    case "INIT_8":
					//        result = "잏";
					//        break;
					//    case "INIT_9":
					//        result = "찧";
					//        break;
					//    case "INIT_10":
					//        result = "칳";
					//        break;
					//    case "INIT_11":
					//        result = "킿";
					//        break;
					//    case "INIT_12":
					//        result = "탛";
					//        break;
					//    case "INIT_13":
					//        result = "핗";
					//        break;
					//    case "INIT_14":
					//        result = "힣";
					//        break;
					//}
					#endregion
				}
            }

            return result;
        }

        /// <summary>
        /// 파일 경로에서 순수 파일명을 추출한다.
        /// </summary>
        /// <param name="filepath">파일경로(경로+파일명)</param>
        /// <returns></returns>
        public static string GetOrgFileName(string filepath)
        {
            string filename = string.Empty;

            if (IsNullOrEmpty(filepath)) return filepath;

            try
            {
                filename = filepath.Substring(filepath.LastIndexOf("/") + 1, filepath.Length - filepath.LastIndexOf("/") - 1);
            }
            catch
            {
                
            }

            return filename;
        }

        /// <summary>
        /// 문자열 크기 변환 메소드
        /// inputString : 입력 문자열
        /// stringLength : 자를 길이
        public static string StringTransfer(string inputString, int stringLength)
        {
            string data = "";
            int byteLen = Convert.ToInt32(Encoding.GetEncoding(949).GetBytes(inputString).GetLength(0));

            if (byteLen > stringLength)
            {   
                for (int i = 0; i < inputString.Length; i++)
                {   
                    data = data + inputString.Substring(i, 1);

                    byteLen = Encoding.GetEncoding(949).GetBytes(data).Length;

                    if (byteLen > stringLength) break;
                }
                
                data = data.Trim() + "..";
            }
            else
            {
                data = inputString;
            }
            
            return data;
        }
    }
}
