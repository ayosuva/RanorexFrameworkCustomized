/*
 * Created by Ranorex
 * User: Yosuva.Arulanthu
 * Date: 03/11/2022
 * 
 * To change this template use Tools > Options > Coding > Edit standard headers.
 */
using System;

namespace Framework
{
	/// <summary>
	/// Description of DataTable.
	/// </summary>
	public class DataTable
	{
		private readonly string _datatablePath;
		private readonly string _datatableName;
		private string _dataReferenceIdentifier;
		private string _currentTestcase;
		private int _currentIteration;
		public string DataReferenceIdentifier
		{
			get
			{
				return this._dataReferenceIdentifier;
			}
			set
			{
				this._dataReferenceIdentifier = value;
			}
		}
		public DataTable(string datatablePath, string datatableName)
		{
			this._datatablePath = datatablePath;
			this._datatableName = datatableName;
		}
		public void SetCurrentRow(string currentTestcase, int currentIteration)
		{
			this._currentTestcase = currentTestcase;
			this._currentIteration = currentIteration;
		}
		private void CheckPreRequisites()
		{
			if (!(this._currentTestcase != null))
			{
				throw new FrameworkException("CraftliteDataTable.currentTestCase is not set!");
			}
			if (!(this._currentIteration != 0))
			{
				throw new FrameworkException("CraftliteDataTable.currentIteration is not set!");
			}
		}

		public string GetData(string datasheetName, string fieldName)
		{
			ExcelDataAccess excelDataAccess;
			int rowNum;
			string text;
			this.CheckPreRequisites();
			excelDataAccess = new ExcelDataAccess(this._datatablePath, this._datatableName);
			excelDataAccess.DatasheetName = datasheetName;
			rowNum = excelDataAccess.GetRowNum(this._currentTestcase, 0);
			if (!(rowNum != -1))
			{
				throw new FrameworkException(string.Concat(new string[]
				{
					"The test case \"",
					this._currentTestcase,
					"\" is not found in the test data sheet \"",
					datasheetName,
					"\"!"
				}));
			}
			rowNum = excelDataAccess.GetRowNum(this._currentIteration.ToString(), 1, rowNum);
			if (!(rowNum != -1))
			{
				throw new FrameworkException(string.Concat(new object[]
				{
					"The iteration number \"",
					this._currentIteration,
					"\" of the test case \"",
					this._currentTestcase,
					"\" is not found in the test data sheet \"",
					datasheetName,
					"\"!"
				}));
			}
			text = excelDataAccess.GetValue(rowNum, fieldName);
			if (!(!text.StartsWith(this.DataReferenceIdentifier)))
			{
				text = this.GetCommonData(fieldName, text);
			}
			return text;
		}
		private string GetCommonData(string fieldName, string dataValue)
		{
			ExcelDataAccess excelDataAccess;
			string text;
			int rowNum;
			excelDataAccess = new ExcelDataAccess(this._datatablePath, "Common Testdata");
			excelDataAccess.DatasheetName = "Common_Testdata";
			text = dataValue.Split(this.DataReferenceIdentifier.ToCharArray())[1];
			rowNum = excelDataAccess.GetRowNum(text, 0);
			if (!(rowNum != -1))
			{
				throw new FrameworkException(string.Concat("The common test data row identified by \"", text, "\" is not found in the common test data sheet!"));
			}
			dataValue = excelDataAccess.GetValue(rowNum, fieldName);
			return dataValue;
		}

		public void PutData(string datasheetName, string fieldName, string dataValue)
		{
			ExcelDataAccess excelDataAccess;
			int rowNum;
			this.CheckPreRequisites();
			excelDataAccess = new ExcelDataAccess(this._datatablePath, this._datatableName);
			excelDataAccess.DatasheetName = datasheetName;
			rowNum = excelDataAccess.GetRowNum(this._currentTestcase, 0);
			if (!(rowNum != -1))
			{
				throw new FrameworkException(string.Concat(new string[]
				{
					"The test case \"",
					this._currentTestcase,
					"\" is not found in the test data sheet \"",
					datasheetName,
					"\"!"
				}));
			}
			rowNum = excelDataAccess.GetRowNum(this._currentIteration.ToString(), 1, rowNum);
			if (!(rowNum != -1))
			{
				throw new FrameworkException(string.Concat(new object[]
				{
					"The iteration number \"",
					this._currentIteration,
					"\" of the test case \"",
					this._currentTestcase,
					"\" is not found in the test data sheet \"",
					datasheetName,
					"\"!"
				}));
			}
			excelDataAccess.SetValue(rowNum, fieldName, dataValue);
		}

		public string GetExpectedResult(string fieldName)
		{
			ExcelDataAccess excelDataAccess;
			int rowNum;
			this.CheckPreRequisites();
			excelDataAccess = new ExcelDataAccess(this._datatablePath, this._datatableName);
			excelDataAccess.DatasheetName = "Parametrized_Checkpoints";
			rowNum = excelDataAccess.GetRowNum(this._currentTestcase, 0);
			if (!(rowNum != -1))
			{
				throw new FrameworkException(string.Concat("The test case \"", this._currentTestcase, "\" is not found in the parametrized checkpoints sheet!"));
			}
			rowNum = excelDataAccess.GetRowNum(this._currentIteration.ToString(), 1, rowNum);
			if (!(rowNum != -1))
			{
				throw new FrameworkException(string.Concat(new object[]
				{
					"The iteration number \"",
					this._currentIteration,
					"\" of the test case \"",
					this._currentTestcase,
					"\" is not found in the parametrized checkpoints sheet!"
				}));
			}
			return excelDataAccess.GetValue(rowNum, fieldName);
		}
	}
}
