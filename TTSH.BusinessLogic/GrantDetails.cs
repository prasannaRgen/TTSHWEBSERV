using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Xml;
using TTSH.DataAccess;
using TTSH.Entity;
namespace TTSH.BusinessLogic
{
    public class GrantDetails
    {
        #region " Fill Main Grid "
        public static List<Grant_Details> FillGrantDetailGrid()
        {
            List<Grant_Details> Gd = new List<Grant_Details>();

            try
            {
                DataHelper _helper = new DataHelper();
                _helper.InitializedHelper();
                List<System.Data.Common.DbParameter> parameter = new List<System.Data.Common.DbParameter>();
                parameter.Add(_helper.CreateDbParameter());
                parameter[parameter.Count - 1].ParameterName = "@StatementType";
                parameter[parameter.Count - 1].Value = "select";

                DataTable gridData = new DataTable();
                gridData = _helper.GetData("[dbo].[spGrant_DetailsDML]", parameter);

                foreach (DataRow dr in gridData.Rows)
                {
                    Gd.Add(new Grant_Details
                    {
                        GD_ID = (dr["GD_ID"] != DBNull.Value) ? Convert.ToInt32(dr["GD_ID"]) : 0,
                        GM_ID = (dr["GM_ID"] != DBNull.Value) ? Convert.ToInt32(dr["GM_ID"]) : 0,
                        i_Project_ID = (dr["i_Project_ID"] != DBNull.Value) ? Convert.ToInt32(dr["i_Project_ID"]) : 0,
                        s_Display_Project_ID = (dr["s_Display_Project_ID"] != DBNull.Value) ? Convert.ToString(dr["s_Display_Project_ID"]) : "",
                        s_Project_Title = (dr["s_Project_Title"] != DBNull.Value) ? Convert.ToString(dr["s_Project_Title"]) : "",
                        Project_Category_Name = (dr["Project_Category"] != DBNull.Value) ? Convert.ToString(dr["Project_Category"]) : "",
                        s_IRB_No = (dr["s_IRB_No"] != DBNull.Value) ? Convert.ToString(dr["s_IRB_No"]) : "",
                        PI_Name = (dr["PI_NAME"] != DBNull.Value) ? Convert.ToString(dr["PI_NAME"]) : "",
                        GrantDetailStatus = (dr["GrantDetailStatus"] != DBNull.Value) ? Convert.ToString(dr["GrantDetailStatus"]) : "",


                    });
                }
            }
            catch (Exception)
            {


            }

            return Gd;
        }
        #endregion

