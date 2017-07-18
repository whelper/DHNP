<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="search.aspx.cs" EnableEventValidation="false" Inherits="HomePage.main.search" %>
<asp:Content ID="Content" ContentPlaceHolderID="ContentPlaceLayer" runat="server">
<hr>
<section  id="content" class="container" style="padding-bottom:50px;">
	<header>
		<h1><img src="/common/images/sub/search_title_01.gif" alt="통합검색"></h1>
		<p class="location" >
			<span><img src="/common/images/common/i_home.png" alt="home"></span>
			<strong style="line-height:16px;"> Search </strong>
		</p>
	</header>
	<img src="/common/images/sub/search_img.jpg" alt="대한뉴팜에서 출시되는 모든 의약품 및 제품을 검색하실수 있습니다. ">    
	<fieldset class="search_total mB20">
		<legend class="acc-hidden">통합 검색어 입력</legend>
		<label for="<%=searchText.ClientID %>"  class="acc-hidden" >제품검색</label>
		<input type="text" runat="server" id="searchText" class="search_input w75p mR5" />
		<asp:LinkButton ID="btnSearch" runat="server" Text="Search" CssClass="btn_search fB" OnClick="btnSearch_Click" style="width:150px;text-align:center" />
	</fieldset>

	<!--  1줄 -->
	<div class="list_group clear">
        <% 
			if (GetDataCount() > 0)
			{
				for (int i = 0; i < GetDataCount(); i++)
				{

					String catg_no1 = GetData(i, "CATG_NO1");
					String prod_type = GetData(i, "PROD_TYPE");
					String product_type = "";
					String URL = "";

					if (catg_no1.Equals("1")) //인체 의약품
					{
						product_type = "i_human";
						URL = "/products/human_new_view.aspx";

					}
					else if(catg_no1.Equals("2")) // 동물 의약품
					{
						product_type = "i_animal";
						URL = "/products/animal_products_view.aspx";
					}
					else if (catg_no1.Equals("3")) // 바이오 공정소재
					{
						//product_type = "i_animal";
						if (prod_type.Equals("PROD_BADG"))
						{
							URL = "/products/bio_badge_view.aspx";
						}
						else
						{
							URL = "/products/bio_resin_view.aspx";
						}

					}
					else if (catg_no1.Equals("4")) // 수출 의약품(인체)
					{
						product_type = "i_human";
						URL = "/products/global_human_view.aspx";
					}
					else if (catg_no1.Equals("5")) // 수출 의약품(동물)
					{
						product_type = "i_animal";
						URL = "/products/global_animal_view.aspx";
					}
					else if (catg_no1.Equals("10")) // 수출 의약품(기타)
					{
						//product_type = "i_animal";
						URL = "/products/global_etc_view.aspx";
					}
					else if (catg_no1.Equals("6")) // 건강기능식품
					{
						//product_type = "i_animal";
						URL = "/products/health_products_view.aspx";
					}
					else if (catg_no1.Equals("7")) // 의료기기
					{
						//product_type = "i_animal";
						URL = "/products/medical_view.aspx";
					}

					String css = (GetData(i, "NEW_YN") == "Y") ? "s_new" : null;

        %>
		        <article class="list_Item total" >
			        <i class="<%=css%>"><em></em></i>
					<%--<i class="<%=product_type%>"></i>--%>
			        <a href="<%=URL  + "?PROD_CD=" + GetData(i, "PROD_CD")%>"><img src="<%=GetData(i, "PROD_IMG1") %>" width="232" height="177" alt="" onerror="this.src='/common/images/products/new_no.jpg'" /></a>
			        <h1><%=GetData(i, "PROD_NM") %></h1>
		        </article>	
        <% 
            }
        }
        %>
	</div>
	<!-- // 1줄 -->
    <asp:HiddenField ID="nowPageNo" runat="server"  Value="1" onvaluechanged="nowPageNo_ValueChanged"/>
    <%= HomePage.page.paging.getPageNo(DataTotalCount, Convert.ToInt32(nowPageNo.Value), 10)%>				
</section>
<script type="text/javascript" >
    function movePage(page_no) {
        document.getElementById('<%= nowPageNo.ClientID %>').value = page_no;
        document.forms[0].submit();
    }
</script>
</asp:Content>