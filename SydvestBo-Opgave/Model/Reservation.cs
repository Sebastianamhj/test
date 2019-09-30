using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using SydvestBo_Opgave.Database;

namespace SydvestBo_Opgave.Model
{

    public class Reservation
    {


        public int Dage { get; set; }
        public string StartDato { get; set; }
        public string Sæson { get; set; }
        public string KundeNavn { get; set; }

        private int ReservationID;
        private int SommerhusID;
        private int KundeTlf;





	    public int MyKundeTlf
	    {
		    get { return KundeTlf;}
		    set { if (value.ToString().Length == 8)
            {
                KundeTlf = value;}
            }
	    }


        public int MySommerhusID
        {
            get { return SommerhusID; }
            set { SommerhusID = value; }
        }

        public int MyReservationID
        {
            get { return ReservationID; }
            set { ReservationID = value; }
        }

        
        public Reservation(int sommerhusID, int dage, string startDato, string sæson, int kundetlf, string kundeNavn)
        {
            
            MySommerhusID = sommerhusID;
            Dage = dage;
            StartDato = startDato;
            Sæson = sæson;
            MyKundeTlf = kundetlf;
            KundeNavn = kundeNavn;
        }
        
        public Reservation()
        {

        }
        
        public void InsertDB()
        {
          
            string sql = "INSERT INTO Reservationer VALUES (" + MySommerhusID + "," + Dage + ",'" + StartDato + "','" + Sæson + "'," + MyKundeTlf + ",'" + KundeNavn + "')"; 

            try 
	        {	        
		    SQL.insert(sql);
            

	        }
        	catch (Exception e)
	        {
               Console.WriteLine("Der skete en fejl, Reservation er ikke oprettet. Fejlkode" + e);

            }
        }

        public static List<Reservation> CreateReservationList()
        {
            
            DataTable ReservationTable = SQL.ReadTable("SELECT Reservationer.*, SommerHuse.* FROM Reservationer INNER JOIN SommerHuse ON SommerHuse.SommerHusID = Reservationer.SommerHusID");

            List<Reservation> ReservationList = new List<Reservation>();
            foreach (DataRow row in ReservationTable.Rows)
	        {
                ReservationList.Add(new Reservation()
                {
                    MyReservationID = Convert.ToInt32(row["ReservationID"]),
                    MySommerhusID = Convert.ToInt32(row["SommerhusID"]),
                    Dage = Convert.ToInt32(row["Dage"]),
                    StartDato = Convert.ToString(row["StartDato"]),
                    Sæson = Convert.ToString(row["Sæson"]),
                    MyKundeTlf = Convert.ToInt32(row["KundeTelefon"]),
                    KundeNavn = Convert.ToString(row["Kundenavn"])
                });
	        }

            return ReservationList;

        }

    }
    
}
