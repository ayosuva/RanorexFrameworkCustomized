/*
 * Created by Ranorex
 * User: Yosuva.Arulanthu
 * Date: 03/11/2022
 * 
 * To change this template use Tools > Options > Coding > Edit standard headers.
 */
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using System;
using System.Drawing;
using System.IO;

namespace Framework
{
  public class ExcelDataAccess
  {
    private string _filePath;
    private string _fileName;

    public string DatasheetName { get; set; }

    public ExcelDataAccess(string filePath, string fileName)
    {
      this._filePath = filePath;
      this._fileName = fileName;
    }

    private void CheckPreRequisites()
    {
      if (this.DatasheetName == null)
        throw new FrameworkException("ExcelDataAccess.datasheetName is not set!");
    }

    private XSSFWorkbook OpenFileForReading()
    {
      string path = this._filePath + Framework.Util.GetFileSeparator() + this._fileName + ".xlsx";
      FileStream s;
      try
      {
        s = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read);
      }
      catch (FileNotFoundException ex)
      {
        Console.WriteLine(ex.StackTrace);
        throw new FrameworkException("The specified file \"" + path + "\" does not exist!");
      }
      XSSFWorkbook xssfWorkbook;
      try
      {
        xssfWorkbook = new XSSFWorkbook((Stream) s);
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.StackTrace);
        throw new FrameworkException("Error while opening the specified Excel workbook \"" + path + "\"");
      }
      return xssfWorkbook;
    }

    private void WriteIntoFile(XSSFWorkbook workbook)
    {
      string path = this._filePath + Framework.Util.GetFileSeparator() + this._fileName + ".xlsx";
      FileStream out1;
      try
      {
        out1 = new FileStream(path, FileMode.Create, FileAccess.Write,FileShare.ReadWrite);
      }
      catch (FileNotFoundException ex)
      {
        Console.WriteLine(ex.StackTrace);
        throw new FrameworkException("The specified file \"" + path + "\" does not exist!");
      }
      try
      {
        workbook.Write((Stream) out1);
        out1.Close();
      }
      catch (IOException ex)
      {
        Console.WriteLine(ex.StackTrace);
        throw new FrameworkException("Error while writing into the specified Excel workbook \"" + path + "\"");
      }
    }

    private XSSFSheet GetWorkSheet(XSSFWorkbook workbook) { 
    	try{
    		return (XSSFSheet) workbook.GetSheet(this.DatasheetName);
    	}
    	catch(IOException ex)
    	{
        	Console.WriteLine(ex.StackTrace);
    		throw new FrameworkException("The specified sheet \"" + this.DatasheetName + "\" does not exist within the workbook \"" + this._fileName + ".xlsx\"");
    	}
    }

    public int GetRowNum(string key, int columnNum, int startRowNum)
    {
      this.CheckPreRequisites();
      XSSFWorkbook workbook = this.OpenFileForReading();
      XSSFSheet workSheet = this.GetWorkSheet(workbook);
      XSSFFormulaEvaluator formulaEvaluator =new XSSFFormulaEvaluator(workbook);
      for (int rowIndex = startRowNum; rowIndex <= workSheet.LastRowNum; ++rowIndex)
      {
        if (this.GetCellValueAsString((XSSFCell) ((XSSFRow) workSheet.GetRow(rowIndex)).GetCell(columnNum), formulaEvaluator).Equals(key))
          return rowIndex;
      }
      return -1;
    }

    private string GetCellValueAsString(XSSFCell cell, XSSFFormulaEvaluator formulaEvaluator)
    {
      if (cell == null || cell.CellType == CellType.Blank)
        return "";
      if (formulaEvaluator.Evaluate((XSSFCell) cell).CellType == CellType.Error)
        throw new FrameworkException("Error in formula within this cell! Error code: " + cell.StringCellValue);
      return new DataFormatter().FormatCellValue(formulaEvaluator.EvaluateInCell((XSSFCell) cell));
    }

    public int GetRowNum(string key, int columnNum) { return this.GetRowNum(key, columnNum, 0);}

    public int GetLastRowNum()
    {
      this.CheckPreRequisites();
      return this.GetWorkSheet(this.OpenFileForReading()).LastRowNum;
    }

    public int GetRowCount(string key, int columnNum, int startRowNum)
    {
      this.CheckPreRequisites();
      XSSFWorkbook workbook = this.OpenFileForReading();
      XSSFSheet workSheet = this.GetWorkSheet(workbook);
      XSSFFormulaEvaluator formulaEvaluator = new XSSFFormulaEvaluator(workbook);
      int rowCount = 0;
      bool flag = false;
      for (int rowIndex = startRowNum; rowIndex <= workSheet.LastRowNum; ++rowIndex)
      {
        if (this.GetCellValueAsString((XSSFCell) ((XSSFRow) workSheet.GetRow(rowIndex)).GetCell(columnNum), formulaEvaluator).Equals(key))
        {
          ++rowCount;
          flag = true;
        }
        else if (flag)
          break;
      }
      return rowCount;
    }

    public int GetRowCount(string key, int columnNum) {return this.GetRowCount(key, columnNum, 0);}

    public int GetColumnNum(string key, int rowNum)
    {
      this.CheckPreRequisites();
      XSSFWorkbook workbook = this.OpenFileForReading();
      XSSFSheet workSheet = this.GetWorkSheet(workbook);
      XSSFFormulaEvaluator formulaEvaluator = new XSSFFormulaEvaluator(workbook);
      XSSFRow row = (XSSFRow) workSheet.GetRow(rowNum);
      for (int cellnum = 0; cellnum < row.LastCellNum; ++cellnum)
      {
        if (this.GetCellValueAsString((XSSFCell) row.GetCell(cellnum), formulaEvaluator).Equals(key))
          return cellnum;
      }
      return -1;
    }

    public string GetValue(int rowNum, int columnNum)
    {
      this.CheckPreRequisites();
      XSSFWorkbook workbook = this.OpenFileForReading();
      XSSFSheet workSheet = this.GetWorkSheet(workbook);
      XSSFFormulaEvaluator formulaEvaluator = new XSSFFormulaEvaluator(workbook);
      return this.GetCellValueAsString((XSSFCell) ((XSSFRow) workSheet.GetRow(rowNum)).GetCell(columnNum), formulaEvaluator);
    }

    public string GetValue(int rowNum, string columnHeader)
    {
      this.CheckPreRequisites();
      XSSFWorkbook workbook = this.OpenFileForReading();
      XSSFSheet workSheet = this.GetWorkSheet(workbook);
      XSSFFormulaEvaluator formulaEvaluator = new XSSFFormulaEvaluator(workbook);
      XSSFRow row = (XSSFRow) workSheet.GetRow(0);
      int cellnum1 = -1;
      for (int cellnum2 = 0; cellnum2 < row.LastCellNum; ++cellnum2)
      {
        if (this.GetCellValueAsString((XSSFCell) row.GetCell(cellnum2), formulaEvaluator).Equals(columnHeader))
        {
          cellnum1 = cellnum2;
          break;
        }
      }
      if (cellnum1 == -1)
        throw new FrameworkException("The specified column header \"" + columnHeader + "\" is not found in the sheet \"" + this.DatasheetName + "\"!");
      return this.GetCellValueAsString((XSSFCell) ((XSSFRow) workSheet.GetRow(rowNum)).GetCell(cellnum1), formulaEvaluator);
    }

    private XSSFCellStyle ApplyCellStyle(
      XSSFWorkbook workbook,
      ExcelCellFormatting cellFormatting)
    {
      XSSFCellStyle cellStyle = (XSSFCellStyle) workbook.CreateCellStyle();
      if (cellFormatting.Centred)
        cellStyle.Alignment = HorizontalAlignment.Center;
      cellStyle.FillForegroundColor = cellFormatting.BackColorIndex;
      //cellStyle.FillPattern = FillPatternType.SOLID_FOREGROUND;
      XSSFFont font = (XSSFFont) workbook.CreateFont();
      font.FontName = cellFormatting.FontName;
      font.FontHeightInPoints = cellFormatting.FontSize;
      //if (cellFormatting.Bold)
        //font.Boldweight = (short) 700;
      font.Color = cellFormatting.ForeColorIndex;
      cellStyle.SetFont((NPOI.XSSF.UserModel.XSSFFont) font);
      return cellStyle;
    }

    public void SetValue(int rowNum, int columnNum, string value) {

    	this.SetValue(rowNum, columnNum, value, (ExcelCellFormatting) null);
    }

    public void SetValue(
      int rowNum,
      int columnNum,
      string value,
      ExcelCellFormatting cellFormatting)
    {
      this.CheckPreRequisites();
      XSSFWorkbook workbook = this.OpenFileForReading();
      XSSFCell cell = (XSSFCell) ((XSSFRow) this.GetWorkSheet(workbook).GetRow(rowNum)).GetCell(columnNum);
      cell.SetCellType(CellType.String);
      cell.SetCellValue(value);
      if (cellFormatting != null)
      {
        XSSFCellStyle hssfCellStyle = this.ApplyCellStyle(workbook, cellFormatting);
        cell.CellStyle = (XSSFCellStyle) hssfCellStyle;
      }
      this.WriteIntoFile(workbook);
    }

    public void SetValue(int rowNum, string columnHeader, string value) { this.SetValue(rowNum, columnHeader, value, (ExcelCellFormatting) null);}

    public void SetValue(
      int rowNum,
      string columnHeader,
      string value,
      ExcelCellFormatting cellFormatting)
    {
      this.CheckPreRequisites();
      XSSFWorkbook workbook = this.OpenFileForReading();
      XSSFSheet workSheet = this.GetWorkSheet(workbook);
      XSSFFormulaEvaluator formulaEvaluator = new XSSFFormulaEvaluator(workbook);
      XSSFRow row = (XSSFRow) workSheet.GetRow(0);
      int column = -1;
      for (int cellnum = 0; cellnum < row.LastCellNum; ++cellnum)
      {
        if (this.GetCellValueAsString((XSSFCell) row.GetCell(cellnum), formulaEvaluator).Equals(columnHeader))
        {
          column = cellnum;
          break;
        }
      }
      if (column == -1)
        throw new FrameworkException("The specified column header " + columnHeader + " is not found in the sheet \"" + this.DatasheetName + "\"!");
      XSSFCell cell = (XSSFCell) ((XSSFRow) workSheet.GetRow(rowNum)).GetCell(column);
      cell.SetCellType(CellType.String);
      cell.SetCellValue(value);
      if (cellFormatting != null)
      {
        XSSFCellStyle hssfCellStyle = this.ApplyCellStyle(workbook, cellFormatting);
        cell.CellStyle = (XSSFCellStyle) hssfCellStyle;
      }
      this.WriteIntoFile(workbook);
    }

    public void SetHyperlink(int rowNum, int columnNum, string linkAddress)
    {
      this.CheckPreRequisites();
      XSSFWorkbook workbook = this.OpenFileForReading();
      XSSFCell cell=(XSSFCell) ((XSSFRow) this.GetWorkSheet(workbook).GetRow(rowNum)).GetCell(columnNum);
      if(cell==null)
      	throw new FrameworkException("Specified cell is empty! Please set a value before including a hyperlink...");
      this.SetCellHyperlink(workbook, cell, linkAddress);
      this.WriteIntoFile(workbook);
    }

    private void SetCellHyperlink(XSSFWorkbook workbook, XSSFCell cell, string linkAddress)
    {
      XSSFCellStyle cellStyle = (XSSFCellStyle) cell.CellStyle;
      XSSFFont font = (XSSFFont) cellStyle.GetFont((XSSFWorkbook) workbook);
      font.Underline=FontUnderlineType.Single;//need to check
      cellStyle.SetFont((NPOI.XSSF.UserModel.XSSFFont) font);
      cell.Hyperlink = (XSSFHyperlink) new XSSFHyperlink(HyperlinkType.Url)
      {
        Address = linkAddress
      };
      cell.CellStyle = (XSSFCellStyle) cellStyle;
    }

    public void SetHyperlink(int rowNum, string columnHeader, string linkAddress)
    {
      this.CheckPreRequisites();
      XSSFWorkbook workbook = this.OpenFileForReading();
      XSSFSheet workSheet = this.GetWorkSheet(workbook);
      XSSFFormulaEvaluator formulaEvaluator = new XSSFFormulaEvaluator(workbook);
      XSSFRow row = (XSSFRow) workSheet.GetRow(0);
      int cellnum1 = -1;
      for (int cellnum2 = 0; cellnum2 < row.LastCellNum; ++cellnum2)
      {
        if (this.GetCellValueAsString((XSSFCell) row.GetCell(cellnum2), formulaEvaluator).Equals(columnHeader))
        {
          cellnum1 = cellnum2;
          break;
        }
      }
      if (cellnum1 == -1)
        throw new FrameworkException("The specified column header " + columnHeader + " is not found in the sheet \"" + this.DatasheetName + "\"!");
      XSSFCell cell=(XSSFCell) ((XSSFRow) workSheet.GetRow(rowNum)).GetCell(cellnum1);
      if(cell==null)
      	throw new FrameworkException("Specified cell is empty! Please set a value before including a hyperlink...");
      this.SetCellHyperlink(workbook, cell, linkAddress);
      this.WriteIntoFile(workbook);
    }

  }
}
