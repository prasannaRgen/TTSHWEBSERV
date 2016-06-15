using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DocumentFormat.OpenXml.Packaging;
using Ap = DocumentFormat.OpenXml.ExtendedProperties;
using Vt = DocumentFormat.OpenXml.VariantTypes;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Spreadsheet;
using A = DocumentFormat.OpenXml.Drawing;


namespace TTSH.ServiceLayer.Excel
{
    public class GenerateExcelTest
    {
        // Creates a SpreadsheetDocument.
        public void CreatePackage(string filePath)
        {
            using (SpreadsheetDocument package = SpreadsheetDocument.Create(filePath, SpreadsheetDocumentType.Workbook))
            {
                CreateParts(package);
            }
        }

        // Adds child parts and generates content of the specified part.
        private void CreateParts(SpreadsheetDocument document)
        {

            WorkbookPart workbookPart1 = document.AddWorkbookPart();
            GenerateWorkbookPart1Content(workbookPart1);

            WorksheetPart worksheetPart1 = workbookPart1.AddNewPart<WorksheetPart>("rId1");
            GenerateWorksheetPart1Content(worksheetPart1);

            SharedStringTablePart sharedStringTablePart1 = workbookPart1.AddNewPart<SharedStringTablePart>("rId6");
            GenerateSharedStringTablePart1Content(sharedStringTablePart1);

            WorkbookStylesPart workbookStylesPart1 = workbookPart1.AddNewPart<WorkbookStylesPart>("rId5");
            GenerateWorkbookStylesPart1Content(workbookStylesPart1);

            //SetPackageProperties(document);
        }

        // Generates content of workbookPart1.
        private void GenerateWorkbookPart1Content(WorkbookPart workbookPart1)
        {
            Workbook workbook1 = new Workbook();
            workbook1.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            FileVersion fileVersion1 = new FileVersion() { ApplicationName = "xl", LastEdited = "4", LowestEdited = "4", BuildVersion = "4506" };
            WorkbookProperties workbookProperties1 = new WorkbookProperties() { FilterPrivacy = true, DefaultThemeVersion = (UInt32Value)124226U };

            BookViews bookViews1 = new BookViews();
            WorkbookView workbookView1 = new WorkbookView() { XWindow = 240, YWindow = 105, WindowWidth = (UInt32Value)14805U, WindowHeight = (UInt32Value)8010U };

            bookViews1.Append(workbookView1);

            Sheets sheets1 = new Sheets();
            Sheet sheet1 = new Sheet() { Name = "TestingTemplate", SheetId = (UInt32Value)1U, Id = "rId1" };
            //Sheet sheet2 = new Sheet() { Name = "Sheet2", SheetId = (UInt32Value)2U, Id = "rId2" };
            //Sheet sheet3 = new Sheet() { Name = "Sheet3", SheetId = (UInt32Value)3U, Id = "rId3" };

            sheets1.Append(sheet1);
            //sheets1.Append(sheet2);
            //sheets1.Append(sheet3);

            DefinedNames definedNames1 = new DefinedNames();
            DefinedName definedName1 = new DefinedName() { Name = "Status" };
            definedName1.Text = "Sheet1!$C$1,Sheet1!$D$1,Sheet1!$E$1";

            definedNames1.Append(definedName1);
            CalculationProperties calculationProperties1 = new CalculationProperties() { CalculationId = (UInt32Value)125725U };

            //workbook1.Append(fileVersion1);
            // workbook1.Append(workbookProperties1);
            // workbook1.Append(bookViews1);
            workbook1.Append(sheets1);
            workbook1.Append(definedNames1);
            workbook1.Append(calculationProperties1);

            workbookPart1.Workbook = workbook1;
        }