        #region " New Project Entry "
        public static GrantNewProjectEntry FillGrantDetailNewProject(int ID)
        {
            GrantNewProjectEntry GNP = new GrantNewProjectEntry();
            DataHelper _helper = new DataHelper();
            List<System.Data.Common.DbParameter> parameter = new List<System.Data.Common.DbParameter>();
            DataTable ProjectsData = new DataTable();
            List<PI_Master> piList = new List<PI_Master>();
            List<Project_Master> pjList = new List<Project_Master>();
            List<Grant_Master> gmList = new List<Grant_Master>();
            List<Project_Master> childpmlist = new List<Project_Master>();
            List<PI_Master> childpilist = new List<PI_Master>();
            try
            {
                _helper.InitializedHelper();

                parameter.Add(_helper.CreateDbParameter());
                parameter[parameter.Count - 1].ParameterName = "@StatementType";
                parameter[parameter.Count - 1].Value = "ByProjectId";
                parameter.Add(_helper.CreateDbParameter());
                parameter[parameter.Count - 1].ParameterName = "@i_Project_ID";
                parameter[parameter.Count - 1].Value = ID;
                ProjectsData = _helper.GetData("dbo.[spGrant_DetailsDML]", parameter);

                foreach (DataRow dr in ProjectsData.Rows)
                {
                    #region " Dept Master "
                    string xmlTestManager = (dr.IsNull("DEPT_PI")) == true ? "" : Convert.ToString(dr["DEPT_PI"]);
                    if (xmlTestManager != string.Empty)
                    {

                        using (XmlReader reader = XmlReader.Create(new StringReader(xmlTestManager)))
                        {
                            XmlDocument xml = new XmlDocument();
                            xml.Load(reader);
                            XmlNodeList xmlNodeList = xml.SelectNodes("DEPT_PI/DEPT");
                            foreach (XmlNode node in xmlNodeList)
                            {
                                PI_Master pi = new PI_Master();

                                if (node["i_Dept_ID"] != null)
                                    pi.i_Dept_ID = Convert.ToInt32(node["i_Dept_ID"].InnerText);
                                if (node["i_ID"] != null)
                                    pi.i_ID = Convert.ToInt32(node["i_ID"].InnerText);
                                if (node["s_Email"] != null)
                                    pi.s_Email = (node["s_Email"].InnerText);
                                if (node["s_Phone_no"] != null)
                                    pi.s_Phone_no = (node["s_Phone_no"].InnerText);
                                if (node["s_MCR_No"] != null)
                                    pi.s_MCR_No = (node["s_MCR_No"].InnerText);
                                if (node["Dept_Name"] != null)
                                    pi.s_DeptName = (node["Dept_Name"].InnerText);
                                if (node["s_PI_Name"] != null)
                                    pi.s_PIName = (node["s_PI_Name"].InnerText);
                                piList.Add(pi);
                            }
                        }

                    }
                    #endregion

                    #region "Child Dept Master "
                    string ChildDept = (dr.IsNull("CHILD_PI_DETAILS")) == true ? "" : Convert.ToString(dr["CHILD_PI_DETAILS"]);
                    if (ChildDept != string.Empty)
                    {

                        using (XmlReader reader = XmlReader.Create(new StringReader(ChildDept)))
                        {
                            XmlDocument xml = new XmlDocument();
                            xml.Load(reader);
                            XmlNodeList xmlNodeList = xml.SelectNodes("DEPT_PI/DEPT");
                            foreach (XmlNode node in xmlNodeList)
                            {
                                PI_Master pi = new PI_Master();

                                if (node["i_ID"] != null)
                                    pi.i_ID = Convert.ToInt32(node["i_ID"].InnerText);

                                if (node["s_PI_Name"] != null)
                                    pi.s_PIName = (node["s_PI_Name"].InnerText);
                                childpilist.Add(pi);
                            }
                        }

                    }
                    #endregion

                    #region " Project Master "
                    string PJmasterList = (dr.IsNull("PROJECT_DATA")) == true ? "" : Convert.ToString(dr["PROJECT_DATA"]);
                    if (PJmasterList != string.Empty)
                    {

                        using (XmlReader reader = XmlReader.Create(new StringReader(PJmasterList)))
                        {
                            XmlDocument xml = new XmlDocument();
                            xml.Load(reader);
                            XmlNodeList xmlNodeList = xml.SelectNodes("PROJECT/PROJECT_DATA");

                            foreach (XmlNode node in xmlNodeList)
                            {
                                Project_Master pmMaster = new Project_Master();
                                if (node["ProjmID"] != null)
                                    pmMaster.i_ID = Convert.ToInt32(node["ProjmID"].InnerText);
                                if (node["s_Project_Title"] != null)
                                    pmMaster.s_Project_Title = Convert.ToString(node["s_Project_Title"].InnerText);
                                if (node["s_Display_Project_ID"] != null)
                                    pmMaster.s_Display_Project_ID = Convert.ToString(node["s_Display_Project_ID"].InnerText);
                                if (node["s_Short_Title"] != null)
                                    pmMaster.s_Short_Title = Convert.ToString(node["s_Short_Title"].InnerText);
                                if (node["Project_Category_Name"] != null)
                                    pmMaster.Project_Category_Name = Convert.ToString(node["Project_Category_Name"].InnerText);
                                if (node["s_Project_Alias1"] != null)
                                    pmMaster.s_Project_Alias1 = Convert.ToString(node["s_Project_Alias1"].InnerText);
                                if (node["s_Project_Alias2"] != null)
                                    pmMaster.s_Project_Alias2 = Convert.ToString(node["s_Project_Alias2"].InnerText);
                                if (node["s_IRB_No"] != null)
                                    pmMaster.s_IRB_No = Convert.ToString(node["s_IRB_No"].InnerText);

                                pjList.Add(pmMaster);
                            }
                        }

                    }
                    #endregion

                    #region " Child Project "
                    string ChildProjList = (dr.IsNull("CHILD_PROJECTGRID_DATA")) == true ? "" : Convert.ToString(dr["CHILD_PROJECTGRID_DATA"]);
                    if (ChildProjList != string.Empty)
                    {

                        using (XmlReader reader = XmlReader.Create(new StringReader(ChildProjList)))
                        {
                            XmlDocument xml = new XmlDocument();
                            xml.Load(reader);
                            XmlNodeList xmlNodeList = xml.SelectNodes("CHILD_PROJECT_DATA/CHILD_PROJECT");

                            foreach (XmlNode node in xmlNodeList)
                            {
                                Project_Master pmMaster = new Project_Master();
                                if (node["i_Project_ID"] != null)
                                    pmMaster.S_ProjectStatus = Convert.ToString(node["i_Project_ID"].InnerText);
                                if (node["s_Project_Title"] != null)
                                    pmMaster.s_Project_Title = Convert.ToString(node["s_Project_Title"].InnerText);
                                if (node["s_Display_Project_ID"] != null)
                                    pmMaster.s_Display_Project_ID = Convert.ToString(node["s_Display_Project_ID"].InnerText);
                                if (node["PI_NAME"] != null)
                                    pmMaster.PI_NAME = Convert.ToString(node["PI_NAME"].InnerText);
                                childpmlist.Add(pmMaster);
                            }
                        }

                    }
                    #endregion

                    #region " Grant Master "
                    string GrantMList = (dr.IsNull("GRANT_MASTER_DATA")) == true ? "" : Convert.ToString(dr["GRANT_MASTER_DATA"]);
                    if (GrantMList != string.Empty)
                    {

                        using (XmlReader reader = XmlReader.Create(new StringReader(GrantMList)))
                        {
                            XmlDocument xml = new XmlDocument();
                            xml.Load(reader);
                            XmlNodeList xmlNodeList = xml.SelectNodes("GRANT_MASTER_DATA/GRANT_MASTER");

                            foreach (XmlNode node in xmlNodeList)
                            {
                                Grant_Master GMaster = new Grant_Master();
                                if (node["i_ID"] != null)
                                    GMaster.i_ID = Convert.ToInt32(node["i_ID"].InnerText);
                                if (node["GRANT_TYPE"] != null)
                                    GMaster.GRANT_TYPE = Convert.ToString(node["GRANT_TYPE"].InnerText);
                                if (node["GRANT_SUB_TYPE1"] != null)
                                    GMaster.GRANT_SUB_TYPE1 = Convert.ToString(node["GRANT_SUB_TYPE1"].InnerText);
                                if (node["GRANT_SUB_TYPE2"] != null)
                                    GMaster.GRANT_SUB_TYPE2 = Convert.ToString(node["GRANT_SUB_TYPE2"].InnerText);
                                if (node["GRANT_SUB_TYPE3"] != null)
                                    GMaster.GRANT_SUB_TYPE3 = Convert.ToString(node["GRANT_SUB_TYPE3"].InnerText);
                                if (node["dt_AwardDate"] != null)
                                    GMaster.Dt_AwardDate = Convert.ToString(node["dt_AwardDate"].InnerText);
                                if (node["DURATION"] != null)
                                    GMaster.s_Duration = Convert.ToString(node["DURATION"].InnerText);
                                gmList.Add(GMaster);
                            }
                        }

                    }
                    #endregion

                }
                GNP = new GrantNewProjectEntry
                {
                    PIList = piList,
                    PMList = pjList,
                    CHildProjectList = childpmlist,
                    GMList = gmList,
                    CHILDpilist=childpilist
                };
            }
            catch (Exception ex)
            {
                return GNP = null;
            }
            return GNP;
        }
        #endregion

