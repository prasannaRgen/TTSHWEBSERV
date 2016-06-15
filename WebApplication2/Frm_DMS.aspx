<%@ Page Title="" Language="C#" MasterPageFile="~/TTSHMasterPage/TTSH.Master" AutoEventWireup="true" CodeBehind="Frm_DMS.aspx.cs" Inherits="WebApplication2.Frm_DMS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <script src="Scripts/jquery.min.js"></script>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
      <div class="roleManager container" runat="server" id="roleManager">
        <div class="row">
            <div class="col-md-6 col-sm-6 paging">
                <h1>
                    Document Management System<span>Search By Document Title,Document Description</span>
                    <%--<span>Search, Filter and View Roles</span>--%></h1>
            </div>
             <%--  <div class="col-md-6 col-sm-6 paging">
                <div class="grid-search">
                          <uc1:SearchBox runat="server" ID="SearchBox" />
                      <asp:TextBox ID="txtDoucumentSearch" runat="server" CssClass="ctltext"  />
                </div>
            </div>--%>
            </div>
            <div class="row">
                        <div class="col-md-12">

                            <p>
                               
                                  <asp:TextBox ID="txtDoucumentSearch" runat="server" Width="100%" placeHolder="Search By Document Title,Document Description" />
                                 <asp:HiddenField ID="HdnNeProjectId" runat="server" /> <asp:HiddenField ID="Hidden" runat="server" />
                            </p>
                        </div>
                    </div>

        </div>
    </div>
      <div class="container DMSContainer" id="dmscontainer" runat="server">
              <%--<div class="frm frmDetails" style="display: block;">
                    <div class="row">
                        <div class="col-md-6 col-sm-6">

                            <p>
                                <label>Project Name<b>*</b></label>
                                <asp:TextBox ID="txtProjectName" runat="server" CssClass="TxtBox" />
                                 <asp:HiddenField ID="HdnNeProjectId" runat="server" />
                            </p>
                        </div>
                    </div>
                </div>--%>

           <div class="row">
            <div class="col-md-12">
                <div class="tblResposiveWrapper">
                    <table id="tblResposive">
                        <thead>
                            <tr>
                               
                                <th width="300">Project Title</th>
                                 <th width="100">Document ID</th>
                                <th width="150">Document Description</th>
                                <th width="150">Document Cateogry</th>
                                
                                <th width="95">Action</th>
                            </tr>
                        </thead>

                        <tbody>

                            <asp:Repeater ID="rptrProjectDetail" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <p><%#Eval("s_Display_Project_ID") %></p>
                                        </td>
                                        <td>
                                            <p><%#Eval("s_Project_Title") %></p>
                                        </td>
                                        <td>
                                            <p><%#Eval("Project_Category_Name") %></p>
                                        </td>
                                        <td>
                                            <p style="text-wrap: normal"><%#Eval("Project_Type") %></p>
                                        </td>
                                        
                                        <td>
                                            <p class="grid-action">
                                                <asp:LinkButton ID="ImgEdit" runat="server" CommandArgument='<%# DataBinder.Eval(Container, "DataItem.i_ID")%>' CommandName="cmdEdit">
													<img title="Edit" alt="" src="Images/downArrow.png"></asp:LinkButton>
                                                <asp:LinkButton ID="ImgDelete" CommandArgument='<%# DataBinder.Eval(Container, "DataItem.i_ID")%>'
                                                    OnClientClick='<%# String.Format("return ConfirmDelete(\"{0}\");",  Eval("i_ID")) %>'
                                                     CommandName="cmdDelete" runat="server">
                                                        <img title="Delete" alt="" src="../images/icon-delete.png">
                                                </asp:LinkButton>
                                                
                                            </p>
                                        </td>
                                    </tr>
                                </ItemTemplate>

                            </asp:Repeater>

                        </tbody>
                    </table>

                    <!-- Grid View -->



                    <!-- Grid View -->
                </div>
            </div>
        </div>

           <div class="row" id="Paging">
            <div class="col-md-6 paging">
                <div class="page-info">
                    <%--<h3>Results Found : 18  </h3>--%>
                    <p>Showing Page 2 of Total 4 Pages | <a href="#">First Page</a> | <a href="#">Last Page</a></p>
                </div>
            </div>
                    <div class="col-md-6 paging">
                <div class="pages">
                    <%--	<a class="current-page" href="#">1</a> <a href="#">2</a> <a href="#">3</a> <a href="#">4</a>--%>
                </div>
            </div>
                

          </div>
          </div>
      <div class="container DMSContainer" id="Div2" runat="server">
    <div class="container UploadContainer" id="Div1" runat="server">
        <div class="row">
            <div class="col-md-12 col-sm-12" >
              
                    <a class="otherDocs link" data-frm="OtherDocs" onclick="ShowUploadSection();" ><span>+</span>  Upload Other Document</a>
                

                 <a class="ProjectDocs link" data-frm="ProjectDocs"  onclick="ShowUploadSection();"style="float:right"> <span>+</span>Upload Project related Document</a>
                

           
                
                           </div>
        </div>
        
        
 <%--  For Project Related Doc--%>
     <div class="frmProjectDocs col-md-6 col-sm-6 paging" style="display:none;">
 
            
            <div class="col-md-6 col-sm-6">
                <div class="row">
               <p runat="server" id="P1">
                    Search Project
                    <asp:TextBox ID="txtProjectSearch" runat="server" Width="100%"   />
               </p>
            </div>
                
               
  
         
                <div class="row">
                    <div class="col-md-6 col-sm-6">
                        <p>
                            <label>Project Title <b>*</b></label>
                            <asp:TextBox ID="TxtProjectTitle" CssClass="ctlinput" onpaste="return false;" Enabled="false"
                                runat="server"></asp:TextBox>
                        </p>
                        <p>
                            <label>Project ID <b>*</b></label>
                            <asp:TextBox ID="TxtProjectId"  CssClass="ctlinput"  runat="server"  Enabled="false"></asp:TextBox>
                        </p>

                        <p>
                            <label>DSRB/IRB 1</label>
                            <asp:TextBox ID="TxtDSRVIRB" CssClass="ctlinput"  runat="server"  Enabled="false"></asp:TextBox>
                        </p>
                      


                    </div>
                    <div class="col-md-6 col-sm-6">
                        <p>
                            <label>Short Title <b>*</b></label>


                            <asp:TextBox ID="TxtShortTitle" CssClass="ctlinput"  runat="server"  Enabled="false" TabIndex="1"></asp:TextBox>
                        </p>
                        <p>
                              <label>Alias 1</label>
                            <asp:TextBox ID="TxtAlias1" CssClass="ctlinput" runat="server"  Enabled="false" ></asp:TextBox>
                        </p>
                          <p>  <label>Alias 2</label>
                            <asp:TextBox ID="TxtAlias2" CssClass="ctlinput" runat="server"  Enabled="false" ></asp:TextBox>
                        </p>
                    </div>
                     <div class="col-md-12 col-sm-12">
                    <div class="tblResposiveWrapper">
                        <table id="tblProjectDocDetail" class="tblResposive">
                            <thead>
                                <tr>

                                    <th style="width: 450px; text-align: left">Doc Title</th>
                                    <th style="text-align: left">Doc Desc</th>
                                    <th style="text-align: left">Doc Category</th>
                                    <th style="text-align: left">Browse File</th>
                                    <th style="width: 45px; text-align: right">Action</th>
                                </tr>
                            </thead>

                            <tbody>
                               <%--  <asp:Repeater ID="rptrProjectDocDetails" runat="server">
                                    <ItemTemplate>
                                        <tr piid="<%# Eval("Doc Title)%>">
                                            <td data-th="DocTitle">
                                                <p><%# Eval("Doc Title") %></p>
                                            </td>
                                            <td data-th="DocDesc">
                                                <p><%# Eval("Doc Desc") %></p>
                                            </td>
                                            <td data-th="Doc Category">
                                                <p><%# Eval("Doc Category") %></p>
                                            </td>
                                            <td data-th="Browse File">
                                                <p><%# Eval("Browse File") %></p>
                                            </td>
                                            
                                            <td data-th="Action" style="text-align: right">
                                                <p class="grid-action">
                                                   
											<asp:LinkButton ID="ImgDownLoad" runat="server" CommandArgument='<%# DataBinder.Eval(Container, "DataItem.Doc Title")%>' CommandName="cmdEdit">
													<img title="Details" alt="" src="../images/icon-edit.png"></asp:LinkButton>-
													
                                                 	  <asp:LinkButton ID="ImgDelete" CommandArgument='<%# DataBinder.Eval(Container, "DataItem.i_ID")%>' OnClientClick="return delPiRows(this);" CommandName="cmdDelete" runat="server">
                                                        <img title="Delete" alt="" src="../images/icon-delete.png">
                                                    </asp:LinkButton>
                                                  
                                                </p>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>--%>




                            </tbody>
                        </table>
                    </div>
                    <p runat="server" id="Pmore" class="align-right"><a class="OtherDocs link" onclick="javascript:alert('Clicked');">+ Add More Docs</a></p>
                </div>

                </div>
            </div>
        </div>
       <%--  For Project Related Doc End Here --%>
       <%-- Other Related Doc--%>
            <div class="row">
           <div class="frmOtherDocs" style="display:none;">

            
                         <div class="row"> 
                            <%-- <div class="col-md-6 col-sm-6">--%>
                                 <div class="col-md-12 col-sm-12">
                        <div class="tblResposiveWrapper">
                        <table id="tblOtherDocs" class="tblResposive">
                            <thead>
                                <tr>

                                    <th style="width: 450px; text-align: left">Doc Title</th>
                                    <th style="text-align: left">Doc Desc</th>
                                    <th style="text-align: left">Doc Category</th>
                                    <th style="text-align: left">Browse File</th>
                                    <th style="width: 45px; text-align: right">Action</th>
                                </tr>
                            </thead>
                        <tbody>
                              <%--  <asp:Repeater ID="rptrProjectDocDetails" runat="server">
                                    <ItemTemplate>
                                        <tr piid="<%# Eval("Doc Title)%>">
                                            <td data-th="DocTitle">
                                                <p><%# Eval("Doc Title") %></p>
                                            </td>
                                            <td data-th="DocDesc">
                                                <p><%# Eval("Doc Desc") %></p>
                                            </td>
                                            <td data-th="Doc Category">
                                                <p><%# Eval("Doc Category") %></p>
                                            </td>
                                            <td data-th="Browse File">
                                                <p><%# Eval("Browse File") %></p>
                                            </td>
                                            
                                            <td data-th="Action" style="text-align: right">
                                                <p class="grid-action">--%>
                                                   
												<%--	<asp:LinkButton ID="ImgDownLoad" runat="server" CommandArgument='<%# DataBinder.Eval(Container, "DataItem.Doc Title")%>' CommandName="cmdEdit">
													<img title="Details" alt="" src="../images/icon-edit.png"></asp:LinkButton>-
													
                                                    <asp:LinkButton ID="ImgDelete" CommandArgument='<%# DataBinder.Eval(Container, "DataItem.i_ID")%>' OnClientClick="return delPiRows(this);" CommandName="cmdDelete" runat="server">
                                                        <img title="Delete" alt="" src="../images/icon-delete.png">
                                                    </asp:LinkButton>--%>
                                                  
                                              <%--  </p>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>--%>




                            </tbody>
                        </table>
                    </div>
                                     </div>
           <%--</div>--%>
                                              
                    <p runat="server" id="P2" class="align-right"><a class="link" onclick="javascript:alert('Clicked');">+ Add More Docs</a></p>
                </div>
                
      </div>
                </div>
           </div>
  <%--  </div>--%>
        <%-- Other Related Doc End Here--%>

            </div> 
   
      <script type="text/javascript">
          ShowNoRecords();
          function ShowUploadSection() {
              var frmName = window.event.srcElement.dataset.frm;
              var divName;
              if (frmName == "ProjectDocs") {
                  divName = ".frmProjectDocs";
              }
              else {
                  divName = ".frmOtherDocs";
              }

              if ($(divName).is(':visible')) {
                  $(divName).slideToggle("slow");
              }
              else {

              }


              $(divName).slideToggle("slow", "swing", function () {
                  if ($(divName).is(':visible')) {
                      //window.event.srcElement.innerText	='-Cancel Uploading Docs';
                      //$(divName).find('.link').prev("span").text("-");
                  }
                  else {
                      $(divName).find('.link').text(' Uploading New Docs');
                      $(divName).find('.link').prev("span").text("-");
                  }
              });
              ShowNoRecords();
          }

          SearchText('<%=txtProjectSearch.ClientID%>', '<%=HdnNeProjectId.ClientID%>', 10, "PROJECT~spAutoComplete", Setvalues, '<%=Hidden.ClientID%>');
          function Setvalues(result) {
              var url = "../Frm_DMS.aspx/GetProjectDetails";
              var projectid = result.split('|')[1];
              // project_id = $(project_id).val();
              $.ajax({
                  type: "POST",
                  url: url,
                  data: '{ "projectid": "' + project_id + '"}',
                  contentType: "application/json; charset=utf-8",
                  dataType: "json",
                  success: function (result) {
                      console.log(result.d[0]);
                      var project = eval('result.d[0]');
                      console.log(project);
                      $('#' + getclientId('TxtProjectTitle')).val(project["s_Project_Title"]);
                      $('#' + getclientId('TxtAlias1')).val(project["s_Project_Alias1"]);
                      $('#' + getclientId('TxtAlias2')).val(project["s_Project_Alias2"]);
                      $('#' + getclientId('TxtShortTitle')).val(project["s_Project_Title"]);
                      $('#' + getclientId('TxtProjectId')).val(project["s_Display_Project_ID"]);
                      $('#' + getclientId('TxtDSRVIRB')).val(project["s_IRB_No"]);

                  },
                  error: function (result) {
                      MessageBox("error " + result);
                  }
              });
          }
          function ShowNoRecords() {
              if ($("#tblResposive tbody tr").length == 0) {

                  $("#tblResposive tbody").html("<tr><td colspan='6' > No Records Available <td></tr>");
                  $("#projectPaging").hide();
                  $("#tblResposive thead th").css("background-image", "none");
                  $("#tblResposive thead th").unbind("click");
              }
          }


          function getclientId(controlid) {
              return $('[id$=' + controlid + ']').attr('id');
          }
      </script>
    
</asp:Content>
