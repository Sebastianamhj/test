using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SydvestBo_Opgave.Database;
using SydvestBo_Opgave.Model;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace SydvestBo_Opgave
{
    class Program
    {
        
        static void Main(string[] args)
        {

            Console.WindowHeight = 25;
            Console.WindowWidth = 95;
            Console.CursorVisible = false;

            string currentMenu = "Main";

            createMainScreen(currentMenu);

            Console.ReadLine();
        }

        public static void ClearCurrentConsoleLine<T>(List<T> menu)
        {
            int quickMaths = 7;
            int stringCounter = menu.Count;
            int currentLineCursor = Console.CursorTop;
            do
            {
                Console.SetCursorPosition(0, quickMaths);
                Console.Write(new string(' ', Console.WindowWidth));
                quickMaths++;
            } while (quickMaths <=stringCounter);
            
            Console.SetCursorPosition(0, currentLineCursor);
        }

        public static void DynamicChoosing<T>(bool firstwrite, List<T> menu, int menuCounter, string currentMenu)
        {
            
            
            //Console.Write(Type.GetTypeCode(typeof(T)));
            Type type = menu.GetType().GetGenericArguments()[0];
            //Type typeParameter = typeof(T);
            //Console.SetCursorPosition(6, 20);
            List<Reservation> reservationList = new List<Reservation>();
            List<SommerhusEjer> ejerList = new List<SommerhusEjer>();
            List<SommerhusClass> sommerhusList = new List<SommerhusClass>();
            List<Konsulent> konsulentList = new List<Konsulent>();
            List<Område> områdeList = new List<Område>();
            

            //Console.Write(type);
            Typeclass Writer = new Typeclass();
            int lineCounter = 7;
            int stringCounter = menu.Count;
            int counter = 0;
            bool continueAccepted = false;


            if (menuCounter <= stringCounter)
            {
                //menuCounter--;
                continueAccepted = true;
            }

            ClearCurrentConsoleLine(menu);
            if (continueAccepted && !firstwrite)
            {
                switch (Type.GetTypeCode(typeof(T))){

                    case TypeCode.String:
                        if (currentMenu.Equals("Main") || currentMenu.Equals("Sæson"))
	                    {
                            foreach (var item in menu)
                            {
                                counter++;
                                Console.SetCursorPosition(1, lineCounter);
                                if (counter.Equals(menuCounter))
                                {
                                    Console.BackgroundColor = ConsoleColor.DarkRed;
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.Write(item.ToString());
                                    Console.ResetColor();
                                }
                                else
                                {
                                    Console.Write(item.ToString());
                                }
                                lineCounter++;

                            }
	                    }else if (currentMenu.Equals("RedigerEjer"))
                        {
                            counter = 0;

                            foreach (var item in menu)
	                        {
                                
                                counter++;
                                if (counter < menu.Count())
	                            {

                                    Console.SetCursorPosition(1, lineCounter);
                                    if (counter == 1)
                                    {
                                        Console.Write("Fornavn: ");
                                    } else if (counter == 2)
                                    {
                                        Console.Write("Efternavn: ");
                                    } else if (counter == 3)
                                    {
                                        Console.Write("Adresse: ");
                                    } else if (counter == 4)
                                    {
                                        Console.Write("PostNr: ");
                                    } else if (counter == 5)
                                    {
                                        Console.Write("Tlf: ");
                                    }
                                    if (counter.Equals(menuCounter))
	                                {
                                        typeRed();
                                        Console.Write(item.ToString());
                                        Console.ResetColor();
	                                } else
                                    {
                                        Console.Write(item.ToString());
                                    }
	                            }
                                
                                lineCounter++;
                                
	                        }
                        }
                        
                        break;

                    case TypeCode.Object:
                        

                        if (type == reservationList.GetType().GetGenericArguments()[0] && currentMenu.Equals("Reservation")){
                            
                            reservationList = menu.Cast<Reservation>().ToList();
                            foreach (var item in reservationList)
	                        {
                                counter++;
                                Console.SetCursorPosition(1, lineCounter);
                                if (counter.Equals(menuCounter))
                                {
                                    Console.BackgroundColor = ConsoleColor.DarkRed;
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.Write($"Uge: {ugeNumre(item.StartDato, item.Dage)} {item.SommerhusAddresse} {item.KundeNavn}");
                                    Console.ResetColor(); 
                                }
                                else
                                {
                                   Console.Write($"Uge: {ugeNumre(item.StartDato, item.Dage)} {item.SommerhusAddresse} {item.KundeNavn}");
                                }
                                lineCounter++;
	                        }
                            
                        } else if (type == ejerList.GetType().GetGenericArguments()[0] && currentMenu.Equals("SommerhusEjer")){

                            ejerList = menu.Cast<SommerhusEjer>().ToList();
                            foreach (var item in ejerList)
	                        {

                                counter++;
                                Console.SetCursorPosition(1, lineCounter);
                                if (counter.Equals(menuCounter))
                                {
                                    Console.BackgroundColor = ConsoleColor.DarkRed;
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.Write($"{item.Fornavn} {item.Efternavn}");
                                    Console.ResetColor();
                                }
                                else
                                {
                                    Console.Write($"{item.Fornavn} {item.Efternavn}");
                                }
                                lineCounter++;
	                        }

                        } else if (type == sommerhusList.GetType().GetGenericArguments()[0] && currentMenu.Equals("Sommerhus")){

                            sommerhusList = menu.Cast<SommerhusClass>().ToList();

                            foreach (var item in sommerhusList)
	                        {
                                
                                counter++;
                                Console.SetCursorPosition(1, lineCounter);
                                if (counter.Equals(menuCounter))
                                {
                                    Console.BackgroundColor = ConsoleColor.DarkRed;
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.Write($"{item.Adresse} {item.Opsynsmand} {item.FornavnEjer} {item.EfternavnEjer}");
                                    Console.ResetColor();
                                }
                                else
                                {
                                    Console.Write($"{item.Adresse} {item.Opsynsmand} {item.FornavnEjer} {item.EfternavnEjer}");
                                }
                                lineCounter++;
	                        }

                        } else if (type == konsulentList.GetType().GetGenericArguments()[0] && currentMenu.Equals("Konsulent")){

                            konsulentList = menu.Cast<Konsulent>().ToList();

                            foreach (var item in konsulentList)
	                        {

                                counter++;
                                Console.SetCursorPosition(1, lineCounter);
                                if (counter.Equals(menuCounter))
                                {
                                    Console.BackgroundColor = ConsoleColor.DarkRed;
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.Write($"{item.Fornavn} {item.Efternavn}");
                                    Console.ResetColor();
                                }
                                else
                                {
                                    Console.Write($"{item.Fornavn} {item.Efternavn}");
                                }
                                lineCounter++;
	                        }
                        } else if (type == områdeList.GetType().GetGenericArguments()[0] && currentMenu.Equals("Område")){

                            områdeList = menu.Cast<Område>().ToList();

                            foreach (var item in områdeList)
	                        {

                                counter++;
                                Console.SetCursorPosition(1, lineCounter);
                                if (counter.Equals(menuCounter))
                                {
                                    Console.BackgroundColor = ConsoleColor.DarkRed;
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.Write($"{item.postNr} {item.områdeBy}");
                                    Console.ResetColor();
                                }
                                else
                                {
                                    Console.Write($"{item.postNr} {item.områdeBy}");
                                }
                                lineCounter++;
	                        }
                        } 
                                   
                        break;
                }
                
            } else if (continueAccepted && firstwrite)
            {
                foreach (var item in menu)
                {
                    counter++;
                    Console.SetCursorPosition(1, lineCounter);
                    if (counter.Equals(menuCounter))
                    {
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Writer.TypeWriter(item.ToString());
                        Console.ResetColor();
                    }
                    else
                    {
                        Writer.TypeWriter(item.ToString());
                    }
                    lineCounter++;

                }
            }

        }

        public static void CreateSommerhusEjerScreen(string currentMenu)
        {
            Console.Clear();
            bool firstWrite = false;

            Console.SetCursorPosition(1, 1);
            Console.WriteLine("Sommerhus Ejere:");
            Console.SetCursorPosition(1, 3);
            Console.WriteLine("Brug piletasterne, og Enter, for at vælge.");
            Console.SetCursorPosition(1, 4);
            Console.WriteLine("Vælg en ejer, for at administrerer deres sommerhuse eller oplysninger.");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.SetCursorPosition(70, 23);
            Console.WriteLine("ESC for at gå tilbage");
            Console.ResetColor();

            List<SommerhusEjer> ejerList = new List<SommerhusEjer>();
            ejerList = SommerhusEjer.LavEjerListe();

            int listCounter = ejerList.Count();

            DynamicChoosing(firstWrite, ejerList, 1, currentMenu);
            MenuOptions(ejerList, currentMenu);

        }

        public static void CreateSommerhusScreen(string currentMenu)
        {
            Console.Clear();
            bool firstWrite = false;

            Console.SetCursorPosition(1, 1);
            Console.WriteLine("Sommerhuse:");
            Console.SetCursorPosition(1, 2);
            Console.WriteLine("Brug piletasterne, og Enter, for at vælge.");
            Console.SetCursorPosition(1, 3);
            Console.WriteLine("Vælg et sommerhus, for at administrerer det eller få flere oplysninger.");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.SetCursorPosition(70, 23);
            Console.WriteLine("ESC for at gå tilbage");
            Console.ResetColor();

            List<SommerhusClass> sommerhusList = new List<SommerhusClass>();
            sommerhusList = SommerhusClass.LavSommerListe();

            DynamicChoosing(firstWrite, sommerhusList, 1, currentMenu);
            MenuOptions(sommerhusList, currentMenu);
        }

        public static void CreateReservationScreen(string currentMenu)
        {
            Console.Clear();
            bool firstWrite = false;

            Console.SetCursorPosition(1, 1);
            Console.WriteLine("Reservationer:");
            Console.SetCursorPosition(1, 2);
            Console.WriteLine("Brug piletasterne, og Enter, for at vælge.");
            Console.SetCursorPosition(1, 3);
            Console.WriteLine("Vælg en Reservation, for at administrerer den eller få flere oplysninger.");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.SetCursorPosition(70, 23);
            Console.WriteLine("ESC for at gå tilbage");
            Console.ResetColor();

            List<Reservation> ReservationList = new List<Reservation>();
            //ReservationList.Add("Opret Reservation");
            ReservationList = Reservation.CreateReservationList();
            
            DynamicChoosing(firstWrite, ReservationList, 1, currentMenu);
            MenuOptions(ReservationList, currentMenu);

        }

        public static void CreateKonsulentScreen(string currentMenu)
        {
            Console.Clear();
            bool firstWrite = false;

            Console.SetCursorPosition(1, 1);
            Console.WriteLine("Udlejningskonsulenter:");
            Console.SetCursorPosition(1, 2);
            Console.WriteLine("Brug piletasterne, og Enter, for at vælge.");
            Console.SetCursorPosition(1, 3);
            Console.WriteLine("Vælg en Konsulent, for at administrerer eller få flere oplysninger.");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.SetCursorPosition(70, 23);
            Console.WriteLine("ESC for at gå tilbage");
            Console.ResetColor();

            List<Konsulent> KonsulentList = new List<Konsulent>();
            KonsulentList = Konsulent.CreateKonsulentList();

            DynamicChoosing(firstWrite, KonsulentList, 1, currentMenu);
            MenuOptions(KonsulentList, currentMenu);
        }

        public static void createOmrådeScreen(string currentMenu)
        {
            Console.Clear();
            bool firstWrite = false;

            Console.SetCursorPosition(1, 1);
            Console.WriteLine("Udlejningskonsulenter:");
            Console.SetCursorPosition(1, 2);
            Console.WriteLine("Brug piletasterne, og Enter, for at vælge.");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.SetCursorPosition(70, 23);
            Console.WriteLine("ESC for at gå tilbage");
            Console.ResetColor();

            List<Område> områdeList = new List<Område>();
            områdeList = Område.createOmrådeList();

            DynamicChoosing(firstWrite, områdeList, 1, currentMenu);
            MenuOptions(områdeList, currentMenu);
        }

        public static void createSæsonScreen(string currentMenu) {

            Console.Clear();
            bool firstWrite = false;

            Console.SetCursorPosition(1, 1);
            Console.WriteLine("Sæson kategorier og priser:");
            Console.SetCursorPosition(1, 2);
            Console.WriteLine("Brug piletasterne, og Enter, for at vælge.");
            Console.SetCursorPosition(1, 3);
            Console.WriteLine("Vælg en Konsulent, for at administrerer eller få flere oplysninger.");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.SetCursorPosition(70, 23);
            Console.WriteLine("ESC for at gå tilbage");
            Console.ResetColor();

            List<string> sæsonList = new List<string>()
            {
                "Lav",
                "Mellem",
                "Høj",
                "Super"
            };

            DynamicChoosing(firstWrite, sæsonList, 1, currentMenu);
            MenuOptions(sæsonList, currentMenu);

        }

        public static void createMainScreen(string currentMenu) {

            Console.Clear();
            bool firstWrite = true;
            Loading.loading();

            Typeclass Writer = new Typeclass();
            Console.SetCursorPosition(Console.WindowWidth / 2 - 10, 1);
            Writer.TypeWriter("Sydvest-Bo Sommerhuse");
            Console.SetCursorPosition(70, 21);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("F1 Opret Sommerhus Ejer");
            Console.SetCursorPosition(70, 22);
            Console.WriteLine("F2 Opret Sommerhus");
            Console.SetCursorPosition(70, 23);
            Console.WriteLine("F3 Opret Reservation.");
            Console.ResetColor();

            List<string> mainScreen = new List<string>()
            {
                "Sommerhus ejere:",
                "Sommerhuse:",
                "Reservationer:",
                "Udlejningskonsulenter:",
                "Områder:",
                "Sæson kategori og priser:"
            };


            DynamicChoosing(firstWrite, mainScreen, 1, currentMenu);
            MenuOptions(mainScreen, currentMenu);

        }

        public static void MenuOptions<T>(List<T> menu, string currentMenu)
        {
            bool firstWrite = false;
            int menuCounter = 1;
            bool titleMenuBool = false;

            if (currentMenu.Equals("Main"))
            {

                do
                {
                    var ch = Console.ReadKey().Key;
                    switch (ch)
                    {

                        case ConsoleKey.UpArrow:
                            if (menuCounter == 1)
                            {
                                menuCounter = menu.Count();
                                DynamicChoosing(firstWrite, menu, menuCounter, currentMenu);

                            }
                            else
                            {
                                menuCounter--;
                                DynamicChoosing(firstWrite, menu, menuCounter, currentMenu);

                            }
                            break;

                        case ConsoleKey.DownArrow:
                            if (menuCounter == menu.Count())
                            {
                                menuCounter = 1;
                                DynamicChoosing(firstWrite, menu, menuCounter, currentMenu);
                            }
                            else
                            {
                                menuCounter++;
                                DynamicChoosing(firstWrite, menu, menuCounter, currentMenu);
                            }
                            break;
                        case ConsoleKey.F1:
                            // Opret sommerhus Ejer

                            break;
                        case ConsoleKey.F2:
                            //Opret Sommerhus

                            break;
                        case ConsoleKey.F3:
                            //Opret reservation

                            break;

                        case ConsoleKey.Enter:
                            if (menuCounter == 1)
                            {
                                currentMenu = "SommerhusEjer";
                                CreateSommerhusEjerScreen(currentMenu);                                

                            }
                            else if (menuCounter == 2)
                            {

                                currentMenu = "Sommerhus";
                                CreateSommerhusScreen(currentMenu);
                            }
                            else if (menuCounter == 3)
                            {
                                //Reservationer();
                                currentMenu = "Reservation";
                                //List<Reservation> ReservationList = new List<Reservation>();
                                //ReservationList = Reservation.CreateReservationList();
                                CreateReservationScreen(currentMenu);
                            }
                            else if (menuCounter == 4)
                            {
                                //Udlejningskonsulent();
                                //currentMenu = "Udlejningskonsulent";
                                currentMenu = "Konsulent";
                                CreateKonsulentScreen(currentMenu);
                            }
                            else if (menuCounter == 5)
                            {
                                currentMenu = "Område";
                                createOmrådeScreen(currentMenu);
                            }
                            else if (menuCounter == 6)
                            {
                                currentMenu = "Sæson";
                                createSæsonScreen(currentMenu);
                            }
                            titleMenuBool = true;
                            break;
                    }
                } while (!titleMenuBool);

            } else if (currentMenu.Equals("RedigerEjer"))
            {
                do {
                    var ch = Console.ReadKey().Key;
                    switch (ch)
                    {

                        case ConsoleKey.UpArrow:
                            if (menuCounter == 1)
                            {
                                menuCounter = menu.Count() - 1;
                                DynamicChoosing(firstWrite, menu, menuCounter, currentMenu);
                            }
                            else 
                            {
                                menuCounter--;
                                DynamicChoosing(firstWrite, menu, menuCounter, currentMenu);
                            }
                            break;

                        case ConsoleKey.DownArrow:
                            if (menuCounter == menu.Count() - 1)
	                        {
                                menuCounter = 1;
                                DynamicChoosing(firstWrite, menu, menuCounter, currentMenu);
	                        }
                            else
                            {
                                menuCounter++;
                                DynamicChoosing(firstWrite, menu, menuCounter, currentMenu);
                            }
                            break;

                        case ConsoleKey.Escape:
                            if (currentMenu.Equals("RedigerEjer"))
                            {
                                currentMenu = "SommerhusEjer";
                                CreateSommerhusEjerScreen(currentMenu);
                                
                            }
                            break;
                            
                         case ConsoleKey.Enter:
                            
                            int clearCounter = 0;
                            int lineCount = 6;
                            
                            
                             List<int> charCounter = new List<int>() { 0, 10, 12, 10, 9, 6 };
                            //charCounter[menuCounter];
                            
                            while (clearCounter < menu[menuCounter-1].ToString().Count())
	                        {
                            Console.SetCursorPosition(clearCounter + charCounter[menuCounter], lineCount+menuCounter);

                            Console.Write(new string(' ', Console.WindowWidth));
                            clearCounter++;
                       
	                        }
                            clearCounter = 0;
                            Console.SetCursorPosition(clearCounter + charCounter[menuCounter], lineCount+menuCounter);

                            List<string> e1 = new List<string>();
                            e1 = menu.Cast<string>().ToList();

                            
                            
                            int ejerID = Convert.ToInt32(e1[5]);
                            string fornavn = e1[0];
                            string efternavn = e1[1];
                            string adresse = e1[2];
                            int postNummer = Convert.ToInt32(e1[3]);
                            int telefon = Convert.ToInt32(e1[4]);
                            

                            string input = Console.ReadLine();


                            switch (menuCounter)
	                        {
                                case 1: //Fornavn
                                    fornavn = input;
                                   
                                    break;
                                
                                case 2: //Efternavn
                                    efternavn = input;
                                    break;
	
                                case 3: //Adresse
                                    adresse = input;
                                    break;

                                case 4: //PostNr
                                    postNummer = Convert.ToInt32(input);
                                    break;

                                case 5: //PostNr
                                    telefon = Convert.ToInt32(input);
                                    break;
                               
		                        default:
                                    break;
	                        }
                            
                            
                            SommerhusEjer e2 = new SommerhusEjer(fornavn, efternavn, adresse, postNummer, telefon);
                            e2.EditDB(ejerID);
                            
                            e1[0] = fornavn;
                            e1[1] = efternavn;
                            e1[2] = adresse;
                            e1[3] = postNummer.ToString();
                            e1[4] = telefon.ToString();
                            e1[5] = ejerID.ToString();
                            

                            DynamicChoosing(firstWrite, e1,menuCounter,currentMenu);
                            MenuOptions(e1, currentMenu);
                            

                            //kald dynamicchoosing til sidst

                            break;

                    }
                } while (!titleMenuBool);
            } else 
            {
                do
                {
                    var ch = Console.ReadKey().Key;
                    switch (ch)
                    {

                        case ConsoleKey.UpArrow:
                            if (menuCounter == 1)
                            {
                                menuCounter = menu.Count();
                                DynamicChoosing(firstWrite, menu, menuCounter, currentMenu);

                            }
                            else
                            {
                                menuCounter--;
                                DynamicChoosing(firstWrite, menu, menuCounter, currentMenu);

                            }
                            break;

                        case ConsoleKey.DownArrow:
                            if (menuCounter == menu.Count())
                            {
                                menuCounter = 1;
                                DynamicChoosing(firstWrite, menu, menuCounter, currentMenu);
                            }
                            else
                            {
                                menuCounter++;
                                DynamicChoosing(firstWrite, menu, menuCounter, currentMenu);
                            }
                            break;

                        case ConsoleKey.Escape:
                            if (currentMenu.Equals("SommerhusEjer") || currentMenu.Equals("Sommerhus") ||
                                currentMenu.Equals("Reservation") || currentMenu.Equals("Konsulent") ||
                                currentMenu.Equals("Område") || currentMenu.Equals("Sæson"))
	                        {
                                currentMenu = "Main";
                                createMainScreen(currentMenu);
	                        }
                            break;

                        case ConsoleKey.Enter:

                            //int sqlIndex = menuCounter - 1;
                            if (currentMenu.Equals("SommerhusEjer"))
                            {

                                Console.Clear();

                                Console.SetCursorPosition(1, 1);
                                Console.WriteLine("Sommerhus Ejere:");
                                Console.SetCursorPosition(1, 3);
                                Console.WriteLine($"Brug piletasterne, og Enter, for at vælge et felt, indtast i \n feltet, og tryk enter igen for at bekræfte.");
                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                Console.SetCursorPosition(70, 23);
                                Console.WriteLine("ESC for at gå tilbage");
                                Console.ResetColor();

                                List<SommerhusEjer> EjerList = new List<SommerhusEjer>();
                                EjerList = SommerhusEjer.LavEjerListe();
                                List<string> newEjer = new List<string>();
                                int i = 1;
                                foreach (var item in EjerList)
	                            {
                                    if (i == menuCounter)
	                                {
                                        
                                        newEjer.Add(item.Fornavn);
                                        newEjer.Add(item.Efternavn);
                                        newEjer.Add(item.Adresse);
                                        newEjer.Add(item.PostNr.ToString());
                                        newEjer.Add(item.Telefon.ToString());
                                        newEjer.Add(item.EjerID.ToString());
                                    }
                                    i++;
	                            }

                                currentMenu = "RedigerEjer";
                                DynamicChoosing(firstWrite, newEjer, 1, currentMenu);
                                MenuOptions(newEjer, currentMenu);

                            }else if (currentMenu.Equals("Sommerhus"))
                            {

                                Console.Clear();

                                Console.SetCursorPosition(1, 1);
                                Console.WriteLine("Sommerhus oplysninger:");
                                Console.SetCursorPosition(1, 3);
                                Console.WriteLine($"Brug piletasterne, og Enter, for at vælge et felt, indtast i \n feltet, og tryk enter igen for at bekræfte.");
                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                Console.SetCursorPosition(70, 23);
                                Console.WriteLine("ESC for at gå tilbage");
                                Console.ResetColor();

                                List<SommerhusClass> sommerhusList = new List<SommerhusClass>();
                                sommerhusList = SommerhusClass.LavSommerListe();
                                List<string> newSommerhus = new List<string>();
                                int i = 1;
                                foreach (var item in sommerhusList)
	                            {
                                    if (i == menuCounter)
	                                {
                                        
                                        newSommerhus.Add(item.Adresse);
                                        newSommerhus.Add(item.FornavnEjer);
                                        newSommerhus.Add(item.EfternavnEjer);
                                        newSommerhus.Add(item.Klassificering);
                                        newSommerhus.Add(item.Stoerrelse.ToString());
                                        newSommerhus.Add(item.Senge.ToString());
                                        newSommerhus.Add(item.StandardUgePris.ToString());
                                        newSommerhus.Add(item.Opsynsmand);
                                        newSommerhus.Add(item.Godkendt);
                                    }
                                    i++;
	                            }
                                

                            }else if (currentMenu.Equals("Reservation"))
                            {
                                List<Reservation> ReservationList = new List<Reservation>();
                                ReservationList = Reservation.CreateReservationList();

                                foreach (var item in ReservationList)
	                            {
                                    Console.WriteLine(item.MySommerhusID);
	                            }
                                string abbb = " " + PrisUdregner("5" , 3000);

                                Console.WriteLine(abbb);
                                Console.ReadLine();

                                //Create New Reservation

                                DateTime tempdate = new DateTime(2019,07,21);
                            

                                Reservation Res1 = new Reservation(2, 1, tempdate,"Super",30304040,"Lauge");
                                //Res1.InsertDB();

                                //Res1.KundeNavn = "YAYYSAYYAY";
                                //Res1.EditDB(2);

                                //Res1.DeleteDB(5);



                            }else if (currentMenu.Equals("Konsulent"))
                            {
                                List<Konsulent> KonsulentList = new List<Konsulent>();
                                KonsulentList = Konsulent.CreateKonsulentList();

                                foreach (var item in KonsulentList)
	                            {
                                    Console.WriteLine(item.Fornavn + " " + item.Efternavn);
	                            }
                            }else if (currentMenu.Equals("Område"))
                            {

                            }else if (currentMenu.Equals("Sæson"))
                            {

                            }
                            titleMenuBool = true;

                            //CREATE KONSULENT

                            //Konsulent kon1 = new Konsulent("Simon", "Juul", "Lyngvej 73", 50603010, 5000, 2400);
                            //kon1.InsertDB();
                            
                            //kon1.MyOmråde = 4000;
                            break;
                    }


                } while (!titleMenuBool);
            }
        }
        //Tester om dato og ugeforløb overlapper med en eksisterende reservation
        //returnere true, hvis de overlapper
        public static bool ugeReserveret(DateTime date, int uger)
        {
            //Test data, der burde blive hentet fra databasen
            DateTime dBDate = new DateTime(2019, 5, 1);
            int dBUger = 1;

            DateTime dBDateEnd = dBDate.AddDays(7 * dBUger);
            DateTime dateEnd = date.AddDays(7 * uger);

            if (date < dBDateEnd && dBDate < dateEnd)
            {
                return true;
            }
            else return false;

        }

        //returner uge til uge streng eks: 29-31
        public static string ugeNumre(DateTime dato,int ugeantal)
        {
            int uge = (dato.DayOfYear / 7) + 1;
            if (dato.DayOfWeek == DayOfWeek.Saturday || dato.DayOfWeek == DayOfWeek.Sunday)
            {
                uge++;
            }
            if (ugeantal < 1){
                return uge.ToString();
            }
            else
            {
                return $"{uge}-{uge + (ugeantal - 1)}";
            }
        }

        public static void typeRed()
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.Black;
        }

        public static double PrisUdregner(string ugenummer, double SommerhusUgepris)
        {
            int uge = Convert.ToInt32(ugenummer);
            double resultat = 0;

            if (uge >= 2 && uge <= 11)
	        {
                //Lav sæson
                resultat = SommerhusUgepris * 0.9;
	        }
            else if (uge >= 12 && uge <= 23 )
	        {
                //Mellem sæson
                resultat = SommerhusUgepris * 1.0;
	        }
            else if (uge == 1 || uge >= 48 && uge <=51 || uge >= 23 && uge <=27)
	        {
                //Høj sæson
                resultat = SommerhusUgepris * 1.6;
	        }
            else if (uge >= 28 && uge <=30 || uge == 52)
	        {
                //Super sæson
                resultat = SommerhusUgepris * 2.0;
	        }

            return resultat;


        }



        
    }
}
