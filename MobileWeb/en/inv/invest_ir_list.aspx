﻿<%@ Page Language="C#" MasterPageFile="/en/EnSiteSub.Master" AutoEventWireup="true" CodeBehind="invest_ir_list.aspx.cs" Inherits="MobileWeb.en.inv.invest_ir_list" %>

<asp:Content ID="Content" ContentPlaceHolderID="ContentPlaceHolder" runat="server">

    <header class="header">
		<script src="<%=GetRoot() %>/en/common/include/header.js" ></script> 	
		<h1 class="acc-hidden">Investors</h1>	
		<p class="location">
			<span>Investors</span><em>></em>
            <span>Prospective Investors</span><em>></em>
			<strong>IR Report</strong>
		</p>
	</header>

    <!-- 오픈시 보일 메뉴 -->
	<nav class="gnb" >
		<script src="<%=GetRoot() %>/en/common/include/gnb.js" ></script> 	
	</nav>
	<!-- // 오픈시 보일 메뉴  -->

	<!--   width:100% -->
	<section class="container">
		<h1 class="acc-hidden">IR자료</h1>
		<fieldset class="search_products w600">
			<legend class="acc-hidden">제품검색 폼</legend>
			<label for="value_01" class="acc-hidden">제품검색</label>
			<span class="input_bg">
                <input type="text" id="title" runat="server" />
            </span>
			<asp:LinkButton ID="btn_new_Search" runat="server" onClick="btnSearch_Click">
				<span class="button green" style="text-align:center">Search</span>
            </asp:LinkButton>
		</fieldset>	
		<!--   content -->
		<section class="content pB40">
			<h1 class="acc-hidden">경영정보 리스트</h1>
			<div class="list_box">
				<ul  class="list_text_arrowR" id="list_box"></ul>	
			</div>
            <div id="spinner" style="display: none; width:0px; margin:0px auto 17px;"></div>
		</section> 
		<!--   // content -->
	</section>
	 <!-- //  width:100% -->
	<script src="<%=GetRoot() %>/en/common/include/footer.js" ></script>
    <script src="<%=GetRoot() %>/en/common/js/spin.min.js" ></script>
    <script language="javascript">
        $(document).ready(function () {
            more_list();

            var opts = {
                lines: 9, // The number of lines to draw
                length: 5, // The length of each line
                width: 4, // The line thickness
                radius: 8, // The radius of the inner circle
                corners: 1, // Corner roundness (0..1)
                rotate: 0, // The rotation offset
                direction: 1, // 1: clockwise, -1: counterclockwise
                color: '#000', // #rgb or #rrggbb or array of colors
                speed: 2.2, // Rounds per second
                trail: 60, // Afterglow percentage
                shadow: false, // Whether to render a shadow
                hwaccel: false, // Whether to use hardware acceleration
                className: 'spinner', // The CSS class to assign to the spinner
                zIndex: 2e9, // The z-index (defaults to 2000000000)
                top: 'auto', // Top position relative to parent in px
                left: 'auto' // Left position relative to parent in px
            };

            var target = document.getElementById('spinner');
            var spinner = new Spinner(opts).spin(target);

        });


        $(window).scroll(function () {
            if ($(window).scrollTop() == $(document).height() - $(window).height()) {

                $("#spinner").show();
                var showTim = function () {
                    more_list();
                    $("#spinner").hide();
                }
                setTimeout(showTim, 300);

            }
        });

        var now_page = 0;

        function more_list() {

            now_page++;

            $.ajax({
                type: "POST"
                , cache: false
                , url: "<%=GetRoot() %>/ws/investment.asmx/GetIrList"
                , data: {
                    "now_page": now_page
                    , "title": $('#<%= title.ClientID %>').val()
                    , "lang_cd": "ENG"
                }
                , async: false
                , dataType: "xml" // Debugging을 위해 일단 TEXT로 받는다.
                , success: function (xml, status) {
                    html = '';

                    $(xml).find("Investment").each(function () {
                        var SEQ_NO = $(this).children("SEQ_NO").text();
                        var TTL = $(this).children("TTL").text();

                        html += '<li>';
                        html += '	<a href="invest_ir_view.aspx?seq_no=' + SEQ_NO + '">' + TTL + '</a>';
                        html += '</li>';
                    });

                    if (html != '') {

                        $('#list_box').append(html);
                    }

                }
	            , error: function (xhr, textStatus) {
	                alert("네트워크 오류 또는 요청을 처리할 수 없습니다.");
	            }
	            , complete: function (xhr, textStatus) {
	            }
            });
        }
    </script>
</asp:Content>