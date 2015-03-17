using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Collections;
using System.Diagnostics;
using System.IO;
using KCZYLIMS.Models;
using XMain.Code;

using S = DocumentFormat.OpenXml.Spreadsheet.Sheets;
using E = DocumentFormat.OpenXml.OpenXmlElement;
using A = DocumentFormat.OpenXml.OpenXmlAttribute;

namespace KCZYLIMS.BLL.Utility
{
    public class OpenXmlHelper
    {
        public static string STR_DEBUG_INFO = string.Empty;

        public static string[] LogBookDataField = {"LogBook:LogID","LogBook:UserID","LogBook:RelatedID","LogBook:RelatedType",
                                        "LogBook:ProjID","LogBook:ProjOrigID","LogBook:StartDayTime",
                                        "LogBook:EndDayTime","LogBook:workhour","LogBook:address","LogBook:workclass",
                                        "LogBook:MyNotes","LogBook:week","LogBook:CreateBy","LogBook:CreateDate",
                                        "LogBook:CreatorID","LogBook:ModifiedBy","LogBook:LastModified","LogBook:ModifierID","LogBook:ItemName","LogBook:UserName",
                                                  "LogBook:FlowID","LogBook:FlowName","LogBook:ProjID","LogBook:ProjName","LogBook:addressType","LogBook:IsReWork"};


        public static Dictionary<string, string> GetCustomProperties(SpreadsheetDocument mySpreadsheet)
        {
            Dictionary<string, string> ans = new Dictionary<string, string>();
            CustomFilePropertiesPart fileProp = mySpreadsheet.CustomFilePropertiesPart;
            var tmp = fileProp.Properties.GetFirstChild<DocumentFormat.OpenXml.CustomProperties.Properties>();
            foreach (var node in fileProp.Properties.Descendants<OpenXmlElement>())
            {
                if (node.LocalName.Equals("property"))
                {
                    foreach (OpenXmlAttribute att in node.GetAttributes())
                    {
                        if (att.LocalName.Equals("name"))
                        {
                            ans.Add(att.Value, node.InnerText);
                            //Response.Write(att.Value + ":" + node.InnerText + "<br/>");
                        }//end if                            
                    }//end foreach
                }//end if
            }//end foreach                

            return ans;
        }//end of func

        /// <summary>
        /// 根据sheetName从excel文件中取sheet对象
        /// </summary>
        /// <param name="document"></param>
        /// <param name="sheetName"></param>
        /// <returns></returns>
        public static WorksheetPart GetWorksheetPartByName(SpreadsheetDocument document, string sheetName)
        {
            //查找sheet
            Sheet theSheet = document.WorkbookPart.Workbook.Descendants<Sheet>().
                Where(s => s.Name == sheetName).FirstOrDefault();
            if (theSheet == null)
            {
                return null;
            }
            // Retrieve a reference to the worksheet part.
            WorksheetPart wsPart =
                (WorksheetPart)(document.WorkbookPart.GetPartById(theSheet.Id));
            return wsPart;
        }//end of func








        /// <summary>
        /// 把几种类型的Insert都集成到一起
        /// </summary>
        /// <param name="_intDataType"></param>
        /// <param name="value"></param>
        /// <param name="strCol"></param>
        /// <param name="uRow"></param>
        /// <param name="strSheetName"></param>
        /// <param name="worksheetPart"></param>
        public static void CompatInsertText(int _intDataType, object value, string strCol, uint uRow, string strSheetName, WorksheetPart worksheetPart)
        {
            //Stopwatch s0 = new Stopwatch();
            //s0.Start();
            if (null == value)
                return;
            if (_intDataType == (int)CustomPropertyInfo.ExcelDataType._Number)
            {
                double dblVal = double.NaN;
                double.TryParse(value.ToString(), out dblVal);
                InsertText(strCol, uRow, dblVal, worksheetPart);
            }
            else if (_intDataType == (int)CustomPropertyInfo.ExcelDataType._String)
            {
                InsertText(strCol, uRow, value.ToString(), worksheetPart);
            }
            else
            {

            }
            //s0.Stop();
            //OpenXmlHelper.STR_DEBUG_INFO += "兼容插入:" + s0.Elapsed + "\t";
        }//end of void CompatInsertText(



