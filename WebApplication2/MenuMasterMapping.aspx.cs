using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication2.TTSHWCFService;
using System.Web.Script.Services;
using System.Web.Services;



namespace WebApplication2
{
    
    public partial class MenuMasterMapping : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            btnSave.Attributes.Add("onclick", "javascript:return FinalValidation();");
            if (!IsPostBack)
            {
                ddlGroupName.FillCombo(DropDownName.MenuMapping);
              
            }
            //if (!IsPostBack)
                
        }
       
        [WebMethod]
        [ScriptMethod]
        public static string[] GetValues1(string Prefix, int count, string ContextKey)
        {
            TTSHWCFServiceClient sc = new TTSHWCFServiceClient();
            List<string> lst = new List<string>();
            lst.AddRange(sc.GetValues("MenuMapping","","","",""));
     
            return lst.ToArray();
        }

        protected void ddlGroupName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BindTreeView();
            }
            catch (Exception ex)
            {
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                CheckUncheckTreeNode(tvAccess.Nodes, false);
                ddlGroupName.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            System.Text.StringBuilder xml;
            try
            {
                xml = new System.Text.StringBuilder();
                xml.Append("<items>");
                foreach (TreeNode TN in tvAccess.Nodes)
                {
                    if (TN.Checked)
                    {
                        xml.AppendFormat("<item menuid='{0}'/>", TN.Value);
                        foreach (TreeNode n in TN.ChildNodes)
                        {
                            if (n.Checked)
                            {
                                xml.AppendFormat("<item menuid='{0}'/>", n.Value);
                            }
                        }
                    }
                }
                xml.Append("</items>");
                TTSHWCFServiceClient c1 = new TTSHWCFService.TTSHWCFServiceClient();
                if (c1.SaveAccess(xml.ToString(), Convert.ToInt32(ddlGroupName.SelectedValue), 1))
                {
                    CheckUncheckTreeNode(tvAccess.Nodes, false);
                    ddlGroupName.SelectedIndex = 0;
                }
            }
            catch (Exception)
            {
                
                //throw;
            }
        }
        protected void BindTreeView()
        {
            bool isupdate = false;
            try
            {
                WebApplication2.TTSHWCFService.UserMenuRights userMenuRights;
                TTSHWCFService.TTSHWCFServiceClient c1 = new TTSHWCFServiceClient();
                userMenuRights = c1.GetAllMenus(ddlGroupName.SelectedItem.ToString());
                tvAccess.Nodes.Clear();
              
                tvAccess.Nodes.Add(new TreeNode("Select All","-1"));
                foreach (ParentMenuAccess menuMaster in userMenuRights.parentMenuAccess)
                {
                    TreeNode root = new TreeNode();
                    root.Text = menuMaster.MenuName;
                    root.Value = menuMaster.MenuId.ToString();
                 
                    root.SelectAction = TreeNodeSelectAction.None;
                    //Added Code To Show Parent Menu Checked When No Child Menu Is There
                    if(menuMaster.AccessRights)
                        root.Checked = true;

                    foreach (MenuAccessRights menuAccessRights in userMenuRights.menuAccessRights)
                    {
                        if (menuMaster.MenuId == menuAccessRights.Parent && menuAccessRights.Parent > 0)
                        {
                            TreeNode cn = new TreeNode();
                            cn.Text = menuAccessRights.MenuName;
                            cn.Value = menuAccessRights.MenuId.ToString();
                            cn.SelectAction = TreeNodeSelectAction.None;

                            root.ChildNodes.Add(cn);
                            if (menuAccessRights.AccessRights)
                            {
                                root.Selected = true; 
                                cn.Checked = true;
                                root.Checked = true;
                            }
                        }
                    }
                    root.ToolTip = "Main";
                    tvAccess.Nodes.Add(root);
                }
                if (userMenuRights.menuAccessRights.Count(x => x.AccessRights == true) > 0 || userMenuRights.parentMenuAccess.Count(x => x.AccessRights == true) > 0)
                    isupdate = true;

                tvAccess.CollapseAll();
                tvAccess.Attributes.Add("onclick", "OnCheckBoxCheckChanged(event)");
               // chkAll.Attributes.Add("change", "CheckAll()");
                btnSave.Attributes.Add("onclick", "javascript:return FinalValidation();");
                btnSave.Text = isupdate ? "Update Details" : "Save Details";
            }
            catch (Exception ex)
            {
            }

        }
        /// <summary>
        /// To Check Or Uncheck the Nodes
        /// </summary>
        /// <param name="trNodeCollection"></param>
        /// <param name="isCheck"></param>
        private void CheckUncheckTreeNode(TreeNodeCollection trNodeCollection, bool isCheck)
        {
            foreach (TreeNode trNode in trNodeCollection)
            {
                trNode.Checked = isCheck;
                if (trNode.ChildNodes.Count > 0)
                    CheckUncheckTreeNode(trNode.ChildNodes, isCheck);
            }
        }

       
    }
}