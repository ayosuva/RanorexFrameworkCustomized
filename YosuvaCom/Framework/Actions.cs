/*
 * Created by Ranorex
 * User: Yosuva.Arulanthu
 * Date: 04/11/2022
 * Time: 15:38
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
using Ranorex.Core.Repository;
using Ranorex.Core.Testing;

namespace Framework
{
    /// <summary>
    /// Creates a Ranorex user code collection. A collection is used to publish user code methods to the user code library.
    /// </summary>
    [UserCodeCollection]
    public class Actions
    {
    	[UserCodeMethod]
    	public static void OpenBrowser(string browser,string url){
    		Host.Current.OpenBrowser(url,browser,"",false,true,false,false,false,true);
    		Report.Log(ReportLevel.Info,"Open Application","URL "+url+" opened in "+browser+"browser in Maximized Mode");
    	}
    	
    	[UserCodeMethod]
    	public static void Click(RepoItemInfo RepoObject){
    		Ranorex.Adapter itemAdapter=RepoObject.CreateAdapter<Unknown>(true);
    		itemAdapter.Click();
    		Report.Log(ReportLevel.Info,"Click",RepoObject.Name.Replace("_","")+" Clicked "+RepoObject.Name.Replace("_",""));
    	}
    	
    	[UserCodeMethod]
    	public static void Type(RepoItemInfo RepoObject,string Value)
        {
    		Ranorex.Adapter itemAdapter=RepoObject.CreateAdapter<Unknown>(true);
    		itemAdapter.PressKeys (Value);
    		Report.Log(ReportLevel.Info,"Enter",RepoObject.Name.Replace("_","")+" Entered "+Value+" in "+RepoObject.Name.Replace("_",""));

        }
    	
    	[UserCodeMethod]
		public static void validateEqual(RepoItemInfo repoItem,string property, string expected)
		{
			string actual =repoItem.CreateAdapter<Unknown>(true).Element.GetAttributeValueText(property);
			if(!string.IsNullOrEmpty(actual)){
				actual = actual.ToString();
			}
			else{
			actual="";
			}
			if (actual.Replace("\n","").Equals(expected.Replace("\n","")))
			{
				Report.Log(ReportLevel.Success,"Verify "+repoItem.Name.Replace("_",""), "The expected value ''"+expected +"'' equal to actual value "+actual);
			}
			else
			{
				Report.Log(ReportLevel.Failure,"Verify "+repoItem.Name.Replace("_",""), "The expected value ''"+expected +"'' not equal to actual value "+actual);
			}

		}
		
		[UserCodeMethod]
		public static void CloseApplication(RepoItemInfo repoItem)
        {
			Host.Current.CloseApplication(repoItem.FindAdapter<WebDocument>(), new Duration(0));
            Report.Log(ReportLevel.Info, "Application", "Closed application  "+repoItem.Name.Replace("_",""), repoItem);

        }
    }
}
