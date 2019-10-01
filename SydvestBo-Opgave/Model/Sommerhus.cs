using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using SydvestBo_Opgave.Database;

namespace SydvestBo_Opgave.Model
{
   class SommerhusClass
{
    public string Klassificering { get; set; }
    public string Adresse { get; set; }
    public string Opsynsmand { get; set; }
    public string Godkendt { get; set; }
    public string FornavnEjer { get; set; }
    public string EfternavnEjer { get; set; }
    public string Bynavn { get; set; }
    
    private int AntalSenge;
    private int husid;
    private int postnummer;
    private int Ugepris;
    private int eID;

        public int StandardUgePris
        {
            get { return Ugepris; }
            set {
                if (value > 1000)
                {
                    Ugepris = value;
                }
                }
        }

        public int EjerID
        {
            get { return eID; }
            set { eID = value; }
        }

        public int SommerHusID
    {
        get { return husid; }
        set { husid = value; }
    }

    public int PostNr
    {
        get { return postnummer; }
        set {
                if ((value.ToString()).Length == 4)
                {
                    
                        postnummer = value;
                         
                }
            }
    }

        public int Senge
        {
            get { return AntalSenge; }
            set {
                if (value != 0)
                {
                    AntalSenge = value;
                }
                }
        }

        private int StrKvm;

        public int Stoerrelse
        {
            get { return StrKvm; }
            set {
                if (value != 0)
                {
                    StrKvm = value;
                }
                }
        }

        public SommerhusClass ()
	    {

    	}

        public SommerhusClass (int postnr, string adresse, int senge, int stoerrelse, string klassificering, int standardugepris, string opsynsmand, string godkendt, int ejerid)
	    {
            PostNr = postnr;
            Adresse = adresse;
            Senge = senge;
            Stoerrelse = stoerrelse;
            Klassificering = klassificering;
            StandardUgePris = standardugepris;
            Opsynsmand = opsynsmand;
            Godkendt = godkendt;
            EjerID = ejerid;
            
    	}

          public void InsertDB()
            {
            string sql = "INSERT INTO SommerHuse VALUES (" + PostNr + ",'" + Adresse + "'," + Senge + "," + Stoerrelse + ",'" + Klassificering + "'," + StandardUgePris + ",'" + Opsynsmand + "','"+Godkendt+"',"+EjerID+")"; 

            try 
	        {	        
		    SQL.insert(sql);
            

	        }
        	catch (Exception e)
	        {
               Console.WriteLine("Der skete en fejl, Sommerhus er ikke oprettet. Fejlkode" + e);

            }
            }

        public static List<SommerhusClass> LavSommerListe()
        {
         string sql = "SELECT SommerHuse.*,Ejer.EjerID, Ejer.Fornavn, Ejer.Efternavn, PostNrby.ByNavn FROM SommerHuse INNER JOIN PostNrby ON SommerHuse.PostNr = PostNrby.postNr INNER JOIN Ejer ON SommerHuse.EjerID = Ejer.EjerID";
            

            DataTable SommerDataTable = SQL.ReadTable(sql);

            List<SommerhusClass> listSommer = new List<SommerhusClass>();
            foreach (DataRow SommerData in SommerDataTable.Rows)
            {
                listSommer.Add(new SommerhusClass()
                {

                SommerHusID = Convert.ToInt32(SommerData["SommerHusID"]),
                PostNr = Convert.ToInt32(SommerData["PostNr"]),
                Adresse = SommerData["Adresse"].ToString(),
                Senge = Convert.ToInt32(SommerData["Senge"]),
                Stoerrelse = Convert.ToInt32(SommerData["Stoerrelse"]),
                Klassificering = SommerData["Klassificering"].ToString(),
                StandardUgePris = Convert.ToInt32(SommerData["StandardUgePris"]),
                Opsynsmand = SommerData["Opsynsmand"].ToString(),
                Godkendt = SommerData["Godkendt"].ToString(),
                EjerID = Convert.ToInt32(SommerData["EjerID"]),
                FornavnEjer = SommerData["Fornavn"].ToString(),
                EfternavnEjer = SommerData["Efternavn"].ToString(),
                Bynavn = SommerData["ByNavn"].ToString()
                

                });
            }
            
            return listSommer;    

        }


	}
}

