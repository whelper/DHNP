﻿<%@ Page Language="C#" MasterPageFile="/en/EnSiteSub.Master" AutoEventWireup="true" CodeBehind="stock_info.aspx.cs" Inherits="MobileWeb.en.inv.stock_info" %>
<asp:Content ID="Content" ContentPlaceHolderID="ContentPlaceHolder" runat="server">

	<header class="header">
		<script src="<%=GetRoot() %>/en/common/include/header.js" ></script> 	
		<h1 class="acc-hidden">Investors</h1>	
		<p class="location">
			<span>Investors</span><em>></em>
            <span>Shareholder Services</span><em>></em>
			<strong>Major Shareholders</strong>
		</p>
	</header>

    <!-- 오픈시 보일 메뉴 -->
	<nav class="gnb" >
		<script src="<%=GetRoot() %>/en/common/include/gnb.js" ></script> 	
	</nav>
	<!-- // 오픈시 보일 메뉴  -->

	<!--   width:100% -->
	<section class="container">
		<h1 class="acc-hidden">주식발행</h1>
		<ul class="tap_3depth mB10">
			<li> <a href="stock_info.aspx" class="onhover">Major Shareholders</a> </li>
			<li> <a href="stockholder.aspx">Number of Issued Shares</a></li>
			<li> <a href="treasury_stock.aspx">Treasury Shares</a></li>
		</ul>
		<!--   content -->
		<section class="content pB40 w600 overflow_x">
			<h1 class="acc-hidden">자기주식</h1>
			<table class="table_style_01 th36" width="700">
				<caption class="hidden">주식발행내역표</caption>
				<colgroup>
					<col >
					<col style="width:23%">
					<col style="width:23%">
					<col style="width:23%">
				</colgroup>
				<thead>
					<tr>
						<th scope="col" class="left_borNo">Class of Shares</th>
						<th scope="col" > Total Number of Issued Shares  </th>
						<th scope="col" > Nominal Value   </th>
						<th scope="col" > Remarks   </th>
					</tr>
				</thead>

				<tbody>
					<%
                        string css = "";
                
                        if (GetRowCount() > 0)
                        {
                            for (int i = 0; i < GetRowCount(); i++)
                            {
                                if (GetData(i, "STOK_TYPE_CD").Equals("Total"))
                                {
                                    css = " class=\"total\"";
                                }
                                else
                                {
                                    css = "";
                                }
                    %>
			        <tr<%=css %>>
				        <th scope="row"><%=GetData(i, "STOK_TYPE_CD")%></th>
				        <td><%=GetData(i, "PUB_STOK_TOTAL_CNT")%></td>
				        <td><%=GetData(i, "FACE_TOTAL_AMT")%></td>
				        <td><%=GetData(i, "REMARK")%></td>
			        </tr>
                    <%
                            }
                        }
                        else
                        {
                    %>
			        <!-- 내용이 없을 경우  -->
			        <tr >
				        <td colspan="6" class="no_data"> 
					        <p > 내용이 없습니다. </p> 
				        </td>
			        </tr>
                    <% 
                        }
                    %>
				</tbody>
			</table>
		</section> 
		<!--   // content -->
	</section>
	 <!-- //  width:100% -->
	 <script src="<%=GetRoot() %>/en/common/include/footer.js" ></script> 

</asp:Content>