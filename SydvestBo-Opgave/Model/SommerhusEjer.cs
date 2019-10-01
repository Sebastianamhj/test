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

        public SommerhusEjer (string fornavn, string efternavn, string adresse, int postnr, int telefon)
	        {
                Fornavn = fornavn;
                Efternavn = efternavn;
                Adresse = adresse;
                PostNr = postnr;
                Telefon = telefon;
	        }

        public void EditDB(int ID)
        {
        string sql = "UPDATE Ejer SET Fornavn = " + "'" + Fornavn + "', Efternavn = '" + Efternavn + "', AdresseEjer = '" +  Adresse + "', PostNr = " + PostNr + ", Telefon = " + Telefon + "WHERE EjerID = " + ID;    

            try 
	        {	        
		    SQL.Edit(sql);
            

	        }
        	catch (Exception e)
	        {
               Console.WriteLine("Der skete en fejl, Ejer er ikke rettet. Fejlkode" + e);

            }
            

        }       

        
        public void InsertDB()
        {
            string sql = "INSERT INTO Ejer VALUES ('" + Fornavn + "','" + Efternavn + "','" + Adresse + "'," + PostNr + "," + Telefon + ")"; 

            try {	        

		    SQL.insert(sql);
	        }
        	catch (Exception e) {

               Console.WriteLine("Der skete en fejl, Ejer er ikke oprettet. Fejlkode" + e);

            }
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
                    Adresse = EjerData["AdresseEjer"].ToString(),
                    PostNr = Convert.ToInt32(EjerData["PostNr"]),
                    Telefon = Convert.ToInt32(EjerData["Telefon"]),

            
                });
            }
            
            return EjerList;    

     }

	


  }
}
