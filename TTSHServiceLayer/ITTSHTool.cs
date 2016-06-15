using System.ServiceModel;
using System.ServiceModel.Web;
using System.Collections.Generic;
using System.Data;
using TTSH.Entity;

namespace TTSHServiceLayer
{
    /// <summary>
    /// Author: TTSH Dev Team
    /// Created Date: 03/11/2014
    /// Description: -
    /// </summary>
    [ServiceContract]
    public interface ITTSHTool
    {
        //[OperationContract]
        //List<Project_Master> GetAllProjectDetails();

        //[OperationContract]
        //Project_Master GetAProjectDetailsByID();

        [OperationContract]
        string ProjectDetails(Project_Master projectMaster);

      
        



       

    }
}
