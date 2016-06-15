<%@ Page Title="" Language="C#" MasterPageFile="~/TTSHMasterPage/TTSH.Master" AutoEventWireup="true" CodeBehind="EthicDetails.aspx.cs" Inherits="WebApplication2.EthicDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<script src="Scripts/jquery.min.js"></script>
	<script type="text/javascript">
		$(function ()
		{
			fetchRecord()
		});
		function fetchRecord()
		{
			debugger
			$.ajax({
				cache: false,
				async: true,
				type: "POST",
				dataType: "json",
				url: "http://localhost:27923/TTSHWCFService.svc/GetContract_Collobrator_MasterByID",
				data: '{ "ID": "' + $("#ddlCollaborator").val() + '" }',
				contentType: "application/json;charset=utf-8;",
				success: function (r)
				{
					alert("Successfully Registered!!!");
				},
				error: function (e) { alert(e.statusText); }
			});
		}



	</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
