using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SydvestBo_Opgave.Model
{
  class SommerhusEjer
  {
    public string Fornavn { get; set; }
    public string Efternavn { get; set; }
    public string Adresse { get; set; }


    private int eID;
    private int postnummer;
    private int tlfNr;


	public int EjerID
	{
		get { return eID;}
		set { eID = value;}
	}

	public int Telefon
	{
		get { return tlfNr;}
		set { 
            if (value.ToString().Length == 8)
                {

                        tlfNr = value;
                }


	         }
    }

    public int PostNr
    {
        get { return postnummer; }
        set {
                if (value.ToString().Length == 4)
                {
                    
                        postnummer = value;
                         
                }
            }
    }


  }
}
