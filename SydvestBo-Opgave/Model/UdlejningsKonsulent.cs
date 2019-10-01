using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using SydvestBo_Opgave.Database;

namespace SydvestBo_Opgave.Model
{

    class Konsulent
    {
        public string Fornavn { get; set; }
        public string Efternavn { get; set; }
        public string Addresse { get; set; }
        
        private int KonsulentTlf;

	public int MykonsulentTlf
	{
		get { return KonsulentTlf;}
		set { if (value.ToString().Length == 8)
        {
            KonsulentTlf = value;}
        }
	}


        private int Område;

	    public int MyOmråde
	    {
		    get { return Område;}
		    set { Område = value;}
	    }

        private int PostNr;

	    public int MyPostNr
	    {
		    get { return PostNr;}
		    set { if (value.ToString().Length == 4 && value <=9999)
                {
                    PostNr = value;}
                }
	    }

        private int KonsulentID;

        public int MyKonsulentID
        {
            get { return KonsulentID; }
            set { KonsulentID = value; }
        }

        public Konsulent ()
	    {

	    }

        public Konsulent(string fornavn, string efternavn, string addresse, int konsulentTLF, int postNr, int område )
        {
            Fornavn = fornavn;
            Efternavn = efternavn;
            Addresse = addresse;
            MykonsulentTlf = konsulentTLF;
            MyPostNr = postNr;
            MyOmråde = område;
        }

        public void EditDB(int ID)
        {


        
        
        }


        public void InsertDB()
            {
            string sql = "INSERT INTO Konsulenter VALUES ('" + Fornavn + "','" + Efternavn + "','" + Addresse + "'," + MykonsulentTlf + "," + MyPostNr + "," + MyOmråde + ")"; 

            try 
	        {	        
		    SQL.insert(sql);
            

	        }
        	catch (Exception e)
	        {
               Console.WriteLine("Der skete en fejl, Konsulent er ikke oprettet. Fejlkode" + e);

            }
            }



        public static List<Konsulent> CreateKonsulentList()
        {

            DataTable KonsulentTable = SQL.ReadTable("SELECT * FROM Konsulenter");

            List<Konsulent> KonsulentList = new List<Konsulent>();
            foreach (DataRow row in KonsulentTable.Rows)
	        {

                KonsulentList.Add(new Konsulent()
                {
                    MyKonsulentID = Convert.ToInt32(row["konsulenterID"]),
                    Fornavn = Convert.ToString(row["Fornavn"]),
                    Efternavn = Convert.ToString(row["Efternavn"]),
                    Addresse = Convert.ToString(row["Adresse"]),
                    MykonsulentTlf = Convert.ToInt32(row["Telefon"]),
                    MyPostNr = Convert.ToInt32(row["PostNr"]),
                    MyOmråde = Convert.ToInt32(row["Område"])
                });
	        }

            return KonsulentList;
        }
    }

}
