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
        
        private int KundeTlf;

	public int MyKundeTlf
	{
		get { return KundeTlf;}
		set { if (value.ToString().Length == 8)
        {
            KundeTlf = value;}
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

        public Konsulent(int konsulentID, string fornavn, string efternavn, string addresse, int kundeTlf, int postNr, int område )
        {
            MyKonsulentID = konsulentID;
            Fornavn = fornavn;
            Efternavn = efternavn;
            Addresse = addresse;
            MyKundeTlf = kundeTlf;
            MyPostNr = postNr;
            MyOmråde = område;
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
                    MyKundeTlf = Convert.ToInt32(row["Telefon"]),
                    MyPostNr = Convert.ToInt32(row["PostNr"]),
                    MyOmråde = Convert.ToInt32(row["Område"])
                });
	        }

            return KonsulentList;
        }
    }

}
