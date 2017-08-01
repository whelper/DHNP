<%@ Page Language="C#" MasterPageFile="/en/EnSite.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="HomePage.en.index" %>

<asp:Content ID="Content" ContentPlaceHolderID="ContentPlaceLayer" runat="server">

    <div class="container">
		<div class="container_content clear">
   			<aside class="main_visual">
   				<h1 class="acc-hidden">대한뉴팜 비쥬얼</h1>
				<div id="slidewrap">
					<div id="slider">
                        <% 
                            if (GetDataTableCount(0) > 0)
                            {
                                // 이미지 존재
                                for (int i = 0; i < GetDataTableCount(0); i++)
                                {
                                    if (GetData(0, i, "FILE_PATH").Equals("") == false)
                                    {
                                        if (GetData(0, i, "LINK_URL").Equals("") == false)
                                        {
                                        // 링크가 있는 경우
                        %>
						<a href="<%=GetData(0, i, "LINK_URL") %>">
                            <img src="<%=GetData(0, i, "FILE_PATH") %>" alt="따뜻함을 함께하는 기업 대한 뉴팜이  있습니다." onerror="this.src='/common/images/main/visual_none.jpg'" style="width:560px;height:646px" title="#caption1" />
                        </a>
                        <%
                                        }
                                        else
                                        {
                                        // 링크 없음
                        %>
                        <img src="<%=GetData(0, i, "FILE_PATH") %>" alt="따뜻함을 함께하는 기업 대한 뉴팜이  있습니다. " onerror="this.src='/common/images/main/visual_none.jpg'" style="width:560px;height:646px" title="#caption1" />                            
                        <%
                                        }
                                    }
                                }
                            }
                            else
                            {
                                // 등록된 이미지 없음
                        %>
                        <img src="" alt="등록된 이미지가 없습니다." title="#caption1" />
                        <% 
                            }
                        %>
					</div>
				</div> <!-- // slidewrap -->
   			</aside>

   			<section class="main_content">
   				<h1 class="acc-hidden">대한뉴팜 컨텐츠</h1>
   				<div class="search">
                    <label for="<%=name01.ClientID %>" class="acc-hidden">검색어 입력하기</label>
   					<input type="text" id="name01" placeholder="<%=searchText%>" runat="server"/>

                    <asp:LinkButton ID="btn_Search" class="btn_search" runat="server" onClick="btnSearch_Click">검색</asp:LinkButton>
                                        
   				</div> <!-- search -->
   				<article class="products  clear">
   					<h1><span>제품</span></h1>
                    <div class="hot">
                        <% if (GetData(2, 0, "PROD_ICON").Equals("NEW"))
                           { %>
						<i class="new"><span>NEW</span> </i> 
                        <% }
                           else if (GetData(2, 0, "PROD_ICON").Equals("HOT"))
                           {
                        %>
						<i class="hot_01"><span>HOT</span> </i>
                        <% 
                            }
                        %>
					</div>
   					<p>Introducing our new and hit products</p>
					<ul id="slides1">
                        <%
                               if (GetDataTableCount(2) > 0)
                               {
                                   for (int i = 0; i < GetDataTableCount(2); i++)
                                   {
                                       if (GetData(2, i, "FILE_PATH").Equals("") == false)
                                       {
                        %>
						<li>
		   					<div class="content">
                                <% 
                                           if (GetData(2, i, "LINK_URL").Equals("") == false)
                                           {
                                        // URL 링크가 있는 경우
                                %>
		   						<a href="<%=GetData(2, i, "LINK_URL")%>"><img src="<%=GetData(2, i, "FILE_PATH") %>" alt="" /></a>
                                <%
                                           }
                                           else
                                           {
                                        // URL 링크가 없는 경우
                                %>
                                <img src="<%=GetData(2, i, "FILE_PATH") %>" alt="" />  <%--style="width:348px;height:110px"--%>
                                <% 
                                           }
                                %>
		   					</div>
		   				</li>
                        <%
                                       }
                                   }
                               }
                               else
                               {
                        %>
                        <li>
		   					<div class="content">
		   						<h2>등록된 제품 없음</h2> 
		   						<p>등록된 제품 없음</p>
		   						<img src="/en/common/images/main/products_none.jpg" alt="" />
		   					</div>
		   				</li>
                        <% 
                               }
                        %>
						
					</ul>
   				</article> <!-- products -->

				<article class="kosdaq">
					<h1><span>주가정보</span></h1>
					<ul id="ul_kosdaq" class="kosdaq_ul clear">
                        <li><span class="change_01 <%=NvCss %>"><%=Nv %></span></li>
                        <li><span class="won"><%=Nv %></span></li>
                        <li><span class="change_02 <%=CvCss %>"><%=Cv %></span></li>
                        <li><span class="gray"><%=CrSign %><%=Cr %>% </span></li>                    
                    </ul>				
				</article> <!-- // kosdaq -->
                

   				<article class="news clear">
   					<h1 class="news_title"><span>새소식</span></h1>
   					<ul class="news_ul">
                    <% 
                        if (GetDataTableCount(3) > 0)
                        {
                            for (int i = 0; i < GetDataTableCount(3); i++)
                            {
                    %>
   						<li><em><%=GetData(3, i, "TTL")%></em><span><%=GetData(3, i, "REG_DT")%></span></li>
                    <% 
                            }
                        }
                        else
                        {
                    %>
                    <li>등록된 새소식이 없습니다.</li>
                    <% 
                        }
                    %>
   					</ul>
   					<span>뉴스 더보기</span>
   				</article> <!-- // news -->

   				<article class="customer clear">
   					<h1 class="acc-hidden">고객센터</h1>
   					<ul class="customer_ul">
   						<li> <a href="/en/intro/location.aspx"><img src="/en/common/images/main/customer_04.png" alt="제휴제안 - +82 2 3415-7833" /></a></li>
                        <li><a href="/en/customer/inquire.aspx"><img src="/en/common/images/main/customer_03.png" alt="제휴제안 - +82 2 3415-7833" /></a></li>
   					</ul>		
   				</article> <!-- // customer -->
					
					<!--
   				<article class="products_manu clear">
   					<h1 class="acc-hidden">제품메뉴로 바로가기</h1>
   					<a href="/en/products/human_new_list.aspx" class="line_Lno"><img src="/en/common/images/main/i_memu_01.png" alt="인체의 약품 " /></a>
   					<a href="/en/products/animal_new_list.aspx"><img src="/en/common/images/main/i_memu_02.png" alt="동물의 약품 " /></a>
   					<a href="/en/products/bio_badge_list.aspx"><img src="/en/common/images/main/i_memu_03.png" alt="바이오공정소개 " /></a>
                    <% 
                        if (GetDataTableCount(4) > 0)
                        {
                            for (int i = 0; i < GetDataTableCount(4); i++)
                            {
                    %>
                    <% 
                        string bottom_target = "Y".Equals(GetData(4, 0, "TARGET_YN")) ? "_blank" : "_self";   
                    %>
                    
   					<a href="<%=GetData(4, i, "LINK_URL") %>" class="cf" target="<%=bottom_target%>"><img src="<%=GetData(4, i, "FILE_PATH") %>" alt="하단배너" style="width:420px;height:67px"></a>	
                    <% 
                            }
                        }
                    %>
   				</article> -->

					<ARTICLE class="products_manu clear">
					<H1 class="acc-hidden">제품메뉴로 바로가기</H1>
					<A class="line_Lno" href="/en/products/human_new_list.aspx"><IMG alt="인체의 약품" src="/en/common/images/main/i_memu_01.png" onmouseover="this.src='/en/common/images/main/i_memu_01_on.png'" onmouseout="this.src='/en/common/images/main/i_memu_01.png'"></A>      
					<A href="/en/products/animal_new_list.aspx"><IMG alt="동물의 약품" src="/en/common/images/main/i_memu_02.png" onmouseover="this.src='/en/common/images/main/i_memu_02_on.png'" onmouseout="this.src='/en/common/images/main/i_memu_02.png'"></A>      
					<A href="/en/products/bio_badge_list.aspx"><IMG alt="바이오 약품" src="/en/common/images/main/i_memu_03.png" onmouseover="this.src='/en/common/images/main/i_memu_03_on.png'" onmouseout="this.src='/en/common/images/main/i_memu_03.png'"></A>      


					</ARTICLE>
					
					<!-- // customer -->

   			</section>	<!--// main_content -->
   		</div> <!--// container_content -->
    </div> <!--// container -->

    <% 
        if (GetDataTableCount(6) > 0)
        {
            for (int i = 0; i < GetDataTableCount(6); i++)
            {
    %>
    <!-- popup  ********************************** **********************************-->
    <div class="pop_wrap" id="pop_wrap">
    <!-- 	<div class="pop_wrap_alpha"></div> -->
	    <div id="popupContainer_01" >
		    <section class="popupContent_main" style="width:720px;">
			    <h1 class="acc-hidden">special Event</h1>
                <% 
                    string target = "Y".Equals(GetData(6, 0, "TARGET_YN")) ? "_blank" : "_self";
                    
                    if ("".Equals(GetData(6, 0, "LINK_URL")) == false)
                    {
                %>
                <a href="<%=GetData(6, 0, "LINK_URL") %>" target="<%=target%>">
                    <p class="popup_auto">
                        <img src="<%=GetData(6, i, "FILE_PATH") %>" alt="" />
                    </p>
                </a>
                <% 
                    }
                    else
                    {
                %>
                <p class="popup_auto">
                    <img src="<%=GetData(6, i, "FILE_PATH") %>" alt=""/>
                </p>
                <% 
                    }
                %>
			    <div class="mainPopup_btn">
				    <span class="mainPopup_btn">
                        <span class="left"> 
                            <input type="checkbox" id="pBox" /> 
                            <label onclick="dayClose(1000); return false;">다시보지않기</label></span> 
                        <span class="right">
                            <input type="checkbox" id="cBox"/> <%--checked="checked"--%>
                            <label onclick="dayClose(1); return false;">오늘 하루닫기</label>
                        </span>
                    </span> 
			    </div>
			    <button class="btn_close" onclick="mainPopupClose(); return false;">닫기</button>
		    </section> 		                                 
        </div>											
    </div>
    <!--// popup  *********************************************************************-->
    <% 
            }
        }
    %>

  <script type="text/javascript">
      $(window).load(function () {
          $('#slider').nivoSlider();   //  메인 비쥬얼 

          $('#slides1').bxSlider({    //  제품 배너 
              prev_image: '/common/images/common/btn_arrow_left.png',
              next_image: '/common/images/common/btn_arrow_right.png',
              wrapper_class: 'slides1_wrap',
              margin: 70,
              auto: true,
              auto_controls: true
          });
      });

      //  메인 팝업 자동조절 
      var popupwidth = $(".popup_auto>img").width();
      var popupheight = $(".popup_auto>img").height();
      $(".popupContent_main").css("width", popupwidth + "px");
      $(".popupContent_main").css("height", popupheight + "px");
      var popupLeft = $(".popup_auto>img").width() / 2;
      var popupTop = $(".popup_auto>img").height() / 2 + 60;
      $(".popupContent_main").css("margin-top", "-" + popupTop + "px");
      $(".popupContent_main").css("margin-left", "-" + popupLeft + "px");

      /***********************************************
      팝업 Popup_f(this.href,580);
      *************************************************/

      // 페이지 로딩시 실행 
      openPop("Notice");

      // 팝업창 열기  
      function openPop(winName) {
          var blnCookie = getCookie(winName);
          var obj = eval("window." + winName);
          if (!blnCookie) {
              $("#pop_wrap").fadeIn();
          }
          else {
              $("#pop_wrap").hide();
          }
      }

      function dayClose(day) {
          if ($("#cBox").is(":checked") == true || $("#pBox").is(":checked") == true) {

              var todayDate = new Date();
              todayDate.setDate(todayDate.getDate() + day);
              document.cookie = "Notice" + "=" + escape("done") + "; path=/; expires=" + todayDate.toGMTString() + ";"
          }

          $("#pop_wrap").hide();
      }

      // 쿠키 가져오기  
      function getCookie(name) {
          var nameOfCookie = name + "=";
          var x = 0;
          while (x <= document.cookie.length) {
              var y = (x + nameOfCookie.length);
              if (document.cookie.substring(x, y) == nameOfCookie) {
                  if ((endOfCookie = document.cookie.indexOf(";", y)) == -1)
                      endOfCookie = document.cookie.length;
                  return unescape(document.cookie.substring(y, endOfCookie));
              }
              x = document.cookie.indexOf(" ", x) + 1;
              if (x == 0)
                  break;
          }
          return "";
      }

      // 팝업 닫기
      function mainPopupClose() {
          $("#pop_wrap").hide();
      }
  </script>

</asp:Content>

