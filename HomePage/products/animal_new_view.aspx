﻿<%@ Page Language="C#" MasterPageFile="~/Products_Sub.Master" AutoEventWireup="true" CodeBehind="animal_new_view.aspx.cs" Inherits="HomePage.products.animal_new_view" %>
<asp:Content ID="Content" ContentPlaceHolderID="ContentPlaceSubLayer" runat="server">
<p class="pdf_target">
    <%
        string rep_catg_url = RepCatal;
        if ("".Equals(rep_catg_url))
        {
    %>
    <a href="javascript:alert('등록된 카달로그가 없습니다. 고객센터로 문의해 주세요.');">
        <img src="/common/images/common/btn_pdf_02.png" alt="카다로그 다운로드" />
    </a>
    <% 
        }
        else
        {
    %>
    <a href="<%=rep_catg_url %>">
        <img src="/common/images/common/btn_pdf_02.png" alt="카다로그 다운로드" />
    </a>
    <% 
        }
    %>
</p>
</nav> <!-- // snb -->
    
    <section id="content" class="sub_content" >
	<header>
		<h1 class="pageTitle"> 신제품 </h1>
		<p class="location">
			<a href="/index.aspx"><span><img src="/common/images/common/i_home.png" alt="home" /></span></a>
			<a href="/products/human_new_list.aspx"><span>제품</span></a><em> > </em>
			<a href="/products/animal_new_list.aspx"><span>동물의약품</span></a><em> > </em>
			<a href="/products/animal_new_list.aspx"><strong>신제품</strong></a>
		</p>
	</header>
	<!--  내용  ***************** -->
	<div class="view_box clear">  
		<!-- 갤러리 -->
	 	<figure class="view_img">
	 		<i class="i_new"> <em> new </em></i>
	 		<%
                string img1Big = GetData(0, "PROD_IMG1").Equals("") ? "/common/images/products/no_big.jpg" : GetData(0, "PROD_IMG1");
                string img1 = GetData(0, "PROD_IMG1").Equals("") ? "/common/images/products/no_small.jpg" : GetData(0, "PROD_IMG1");
                string img2 = GetData(0, "PROD_IMG2").Equals("") ? "/common/images/products/no_small.jpg" : GetData(0, "PROD_IMG2");
                string img3 = GetData(0, "PROD_IMG3").Equals("") ? "/common/images/products/no_small.jpg" : GetData(0, "PROD_IMG3");
                string img4 = GetData(0, "PROD_IMG4").Equals("") ? "/common/images/products/no_small.jpg" : GetData(0, "PROD_IMG4");
                string img5 = GetData(0, "PROD_IMG5").Equals("") ? "/common/images/products/no_small.jpg" : GetData(0, "PROD_IMG5");
				string[] thumb = { img1,img2,img3,img4,img5 };
			%>

            <a class= "image-popup-vertical-fit" href="<%=img1Big %>">
	 		<img id="largeImage" src="<%=img1Big %>" width="300" height="218" alt="" > 
            </a>
	 		<div  id="thumbs" class="small" >
				 <%
					foreach (string s in thumb) {
						if (s == "/common/images/products/no_small.jpg") continue;
				%>
				<span><img src="<%=s%>" width="56" height="56" alt="" onerror="this.src='/common/images/products/new_no.jpg'"></span>
				<%
					}
				%>
		 		<!--<span><img src="<%=img1%>" width="56" height="56" alt="" onerror="this.src='/common/images/products/new_no.jpg'"></span>
		 		<span><img src="<%=img2%>" width="56" height="56" alt="" onerror="this.src='/common/images/products/new_no.jpg'"></span>
		 		<span><img src="<%=img3%>" width="56" height="56" alt="" onerror="this.src='/common/images/products/new_no.jpg'"></span>
		 		<span><img src="<%=img4%>" width="56" height="56" alt="" onerror="this.src='/common/images/products/new_no.jpg'"></span>
		 		<span><img src="<%=img5%>"  width="56" height="56" alt=""onerror="this.src='/common/images/products/new_no.jpg'"></span> 
		 		-->
			 </div>
	 	</figure>

	 	<article class="view_text">
	  		<h1><%=GetData(0, "PROD_NM") %></h1>
		  	<ul class="view_text_ul">
	  			<li><strong>분류</strong><em><%=GetData(0, "CATG_NM2")%></em></li>
               <%if (!GetData(0, "CATG_NO").Equals("0")){ %>
				<li><strong>분류번호</strong><em><%=GetData(0, "CATG_NO")%></em></li>
	  			<%} %>
				<%if (!GetData(0, "INGREDI").Equals("")){ %>
				<li><strong>주요성분</strong><em><%=GetData(0, "INGREDI")%></em></li>
	  			<%} %>
	  			<%if (!GetData(0, "INSU_CD").Equals("")){ %>
				<li><strong>보험코드</strong><em><%=GetData(0, "INSU_CD")%></em></li>
                <%} %>
				<%if (!GetData(0, "PMEDI").Equals("")){ %>
				<li><strong>약가</strong><em><%=GetData(0, "PMEDI")%></em></li>
	  			<%} %>
	  		</ul>
	  		<p class="btn_target"> 
                <% 
                    if (GetData(0, "MANUAL").Equals("") == false)
                    {
                %>
	  			<button type="button" class="view_story" onclick="download_descript('<%=GetData(0, "MANUAL")%>');"><span> 제품설명서</span></button>
                <% 
                    }
                %>
                <% 
                    if (GetData(0, "CLIP_URL").Equals("") == false)
                    {
                %>
	  			<a href="#pop_mov_guide" data-toggle="modal"><button type="button" class="view_video"><span> 동영상 보기</span></button></a>
                <% 
                    }
                %>
                <button type="button" onclick="window.print();" class="view_print"><span>인쇄하기</span></button>
	  		</p>
	 	</article>	
	</div> <!--// view_box -->
	<div class="con_tap_box">
	 	<article class="con_tap_01">   <!-- 주요정보 내용  -->
	 		<h1 class="tap_01"> 
	 			<a href="#none" id="tap_01" onclick="changeContent_tap(1); return false;" class="onhover"> 주요정보 </a> 
	 		</h1>
	 		<div  class="content tab_content_01"> 
	 			<dl>
					<dd><%=GetData(0, "USAGE") %></dd>
				</dl>
			</div>
	 	</article>    <!--  // 주요정보 내용  -->
	 	<div class="sns_box"> 
  			<ul>
  				<li><button type="button" onclick="javascript:history.back();" class="btn_view_list" ><span>목록보기</span></button></li>
  			</ul>
  		</div>
	</div> <!--// con_tap_box -->
	<!-- // 내용 ***************** -->         
