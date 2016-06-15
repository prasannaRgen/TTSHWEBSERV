<%@ Page Title="" Language="C#" MasterPageFile="~/TTSHMasterPage/TTSH.Master" AutoEventWireup="true" CodeBehind="frmProject_Master.aspx.cs" Inherits="WebApplication1.UI.frmProject_Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<link href="../css/Grid.css" rel="stylesheet" />
	<style type="text/css">
		.red {
			color: red;
		}

		.TxtBox {
			border: 1px solid;
			border-color: #a8babd;
			padding: 2px;
			margin: 0px;
			font-family: Tahoma;
			font-size: 9pt;
			background: rgb(237,237,237); /* Old browsers */
			background: -moz-linear-gradient(top, rgba(237,237,237,1) 0%, rgba(246,246,246,1) 53%, rgba(255,255,255,1) 100%); /* FF3.6+ */
			background: -webkit-gradient(linear, left top, left bottom, color-stop(0%,rgba(237,237,237,1)), color-stop(53%,rgba(246,246,246,1)), color-stop(100%,rgba(255,255,255,1))); /* Chrome,Safari4+ */
			background: -webkit-linear-gradient(top, rgba(237,237,237,1) 0%,rgba(246,246,246,1) 53%,rgba(255,255,255,1) 100%); /* Chrome10+,Safari5.1+ */
			background: -o-linear-gradient(top, rgba(237,237,237,1) 0%,rgba(246,246,246,1) 53%,rgba(255,255,255,1) 100%); /* Opera 11.10+ */
			background: -ms-linear-gradient(top, rgba(237,237,237,1) 0%,rgba(246,246,246,1) 53%,rgba(255,255,255,1) 100%); /* IE10+ */
			background: linear-gradient(top, rgba(237,237,237,1) 0%,rgba(246,246,246,1) 53%,rgba(255,255,255,1) 100%); /* W3C */
			filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#ededed', endColorstr='#ffffff',GradientType=0 ); /* IE6-9 */
		}

			.TxtBox:focus {
				background: rgb(213,227,225); /* Old browsers */
				background: -moz-linear-gradient(top, rgba(213,227,225,1) 0%, rgba(244,250,250,1) 100%); /* FF3.6+ */
				background: -webkit-gradient(linear, left top, left bottom, color-stop(0%,rgba(213,227,225,1)), color-stop(100%,rgba(244,250,250,1))); /* Chrome,Safari4+ */
				background: -webkit-linear-gradient(top, rgba(213,227,225,1) 0%,rgba(244,250,250,1) 100%); /* Chrome10+,Safari5.1+ */
				background: -o-linear-gradient(top, rgba(213,227,225,1) 0%,rgba(244,250,250,1) 100%); /* Opera 11.10+ */
				background: -ms-linear-gradient(top, rgba(213,227,225,1) 0%,rgba(244,250,250,1) 100%); /* IE10+ */
				background: linear-gradient(top, rgba(213,227,225,1) 0%,rgba(244,250,250,1) 100%); /* W3C */
				filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#d5e3e1', endColorstr='#f4fafa',GradientType=0 ); /* IE6-9 */
			}

		.DdlList {
			border: 1px solid #a8babd;
			padding: 1px;
			margin: 0px;
			font-family: Tahoma;
			font-size: 9pt;
			background: rgb(237,237,237); /* Old browsers */
			background: -moz-linear-gradient(top, rgba(237,237,237,1) 0%, rgba(246,246,246,1) 53%, rgba(255,255,255,1) 100%); /* FF3.6+ */
			background: -webkit-gradient(linear, left top, left bottom, color-stop(0%,rgba(237,237,237,1)), color-stop(53%,rgba(246,246,246,1)), color-stop(100%,rgba(255,255,255,1))); /* Chrome,Safari4+ */
			background: -webkit-linear-gradient(top, rgba(237,237,237,1) 0%,rgba(246,246,246,1) 53%,rgba(255,255,255,1) 100%); /* Chrome10+,Safari5.1+ */
			background: -o-linear-gradient(top, rgba(237,237,237,1) 0%,rgba(246,246,246,1) 53%,rgba(255,255,255,1) 100%); /* Opera 11.10+ */
			background: -ms-linear-gradient(top, rgba(237,237,237,1) 0%,rgba(246,246,246,1) 53%,rgba(255,255,255,1) 100%); /* IE10+ */
			filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#ededed', endColorstr='#ffffff',GradientType=0 );
			width: 133px;
		}

			.DdlList:focus {
				background: rgb(213,227,225); /* Old browsers */
				background: -moz-linear-gradient(top, rgba(213,227,225,1) 0%, rgba(244,250,250,1) 100%); /* FF3.6+ */
				background: -webkit-gradient(linear, left top, left bottom, color-stop(0%,rgba(213,227,225,1)), color-stop(100%,rgba(244,250,250,1))); /* Chrome,Safari4+ */
				background: -webkit-linear-gradient(top, rgba(213,227,225,1) 0%,rgba(244,250,250,1) 100%); /* Chrome10+,Safari5.1+ */
				background: -o-linear-gradient(top, rgba(213,227,225,1) 0%,rgba(244,250,250,1) 100%); /* Opera 11.10+ */
				background: -ms-linear-gradient(top, rgba(213,227,225,1) 0%,rgba(244,250,250,1) 100%); /* IE10+ */
				background: linear-gradient(top, rgba(213,227,225,1) 0%,rgba(244,250,250,1) 100%); /* W3C */
				filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#d5e3e1', endColorstr='#f4fafa',GradientType=0 ); /* IE6-9 */
			}

		.Btn {
			border-radius: 2px;
			border: 1px solid;
			border-color: #2c485d;
			background: #2c485d;
			color: #ffffff;
			cursor: pointer;
			font-family: Tahoma;
			font-size: 10pt;
			padding: 1px 2px 2px 2px;
			margin: 2px;
			-moz-box-shadow: 0 0 10px 0 #c2c6c6;
			-webkit-box-shadow: 0 0 10px 0 #c2c6c6;
			box-shadow: 0 5px 5px 0 #c2c6c6;
		}

			.Btn:hover {
				color: #2c485d;
				border-radius: 2px;
				border: 1px solid;
				border-color: #7390a1;
				background: #7390a1;
			}

		table.hovertable {
			border-width: 1px;
			border-color: #EEE5DE;
			border-collapse: collapse;
		}

			table.hovertable th {
				background-color: transparent;
				border-width: 1px;
				padding: 2px;
				border-style: solid;
				border-color: #EEE5DE;
			}

			table.hovertable tr {
				background-color: transparent;
			}

			table.hovertable td {
				border-width: 1px;
				padding: 0;
				border-style: solid;
				border-color: #EEE5DE;
			}

			table.hovertable lable {
				font-weight: bold;
			}

		.legend {
			font-family: Calibri;
			font-size: medium;
		}
	</style>
	<link href="../css/ModelPopUp.css" rel="stylesheet" />
	<link href="../css/jquery-ui.css" rel="stylesheet" />
	<script src="../Scripts/jquery-1.7.1.min.js"></script>
	<script src="../Scripts/jquery-ui.js"></script>
	<script src="../Scripts/jquery.helper.js"></script>
	<script src="../Scripts/Common.js"></script>
	<script type="text/javascript">
		if (typeof window.event != 'undefined') {
			document.onkeydown = function () { return IE_keydown(); }
		}
		else {
			document.onkeypress = function (e)
			{
				return Other_keypress(e);
			}
		}
	</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
	<div style="text-align: center; width: 100%; margin: 0 auto 5px auto">
		<asp:Label ID="lblHeader" runat="server" Text="Project Master"></asp:Label>
	</div>
	<div runat="server" id="DivMain" style="width: 100%">
		<asp:GridView ID="GvMain" CssClass="GridView" runat="server"></asp:GridView>
		<asp:Button ID="btnNew" Text="New" runat="server" Width="60px" CssClass="Btn" OnClick="btnNew_Click" />
	</div>
	<div runat="server" id="DivDetail" style="width: 100%">
		<div style="float: right">
			<asp:ImageButton ID="Imgback" runat="server" ImageUrl="~/Images/MB__back.png" Width="20px" OnClick="Imgback_Click" />
		</div>
		<div style="width: 100%; margin-top: 10px">
			<fieldset style="text-align: left;">
				<legend><span class="legend"><b>Project Information</b></span></legend>
				<table class="tblResposive" style="width: 100%">
					<tr>
						<td style="text-align: left; vertical-align: middle; width: 10%">
							<span class="legend">Project Title</span><span class="red">*</span>

						</td>
						<td style="text-align: left; vertical-align: middle; width: 40%">
							<asp:TextBox ID="TxtprojTitle" CssClass="TxtBox" Width="200px" Height="25px" runat="server"></asp:TextBox>
						</td>

						<td style="text-align: left; vertical-align: middle; width: 12%">
							<span>Short Title</span>

						</td>
						<td style="text-align: left; vertical-align: middle; width: 40%">
							<asp:TextBox ID="TxtShortTitle" CssClass="TxtBox" Width="200px" Height="25px" runat="server"></asp:TextBox>
						</td>
					</tr>
					<tr>
						<td style="text-align: left; vertical-align: middle; width: 10%">
							<span class="legend">Project Title Alias1</span>

						</td>
						<td style="text-align: left; vertical-align: middle; width: 40%">
							<asp:TextBox ID="TxtProjTitleAlias1" CssClass="TxtBox" Width="200px" Height="25px" runat="server"></asp:TextBox>
						</td>

						<td style="text-align: left; vertical-align: middle; width: 12%">
							<span>Project Title Alias2</span>

						</td>
						<td style="text-align: left; vertical-align: middle; width: 40%">
							<asp:TextBox ID="TxtProjTitleAlias2" CssClass="TxtBox" Width="200px" Height="25px" runat="server"></asp:TextBox>
						</td>
					</tr>
					<tr>
						<td style="text-align: left; vertical-align: middle; width: 10%">
							<span class="legend">Project Description</span>

						</td>
						<td style="text-align: left; vertical-align: middle; width: 40%">
							<asp:TextBox ID="TxtProjDescription" CssClass="TxtBox" Width="200px" Height="25px" runat="server"></asp:TextBox>
						</td>

						<td style="text-align: left; vertical-align: middle; width: 10%">
							<span>DSRB/IRB No</span>

						</td>
						<td style="text-align: left; vertical-align: middle; width: 40%">
							<asp:TextBox ID="TxtIRBno" CssClass="TxtBox" Width="200px" Height="25px" runat="server"></asp:TextBox>
						</td>
					</tr>

				</table>
			</fieldset>
			<fieldset style="text-align: left; margin-top: 5px">
				<legend><span class="legend"><b>Project Category</b></span></legend>
				<table class="hovertable" style="width: 100%">
					<tr>
						<td style="text-align: left; vertical-align: middle; width: 10%">
							<span class="legend">Project Caregory</span><span class="red">*</span>

						</td>
						<td style="text-align: left; vertical-align: middle; width: 40%">
							<asp:DropDownList ID="ddlProjCategory" CssClass="DdlList" Width="205px" runat="server"></asp:DropDownList>
						</td>

						<td style="text-align: left; vertical-align: middle; width: 10%">
							<span>Project Type</span><span class="red">*</span>

						</td>
						<td style="text-align: left; vertical-align: middle; width: 40%">
							<asp:DropDownList ID="ddlProjType" CssClass="DdlList" Width="205px" runat="server"></asp:DropDownList>
						</td>
					</tr>
					<tr>
						<td style="text-align: left; vertical-align: middle; width: 10%">
							<span class="legend">Project Sub Type</span><span class="red">*</span>

						</td>
						<td style="text-align: left; vertical-align: middle; width: 40%">
							<asp:DropDownList ID="ddlProjSubType" CssClass="DdlList" Width="205px" runat="server"></asp:DropDownList>
						</td>

						<td style="text-align: left; vertical-align: middle; width: 12%">
							<span>Feasibility Check Status</span><span class="red">*</span>

						</td>
						<td style="text-align: left; vertical-align: middle; width: 40%">
							<asp:DropDownList ID="ddlFeasibilityStatus" CssClass="DdlList" Width="205px" runat="server"></asp:DropDownList>
						</td>
					</tr>
					<tr>
						<td style="text-align: left; vertical-align: middle; width: 10%">
							<span class="legend">Is Selected Project</span>

						</td>
						<td style="text-align: left; vertical-align: middle; width: 40%">
							<asp:DropDownList ID="ddlselectedproject" CssClass="DdlList" Width="205px" runat="server"></asp:DropDownList>
						</td>


					</tr>

				</table>
			</fieldset>
			<fieldset style="text-align: left; margin-top: 5px">
				<legend><span class="legend"><b>Project Key information</b></span></legend>
				<table class="hovertable" style="width: 100%">
					<tr>
						<td style="text-align: left; vertical-align: middle; width: 10%">
							<span class="legend">Collobration Involved</span><span class="red">*</span>

						</td>
						<td style="text-align: left; vertical-align: middle; width: 40%">
							<asp:DropDownList ID="ddlCollbrationInv" CssClass="DdlList" Width="205px" runat="server"></asp:DropDownList>
						</td>

						<td style="text-align: left; vertical-align: middle; width: 10%">
							<span>Start by TTSH</span><span class="red">*</span>

						</td>
						<td style="text-align: left; vertical-align: middle; width: 40%">
							<asp:DropDownList ID="ddlstartbyTTSH" CssClass="DdlList" Width="205px" runat="server"></asp:DropDownList>
						</td>
					</tr>
					<tr>
						<td style="text-align: left; vertical-align: middle; width: 10%">
							<span class="legend">Funding Required</span><span class="red">*</span>

						</td>
						<td style="text-align: left; vertical-align: middle; width: 40%">
							<asp:DropDownList ID="ddlfundingReq" CssClass="DdlList" Width="205px" runat="server"></asp:DropDownList>
						</td>

						<td style="text-align: left; vertical-align: middle; width: 12%">
							<span>Whether is Child/Parent</span><span class="red">*</span>

						</td>
						<td style="text-align: left; vertical-align: middle; width: 40%">
							<asp:DropDownList ID="ddlChildParent" CssClass="DdlList" Width="205px" runat="server"></asp:DropDownList>
						</td>
					</tr>
					<tr>
						<td style="text-align: left; vertical-align: middle; width: 10%">
							<span class="legend">Parent Project Id</span>

						</td>
						<td style="text-align: left; vertical-align: middle; width: 40%">
							<asp:TextBox ID="txtParentProjId" CssClass="TxtBox" Width="200px" Height="25px" runat="server"></asp:TextBox>
						</td>


					</tr>

				</table>
			</fieldset>
			<fieldset style="text-align: left; margin-top: 5px">
				<legend><span class="legend"><b>Principal Investigator(PI) Details</b></span></legend>
				<table class="hovertable" style="width: 100%">
					<tr>
						<td style="text-align: left; vertical-align: middle; width: 10%">
							<span class="legend">Department</span><span class="red">*</span>

						</td>
						<td style="text-align: left; vertical-align: middle; width: 40%">
							<asp:DropDownList ID="ddlDepartment" CssClass="DdlList" Width="205px" runat="server"></asp:DropDownList>
						</td>

						<td style="text-align: left; vertical-align: middle; width: 12%">
							<span>PI Name</span><span class="red">*</span>

						</td>
						<td style="text-align: left; vertical-align: middle; width: 40%">
							<asp:DropDownList ID="ddlPIName" CssClass="DdlList" Width="205px" runat="server"></asp:DropDownList>
						</td>
					</tr>
					<tr>
						<td style="text-align: left; vertical-align: middle; width: 10%">
							<span class="legend">PI Email Addess</span><span class="red">*</span>

						</td>
						<td style="text-align: left; vertical-align: middle; width: 40%">
							<asp:TextBox ID="txtPIEmail" CssClass="TxtBox" Width="200px" Height="25px" runat="server"></asp:TextBox>
						</td>

						<td colspan="2" style="text-align: left; vertical-align: middle; width: 12%">
							<asp:Button ID="btnAddnewPi" runat="server" Text="Add More PI" OnClientClick="return  ShowModalPopup('DivPIOtherSection');"  CssClass="Btn" Width="100px" />

						</td>

					</tr>
					<tr>
						<td style="text-align: left; vertical-align: middle; width: 10%">
							<span class="legend">PI Phone No</span>

						</td>
						<td style="text-align: left; vertical-align: middle; width: 40%">
							<asp:TextBox ID="txtPiPhoneNo" CssClass="TxtBox" Width="200px" Height="25px" runat="server"></asp:TextBox>
						</td>
						<td style="text-align: left; vertical-align: middle; width: 10%">
							<span class="legend">PI MCR No</span>

						</td>
						<td style="text-align: left; vertical-align: middle; width: 40%">
							<asp:TextBox ID="txtPiMCRNo" CssClass="TxtBox" Width="200px" Height="25px" runat="server"></asp:TextBox>
						</td>

					</tr>

				</table>
			</fieldset>
			<fieldset style="text-align: left; margin-top: 5px">
				<legend><span class="legend"><b>Other Details</b></span></legend>
				<table class="hovertable" style="width: 100%">
					<tr>
						<td style="text-align: left; vertical-align: middle; width: 10%">
							<span class="legend">Research(IO) Internal Order</span><span class="red">*</span>

						</td>
						<td style="text-align: left; vertical-align: middle; width: 40%">
							<asp:TextBox ID="txtResearchOrder" CssClass="TxtBox" Width="200px" Height="25px" runat="server"></asp:TextBox>
						</td>

						<td style="text-align: left; vertical-align: middle; width: 12%">
							<span>Research(IP) Insurance Provider</span><span class="red">*</span>

						</td>
						<td style="text-align: left; vertical-align: middle; width: 40%">
							<asp:TextBox ID="txtReserchInsurance" CssClass="TxtBox" Width="200px" Height="25px" runat="server"></asp:TextBox>
						</td>
					</tr>
					<tr>
						<td style="text-align: left; vertical-align: middle; width: 10%">
							<span class="legend">Co-Ordinators</span><span class="red">*</span>

						</td>
						<td style="text-align: left; vertical-align: middle; width: 40%">
							<asp:DropDownList ID="ddlcoOrdinator" CssClass="DdlList" Width="200px" runat="server"></asp:DropDownList>
						</td>

					</tr>
				</table>
			</fieldset>
			<fieldset style="text-align: left; margin-top: 5px">
				<div style="float: left">
					<asp:Button runat="server" ID="btnSave" Text="Save" Width="60px" CssClass="Btn" />
				</div>
			</fieldset>
		</div>
		<div id="DivPIOtherSection" class="ModelPopup" runat="server" style="display: none; width: 450px">
			<div class="ModelContainer">
				<div class="ModelHeader">
					<span id="Span5" class="ModelMsg">Select Column</span> <a id="A5" class="ModelClose"
						onclick="return HideModalPopup('DivPIOtherSection');"></a>
				</div>
				<div class="ModelBody">
					<div style="min-height: 250px; max-height: 300px; overflow: auto">
						<fieldset style="text-align: left;">
							<legend><span class="legend"><b>Principal Investigator(PI) Detail Section</b></span></legend>
							<table class="hovertable" style="width: 100%">
								<tr>
									<td style="text-align: left; vertical-align: middle; width: 10%">
										<span class="legend">Department</span><span class="red">*</span>

									</td>
									<td style="text-align: left; vertical-align: middle; width: 40%">
										<asp:DropDownList ID="ddlPIdepartment" CssClass="DdlList" Width="200px" runat="server"></asp:DropDownList>
									</td>

									<td style="text-align: left; vertical-align: middle; width: 12%">
										<span>First Name</span>

									</td>
									<td style="text-align: left; vertical-align: middle; width: 40%">
										<asp:TextBox ID="txtPiFirstName" CssClass="TxtBox" Width="200px" Height="25px" runat="server"></asp:TextBox>
									</td>
								</tr>
								<tr>
									<td style="text-align: left; vertical-align: middle; width: 10%">
										<span class="legend">PI Email Addess</span><span class="red">*</span>

									</td>
									<td style="text-align: left; vertical-align: middle; width: 40%">
										<asp:TextBox ID="txtPIEmailAddress" CssClass="TxtBox" Width="200px" Height="25px" runat="server"></asp:TextBox>
									</td>

									<td style="text-align: left; vertical-align: middle; width: 12%">
										<span>PI Last Name</span><span class="red">*</span>

									</td>
									<td style="text-align: left; vertical-align: middle; width: 40%">
										<asp:TextBox ID="txtPiLastName" CssClass="TxtBox" Width="200px" Height="25px" runat="server"></asp:TextBox>
									</td>
								</tr>
								<tr>
									<td style="text-align: left; vertical-align: middle; width: 10%">
										<span class="legend">Phone Number</span>

									</td>
									<td style="text-align: left; vertical-align: middle; width: 40%">
										<asp:TextBox ID="txtPiPhNo" CssClass="TxtBox" Width="200px" Height="25px" runat="server"></asp:TextBox>
									</td>

									<td style="text-align: left; vertical-align: middle; width: 10%">
										<span>PI MCR No</span>

									</td>
									<td style="text-align: left; vertical-align: middle; width: 40%">
										<asp:TextBox ID="txtPIMCR_NO" CssClass="TxtBox" Width="200px" Height="25px" runat="server"></asp:TextBox>
									</td>
								</tr>

							</table>
						</fieldset>
					</div>
				</div>
				<div class="ModelFooter">
					<table style="width: 100%" cellpadding="0" cellspacing="1" class="hovertable">
						<tr>
							<td align="left">
								<asp:Button ID="btnModalSave" runat="server" CssClass="Btn"
									Text="Save" Width="60px" />
							</td>
							<td align="right">
								<asp:Button ID="btnModalCancel" OnClientClick="return HideModalPopup('DivPIOtherSection');" runat="server" CssClass="Btn"
									Text="Save" Width="60px" />
							</td>
						</tr>
					</table>
				</div>
			</div>
		</div>
	</div>
</asp:Content>
