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
  public class FrameworkException : Exception
  {
    public string errorName = "Error";

    public FrameworkException()
    {
    }

    public FrameworkException(string errorDescription)
      : base(errorDescription)
    {
    }

    public FrameworkException(string errorName, string errorDescription)
      : base(errorDescription)
    {
      this.errorName = errorName;
      throw new Exception(errorDescription);
    }

    public FrameworkException(string errorDescription, Exception ex)
      : base(errorDescription, ex)
    {
    }
  }
}
