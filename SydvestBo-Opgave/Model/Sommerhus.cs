using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SydvestBo_Opgave.Model
{
   class SommerhusClass
{
    public int Klassificering { get; set; }
    public string Adresse { get; set; }
    public string Opsynsmand { get; set; }
    public string Godkendt { get; set; }


    private int AntalSenge;
    private int husid;
    private int postnummer;
    private int Ugepris;
    private int eID;

        public int StandardUgePris
        {
            get { return myVar; }
            set {
                if (value > 1000)
                {
                    myVar = value;
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
}
}
