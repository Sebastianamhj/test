using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using SydvestBo_Opgave.Database;

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

        public SommerhusEjer ()
	{

	}

        public SommerhusEjer (int ejerid, string fornavn, string efternavn, string adresse, int postnr, int telefon)
	{
            EjerID = ejerid;
            Fornavn = fornavn;
            Efternavn = efternavn;
            Adresse = adresse;
            PostNr = postnr;
            Telefon = telefon;
	}

     public static List<SommerhusEjer> LavEjerListe()
        {
         string sql = "SELECT * FROM Ejer";

            
            DataTable EjerDataTable = SQL.ReadTable(sql);

            List<SommerhusEjer> EjerList = new List<SommerhusEjer>();
            foreach (DataRow EjerData in EjerDataTable.Rows)
            {
                EjerList.Add(new SommerhusEjer()
                {

            EjerID = Convert.ToInt32(EjerData["EjerID"]),
            Fornavn = EjerData["Fornavn"].ToString(),
            Efternavn = EjerData["Efternavn"].ToString(),
            Adresse = EjerData["Adresse"].ToString(),
            PostNr = Convert.ToInt32(EjerData["PostNr"]),
            Telefon = Convert.ToInt32(EjerData["Telefon"])
            
                });
            }
            
            return EjerList;    

         }

	


  }
}
