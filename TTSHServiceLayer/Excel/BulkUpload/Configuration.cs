using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TTSH.ServiceLayer.Excel.BulkUpload
{
    internal static class Configuration
    {
        internal static string TemplateFileName = "SampleTemplate\\BulkImportTemplate.xlsx";

        internal static string TabName_TestPass = "Test Pass";
        internal static string TabName_Tester = "Tester";
        internal static string TabName_TestCase = "Test Case";
        internal static string TabName_TestStep = "Test Step";

        internal static string TableName_TestPass = "tblTestPass";
        internal static string TableName_Tester = "tblTester";
        internal static string TableName_TestCase = "tblTestCase";
        internal static string TableName_TestStep = "tblTestStep";
    }
}