        // Generates content of worksheetPart1.
        private void GenerateWorksheetPart1Content(WorksheetPart worksheetPart3)
        {
            Worksheet worksheet3 = new Worksheet();
            worksheet3.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
            SheetDimension sheetDimension3 = new SheetDimension() { Reference = "A1:E16" };

            SheetViews sheetViews3 = new SheetViews();

            SheetView sheetView3 = new SheetView() { TabSelected = true, WorkbookViewId = (UInt32Value)0U };
            Selection selection2 = new Selection() { ActiveCell = "E2", SequenceOfReferences = new ListValue<StringValue>() { InnerText = "E2" } };

            sheetView3.Append(selection2);

            sheetViews3.Append(sheetView3);
            SheetFormatProperties sheetFormatProperties3 = new SheetFormatProperties() { DefaultRowHeight = 15D };

            Columns columns1 = new Columns();
            Column column1 = new Column() { Min = (UInt32Value)1U, Max = (UInt32Value)1U, Width = 29.140625D, CustomWidth = true };
            Column column2 = new Column() { Min = (UInt32Value)2U, Max = (UInt32Value)2U, Width = 44.7109375D, CustomWidth = true };
            Column column3 = new Column() { Min = (UInt32Value)3U, Max = (UInt32Value)3U, Width = 18.42578125D, CustomWidth = true };
            Column column4 = new Column() { Min = (UInt32Value)4U, Max = (UInt32Value)4U, Width = 18.140625D, CustomWidth = true };
            Column column5 = new Column() { Min = (UInt32Value)5U, Max = (UInt32Value)5U, Width = 17D, CustomWidth = true };

            columns1.Append(column1);
            columns1.Append(column2);
            columns1.Append(column3);
            columns1.Append(column4);
            columns1.Append(column5);

            SheetData sheetData3 = new SheetData();

            Row row4 = new Row() { RowIndex = (UInt32Value)1U, Spans = new ListValue<StringValue>() { InnerText = "1:5" } };

            Cell cell4 = new Cell() { CellReference = "A1", StyleIndex = (UInt32Value)4U, DataType = CellValues.SharedString };
            CellValue cellValue4 = new CellValue();
            cellValue4.Text = "8";

            cell4.Append(cellValue4);
            Cell cell5 = new Cell() { CellReference = "B1", StyleIndex = (UInt32Value)4U };

            //hidden cells
            Cell cellP = new Cell() { CellReference = "C1", StyleIndex = (UInt32Value)7U, DataType = CellValues.SharedString };
            CellValue cellValueP = new CellValue();
            cellValueP.Text = "17";
            cellP.Append(cellValueP);
            Cell cellF = new Cell() { CellReference = "D1", StyleIndex = (UInt32Value)8U, DataType = CellValues.SharedString };
            CellValue cellValueF = new CellValue();
            cellValueF.Text = "18";
            cellF.Append(cellValueF);
            Cell cellNC = new Cell() { CellReference = "E1", StyleIndex = (UInt32Value)7U, DataType = CellValues.SharedString };
            CellValue cellValueNC = new CellValue();
            cellValueNC.Text = "19";
            cellNC.Append(cellValueNC);

            row4.Append(cell4);
            row4.Append(cell5);

            row4.Append(cellP);
            row4.Append(cellF);
            row4.Append(cellNC);

            Row row5 = new Row() { RowIndex = (UInt32Value)2U, Spans = new ListValue<StringValue>() { InnerText = "1:5" } };
            Cell cell6 = new Cell() { CellReference = "A2", StyleIndex = (UInt32Value)4U };
            Cell cell7 = new Cell() { CellReference = "B2", StyleIndex = (UInt32Value)4U };
            Cell cell8 = new Cell() { CellReference = "E2", StyleIndex = (UInt32Value)6U };

            row5.Append(cell6);
            row5.Append(cell7);
            row5.Append(cell8);

            Row row6 = new Row() { RowIndex = (UInt32Value)3U, Spans = new ListValue<StringValue>() { InnerText = "1:5" } };

            //Cell cell9 = new Cell() { CellReference = "A3", StyleIndex = (UInt32Value)2U, DataType = CellValues.SharedString };
            //CellValue cellValue5 = new CellValue();
            //cellValue5.Text = "0";

            Cell cell9 = new Cell() { CellReference = "A3", StyleIndex = (UInt32Value)2U, DataType = CellValues.String };
            CellValue cellValue5 = new CellValue();
            cellValue5.Text = "Project Name";

            cell9.Append(cellValue5);
            Cell cell10 = new Cell() { CellReference = "B3", StyleIndex = (UInt32Value)1U };

            row6.Append(cell9);
            row6.Append(cell10);

            Row row7 = new Row() { RowIndex = (UInt32Value)4U, Spans = new ListValue<StringValue>() { InnerText = "1:5" } };

            Cell cell11 = new Cell() { CellReference = "A4", StyleIndex = (UInt32Value)2U, DataType = CellValues.SharedString };
            CellValue cellValue6 = new CellValue();
            cellValue6.Text = "1";

            cell11.Append(cellValue6);
            Cell cell12 = new Cell() { CellReference = "B4", StyleIndex = (UInt32Value)1U };

            row7.Append(cell11);
            row7.Append(cell12);

            Row row8 = new Row() { RowIndex = (UInt32Value)5U, Spans = new ListValue<StringValue>() { InnerText = "1:5" } };

            Cell cell13 = new Cell() { CellReference = "A5", StyleIndex = (UInt32Value)2U, DataType = CellValues.SharedString };
            CellValue cellValue7 = new CellValue();
            cellValue7.Text = "2";

            cell13.Append(cellValue7);
            Cell cell14 = new Cell() { CellReference = "B5", StyleIndex = (UInt32Value)1U };

            row8.Append(cell13);
            row8.Append(cell14);

            Row row9 = new Row() { RowIndex = (UInt32Value)6U, Spans = new ListValue<StringValue>() { InnerText = "1:5" } };

            Cell cell15 = new Cell() { CellReference = "A6", StyleIndex = (UInt32Value)2U, DataType = CellValues.SharedString };
            CellValue cellValue8 = new CellValue();
            cellValue8.Text = "3";

            cell15.Append(cellValue8);
            Cell cell16 = new Cell() { CellReference = "B6", StyleIndex = (UInt32Value)1U };

            row9.Append(cell15);
            row9.Append(cell16);

            Row row10 = new Row() { RowIndex = (UInt32Value)7U, Spans = new ListValue<StringValue>() { InnerText = "1:5" } };

            Cell cell17 = new Cell() { CellReference = "A7", StyleIndex = (UInt32Value)2U, DataType = CellValues.SharedString };
            CellValue cellValue9 = new CellValue();
            cellValue9.Text = "4";

            cell17.Append(cellValue9);
            Cell cell18 = new Cell() { CellReference = "B7", StyleIndex = (UInt32Value)1U };

            row10.Append(cell17);
            row10.Append(cell18);

            Row row11 = new Row() { RowIndex = (UInt32Value)8U, Spans = new ListValue<StringValue>() { InnerText = "1:5" } };

            Cell cell19 = new Cell() { CellReference = "A8", StyleIndex = (UInt32Value)2U, DataType = CellValues.SharedString };
            CellValue cellValue10 = new CellValue();
            cellValue10.Text = "5";

            cell19.Append(cellValue10);
            Cell cell20 = new Cell() { CellReference = "B8", StyleIndex = (UInt32Value)1U };

            row11.Append(cell19);
            row11.Append(cell20);

            Row row12 = new Row() { RowIndex = (UInt32Value)9U, Spans = new ListValue<StringValue>() { InnerText = "1:5" } };

            Cell cell21 = new Cell() { CellReference = "A9", StyleIndex = (UInt32Value)3U, DataType = CellValues.SharedString };
            CellValue cellValue11 = new CellValue();
            cellValue11.Text = "6";

            cell21.Append(cellValue11);

            row12.Append(cell21);

            Row row13 = new Row() { RowIndex = (UInt32Value)10U, Spans = new ListValue<StringValue>() { InnerText = "1:5" } };

            Cell cell22 = new Cell() { CellReference = "A10", StyleIndex = (UInt32Value)3U, DataType = CellValues.SharedString };
            CellValue cellValue12 = new CellValue();
            cellValue12.Text = "7";

            cell22.Append(cellValue12);

            row13.Append(cell22);

            Row row14 = new Row() { RowIndex = (UInt32Value)11U, Spans = new ListValue<StringValue>() { InnerText = "1:5" } };

            Cell cell23 = new Cell() { CellReference = "A11", StyleIndex = (UInt32Value)5U, DataType = CellValues.SharedString };
            CellValue cellValue13 = new CellValue();
            cellValue13.Text = "13";

            cell23.Append(cellValue13);

            Cell cell24 = new Cell() { CellReference = "B11", StyleIndex = (UInt32Value)5U, DataType = CellValues.SharedString };
            CellValue cellValue14 = new CellValue();
            cellValue14.Text = "12";

            cell24.Append(cellValue14);

            Cell cell25 = new Cell() { CellReference = "C11", StyleIndex = (UInt32Value)5U, DataType = CellValues.SharedString };
            CellValue cellValue15 = new CellValue();
            cellValue15.Text = "9";

            cell25.Append(cellValue15);

            Cell cell26 = new Cell() { CellReference = "D11", StyleIndex = (UInt32Value)5U, DataType = CellValues.SharedString };
            CellValue cellValue16 = new CellValue();
            cellValue16.Text = "10";

            cell26.Append(cellValue16);

            Cell cell27 = new Cell() { CellReference = "E11", StyleIndex = (UInt32Value)5U, DataType = CellValues.SharedString };
            CellValue cellValue17 = new CellValue();
            cellValue17.Text = "11";

            cell27.Append(cellValue17);

            row14.Append(cell23);
            row14.Append(cell24);
            row14.Append(cell25);
            row14.Append(cell26);
            row14.Append(cell27);

            Row row15 = new Row() { RowIndex = (UInt32Value)12U, Spans = new ListValue<StringValue>() { InnerText = "1:5" } };

            Cell cell28 = new Cell() { CellReference = "A12" };
            CellValue cellValue18 = new CellValue();
            cellValue18.Text = "1";

            cell28.Append(cellValue18);

            Cell cell29 = new Cell() { CellReference = "B12", DataType = CellValues.SharedString };
            CellValue cellValue19 = new CellValue();
            cellValue19.Text = "14";

            cell29.Append(cellValue19);

            Cell cell30 = new Cell() { CellReference = "C12", DataType = CellValues.SharedString };
            CellValue cellValue20 = new CellValue();
            cellValue20.Text = "15";

            cell30.Append(cellValue20);

            Cell cell31 = new Cell() { CellReference = "D12", DataType = CellValues.SharedString };
            CellValue cellValue21 = new CellValue();
            cellValue21.Text = "16";

            cell31.Append(cellValue21);
            //unlock cell
            Cell cell32 = new Cell() { CellReference = "E12", StyleIndex = (UInt32Value)10U, DataType = CellValues.SharedString };
            CellValue cellValue22 = new CellValue();
            cellValue22.Text = "17";

            cell32.Append(cellValue22);

            row15.Append(cell28);
            row15.Append(cell29);
            row15.Append(cell30);
            row15.Append(cell31);
            row15.Append(cell32);

            Row row16 = new Row() { RowIndex = (UInt32Value)13U, Spans = new ListValue<StringValue>() { InnerText = "1:5" } };

            Cell cell33 = new Cell() { CellReference = "A13" };
            CellValue cellValue23 = new CellValue();
            cellValue23.Text = "2";

            cell33.Append(cellValue23);

            Cell cell34 = new Cell() { CellReference = "B13", DataType = CellValues.SharedString };
            CellValue cellValue24 = new CellValue();
            cellValue24.Text = "20";

            cell34.Append(cellValue24);

            Cell cell35 = new Cell() { CellReference = "C13", DataType = CellValues.SharedString };
            CellValue cellValue25 = new CellValue();
            cellValue25.Text = "21";

            cell35.Append(cellValue25);

            Cell cell36 = new Cell() { CellReference = "D13", DataType = CellValues.SharedString };
            CellValue cellValue26 = new CellValue();
            cellValue26.Text = "22";

            cell36.Append(cellValue26);

            Cell cell37 = new Cell() { CellReference = "E13", StyleIndex = (UInt32Value)10U, DataType = CellValues.SharedString };
            CellValue cellValue27 = new CellValue();
            cellValue27.Text = "19";

            cell37.Append(cellValue27);

            row16.Append(cell33);
            row16.Append(cell34);
            row16.Append(cell35);
            row16.Append(cell36);
            row16.Append(cell37);

            Row row17 = new Row() { RowIndex = (UInt32Value)15U, Spans = new ListValue<StringValue>() { InnerText = "1:5" } };

            Cell cell38 = new Cell() { CellReference = "A15", StyleIndex = (UInt32Value)5U, DataType = CellValues.SharedString };
            CellValue cellValue28 = new CellValue();
            cellValue28.Text = "13";

            cell38.Append(cellValue28);

            Cell cell39 = new Cell() { CellReference = "B15", StyleIndex = (UInt32Value)5U, DataType = CellValues.SharedString };
            CellValue cellValue29 = new CellValue();
            cellValue29.Text = "12";

            cell39.Append(cellValue29);

            Cell cell40 = new Cell() { CellReference = "C15", StyleIndex = (UInt32Value)5U, DataType = CellValues.SharedString };
            CellValue cellValue30 = new CellValue();
            cellValue30.Text = "9";

            cell40.Append(cellValue30);

            Cell cell41 = new Cell() { CellReference = "D15", StyleIndex = (UInt32Value)5U, DataType = CellValues.SharedString };
            CellValue cellValue31 = new CellValue();
            cellValue31.Text = "10";

            cell41.Append(cellValue31);

            Cell cell42 = new Cell() { CellReference = "E15", StyleIndex = (UInt32Value)5U, DataType = CellValues.SharedString };
            CellValue cellValue32 = new CellValue();
            cellValue32.Text = "11";

            cell42.Append(cellValue32);

            row17.Append(cell38);
            row17.Append(cell39);
            row17.Append(cell40);
            row17.Append(cell41);
            row17.Append(cell42);

            Row row18 = new Row() { RowIndex = (UInt32Value)16U, Spans = new ListValue<StringValue>() { InnerText = "1:5" } };

            Cell cell43 = new Cell() { CellReference = "A16" };
            CellValue cellValue33 = new CellValue();
            cellValue33.Text = "1";

            cell43.Append(cellValue33);

            Cell cell44 = new Cell() { CellReference = "B16", DataType = CellValues.SharedString };
            CellValue cellValue34 = new CellValue();
            cellValue34.Text = "23";

            cell44.Append(cellValue34);

            Cell cell45 = new Cell() { CellReference = "C16", DataType = CellValues.SharedString };
            CellValue cellValue35 = new CellValue();
            cellValue35.Text = "24";

            cell45.Append(cellValue35);

            Cell cell46 = new Cell() { CellReference = "D16", DataType = CellValues.SharedString };
            CellValue cellValue36 = new CellValue();
            cellValue36.Text = "25";

            cell46.Append(cellValue36);

            Cell cell47 = new Cell() { CellReference = "E16", StyleIndex = (UInt32Value)10U, DataType = CellValues.SharedString };
            CellValue cellValue37 = new CellValue();
            cellValue37.Text = "18";

            cell47.Append(cellValue37);

            row18.Append(cell43);
            row18.Append(cell44);
            row18.Append(cell45);
            row18.Append(cell46);
            row18.Append(cell47);

            //percentage cell example
            //Cell cell34 = new Cell() { CellReference = "F12", StyleIndex = (UInt32Value)9U };
            //CellValue cellValue24 = new CellValue();
            //cellValue24.Text = "0.2";

            //cell34.Append(cellValue24);

            //row12.Append(cell29);


            sheetData3.Append(row4);
            sheetData3.Append(row5);
            sheetData3.Append(row6);
            sheetData3.Append(row7);
            sheetData3.Append(row8);
            sheetData3.Append(row9);
            sheetData3.Append(row10);
            sheetData3.Append(row11);
            sheetData3.Append(row12);
            sheetData3.Append(row13);
            sheetData3.Append(row14);
            sheetData3.Append(row15);
            sheetData3.Append(row16);
            sheetData3.Append(row17);
            sheetData3.Append(row18);

            //protect sheet review tab and set password 12345
            SheetProtection sheetProtection1 = new SheetProtection() { Password = "CA9C", Sheet = true, Objects = true, Scenarios = true };

            DataValidations dataValidations1 = new DataValidations() { Count = (UInt32Value)1U };

            DataValidation dataValidation1 = new DataValidation() { Type = DataValidationValues.List, AllowBlank = true, ShowInputMessage = true, ShowErrorMessage = true, SequenceOfReferences = new ListValue<StringValue>() { InnerText = "E12:E13 E16" } };
            Formula1 formula11 = new Formula1();
            formula11.Text = "TestingTemplate!$C$1:$E$1";

            dataValidation1.Append(formula11);

            dataValidations1.Append(dataValidation1);
            PageMargins pageMargins3 = new PageMargins() { Left = 0.7D, Right = 0.7D, Top = 0.75D, Bottom = 0.75D, Header = 0.3D, Footer = 0.3D };
            PageSetup pageSetup1 = new PageSetup() { PaperSize = (UInt32Value)9U, Orientation = OrientationValues.Portrait, VerticalDpi = (UInt32Value)0U, Id = "rId1" };

            worksheet3.Append(sheetDimension3);
            worksheet3.Append(sheetViews3);
            worksheet3.Append(sheetFormatProperties3);
            worksheet3.Append(columns1);
            worksheet3.Append(sheetData3);
            worksheet3.Append(sheetProtection1);
            worksheet3.Append(dataValidations1);
            worksheet3.Append(pageMargins3);
            worksheet3.Append(pageSetup1);

            worksheetPart3.Worksheet = worksheet3;
        }

