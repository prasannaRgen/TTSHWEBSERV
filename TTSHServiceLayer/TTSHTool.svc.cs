using System;
using TTSH.Entity;
using System.Collections.Generic;
using System.ServiceModel.Activation;
using System.Data.SqlClient;
using System.Data;
using System.ServiceModel.Web;
using System.Globalization;
using System.Linq;
using System.Xml;
using System.IO;
using TTSH.ServiceLayer.Excel;



namespace TTSHServiceLayer
{
    /// <summary>
    /// Author: TTSH Dev Team
    /// Created Date: 09/06/2015
    /// Description: -
    /// </summary>
    //[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class TTSHTool : ITTSHTool
    {
        //public string HelloWorld(string value)
        //{
        //    //string _clientSchemaName = new TTSHClient().GetClientSchema();

        //    //return string.Format("Hello World Function called with value: {0} : SchemName : {1}", value, _clientSchemaName);

        //    return "";
        //}





        //public List<Project_Master> GetAllProjectDetails()
        //{
        //    throw new NotImplementedException();

        //}

        //public Project_Master GetAProjectDetailsByID()
        //{
        //    throw new NotImplementedException();
        //}


        public string ProjectDetails(Project_Master projectMaster)
        {
            return "";
        }
    }
}
