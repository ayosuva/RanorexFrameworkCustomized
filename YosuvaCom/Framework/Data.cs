/*
 * Created by Ranorex
 * User: Yosuva.Arulanthu
 * Date: 03/11/2022
 * 
 * To change this template use Tools > Options > Coding > Edit standard headers.
 */
using System;
using System.Configuration;
using System.IO;
using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

namespace Framework
{
	/// <summary>
	/// Description of Data.
	/// </summary>
	public class Data
	{
		private static DataTable _dataTable;
        
        public static DataTable Instance
        {
        	get{
        		if(_dataTable == null)
        		{
        			Initialize();
        		}
        		
        		SetDataTableRow();
        		
        		return _dataTable;
        	}
        }
		
        private static void Initialize()
        {
        	
        	string relativePath = Directory.GetCurrentDirectory();
            relativePath = relativePath.Substring(0, relativePath.IndexOf("bin"));
            
            string datatablePath = relativePath + Path.DirectorySeparatorChar.ToString() + "TestData";

            var currentTest = (TestCaseNode) TestSuite.CurrentTestContainer;
            string currentScenario = currentTest.Parent.Name;
            
            
            _dataTable = new DataTable(datatablePath, currentScenario);
            //_dataTable.DataReferenceIdentifier = ConfigurationManager.AppSettings["DataReferenceIdentifier"];
            _dataTable.DataReferenceIdentifier ="#";
        }
        
        private static void SetDataTableRow()
        {
        	var currentTest=(TestCaseNode) TestSuite.CurrentTestContainer;
        	string currentTestCase = currentTest.Name;

            int currentIteration = currentTest.DataContext.CurrentRowIndex;
        	_dataTable.SetCurrentRow(currentTestCase, currentIteration);
        }
	}
}
