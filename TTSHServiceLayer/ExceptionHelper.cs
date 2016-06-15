using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Web;
using System.Web;

namespace TTSH.ServiceLayer
{
    /// <summary>
    /// Author: TTSH Dev Team
    /// Created Date: 04/06/2015
    /// Description: Helper to handle Exception
    /// </summary>
    internal class ExceptionHelper
    {
        internal static string TraceDBLevelException(List<System.Data.Common.DbParameter> outParameter)
        {
            OutgoingWebResponseContext _response = WebOperationContext.Current.OutgoingResponse;
            _response.StatusCode = System.Net.HttpStatusCode.InternalServerError;
            _response.StatusDescription = "DBLevelExceptionOccured";

            string errorDetails = string.Empty;

            errorDetails += "[";
            foreach (var outP in outParameter)
            {
                if (outP.Direction == System.Data.ParameterDirection.Output)
                    errorDetails += "{'" + outP.ParameterName + "':'" + outP.Value + "'}";
                //errorDetails += "{" + "" + outP.Value + "}";
            }

            errorDetails += "]";

            return errorDetails;
        }

        internal static string TraceDBLevelException(string ExceptionMessage)
        {

            OutgoingWebResponseContext _response = WebOperationContext.Current.OutgoingResponse;
            _response.StatusCode = System.Net.HttpStatusCode.InternalServerError;
            _response.StatusDescription = "DBLevelExceptionOccured";
            return "[" + ExceptionMessage + "]";
            
        }

        internal static string TraceServiceLevelException(Exception ex)
        {
            OutgoingWebResponseContext _response = WebOperationContext.Current.OutgoingResponse;
            _response.StatusCode = System.Net.HttpStatusCode.InternalServerError;
            _response.StatusDescription = "ServiceLevelExceptionOccured";

            return ex.Message;
        }

        internal static string TraceServiceLevelException(string errorMessage)
        {
            OutgoingWebResponseContext _response = WebOperationContext.Current.OutgoingResponse;
            _response.StatusCode = System.Net.HttpStatusCode.InternalServerError;
            _response.StatusDescription = "ServiceLevelExceptionOccured";

            return errorMessage;
        }
    }
}