        /// <summary>
        /// 插入text类型的单元格
        /// </summary>
        /// <param name="columnName"></param>
        /// <param name="rowIndex"></param>
        /// <param name="strText"></param>
        /// <param name="worksheetPart"></param>
        public static void InsertText(string columnName, uint rowIndex, string strText, WorksheetPart worksheetPart)
        {
            Cell newCell = InsertText(columnName, rowIndex, worksheetPart);
            newCell.CellValue = new CellValue(strText);
            newCell.DataType = new EnumValue<CellValues>(CellValues.String);
            //worksheetPart.Worksheet.Save();
        }//end of func

        /// <summary>
        /// 插入数值类型的单元格，double
        /// </summary>
        /// <param name="columnName"></param>
        /// <param name="rowIndex"></param>
        /// <param name="dblText"></param>
        /// <param name="worksheetPart"></param>
        public static void InsertText(string columnName, uint rowIndex, double dblText, WorksheetPart worksheetPart)
        {
            Cell newCell = InsertText(columnName, rowIndex, worksheetPart);
            newCell.CellValue = new CellValue(dblText.ToString());
            newCell.DataType = new EnumValue<CellValues>(CellValues.Number);
            //worksheetPart.Worksheet.Save();
        }//end of func

        /// <summary>
        /// 插入数值类型的单元格，int
        /// </summary>
        /// <param name="columnName"></param>
        /// <param name="rowIndex"></param>
        /// <param name="intText"></param>
        /// <param name="worksheetPart"></param>
        public static void InsertText(string columnName, uint rowIndex, int intText, WorksheetPart worksheetPart)
        {
            Cell newCell = InsertText(columnName, rowIndex, worksheetPart);
            newCell.CellValue = new CellValue(intText.ToString());
            newCell.DataType = new EnumValue<CellValues>(CellValues.Number);
            //worksheetPart.Worksheet.Save();
        }//end of func
        public static void InsertText(string columnName, uint rowIndex, string strText, WorksheetPart worksheetPart, UInt32Value styleIdx)
        {
            Cell newCell = InsertText(columnName, rowIndex, worksheetPart);
            newCell.StyleIndex = styleIdx;
            newCell.CellValue = new CellValue(strText);
            newCell.DataType = new EnumValue<CellValues>(CellValues.String);
            //worksheetPart.Worksheet.Save();
        }//end of func
        public static void CompatInsertText(int _intDataType, object value, string strCol, uint uRow, string strSheetName, WorksheetPart worksheetPart, UInt32Value styleIdx)
        {
            //Stopwatch s0 = new Stopwatch();
            //s0.Start();
            if (null == value)
                return;
            if (_intDataType == (int)CustomPropertyInfo.ExcelDataType._Number)
            {
                double dblVal = double.NaN;
                double.TryParse(value.ToString(), out dblVal);
                InsertText(strCol, uRow, dblVal, worksheetPart);
            }
            else if (_intDataType == (int)CustomPropertyInfo.ExcelDataType._String)
            {
                InsertText(strCol, uRow, value.ToString(), worksheetPart, styleIdx);
            }
            else
            {

            }
            //s0.Stop();
            //OpenXmlHelper.STR_DEBUG_INFO += "兼容插入:" + s0.Elapsed + "\t";
        }//end of void CompatInsertText(
        /// <summary>
        /// 插入数值类型的单元格，long
        /// </summary>
        /// <param name="columnName"></param>
        /// <param name="rowIndex"></param>
        /// <param name="lngText"></param>
        /// <param name="worksheetPart"></param>
        public static void InsertText(string columnName, uint rowIndex, long lngText, WorksheetPart worksheetPart)
        {
            Cell newCell = InsertText(columnName, rowIndex, worksheetPart);
            newCell.CellValue = new CellValue(lngText.ToString());
            newCell.DataType = new EnumValue<CellValues>(CellValues.Number);
            //worksheetPart.Worksheet.Save();
        }//end of func

        /// <summary>
        /// 插入时间类型的单元格,dtm
        /// </summary>
        /// <param name="columnName"></param>
        /// <param name="rowIndex"></param>
        /// <param name="dtmText"></param>
        /// <param name="worksheetPart"></param>
        public static void InsertText(string columnName, uint rowIndex, DateTime dtmText, WorksheetPart worksheetPart)
        {
            Cell newCell = InsertText(columnName, rowIndex, worksheetPart);
            newCell.CellValue = new CellValue(dtmText.ToOADate().ToString());
            newCell.DataType = new EnumValue<CellValues>(CellValues.Date);
            newCell.StyleIndex = 1;
            //worksheetPart.Worksheet.Save();
        }//end of func

