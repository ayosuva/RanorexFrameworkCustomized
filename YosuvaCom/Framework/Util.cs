/*
 * Created by Ranorex
 * User: Yosuva.Arulanthu
 * Date: 03/11/2022
 * 
 * To change this template use Tools > Options > Coding > Edit standard headers.
 */
using System;
using System.IO;

namespace Framework
{
  public static class Util
  {
  	public static string GetFileSeparator() { return Path.DirectorySeparatorChar.ToString();}

  	public static string GetCurrentTime() { return string.Format("{0:t}", (object) DateTime.Now);}

    public static string GetCurrentFormattedTime(string dateFormatstring)
    {
      DateTime now = DateTime.Now;
      return string.Format("{0:" + dateFormatstring + "}", (object) now);
    }

    public static string GetFormattedTime(DateTime time, string dateFormatstring) { return string.Format(dateFormatstring, (object) time);}

    public static string GetTimeDifference(DateTime startTime, DateTime endTime) { return endTime.Subtract(startTime).TotalMinutes.ToString();}
  }
}
