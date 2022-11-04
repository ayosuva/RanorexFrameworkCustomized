/*
 * Created by Ranorex
 * User: Yosuva.Arulanthu
 * Date: 03/11/2022
 * 
 * To change this template use Tools > Options > Coding > Edit standard headers.
 */
namespace Framework
{
  public class ExcelCellFormatting
  {
    private short _backColorIndex;
    private short _foreColorIndex;
    public bool Bold = false;
    public bool Italics = false;
    public bool Centred = false;

    public string FontName { get; set; }

    public short FontSize { get; set; }

    public short BackColorIndex
    {
    	get { 
    		return this._backColorIndex;
    	}
    	set { 
    		if(value<(short) 8 || value>(short) 64)
    			throw new FrameworkException("Valid indexes for the Excel custom palette are from 0x8 to 0x40 (inclusive)!");	
    		this._backColorIndex = value; 
    	}
    }

     public short ForeColorIndex
    {
     	get {return this._foreColorIndex;}
     	set { 
    		if(value<(short) 8 || value>(short) 64)
    			throw new FrameworkException("Valid indexes for the Excel custom palette are from 0x8 to 0x40 (inclusive)!");	
    		this._foreColorIndex = value; 
    	}
    }
  }
}