        // Generates content of sharedStringTablePart1.
        private void GenerateSharedStringTablePart1Content(SharedStringTablePart sharedStringTablePart1)
        {
            SharedStringTable sharedStringTable1 = new SharedStringTable() { Count = (UInt32Value)34U, UniqueCount = (UInt32Value)26U };

            SharedStringItem sharedStringItem1 = new SharedStringItem();
            Text text1 = new Text();
            text1.Text = "ProjectName";

            sharedStringItem1.Append(text1);

            SharedStringItem sharedStringItem2 = new SharedStringItem();
            Text text2 = new Text();
            text2.Text = "VersionName";

            sharedStringItem2.Append(text2);

            SharedStringItem sharedStringItem3 = new SharedStringItem();
            Text text3 = new Text();
            text3.Text = "TestPassName";

            sharedStringItem3.Append(text3);

            SharedStringItem sharedStringItem4 = new SharedStringItem();
            Text text4 = new Text();
            text4.Text = "ManagerName";

            sharedStringItem4.Append(text4);

            SharedStringItem sharedStringItem5 = new SharedStringItem();
            Text text5 = new Text();
            text5.Text = "Tester";

            sharedStringItem5.Append(text5);

            SharedStringItem sharedStringItem6 = new SharedStringItem();
            Text text6 = new Text();
            text6.Text = "Role";

            sharedStringItem6.Append(text6);

            SharedStringItem sharedStringItem7 = new SharedStringItem();
            Text text7 = new Text();
            text7.Text = "TestCaseName";

            sharedStringItem7.Append(text7);

            SharedStringItem sharedStringItem8 = new SharedStringItem();
            Text text8 = new Text();
            text8.Text = "ETT";

            sharedStringItem8.Append(text8);

            SharedStringItem sharedStringItem9 = new SharedStringItem();
            Text text9 = new Text();
            text9.Text = "Note";

            sharedStringItem9.Append(text9);

            SharedStringItem sharedStringItem10 = new SharedStringItem();
            Text text10 = new Text();
            text10.Text = "Expected Result";

            sharedStringItem10.Append(text10);

            SharedStringItem sharedStringItem11 = new SharedStringItem();
            Text text11 = new Text();
            text11.Text = "Actual Result";

            sharedStringItem11.Append(text11);

            SharedStringItem sharedStringItem12 = new SharedStringItem();
            Text text12 = new Text();
            text12.Text = "Status";

            sharedStringItem12.Append(text12);

            SharedStringItem sharedStringItem13 = new SharedStringItem();
            Text text13 = new Text();
            text13.Text = "TestActionName";

            sharedStringItem13.Append(text13);

            SharedStringItem sharedStringItem14 = new SharedStringItem();
            Text text14 = new Text();
            text14.Text = "Sequence";

            sharedStringItem14.Append(text14);

            SharedStringItem sharedStringItem15 = new SharedStringItem();
            Text text15 = new Text();
            text15.Text = "TS1";

            sharedStringItem15.Append(text15);

            SharedStringItem sharedStringItem16 = new SharedStringItem();
            Text text16 = new Text();
            text16.Text = "EP";

            sharedStringItem16.Append(text16);

            SharedStringItem sharedStringItem17 = new SharedStringItem();
            Text text17 = new Text();
            text17.Text = "AR";

            sharedStringItem17.Append(text17);

            SharedStringItem sharedStringItem18 = new SharedStringItem();
            Text text18 = new Text();
            text18.Text = "Pass";

            sharedStringItem18.Append(text18);

            SharedStringItem sharedStringItem19 = new SharedStringItem();
            Text text19 = new Text();
            text19.Text = "Fail";

            sharedStringItem19.Append(text19);

            SharedStringItem sharedStringItem20 = new SharedStringItem();
            Text text20 = new Text();
            text20.Text = "NotCompleted";

            sharedStringItem20.Append(text20);

            SharedStringItem sharedStringItem21 = new SharedStringItem();
            Text text21 = new Text();
            text21.Text = "TS2";

            sharedStringItem21.Append(text21);

            SharedStringItem sharedStringItem22 = new SharedStringItem();
            Text text22 = new Text();
            text22.Text = "EP1";

            sharedStringItem22.Append(text22);

            SharedStringItem sharedStringItem23 = new SharedStringItem();
            Text text23 = new Text();
            text23.Text = "AR1";

            sharedStringItem23.Append(text23);

            SharedStringItem sharedStringItem24 = new SharedStringItem();
            Text text24 = new Text();
            text24.Text = "TS";

            sharedStringItem24.Append(text24);

            SharedStringItem sharedStringItem25 = new SharedStringItem();
            Text text25 = new Text();
            text25.Text = "EPP";

            sharedStringItem25.Append(text25);

            SharedStringItem sharedStringItem26 = new SharedStringItem();
            Text text26 = new Text();
            text26.Text = "ARR";

            sharedStringItem26.Append(text26);

            sharedStringTable1.Append(sharedStringItem1);
            sharedStringTable1.Append(sharedStringItem2);
            sharedStringTable1.Append(sharedStringItem3);
            sharedStringTable1.Append(sharedStringItem4);
            sharedStringTable1.Append(sharedStringItem5);
            sharedStringTable1.Append(sharedStringItem6);
            sharedStringTable1.Append(sharedStringItem7);
            sharedStringTable1.Append(sharedStringItem8);
            sharedStringTable1.Append(sharedStringItem9);
            sharedStringTable1.Append(sharedStringItem10);
            sharedStringTable1.Append(sharedStringItem11);
            sharedStringTable1.Append(sharedStringItem12);
            sharedStringTable1.Append(sharedStringItem13);
            sharedStringTable1.Append(sharedStringItem14);
            sharedStringTable1.Append(sharedStringItem15);
            sharedStringTable1.Append(sharedStringItem16);
            sharedStringTable1.Append(sharedStringItem17);
            sharedStringTable1.Append(sharedStringItem18);
            sharedStringTable1.Append(sharedStringItem19);
            sharedStringTable1.Append(sharedStringItem20);
            sharedStringTable1.Append(sharedStringItem21);
            sharedStringTable1.Append(sharedStringItem22);
            sharedStringTable1.Append(sharedStringItem23);
            sharedStringTable1.Append(sharedStringItem24);
            sharedStringTable1.Append(sharedStringItem25);
            sharedStringTable1.Append(sharedStringItem26);

            sharedStringTablePart1.SharedStringTable = sharedStringTable1;
        }