        #region " Edit Grid Details By Id "
        public static Grant_Details GetGrantDetailsById(int ID)
        {
            Grant_Details GDList = new Grant_Details();
            List<Project_Master> pjlist = new List<Project_Master>();
            List<Project_Master> childpmlist = new List<Project_Master>();
            List<PI_Master> pilist = new List<PI_Master>();
            List<PI_Master> childpilist = new List<PI_Master>();
            List<Grant_Master> gmList = new List<Grant_Master>();
            try
            {
                DataHelper _helper = new DataHelper();
                _helper.InitializedHelper();
                List<System.Data.Common.DbParameter> parameter = new List<System.Data.Common.DbParameter>();
                parameter.Add(_helper.CreateDbParameter());
                parameter[parameter.Count - 1].ParameterName = "@StatementType";
                parameter[parameter.Count - 1].Value = "select";
                parameter.Add(_helper.CreateDbParameter());
                parameter[parameter.Count - 1].ParameterName = "@i_ID";
                parameter[parameter.Count - 1].Value = ID;
                DataTable gridData = new DataTable();
                gridData = _helper.GetData("[dbo].[spGrant_DetailsDML]", parameter);
                if (gridData != null)
                {
                    if (gridData.Rows.Count > 0)
                    {
                        foreach (DataRow dr in gridData.Rows)
                        {
                            #region " Dept Master "
                            string xmlTestManager = (dr.IsNull("DEPT_PI")) == true ? "" : Convert.ToString(dr["DEPT_PI"]);
                            if (xmlTestManager != string.Empty)
                            {

                                using (XmlReader reader = XmlReader.Create(new StringReader(xmlTestManager)))
                                {
                                    XmlDocument xml = new XmlDocument();
                                    xml.Load(reader);
                                    XmlNodeList xmlNodeList = xml.SelectNodes("DEPT_PI/DEPT");
                                    foreach (XmlNode node in xmlNodeList)
                                    {
                                        PI_Master pi = new PI_Master();

                                        if (node["i_Dept_ID"] != null)
                                            pi.i_Dept_ID = Convert.ToInt32(node["i_Dept_ID"].InnerText);
                                        if (node["i_ID"] != null)
                                            pi.i_ID = Convert.ToInt32(node["i_ID"].InnerText);
                                        if (node["s_Email"] != null)
                                            pi.s_Email = (node["s_Email"].InnerText);
                                        if (node["s_Phone_no"] != null)
                                            pi.s_Phone_no = (node["s_Phone_no"].InnerText);
                                        if (node["s_MCR_No"] != null)
                                            pi.s_MCR_No = (node["s_MCR_No"].InnerText);
                                        if (node["Dept_Name"] != null)
                                            pi.s_DeptName = (node["Dept_Name"].InnerText);
                                        if (node["s_PI_Name"] != null)
                                            pi.s_PIName = (node["s_PI_Name"].InnerText);
                                        pilist.Add(pi);
                                    }
                                }

                            }
                            #endregion

                            #region "Child Dept Master "
                            string ChildDept = (dr.IsNull("CHILD_PI_DETAILS")) == true ? "" : Convert.ToString(dr["CHILD_PI_DETAILS"]);
                            if (ChildDept != string.Empty)
                            {

                                using (XmlReader reader = XmlReader.Create(new StringReader(ChildDept)))
                                {
                                    XmlDocument xml = new XmlDocument();
                                    xml.Load(reader);
                                    XmlNodeList xmlNodeList = xml.SelectNodes("DEPT_PI/DEPT");
                                    foreach (XmlNode node in xmlNodeList)
                                    {
                                        PI_Master pi = new PI_Master();

                                        if (node["i_ID"] != null)
                                            pi.i_ID = Convert.ToInt32(node["i_ID"].InnerText);
                                       
                                        if (node["s_PI_Name"] != null)
                                            pi.s_PIName = (node["s_PI_Name"].InnerText);
                                        childpilist.Add(pi);
                                    }
                                }

                            }
                            #endregion

                            #region " Project Master "
                            string PJmasterList = (dr.IsNull("PROJECT_DATA")) == true ? "" : Convert.ToString(dr["PROJECT_DATA"]);
                            if (PJmasterList != string.Empty)
                            {

                                using (XmlReader reader = XmlReader.Create(new StringReader(PJmasterList)))
                                {
                                    XmlDocument xml = new XmlDocument();
                                    xml.Load(reader);
                                    XmlNodeList xmlNodeList = xml.SelectNodes("PROJECT/PROJECT_DATA");

                                    foreach (XmlNode node in xmlNodeList)
                                    {
                                        Project_Master pmMaster = new Project_Master();
                                        if (node["ProjmID"] != null)
                                            pmMaster.i_ID = Convert.ToInt32(node["ProjmID"].InnerText);
                                        if (node["s_Project_Title"] != null)
                                            pmMaster.s_Project_Title = Convert.ToString(node["s_Project_Title"].InnerText);
                                        if (node["s_Display_Project_ID"] != null)
                                            pmMaster.s_Display_Project_ID = Convert.ToString(node["s_Display_Project_ID"].InnerText);
                                        if (node["s_Short_Title"] != null)
                                            pmMaster.s_Short_Title = Convert.ToString(node["s_Short_Title"].InnerText);
                                        if (node["Project_Category_Name"] != null)
                                            pmMaster.Project_Category_Name = Convert.ToString(node["Project_Category_Name"].InnerText);
                                        if (node["s_Project_Alias1"] != null)
                                            pmMaster.s_Project_Alias1 = Convert.ToString(node["s_Project_Alias1"].InnerText);
                                        if (node["s_Project_Alias2"] != null)
                                            pmMaster.s_Project_Alias2 = Convert.ToString(node["s_Project_Alias2"].InnerText);
                                        if (node["s_IRB_No"] != null)
                                            pmMaster.s_IRB_No = Convert.ToString(node["s_IRB_No"].InnerText);

                                        pjlist.Add(pmMaster);
                                    }
                                }

                            }
                            #endregion

                            #region " Child Project "
                            string ChildProjList = (dr.IsNull("CHILD_PROJECTGRID_DATA")) == true ? "" : Convert.ToString(dr["CHILD_PROJECTGRID_DATA"]);
                            if (ChildProjList != string.Empty)
                            {

                                using (XmlReader reader = XmlReader.Create(new StringReader(ChildProjList)))
                                {
                                    XmlDocument xml = new XmlDocument();
                                    xml.Load(reader);
                                    XmlNodeList xmlNodeList = xml.SelectNodes("CHILD_PROJECT_DATA/CHILD_PROJECT");

                                    foreach (XmlNode node in xmlNodeList)
                                    {
                                        Project_Master pmMaster = new Project_Master();
                                        if (node["i_Project_ID"] != null)
                                            pmMaster.S_ProjectStatus = Convert.ToString(node["i_Project_ID"].InnerText);
                                        if (node["s_Project_Title"] != null)
                                            pmMaster.s_Project_Title = Convert.ToString(node["s_Project_Title"].InnerText);
                                        if (node["s_Display_Project_ID"] != null)
                                            pmMaster.s_Display_Project_ID = Convert.ToString(node["s_Display_Project_ID"].InnerText);
                                        if (node["PI_NAME"] != null)
                                            pmMaster.PI_NAME = Convert.ToString(node["PI_NAME"].InnerText);
                                        childpmlist.Add(pmMaster);
                                    }
                                }

                            }
                            #endregion

                            #region " Grant Master "
                            string GrantMList = (dr.IsNull("GRANT_MASTER_DATA")) == true ? "" : Convert.ToString(dr["GRANT_MASTER_DATA"]);
                            if (GrantMList != string.Empty)
                            {

                                using (XmlReader reader = XmlReader.Create(new StringReader(GrantMList)))
                                {
                                    XmlDocument xml = new XmlDocument();
                                    xml.Load(reader);
                                    XmlNodeList xmlNodeList = xml.SelectNodes("GRANT_MASTER_DATA/GRANT_MASTER");

                                    foreach (XmlNode node in xmlNodeList)
                                    {
                                        Grant_Master GMaster = new Grant_Master();
                                        if (node["i_ID"] != null)
                                            GMaster.i_ID = Convert.ToInt32(node["i_ID"].InnerText);
                                        if (node["GRANT_TYPE"] != null)
                                            GMaster.GRANT_TYPE = Convert.ToString(node["GRANT_TYPE"].InnerText);
                                        if (node["GRANT_SUB_TYPE1"] != null)
                                            GMaster.GRANT_SUB_TYPE1 = Convert.ToString(node["GRANT_SUB_TYPE1"].InnerText);
                                        if (node["GRANT_SUB_TYPE2"] != null)
                                            GMaster.GRANT_SUB_TYPE2 = Convert.ToString(node["GRANT_SUB_TYPE2"].InnerText);
                                        if (node["GRANT_SUB_TYPE3"] != null)
                                            GMaster.GRANT_SUB_TYPE3 = Convert.ToString(node["GRANT_SUB_TYPE3"].InnerText);
                                        if (node["dt_AwardDate"] != null)
                                            GMaster.Dt_AwardDate = Convert.ToString(node["dt_AwardDate"].InnerText);
                                        if (node["DURATION"] != null)
                                            GMaster.s_Duration = Convert.ToString(node["DURATION"].InnerText);
                                        gmList.Add(GMaster);
                                    }
                                }

                            }
                            #endregion

                            #region " Grant Details "
                            GDList = new Grant_Details()
                            {
                                i_ID = (dr.IsNull("i_ID") ? 0 : Convert.ToInt32(dr["i_ID"])),
                                i_Project_ID = (dr.IsNull("i_Project_ID") ? 0 : Convert.ToInt32(dr["i_Project_ID"])),
                                i_GrantMaster_ID = (dr.IsNull("i_GrantMaster_ID") ? 0 : Convert.ToInt32(dr["i_GrantMaster_ID"])),
                                s_Award_Letter_File = (dr.IsNull("s_Award_Letter_File") ? "" : Convert.ToString(dr["s_Award_Letter_File"])),
                                i_Grant_ID = (dr.IsNull("i_Grant_ID") ? 0 : Convert.ToInt32(dr["i_Grant_ID"])),
                                s_Research_IO = (dr.IsNull("s_Research_IO") ? "" : Convert.ToString(dr["s_Research_IO"])),
                                i_Donation_Amt = (dr.IsNull("i_Donation_Amt") ? 0 : Convert.ToInt32(dr["i_Donation_Amt"])),
                                s_Donation_Body = (dr.IsNull("s_Donation_Body") ? "" : Convert.ToString(dr["s_Donation_Body"])),
                                dt_Grant_Expiry_Date = (dr.IsNull("dt_Grant_Expiry_Date") ? "" : Convert.ToString(dr["dt_Grant_Expiry_Date"])),
                                b_Grant_Extended = (dr.IsNull("b_Grant_Extended") ? null :(bool?) Convert.ToBoolean(dr["dt_Grant_Expiry_Date"])),
                                dt_New_Grant_Expiry_Date = (dr.IsNull("dt_New_Grant_Expiry_Date") ? "" : Convert.ToString(dr["dt_New_Grant_Expiry_Date"])),
                                i_Indirects = (dr.IsNull("i_Indirects") ? 0 : Convert.ToInt32(dr["i_Indirects"])),
                                i_Indirects_Amt_Utilized = (dr.IsNull("i_Indirects_Amt_Utilized") ? 0 : Convert.ToInt32(dr["i_Indirects_Amt_Utilized"])),
                                b_Mentor = (dr.IsNull("b_Grant_Extended") ? null : (bool?)Convert.ToBoolean(dr["dt_Grant_Expiry_Date"])),
                                s_Mentor_Name = (dr.IsNull("s_Mentor_Name") ? "" : Convert.ToString(dr["s_Mentor_Name"])),
                                s_Mentor_Institute = (dr.IsNull("s_Mentor_Institute") ? "" : Convert.ToString(dr["s_Mentor_Institute"])),
                                s_Mentor_Dept = (dr.IsNull("s_Mentor_Dept") ? "" : Convert.ToString(dr["s_Mentor_Dept"])),
                                s_Tech_PI_Name = (dr.IsNull("s_Tech_PI_Name") ? "" : Convert.ToString(dr["s_Tech_PI_Name"])),
                                s_Tech_PI_Institution = (dr.IsNull("s_Tech_PI_Institution") ? "" : Convert.ToString(dr["s_Tech_PI_Institution"])),
                                s_Tech_PI_Dept = (dr.IsNull("s_Tech_PI_Dept") ? "" : Convert.ToString(dr["s_Tech_PI_Dept"])),
                                s_Point_of_Submission = (dr.IsNull("s_Point_of_Submission") ? "" : Convert.ToString(dr["s_Point_of_Submission"])),
                                i_FTE = (dr.IsNull("i_FTE") ? 0 : Convert.ToInt32(dr["i_FTE"])),
                                i_GrantStatus_ID = (dr.IsNull("i_GrantStatus_ID") ? 0 : Convert.ToInt32(dr["i_GrantStatus_ID"])),
                                b_IsVariation_Needed = (dr.IsNull("b_IsVariation_Needed") ? null : (bool?)Convert.ToBoolean(dr["b_IsVariation_Needed"])),

                                PIList=pilist,
                                PMList=pjlist,
                                CHILDPIList=childpilist,
                                CHildProjectList=childpmlist,
                                GMList=gmList
                            };
                            #endregion
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                GDList = null;
            }
            return GDList;
        }
        #endregion
    }
}
