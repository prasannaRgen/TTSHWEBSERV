using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.TTSHServiceReference;
namespace WebApplication1.UI
	{
	public partial class frmProject_Master : System.Web.UI.Page
		{

		#region " Load Event "
		protected void Page_Load(object sender, EventArgs e)
			{
			if ( !IsPostBack )
				{
				ShowPanel("main");
				BindCombo();
				}
			}
		#endregion

		#region " Methods "
		protected void ShowPanel(string Type)
			{
			DivMain.Visible = false; DivDetail.Visible = false;
			btnSave.Visible = true;
			EnableAllandClearControl(true);
			switch ( Type.ToLower() )
				{
				case "entry":
					DivDetail.Visible = true;
					TxtprojTitle.Focus();
					break;
				case "main":
					DivMain.Visible = true;
					btnNew.Focus();
					break;
				}
			}
		protected void EnableAllandClearControl(bool isEnabled = false, bool IsClear = false, string ContentPageName = "maincontent")
			{
			foreach ( Control ctrl in Master.Controls )
				{
				if ( ctrl.HasControls() )
					{
					foreach ( Control item in ctrl.Controls )
						{
						if ( item.HasControls() )
							{
							if ( item.GetType().ToString().ToLower() == "system.web.ui.webcontrols.contentplaceholder" && item.ClientID.ToLower() == ContentPageName )
								{
								foreach ( Control lst in item.Controls )
									{
									if ( lst.HasControls() )
										{
										foreach ( Control child in lst.Controls )
											{
											if ( child is TextBox )
												{
												( (TextBox)child ).Enabled = isEnabled;
												if ( IsClear )
													{
													( (TextBox)child ).Text = "";
													}
												}
											else if ( child is System.Web.UI.WebControls.DropDownList )
												{
												( (System.Web.UI.WebControls.DropDownList)child ).Enabled = isEnabled;
												if ( IsClear )
													{
													( (System.Web.UI.WebControls.DropDownList)child ).SelectedIndex = -1;
													}
												}
											}

										}
									}
								}

							}

						}
					}

				}

			}
		protected void BindCombo()
			{
			TTSHWCFServiceClient client = new TTSHWCFServiceClient();
			List<TTSHServiceReference.DropDownList> ddllist = client.GetDropDownData("Project_Master", "Get_CommonDDl", "tblProject_Category_Master", "", "", "").ToList();
			ddlProjCategory.DataSource = ddllist;
			ddlProjCategory.DataTextField = "DisplayField";
			ddlProjCategory.DataValueField = "ValueField";
			ddlProjCategory.DataBind();

			}
		#endregion

		#region " Button Event "
		protected void btnNew_Click(object sender, EventArgs e)
			{
			ShowPanel("entry");
			}
		protected void Imgback_Click(object sender, ImageClickEventArgs e)
			{
			ShowPanel("main");
			}
		#endregion




		}
	}