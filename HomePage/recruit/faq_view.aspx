﻿<%@ Page Language="C#" MasterPageFile="~/SiteSub.Master" AutoEventWireup="true" CodeBehind="faq_view.aspx.cs" Inherits="HomePage.recruit.faq_view" %>

<asp:Content ID="Content" ContentPlaceHolderID="ContentPlaceSubLayer" runat="server">

<section id="content" class="sub_content" >
			<header>
				<h1 class="pageTitle">FAQ</h1>
				<p class="location">
					<a href="/index.aspx"><span><img src="/common/images/common/i_home.png" alt="home" /></span></a>
                    <a href="/recruit/new_person.aspx"><span>채용</span></a><em> > </em>
			        <a href="/recruit/faq_list.aspx"><span>FAQ</span></a><em> > </em>
			        <a href="/recruit/faq_list.aspx"><strong>FAQ</strong></a>
				</p>
			</header>
			<!--  내용  ***************** -->
			<table class="table_view" border="1">
				<caption class="hidden">공고사항 상세보기</caption>
				<colgroup>
					<col style="width:12%" />
					<col style="width:13%" />
					<col style="width:12%" />
					<col style="width:13%" />
					<col style="width:12%" />
					<col style="width:15%" />
					<col style="width:12%" />
					<col>
				</colgroup>
				<thead>
					<tr>
				        <th scope="row" colspan="1"><span>제목</span></th>
				        <td colspan="7"><%=GetData(0, 0, "TTL", 86)%></td>
			        </tr>
			        <tr>
				        <th scope="col"> <span> 번호  </span></th>
				        <td><%=DpSeqNo %></td>
				        <th scope="col"> <span> 작성자  </span>  </th>
				        <td><%=GetData(0, 0, "WRITER_NM")%></td>
				        <th scope="col">  <span> 날짜   </span> </th>
				        <td><%=GetData(0, 0, "REG_DT")%></td>
				        <th scope="col">  <span> 조회수    </span> </th>
				        <td><%=GetData(0, 0, "HIT_CNT")%></td>
			        </tr>
                    <tr>
				        <th colspan="1" scope="row"> <span> 첨부파일  </span> </th>
				        <td colspan="7"> 
					        <% if ("".Equals(GetData(0, 0, "IMG1")) == false) {%><span class="i_file"><a href="<%=GetData(0, 0, "IMG1") %>" title="<%=GetFileName(GetData(0, 0, "IMG1"))%>"><%=GetFileName(GetData(0, 0, "IMG1"), 80)%></a></span> <%} %>
					<% if ("".Equals(GetData(0, 0, "IMG2")) == false) {%><br /><span class="i_file"><a href="<%=GetData(0, 0, "IMG2") %>" title="<%=GetFileName(GetData(0, 0, "IMG2"))%>"><%=GetFileName(GetData(0, 0, "IMG2"), 80)%></a></span> <%} %>
                    <% if ("".Equals(GetData(0, 0, "IMG3")) == false) {%><br /><span class="i_file"><a href="<%=GetData(0, 0, "IMG3") %>" title="<%=GetFileName(GetData(0, 0, "IMG3"))%>"><%=GetFileName(GetData(0, 0, "IMG3"), 80)%></a></span> <%} %>
                    <% if ("".Equals(GetData(0, 0, "IMG4")) == false) {%><br /><span class="i_file"><a href="<%=GetData(0, 0, "IMG4") %>" title="<%=GetFileName(GetData(0, 0, "IMG4"))%>"><%=GetFileName(GetData(0, 0, "IMG4"), 80)%></a></span> <%} %>
                    <% if ("".Equals(GetData(0, 0, "IMG5")) == false) {%><br /><span class="i_file"><a href="<%=GetData(0, 0, "IMG5") %>" title="<%=GetFileName(GetData(0, 0, "IMG5"))%>"><%=GetFileName(GetData(0, 0, "IMG5"), 80)%></a></span> <%} %>
				        </td>
			        </tr>
				</thead>
				<tbody>
					<tr>
						<td colspan="8">
							<div class="view_adit">
								<p><%=GetData(0, 0, "CONT")%></p>
							</div>	 
						</td>
					</tr>
				</tbody>
			</table>
			<p class="listview_btns">
				<%
                    if (GetData(1, 0, "PREV_SEQ_NO").Equals("0") == false)
                    {
                %>
		        <button type="button" class="btn_view_prev" onclick="location.href='faq_view.aspx?seq_no=<%=GetData(1, 0, "PREV_SEQ_NO")%>'">이전글</button>
                <% 
                    }
                %>
                <%
                    if (GetData(2, 0, "NEXT_SEQ_NO").Equals("0") == false)
                    {
                %>
		        <button type="button" class="btn_view_next" onclick="location.href='faq_view.aspx?seq_no=<%=GetData(2, 0, "NEXT_SEQ_NO")%>'">다음글</button>
                <% 
                    }
                %>
				<button type="button" onclick="javascript:location.href='faq_list.aspx';" class="btn_view_list">목록보기</button>
			</p>
			<!-- // 내용 ***************** -->     
		</section>  <!--// sub_content -->

</asp:Content>