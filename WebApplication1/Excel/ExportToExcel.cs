using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.IO;
using System.Net;
using WebApplication1.Excel;
using ExportToExcel;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace WebApplication1.Excel
{
    public class ExportToExcel
    {

        public HttpResponse Export(DataTable dt, HttpResponse Response)
        {
            
            string fileName = HttpContext.Current.Server.MapPath("~\\DownloadFile\\Excel_") + Guid.NewGuid() + ".xlsx";
            string pageName = dt.TableName;

            CreateExcelFile.CreateExcelDocument(dt, fileName);

            Excel.ExportExcel objFile = new Excel.ExportExcel();

            List<EntityDynamicExcel> listExcelInfo = new List<EntityDynamicExcel>();

            List<RowData> listRowData = new List<RowData>();

            List<CellData> listData = new List<CellData>();

            CellData objCell = new CellData();

            DataTable dtReportData = dt;
            int columnCount = dtReportData.Columns.Count;

            listData = new List<CellData>();
            RowData objRowPrjId = new RowData();
            objRowPrjId.rowIndex = 1;
            objRowPrjId.rowCellStartIndex = 1;
            objRowPrjId.rowCellEndIndex = columnCount;

            for (int i = 0; i < columnCount; i++)
            {
                objCell = new CellData();
                objCell.cellName = (CellName)i + 1;
                objCell.cellType = CellType.textBlueFill;
                objCell.cellValue = dtReportData.Columns[i].ToString();
                listData.Add(objCell);
            }

            objRowPrjId.listData = listData;
            listRowData.Add(objRowPrjId);
            List<SheetColumns> listSheet1Columns = new List<SheetColumns>();

            if (dtReportData != null && dtReportData.Rows.Count > 0)
            {
                for (int i = 0; i < dtReportData.Rows.Count; i++)
                {
                    int index = i + 1;
         
                    listData = new List<CellData>();
                    RowData objRowPrjId1 = new RowData();
                    objRowPrjId1.rowIndex = index + 1;
                    objRowPrjId1.rowCellStartIndex = 1;
                    objRowPrjId1.rowCellEndIndex = columnCount;


                    for (int j = 0; j < columnCount; j++)
                    {
                        objCell = new CellData();
                        objCell.cellName = (CellName)j + 1;
                        objCell.cellType = CellType.textNoFill;
                        objCell.cellValue = dtReportData.Rows[i].ItemArray[j].ToString();
                        listData.Add(objCell);

                        #region To Set Sheet Column Width
                        SheetColumns SheetColumns1 = new SheetColumns();
                        SheetColumns1.columnIndex = j + 1;
                        SheetColumns1.columnWidth = 30;

                        listSheet1Columns.Add(SheetColumns1);
                        #endregion
                    }

                    objRowPrjId1.listData = listData;
                    listRowData.Add(objRowPrjId1);


                }
            }

            #region finalExportObject for Sheet1
            listExcelInfo.Add(new EntityDynamicExcel()
            {
                sheetName = pageName + "Details",
                sheetDimensionStart = "A1",
                sheetDimensionEnd = "B5",
                isSheetProtected = false,
                password = "",
                listRowData = listRowData,
                listSheetColumns = listSheet1Columns
            });
            #endregion

            Response.ContentType = "application/vnd.ms-excel";

            Response.AppendHeader("Content-Disposition", "attachment; filename=" + pageName+".xlsx");

            Response.TransmitFile(fileName);

            Response.End();

            FileInfo file = new FileInfo(fileName);
            if (file.Exists)
            {
                file.Delete();
            }

            return Response;
            
        }
    }
}