        /// <summary>
        /// 根据worksheetpart和行列值，插入一个Cell。但是这个Cell还没填值
        /// 本质上就是往xml文件里打个标签
        /// </summary>
        /// <param name="columnName"></param>
        /// <param name="rowIndex"></param>
        /// <param name="worksheetPart"></param>
        /// <returns></returns>
        private static Cell InsertText(string columnName, uint rowIndex, WorksheetPart worksheetPart)
        {

            Worksheet worksheet = worksheetPart.Worksheet;
            SheetData sheetData = worksheet.GetFirstChild<SheetData>();
            string cellReference = columnName + rowIndex;
            // If the worksheet does not contain a row with the specified row index, insert one.
            Row row;
            if (sheetData.Elements<Row>().Where(r => r.RowIndex == rowIndex).Count() != 0)
            {
                row = sheetData.Elements<Row>().Where(r => r.RowIndex == rowIndex).First();
            }
            else
            {
                row = new Row() { RowIndex = rowIndex };
                sheetData.Append(row);
            }
            // If there is not a cell with the specified column name, insert one.  
            if (row.Elements<Cell>().Where(c => c.CellReference.Value == columnName + rowIndex).Count() > 0)
            {
                return row.Elements<Cell>().Where(c => c.CellReference.Value == cellReference).First();
            }
            else
            {
                // Cells must be in sequential order according to CellReference. Determine where to insert the new cell.
                Cell refCell = null;
                foreach (Cell cell in row.Elements<Cell>())
                {
                    if (string.Compare(cell.CellReference.Value, cellReference, true) > 0)
                    {
                        refCell = cell;
                        break;
                    }
                }
                Cell newCell = new Cell() { CellReference = cellReference };
                row.InsertBefore(newCell, refCell);

                //worksheet.Save();

                return newCell;
            }


        }//end of func

        /// <summary>
        /// 列++,'A'递增到'B'等类似操作
        /// </summary>
        /// <param name="strAddr"></param>
        public static void ColumnPlusPlus(string strAddr)
        {
            char[] strArr = strAddr.ToCharArray();
            int inc = 1;
            for (int i = strArr.Length - 1; i >= 0 && inc == 1; i--)
            {
                if (strArr[i] == 'Z')
                {
                    strArr[i] = 'A';
                    inc = 1;
                }
                else
                {
                    strArr[i]++;
                    inc = 0;
                }
            }//end of for
            strAddr = strArr.ToString();
        }//end of public static void ColumnPlusPlus(string strAddr)

        /// <summary>
        /// 循环调用ColumnPlusPlus
        /// </summary>
        /// <param name="strAddr"></param>
        /// <param name="intNum">表示递增几次</param>
        public static void ColumnChanges(string strAddr, int intNum)
        {
            for (int i = 0; i < intNum; i++)
            {
                ColumnPlusPlus(strAddr);
            }
        }//end of public static void ColumnPlusPlus(string strAddr)

        public static void ColumnChanges(string strAddr, uint intNum)
        {
            for (int i = 0; i < intNum; i++)
            {
                ColumnPlusPlus(strAddr);
            }
        }//end of public static void ColumnPlusPlus(string strAddr)


