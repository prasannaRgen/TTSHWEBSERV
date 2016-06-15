<%@ Page Title="" Language="C#" MasterPageFile="~/TTSHMasterPage/TTSH.Master" AutoEventWireup="true" CodeBehind="MenuMasterMapping.aspx.cs" Inherits="WebApplication2.MenuMasterMapping" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="MainContent" runat="server">
    	<script src="Scripts/jquery.min.js"></script>
    <asp:TextBox ID="txtCountry" runat="server" onpaste="return false;" placeholder="Type Keyword to search Country" CssClass="ctlinput" />
    <asp:HiddenField ID="HdnCountryId" runat="server" />
    <asp:ScriptManager ID="uxs" runat="server"></asp:ScriptManager>
    <div class="roleManager container" runat="server" id="roleManager">
        <div class="row">
            <div class="col-md-6 col-sm-6 paging">
                <h1>Create Roles<span>Search, Filter and View Roles</span></h1>
            </div>
            <div class="col-md-6 col-sm-6 paging">
                <div class="grid-search">
                    <%--         <uc1:SearchBox runat="server" ID="SearchBox" />--%>
                </div>
            </div>
        </div>
    </div>


    


    <div class="container rolesContainer" id="rolesContainer" runat="server">
      
        <asp:UpdatePanel runat="server" ID="UpPi">

            <ContentTemplate>
                <div class="frm frmDetails" style="display: block;">
                    <div class="row">
                        <div class="col-md-6 col-sm-6">

                            <p>
                                <label>Group Name<b>*</b></label>

                                <asp:DropDownList ID="ddlGroupName" TabIndex="1" runat="server" CssClass="ctlselect" AutoPostBack="true" OnSelectedIndexChanged="ddlGroupName_SelectedIndexChanged"></asp:DropDownList>
                            </p>
                        </div>
                    </div>
                </div>



                <div class="frm frmDetails" style="display: block;min-height:200px;">
                    <div class="row">
                        <div class="col-md-6 col-sm-6">

                            <p>
                                <label>Access Rights<b>*</b></label>
                             <%--   <asp:CheckBox ID="chkAll" runat="server" Text="Check All" AutoPostBack="false" />--%>
                                <asp:TreeView ID="tvAccess" runat="server" ShowCheckBoxes="All" CssClass="tvAccess">
                                </asp:TreeView>
                            </p>
                        </div>
                    </div>
                      <div class="row margin-top frmAction">
            <div class="col-md-12">
                <p style="text-align: right">


                    <asp:Button CssClass="action" ID="btnSave" runat="server" Text="Save Details" OnClick="btnSave_Click" OnClientClick="return FinalValidation();"  />
                    <asp:Button CssClass="action" ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click"  />

                </p>
            </div>
        </div>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="ddlGroupName" EventName="SelectedIndexChanged" />
                <asp:AsyncPostBackTrigger ControlID="btnSave" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btnCancel" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
        <script type="text/javascript">
            function OnCheckBoxCheckChanged(evt) {
                var src = window.event != window.undefined ? window.event.srcElement : evt.target;
                var isChkBoxClick = (src.tagName.toLowerCase() == "input" && src.type == "checkbox");
                    
                if ( $('input:checkbox')[0].checked && (src.id == "MainContent_tvAccesst0" || src.id == "MainContent_tvAccessn0CheckBox"))
                    $('input:checkbox').prop('checked', true);
               //else
               //     $('input:checkbox')[0].prop('checked', false);
                 
               
                if (isChkBoxClick) {
                    var parentTable = GetParentByTagName("table", src);
                    var nxtSibling = parentTable.nextSibling;
                    if (src.checked == false)
                        $('input:checkbox')[0].checked = $('input:checkbox:checked').length != ($('input:checkbox').length - 1);
                    if (src.title.toLowerCase() == "main" && (!nxtSibling || nxtSibling.tagName.toLowerCase() != "div")) 
                    {
                        //DisplayMessage('This menu item does not have sub menus.');
                       // src.checked = false;
                        return false;
                    }
                    if (nxtSibling && nxtSibling.nodeType == 1) //check if nxt sibling is not null & is an element node
                    {
                        if (nxtSibling.tagName.toLowerCase() == "div") //if node has children
                        {
                            //check or uncheck children at all levels
                            CheckUncheckChildren(parentTable.nextSibling, src.checked);
                        }           

                    }
                    //check or uncheck parents at all levels
                    CheckUncheckParents(src, src.checked);
                    if (src.checked )
                        $('input:checkbox')[0].checked = $('input:checkbox:checked').length === ($('input:checkbox').length - 1);
            
                }
               
            }

            function resetfields() {

                document.getElementById('ContentPlaceHolder1_ddlRoles').selectedIndex = 0;
                document.getElementById('ContentPlaceHolder1_ddlGroup').selectedIndex = 0;
                var treeView = document.getElementById("ContentPlaceHolder1_tvAccess");
                var checkBoxes = treeView.getElementsByTagName("input");

                for (var i = 0; i < checkBoxes.length; i++) {
                    if (checkBoxes[i].checked) {
                        checkBoxes[i].checked = false;
                    }
                }


            }

            function CheckUncheckChildren(childContainer, check) {
                var childChkBoxes = childContainer.getElementsByTagName("input");
                var childChkBoxCount = childChkBoxes.length;

                for (var i = 0; i < childChkBoxCount; i++) {
                    childChkBoxes[i].checked = check;
                }
            }

            function CheckUncheckParents(srcChild, check) {
                var parentDiv = GetParentByTagName("div", srcChild);
                var parentNodeTable = parentDiv.previousSibling;

                if (parentNodeTable) {
                    var checkUncheckSwitch;

                    if (check) //checkbox checked
                    {
                        var isAllSiblingsChecked = AreAllSiblingsChecked(srcChild);
                        if (isAllSiblingsChecked)
                            checkUncheckSwitch = true;
                        else
                            return; //do not need to check parent if any(one or more) child not checked
                    }
                    else //checkbox unchecked
                    {
                        //checkUncheckSwitch = false;
                        var isAllSiblingsChecked = AreAllSiblingsChecked(srcChild);
                        if (isAllSiblingsChecked)
                            checkUncheckSwitch = true;
                        else
                            checkUncheckSwitch = false;
                    }

                    var inpElemsInParentTable = parentNodeTable.getElementsByTagName("input");
                    if (inpElemsInParentTable.length > 0) {
                        var parentNodeChkBox = inpElemsInParentTable[0];
                       // if(parentNodeChkBox.id !="MainContent_chkAll")
                            parentNodeChkBox.checked = checkUncheckSwitch;
                        //do the same recursively
                        CheckUncheckParents(parentNodeChkBox, checkUncheckSwitch);
                    }
                }
            }

            function AreAllSiblingsChecked(chkBox) {
                var parentDiv = GetParentByTagName("div", chkBox);
                var childCount = parentDiv.childNodes.length;
                var flag = false;
                for (var i = 0; i < childCount; i++) {
                    if (parentDiv.childNodes[i].nodeType == 1) //check if the child node is an element node
                    {
                        if (parentDiv.childNodes[i].tagName.toLowerCase() == "table") {
                            var prevChkBox = parentDiv.childNodes[i].getElementsByTagName("input")[0];
                            //if any of sibling nodes are not checked, return false
                            if (prevChkBox.checked) {
                                flag = true;
                            }
                        }
                    }
                }
                return flag;
            }

            //utility function to get the container of an element by tagname
            function GetParentByTagName(parentTagName, childElementObj) {
                var parent = childElementObj.parentNode;
                while (parent.tagName.toLowerCase() != parentTagName.toLowerCase()) {
                    parent = parent.parentNode;
                }
                return parent;
            }

            function ValidateAccessrights() {
                var treeView = document.getElementById("<%=tvAccess.ClientID%>");
                var checkBoxes = treeView.getElementsByTagName("input");
                var checkedCount = 0;
                for (var i = 0; i < checkBoxes.length; i++) {
                    if (checkBoxes[i].checked) {
                        checkedCount++;
                    }
                }

                if (checkedCount > 0) {
                    return true;
                }
                else {
                    alert('Select Atleast One Access Right.');
                    return false;
                }
            }

            function FinalValidation() {
                if (!(dropdownvalidation('<%=ddlGroupName.ClientID%>'))) {
                    return false;
                }
                
                if (ValidateAccessrights() == false) {
                    return false;
                }
                return true;
            }
            function dropdownvalidation(x) {
                if ($('#' + x + ' option:selected').val() > 0)
                    return true;
                else {
                    alert('Select Role.');
                    $('#' + x + ' option:selected').focus();
                    return false;
                }
            }
            
               
               function CheckAll () {
                    if (this.checked)
                        $('input[type="checkbox"]').prop('checked', true);
            }
        </script>
    </div>

</asp:Content>
