/*
 * Created by Ranorex
 * User: Yosuva.Arulanthu
 * Date: 04/11/2022
 * Time: 08:51
 * 
 * To change this template use Tools > Options > Coding > Edit standard headers.
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using WinForms = System.Windows.Forms;

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;
using System.IO;

namespace Framework
{
    /// <summary>
    /// Description of DriveBatchExecution.
    /// </summary>
    [TestModule("24226684-F331-430E-A483-32629A15B8F5", ModuleType.UserCode, 1)]
    public class RunnerSetup : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public RunnerSetup()
        {
            // Do not delete - a parameterless constructor is required!
        }

        /// <summary>
        /// Performs the playback of actions in this module.
        /// </summary>
        /// <remarks>You should not call this method directly, instead pass the module
        /// instance to the <see cref="TestModuleRunner.Run(ITestModule)"/> method
        /// that will in turn invoke this method.</remarks>
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            GetRunInfo();
        }
        
        private void GetRunInfo()
        {
        	string relativePath = Directory.GetCurrentDirectory();
            relativePath = relativePath.Substring(0, relativePath.IndexOf("bin"));
            
            ExcelDataAccess runManagerAccess = new ExcelDataAccess(relativePath, "Runner");
            runManagerAccess.DatasheetName= TestSuite.Current.SelectedRunConfig.Name.ToString();
			
            int nTestInstances = runManagerAccess.GetLastRowNum();
            
            for (int currentTestInstance = 1; currentTestInstance <= nTestInstances; currentTestInstance++)
            {
                string executeFlag = runManagerAccess.GetValue(currentTestInstance, "Ranorex");
                string tc_id=runManagerAccess.GetValue(currentTestInstance,"Test_ID");
                if (executeFlag.Equals("Yes", StringComparison.InvariantCultureIgnoreCase))
                {
                	Boolean statebefore=TestSuite.Current.GetTestContainer(tc_id).Checked;
                 	TestSuite.Current.GetTestContainer(tc_id).Checked = true;
                }
                else
                {
                	TestSuite.Current.GetTestContainer(tc_id).Checked = false;
                }
            }
        }
    }
}