        // Generates content of workbookStylesPart1.
        private void GenerateWorkbookStylesPart1Content(WorkbookStylesPart workbookStylesPart1)
        {
            Stylesheet stylesheet1 = new Stylesheet();
            //for hidden cell custom cell format as ';;;'
            NumberingFormats numberingFormats1 = new NumberingFormats() { Count = (UInt32Value)1U };
            NumberingFormat numberingFormat1 = new NumberingFormat() { NumberFormatId = (UInt32Value)164U, FormatCode = ";;;" };
            numberingFormats1.Append(numberingFormat1);

            Fonts fonts1 = new Fonts() { Count = (UInt32Value)2U };

            Font font1 = new Font();
            FontSize fontSize1 = new FontSize() { Val = 11D };
            Color color1 = new Color() { Theme = (UInt32Value)1U };
            FontName fontName1 = new FontName() { Val = "Calibri" };
            FontFamilyNumbering fontFamilyNumbering1 = new FontFamilyNumbering() { Val = 2 };
            FontScheme fontScheme1 = new FontScheme() { Val = FontSchemeValues.Minor };

            font1.Append(fontSize1);
            font1.Append(color1);
            font1.Append(fontName1);
            font1.Append(fontFamilyNumbering1);
            font1.Append(fontScheme1);

            Font font2 = new Font();
            Bold bold1 = new Bold();
            FontSize fontSize2 = new FontSize() { Val = 11D };
            Color color2 = new Color() { Theme = (UInt32Value)1U };
            FontName fontName2 = new FontName() { Val = "Calibri" };
            FontFamilyNumbering fontFamilyNumbering2 = new FontFamilyNumbering() { Val = 2 };
            FontScheme fontScheme2 = new FontScheme() { Val = FontSchemeValues.Minor };

            font2.Append(bold1);
            font2.Append(fontSize2);
            font2.Append(color2);
            font2.Append(fontName2);
            font2.Append(fontFamilyNumbering2);
            font2.Append(fontScheme2);

            fonts1.Append(font1);
            fonts1.Append(font2);

            Fills fills1 = new Fills() { Count = (UInt32Value)5U };

            Fill fill1 = new Fill();
            PatternFill patternFill1 = new PatternFill() { PatternType = PatternValues.None };

            fill1.Append(patternFill1);

            Fill fill2 = new Fill();
            PatternFill patternFill2 = new PatternFill() { PatternType = PatternValues.Gray125 };

            fill2.Append(patternFill2);

            Fill fill3 = new Fill();

            PatternFill patternFill3 = new PatternFill() { PatternType = PatternValues.Solid };
            ForegroundColor foregroundColor1 = new ForegroundColor() { Rgb = "FFFFFF00" };
            BackgroundColor backgroundColor1 = new BackgroundColor() { Indexed = (UInt32Value)64U };

            patternFill3.Append(foregroundColor1);
            patternFill3.Append(backgroundColor1);

            fill3.Append(patternFill3);

            Fill fill4 = new Fill();

            PatternFill patternFill4 = new PatternFill() { PatternType = PatternValues.Solid };
            ForegroundColor foregroundColor2 = new ForegroundColor() { Theme = (UInt32Value)0U, Tint = -0.249977111117893D };
            BackgroundColor backgroundColor2 = new BackgroundColor() { Indexed = (UInt32Value)64U };

            patternFill4.Append(foregroundColor2);
            patternFill4.Append(backgroundColor2);

            fill4.Append(patternFill4);

            Fill fill5 = new Fill();

            PatternFill patternFill5 = new PatternFill() { PatternType = PatternValues.Solid };
            ForegroundColor foregroundColor3 = new ForegroundColor() { Theme = (UInt32Value)9U, Tint = -0.249977111117893D };
            BackgroundColor backgroundColor3 = new BackgroundColor() { Indexed = (UInt32Value)64U };

            patternFill5.Append(foregroundColor3);
            patternFill5.Append(backgroundColor3);

            fill5.Append(patternFill5);

            fills1.Append(fill1);
            fills1.Append(fill2);
            fills1.Append(fill3);
            fills1.Append(fill4);
            fills1.Append(fill5);

            Borders borders1 = new Borders() { Count = (UInt32Value)1U };

            Border border1 = new Border();
            LeftBorder leftBorder1 = new LeftBorder();
            RightBorder rightBorder1 = new RightBorder();
            TopBorder topBorder1 = new TopBorder();
            BottomBorder bottomBorder1 = new BottomBorder();
            DiagonalBorder diagonalBorder1 = new DiagonalBorder();

            border1.Append(leftBorder1);
            border1.Append(rightBorder1);
            border1.Append(topBorder1);
            border1.Append(bottomBorder1);
            border1.Append(diagonalBorder1);

            borders1.Append(border1);

            CellStyleFormats cellStyleFormats1 = new CellStyleFormats() { Count = (UInt32Value)1U };
            CellFormat cellFormat1 = new CellFormat() { NumberFormatId = (UInt32Value)0U, FontId = (UInt32Value)0U, FillId = (UInt32Value)0U, BorderId = (UInt32Value)0U };

            cellStyleFormats1.Append(cellFormat1);

            CellFormats cellFormats1 = new CellFormats() { Count = (UInt32Value)11U };
            CellFormat cellFormat2 = new CellFormat() { NumberFormatId = (UInt32Value)0U, FontId = (UInt32Value)0U, FillId = (UInt32Value)0U, BorderId = (UInt32Value)0U, FormatId = (UInt32Value)0U };
            CellFormat cellFormat3 = new CellFormat() { NumberFormatId = (UInt32Value)0U, FontId = (UInt32Value)0U, FillId = (UInt32Value)2U, BorderId = (UInt32Value)0U, FormatId = (UInt32Value)0U, ApplyFill = true };
            CellFormat cellFormat4 = new CellFormat() { NumberFormatId = (UInt32Value)0U, FontId = (UInt32Value)1U, FillId = (UInt32Value)2U, BorderId = (UInt32Value)0U, FormatId = (UInt32Value)0U, ApplyFont = true, ApplyFill = true };
            CellFormat cellFormat5 = new CellFormat() { NumberFormatId = (UInt32Value)0U, FontId = (UInt32Value)1U, FillId = (UInt32Value)0U, BorderId = (UInt32Value)0U, FormatId = (UInt32Value)0U, ApplyFont = true, ApplyFill = true };
            CellFormat cellFormat6 = new CellFormat() { NumberFormatId = (UInt32Value)0U, FontId = (UInt32Value)1U, FillId = (UInt32Value)3U, BorderId = (UInt32Value)0U, FormatId = (UInt32Value)0U, ApplyFont = true, ApplyFill = true };
            CellFormat cellFormat7 = new CellFormat() { NumberFormatId = (UInt32Value)0U, FontId = (UInt32Value)1U, FillId = (UInt32Value)4U, BorderId = (UInt32Value)0U, FormatId = (UInt32Value)0U, ApplyFont = true, ApplyFill = true };

            //hidden cell style
            CellFormat cellFormat8 = new CellFormat() { NumberFormatId = (UInt32Value)0U, FontId = (UInt32Value)0U, FillId = (UInt32Value)0U, BorderId = (UInt32Value)0U, FormatId = (UInt32Value)0U, ApplyProtection = true };
            Protection protection1 = new Protection() { Hidden = true };

            cellFormat8.Append(protection1);

            CellFormat cellFormat9 = new CellFormat() { NumberFormatId = (UInt32Value)164U, FontId = (UInt32Value)0U, FillId = (UInt32Value)0U, BorderId = (UInt32Value)0U, FormatId = (UInt32Value)0U, ApplyNumberFormat = true };
            //percentage cell style
            CellFormat cellFormat10 = new CellFormat() { NumberFormatId = (UInt32Value)164U, FontId = (UInt32Value)0U, FillId = (UInt32Value)0U, BorderId = (UInt32Value)0U, FormatId = (UInt32Value)0U, ApplyNumberFormat = true, ApplyProtection = true };
            CellFormat cellFormat11 = new CellFormat() { NumberFormatId = (UInt32Value)9U, FontId = (UInt32Value)0U, FillId = (UInt32Value)0U, BorderId = (UInt32Value)0U, FormatId = (UInt32Value)0U, ApplyNumberFormat = true };

            //unlocked cell style
            CellFormat cellFormat12 = new CellFormat() { NumberFormatId = (UInt32Value)0U, FontId = (UInt32Value)0U, FillId = (UInt32Value)0U, BorderId = (UInt32Value)0U, FormatId = (UInt32Value)0U, ApplyProtection = true };
            Protection protection2 = new Protection() { Locked = false };
            cellFormat12.Append(protection2);

            cellFormats1.Append(cellFormat2);
            cellFormats1.Append(cellFormat3);
            cellFormats1.Append(cellFormat4);
            cellFormats1.Append(cellFormat5);
            cellFormats1.Append(cellFormat6);
            cellFormats1.Append(cellFormat7);
            cellFormats1.Append(cellFormat8);
            cellFormats1.Append(cellFormat9);
            cellFormats1.Append(cellFormat10);
            cellFormats1.Append(cellFormat11);
            cellFormats1.Append(cellFormat12);

            CellStyles cellStyles1 = new CellStyles() { Count = (UInt32Value)1U };
            CellStyle cellStyle1 = new CellStyle() { Name = "Normal", FormatId = (UInt32Value)0U, BuiltinId = (UInt32Value)0U };

            cellStyles1.Append(cellStyle1);
            DifferentialFormats differentialFormats1 = new DifferentialFormats() { Count = (UInt32Value)0U };
            TableStyles tableStyles1 = new TableStyles() { Count = (UInt32Value)0U, DefaultTableStyle = "TableStyleMedium9", DefaultPivotStyle = "PivotStyleLight16" };

            Colors colors1 = new Colors();

            MruColors mruColors1 = new MruColors();
            Color color3 = new Color() { Rgb = "FFFFFF00" };

            mruColors1.Append(color3);

            colors1.Append(mruColors1);

            stylesheet1.Append(numberingFormats1);
            stylesheet1.Append(fonts1);
            stylesheet1.Append(fills1);
            stylesheet1.Append(borders1);
            stylesheet1.Append(cellStyleFormats1);
            stylesheet1.Append(cellFormats1);
            stylesheet1.Append(cellStyles1);
            stylesheet1.Append(differentialFormats1);
            stylesheet1.Append(tableStyles1);
            stylesheet1.Append(colors1);

            workbookStylesPart1.Stylesheet = stylesheet1;
        }


       


    }
}