</section>  <!--// sub_content -->

<% 
    if (GetData(0, "CLIP_URL").Equals("") == false)
    {
%>
<div id="pop_mov_guide" class="modal hide fade" style="display: none; ">
	<div class="modal-header">
		<h3>동영상</h3>
		<button type="button" class="close" data-dismiss="modal"><span class="icon_close"></span></button>
	</div>
	<div class="modal-body">	
		<div class="movie_iframe">
            <iframe title="youtube clips" width="100%" height="100%" style="height:300px" src="http://www.youtube.com/embed/<%=GetData(0, "CLIP_URL")%>" frameborder="0" allowscriptaccess="always" allowfullscreen="true"></iframe>
        </div>
	</div>
	<div class="modal-footer">
	    <a href="#" data-dismiss="modal"><button class="btn">닫기</button></a>
	</div>
</div>
<% 
    }
%>


<script>    !function (d, s, id) { var js, fjs = d.getElementsByTagName(s)[0], p = /^http:/.test(d.location) ? 'http' : 'https'; if (!d.getElementById(id)) { js = d.createElement(s); js.id = id; js.src = p + '://platform.twitter.com/widgets.js'; fjs.parentNode.insertBefore(js, fjs); } } (document, 'script', 'twitter-wjs');</script>
<script>
    (function (d, s, id) {
        var js, fjs = d.getElementsByTagName(s)[0];
        if (d.getElementById(id)) return;
        js = d.createElement(s); js.id = id;
        js.src = "//connect.facebook.net/ko_KR/all.js#xfbml=1";
        fjs.parentNode.insertBefore(js, fjs);
    } (document, 'script', 'facebook-jssdk'));
</script>
<script type="text/javascript">
    var download_descript = function (url) {
        location.href = url;
    }
</script>

</asp:Content>