        /// <summary>
        /// 泛型excel导出函数
        /// </summary>
        /// <typeparam name="T">类名</typeparam>
        /// <param name="list"></param>
        /// <param name="mapping"> BatchNumber -> A   Price -> B 这种映射方式， BatchNumber是类中属性，A是excel的列名 </param>
        /// <param name="uStartRow"> excel写文件时起始行 </param>
        /// <returns></returns>
        public static string ExportExcelGenerics<T>(List<T> list, Dictionary<string, string> mapping, uint uStartRow, string strTemplateName)
        {
            string strTest = string.Empty;
            if (list.Count == 0)
                return string.Empty;
            Type type = list[0].GetType();

            PropertyInfo[] props = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            string strSrcFileName = System.Configuration.ConfigurationManager.AppSettings["PrivateFile"] + strTemplateName + ".xlsx";
            //获取当前页面的操作人
            KCZYLIMS.Models.UsersMD creator = KCZYLIMS.BLL.UsersBO.GetCurrentUser();

            string filename = System.Configuration.ConfigurationManager.AppSettings["PublicFile"] + DateTime.Now.ToString("yyyy-MM-dd") + ".xlsx";
            try
            {
                if (!File.Exists(strSrcFileName))
                {
                    return string.Empty;
                }
                else
                {
                    File.Copy(strSrcFileName, filename, true);
                }

                XData.LinqToSqlClass.XFormDataClassesDataContext dc = new XData.LinqToSqlClass.XFormDataClassesDataContext();

                //还要创建这个文件
                //OpenXmlExcel.CreateSpreadsheetWorkbook(filename);
                if (!File.Exists(filename))
                    return string.Empty;

                using (SpreadsheetDocument spreadSheet = SpreadsheetDocument.Open(filename, true))
                {
                    //设置打开时计算
                    spreadSheet.WorkbookPart.Workbook.CalculationProperties.ForceFullCalculation = true;
                    spreadSheet.WorkbookPart.Workbook.CalculationProperties.FullCalculationOnLoad = true;

                    WorksheetPart worksheetPart = OpenXmlHelper.GetWorksheetPartByName(spreadSheet, "Sheet1");

                    uint uRowIdx = uStartRow;
                    foreach (var obj in list)
                    {
                        foreach (PropertyInfo p in props)
                        {
                            if (mapping.ContainsKey(p.Name))
                            {
                                OpenXmlHelper.CompatInsertText(0, p.GetValue(obj, null), mapping[p.Name.Trim()], uRowIdx,
                                                               "Sheet1", worksheetPart);
                            }
                        }

                        uRowIdx++;
                    }//end foreach  (var obj in list)

                    worksheetPart.Worksheet.Save();
                    spreadSheet.WorkbookPart.Workbook.Save();
                }//end of using  ************************    
            }//end of try
            catch (Exception ex)
            {
                filename = string.Empty;
            }
            return DateTime.Now.ToString("yyyy-MM-dd") + ".xlsx";

        }//end of func
        public static string ProjectAttorney(kczy_ProjectAttorneyMD model)
        {
            string strSrcFileName = System.Configuration.ConfigurationManager.AppSettings["Reportlet"] + "ProjectAttorneyForYuanOutside" + ".xlsx";
            string filename = System.Configuration.ConfigurationManager.AppSettings["PublicFile"] + DateTime.Now.ToString("yyyy-MM-dd") + ".xlsx";

            try
            {
                if (!File.Exists(strSrcFileName))
                {
                    return string.Empty;
                }
                else
                {
                    File.Copy(strSrcFileName, filename, true);
                }
                if (!File.Exists(filename))
                    return string.Empty;
                using (SpreadsheetDocument spreadSheet = SpreadsheetDocument.Open(filename, true))
                {

                    //设置打开时计算
                    spreadSheet.WorkbookPart.Workbook.CalculationProperties.ForceFullCalculation = true;
                    spreadSheet.WorkbookPart.Workbook.CalculationProperties.FullCalculationOnLoad = true;
                    WorksheetPart worksheetPart = OpenXmlHelper.GetWorksheetPartByName(spreadSheet, "Sheet1");

                    uint uRowIdx = 8;
                   
                        //列名
                        
                        OpenXmlHelper.CompatInsertText(0, model.SampleDate, "B", 2, "Sheet1", worksheetPart);
                        OpenXmlHelper.CompatInsertText(0, model.Sampler, "E", 2, "Sheet1", worksheetPart);
                        OpenXmlHelper.CompatInsertText(0, model.Client, "B", 3, "Sheet1", worksheetPart);
                        OpenXmlHelper.CompatInsertText(0, model.Address, "B", 4, "Sheet1", worksheetPart);
                        OpenXmlHelper.CompatInsertText(0, model.SampleNum, "E", 4, "Sheet1", worksheetPart);
                        OpenXmlHelper.CompatInsertText(0, model.SampleName, "B", 5, "Sheet1", worksheetPart);
                        OpenXmlHelper.CompatInsertText(0,model.Email, "E", 5, "Sheet1", worksheetPart);
                        OpenXmlHelper.CompatInsertText(0, model.WorkRequirement, "B", 6, "Sheet1", worksheetPart);
                        OpenXmlHelper.CompatInsertText(0, model.Telephone, "E", 6, "Sheet1", worksheetPart);
                        var method = "";
                        switch (model.GetReportMethod)
                        {
                            case 1:
                                method = "来人取";
                                break;
                            case 2:
                                method = "电话";
                                break;
                            case 3:
                                method = "传真";
                                break;
                            case 4:
                                method = "邮寄";
                                break;
                            case 5:
                                method = "电子邮件";
                                break;
                        }
                        OpenXmlHelper.CompatInsertText(0, method, "B", 7, "Sheet1", worksheetPart);
                        //OpenXmlHelper.CompatInsertText(0, "失业保险", "L", uRowIdx, "Sheet1", worksheetPart);
                        //OpenXmlHelper.CompatInsertText(0, "医疗保险", "M", uRowIdx, "Sheet1", worksheetPart);
                        //OpenXmlHelper.CompatInsertText(0, "公积金", "N", uRowIdx, "Sheet1", worksheetPart);
                        //OpenXmlHelper.CompatInsertText(0, "房租水电", "O", uRowIdx, "Sheet1", worksheetPart);
                        //OpenXmlHelper.CompatInsertText(0, "风险金", "P", uRowIdx, "Sheet1", worksheetPart);
                        //OpenXmlHelper.CompatInsertText(0, "实发工资", "Q", uRowIdx, "Sheet1", worksheetPart);
                    KCZYExperimentAmountBO obj=new KCZYExperimentAmountBO();
                    var expAmount = obj.GetInstancesByItemID(model.ItemID);
                    if (expAmount.Count > 0)
                    {
                        for (int i = 0; i < expAmount.Count; i++)
                        {
                            ++uRowIdx;
                            OpenXmlHelper.CompatInsertText(0, expAmount[i].ExperimentName, "B", uRowIdx, "Sheet1", worksheetPart);
                            OpenXmlHelper.CompatInsertText(0, expAmount[i].ExperimentAmount, "C", uRowIdx, "Sheet1", worksheetPart);
                        }
                    }
                        uRowIdx++;
                        

                       /* OpenXmlHelper.CompatInsertText(0, obj["EmpName"].ToString(), "A", uRowIdx, "Sheet1", worksheetPart);
                        OpenXmlHelper.CompatInsertText(1, obj["BasicSalary"].ToString(), "B", uRowIdx, "Sheet1", worksheetPart);
                        OpenXmlHelper.CompatInsertText(1, obj["SenioritySalary"].ToString(), "C", uRowIdx, "Sheet1", worksheetPart);
                        OpenXmlHelper.CompatInsertText(1, obj["OvertimeSalary"].ToString(), "D", uRowIdx, "Sheet1", worksheetPart);
                        OpenXmlHelper.CompatInsertText(1, obj["PerformanceSalary"].ToString(), "E", uRowIdx, "Sheet1", worksheetPart);
                        OpenXmlHelper.CompatInsertText(1, obj["JobAllowances"].ToString(), "F", uRowIdx, "Sheet1", worksheetPart);
                        OpenXmlHelper.CompatInsertText(1, obj["OtherSubsides"].ToString(), "G", uRowIdx, "Sheet1", worksheetPart);
                        OpenXmlHelper.CompatInsertText(1, obj["ShouldSalary"].ToString(), "H", uRowIdx, "Sheet1", worksheetPart);
                        OpenXmlHelper.CompatInsertText(1, obj["HousingSubsides"].ToString(), "I", uRowIdx, "Sheet1", worksheetPart);
                        OpenXmlHelper.CompatInsertText(1, obj["Tax"].ToString(), "J", uRowIdx, "Sheet1", worksheetPart);
                        OpenXmlHelper.CompatInsertText(1, obj["PensionInsurance"].ToString(), "K", uRowIdx, "Sheet1", worksheetPart);
                        OpenXmlHelper.CompatInsertText(1, obj["UnempInsurance"].ToString(), "L", uRowIdx, "Sheet1", worksheetPart);
                        OpenXmlHelper.CompatInsertText(1, obj["MedicalInsurance"].ToString(), "M", uRowIdx, "Sheet1", worksheetPart);
                        OpenXmlHelper.CompatInsertText(1, obj["HousingFund"].ToString(), "N", uRowIdx, "Sheet1", worksheetPart);
                        OpenXmlHelper.CompatInsertText(1, obj["OtherFees"].ToString(), "O", uRowIdx, "Sheet1", worksheetPart);
                        OpenXmlHelper.CompatInsertText(1, obj["RiskPayment"].ToString(), "P", uRowIdx, "Sheet1", worksheetPart);
                        OpenXmlHelper.CompatInsertText(1, obj["RealSalary"].ToString(), "Q", uRowIdx, "Sheet1", worksheetPart);*/

                    

                    worksheetPart.Worksheet.Save();
                    spreadSheet.WorkbookPart.Workbook.Save();
                }//end of using  ************************    
            }//end of try

            catch (Exception ex)
            {
                filename = string.Empty;
            }
            return filename;
        }//end of func

    }//end of class
}