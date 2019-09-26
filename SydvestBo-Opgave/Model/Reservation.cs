using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SydvestBo_Opgave.Model
{

    public class Reservationer
    {


        public int Dage { get; set; }
        public DateTime StartDato { get; set; }
        public string Sæson { get; set; }
        public int KundeTlf { get; set; }
        public string KundeNavn { get; set; }

        private int ReservationID;
        private int SommerhusID;

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

        public Reservationer(int ReservationID, int SommerhusID, int Dage, DateTime StartDato, string Sæson, int Kundetlf, string KundeNavn)
        {

        }

        public Reservationer()
        {

        }

    }
}
