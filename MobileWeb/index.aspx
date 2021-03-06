﻿<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="MobileWeb.index" %>
<asp:Content ID="Content" ContentPlaceHolderID="HeadContent" runat="server">
    <header class="header main">
        <h1 class="logo"><span>대한뉴팜</span></h1>
        <button class="gnb_icon" id="j_iconOpen" onclick="return false;"><span>글로벌 네비게이션</span></button>
        <div class="search">
            <label for="f_headerSearch" class="acc-hidden"> 검색어 입력 </label>
            <input type="text" id="txt_search" runat="server"/>
            <asp:LinkButton ID="btn_Search" class="btn_headerSearch" runat="server" onClick="btnSearch_Click">검색</asp:LinkButton>
		</div>
	</header>

	<!-- 오픈시 보일 메뉴 -->
	<nav class="gnb" >
		<script src="<%=GetRoot() %>/common/include/gnb.js"></script> 	
	</nav>
	<!-- // 오픈시 보일 메뉴  -->

	<section class="container main" style="text-align:center;">
		<h1 class="acc-hidden">메인 컨텐츠</h1>
		<!-- 롤링 배너  -->
		<div class="bxslider_box"> 
			<ul  id="slider1" >
                <% 
                    if (GetDataTableCount(0) > 0)
                    {
                        // 이미지 존재
                        for (int i = 0; i < GetDataTableCount(0); i++)
                        {
                                // 링크가 있는 경우
                %>
                <li>
                    <img src="<%=GetData(0, i, "FILE_PATH") %>" alt="" onerror="this.src='/common/images/index_visual_01.jpg'" />
                </li>
                <%
                           
                        }
                    }
                    else
                    {
                        // 등록된 이미지 없음
                %>
                <img src="" alt="등록된 이미지가 없습니다." title="#caption1" onerror="this.src='/common/images/index_visual_01.jpg'" />
                <% 
                    }
                %>
			</ul>
		</div>
		<!-- // 롤링 배너  -->

		<!--  인체의약품 /동물의약품/바이오공정소재  -->
		<article class="products_go">
			<h1 class="acc-hidden"> 제품소개 </h1>	
			<ul>
				<li><a href="/pdt/pdt_human_new_list.aspx"><img src="<%=GetRoot() %>/common/images/indexPr_icon_01.png" alt="인체 의약품" /></a></li>
				<li><a href="/pdt/pdt_animal_new_list.aspx"><img src="<%=GetRoot() %>/common/images/indexPr_icon_02.png" alt="동물 의약품" /></a></li>
				<li><a href="/pdt/pdt_bio_badge_list.aspx"><img src="<%=GetRoot() %>/common/images/indexPr_icon_03.png" alt="바이오 공정소재" /></a></li>
			</ul>                
		</article> 
		<!--  //  인체의약품 /동물의약품/바이오공정소재  -->
		<div class="content  main">
			<!-- 제품소개  -->
			<article  id="slider2_btns"class="products_about">
				<h1> <span> 제품소개 </span> </h1>	
 				<ul  id="slider2" class="products_about_list bxslider">
                        <% 
                            if (GetDataTableCount(2) > 0)
                            {
                                // 이미지 존재
                                for (int i = 0; i < GetDataTableCount(2); i++)
                                {   
                                    if (GetData(0, i, "LINK_URL").Equals("") == false)
                                    {
                                        // 링크가 있는 경우
                        %>
                        <li>
						    <a href="<%=GetData(2, i, "LINK_URL") %>">
                                <img src="<%=GetData(2, i, "FILE_PATH") %>" alt="" onerror="this.src='/common/images/products/new_no.jpg'" />
                            </a>
                        </li>
                        <%
                                    }
                                    else
                                    {
                                        // 링크 없음
                        %>
                        <li>
                                <img src="<%=GetData(2, i, "FILE_PATH") %>" alt="" onerror="this.src='/common/images/products/new_no.jpg'" />
                        </li>                        
                        <%
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
 				</ul>
 				<a href="/pdt/pdt_human_new_list.aspx"><span class="more_arrow">more</span></a>	                     
			</article>
			<!-- // 제품소개  -->
			<article class="news_info">
				<h1 class="acc-hidden">새소식과 주가정보</h1>	
 				<ul>
 					<li><strong>새소식 </strong>
 						<a href="/pr/pr_new_list.aspx" ><span><%=GetData(5, 0, "TTL")%></span></a>	 
 						<a href="/pr/pr_new_list.aspx"><span class="more_arrow">more</span></a>	
 					</li>
 					<li>
                        <% 
                            if (GetDataTableCount(6) > 0)
                            {
                                string css = GetData(6, 0, "SIGN").Equals("2") ? "change_01 up" : (GetData(6, 0, "SIGN").Equals("5") ? "change_01 down" : "change_01 stand");
                                string s_css = GetData(6, 0, "SIGN").Equals("2") ? "change_02 up" : (GetData(6, 0, "SIGN").Equals("5") ? "change_02 down" : "change_02 stand");
                                string sign = GetData(6, 0, "SIGN").Equals("2") ? "+" : "";
                        %>
                        <strong>주가정보</strong> 
 						<strong class="<%=css%>"><%=GetData(6, 0, "SIGN_NM")%></strong>
 						<strong class="won"><%=GetDataComma(6, 0, "PRICE")%></strong>
 						<span class="<%=s_css%>"><%=GetDataComma(6, 0, "CHANGE")%></span>
 						<span class="gray"><%=sign%><%=GetData(6, 0, "DIFF")%>%</span>
                        <% 
                            }
                        %>
 					</li>
 				</ul>	                     
			</article>

			<article class="customer_go">
				<h1 class="acc-hidden"> <span> 고객센터 </span> </h1>	
 				<ul>
 					<li><a href="javascript:alert('모바일웹에서는 지원하실 수 없습니다.');"><img src="/common/images/indexCus_icon_01.png" alt="입사지원 " /></a></li>
 					<li><a href="/cust/inquire_list.aspx"> <img src="/common/images/indexCus_icon_02.png" alt="고객문의 " /></a></li>
 				</ul>                   
			</article> <!-- // products_go  -->
		</div> <!-- // content  -->
		
		<footer class="footer main">
		    <nav class="footer_nav">
			    <h1 class="acc-hidden"> 하단 메뉴  </h1>
			    <nav class="fnb ">
				    <ul> 
					    <li> <a href="/intro/location.aspx"> 오시는 길 </a> </li>  
					    <li> <a href="#tos"> 이용약관  </a> </li>
				    </ul>
			    </nav>
			    <p class="lnb"> 
				    <a href="/cust/inquire_list.aspx">Customer</a>  <span>|</span> 
				    <a href="/en/index.aspx">English</a> 		
			    </p>  	
		    </nav> 
		    <p class="copyright"> Copyright  &copy;  Daehan New Pharm Co.,Ltd </p>
	    </footer>
		
	</section> 
	<!-- // container main -->
</asp:Content>