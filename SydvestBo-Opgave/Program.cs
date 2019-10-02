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
                            

                            foreach (var item in menu)
	                        {
                                
                                counter++;
                                if (counter < menu.Count())
	                            {

                                    Console.SetCursorPosition(1, lineCounter);
                                    Console.ForegroundColor = ConsoleColor.Red;
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
                                    Console.ResetColor();
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
                        }else if (currentMenu.Equals("RedigerSommerhus"))
                        {
                            counter = 0;

                            foreach (var item in menu)
	                        {

                                counter++;
                                if (counter < menu.Count())
	                            {

                                    Console.SetCursorPosition(1, lineCounter);
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    switch (counter)
                                    {
                                        case 1:
                                            Console.Write("Adresse: ");
                                            break;
                                        case 2:
                                            Console.Write("Ejer Fornavn: ");
                                            break;
                                        case 3:
                                            Console.Write("Ejer Efternavn: ");
                                            break;
                                        case 4:
                                            Console.Write("Kvalificering: ");
                                            break;
                                        case 5:
                                            Console.Write("Størrelse: ");
                                            break;
                                        case 6:
                                            Console.Write("Antal senge: ");
                                            break;
                                        case 7:
                                            Console.Write("Uge pris: ");
                                            break;
                                        case 8:
                                            Console.Write("Opsynsmand: ");
                                            break;
                                        case 9:
                                            Console.Write("Status: ");
                                            break;

                                    }
                                    Console.ResetColor();
                                    if(counter.Equals(menuCounter))
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
                        } else if (currentMenu.Equals("RedigerReservation"))
                        {
                            counter = 0;

                            foreach (var item in menu)
	                        {

                                counter++;
                                if (counter < menu.Count() -1)
	                            {

                                    Console.SetCursorPosition(1, lineCounter);
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    switch (counter)
                                    {
                                        case 1:
                                            Console.Write("Adresse: ");
                                            break;
                                        case 2:
                                            Console.Write("Tidspunkt: ");
                                            break;
                                        case 3:
                                            Console.Write("Sæson: ");
                                            break;
                                        case 4:
                                            Console.Write("Kunde: ");
                                            break;
                                        case 5: 
                                            Console.Write("kunde Tlf: ");
                                            break;
                                        case 6:
                                            Console.Write("Samlet pris: ");
                                                break;
                                    }
                                    Console.ResetColor();
                                    if(counter.Equals(menuCounter))
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
                        } else if (currentMenu.Equals("RedigerKonsulent"))
                        {
                            counter = 0;

                            foreach (var item in menu)
	                        {

                                counter++;
                                if (counter < menu.Count())
	                            {
                                    Console.SetCursorPosition(1, lineCounter);
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    switch (counter)
                                    {
                                        case 1:
                                            Console.Write("Fornavn: ");
                                            break;
                                        case 2:
                                            Console.Write("Efternavn");
                                            break;
                                        case 3:
                                            Console.Write("Adresse: ");
                                            break;
                                        case 4:
                                            Console.Write("PostNr: ");
                                            break;
                                        case 5:
                                            Console.Write("Tlf: ");
                                            break;
                                        case 6:
                                            Console.Write("Område: ");
                                            break;

                                    }
                                    Console.ResetColor();
                                    if(counter.Equals(menuCounter))
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
                        } else if (currentMenu.Equals("RedigerOmråde"))
                        {
                            counter = 0;

                            foreach (var item in menu)
	                        {

                                counter++;
                                
                                Console.SetCursorPosition(1, lineCounter);
                                Console.ForegroundColor = ConsoleColor.Red;
                                switch (counter)
                                {
                                    case 1:
                                        Console.Write("Område: ");
                                        break;
                                    case 2:
                                        Console.Write("By navn: ");
                                        break;
                                }
                                Console.ResetColor();
                                if(counter.Equals(menuCounter))
                                {
                                    typeRed();
                                    Console.Write(item.ToString());
                                    Console.ResetColor();
                                } else
                                {
                                    Console.Write(item.ToString());
                                }
                                lineCounter++;
	                        }
                        } else if (currentMenu.Equals("RedigerSæson"))
                        {
                            counter = 0;

                            foreach (var item in menu)
	                        {

                                counter++;
                                
                                Console.SetCursorPosition(1, lineCounter);
                                Console.ForegroundColor = ConsoleColor.Red;
                                switch (counter)
                                {
                                    case 1:
                                        Console.Write("Sæson kategori: ");
                                        break;
                                    case 2:
                                        Console.Write("Pris fordobbler: ");
                                        break;
                                    case 3:
                                        Console.Write("Uger: ");
                                        break;
                                }
                                Console.ResetColor();
                                if(counter.Equals(menuCounter))
                                {
                                    typeRed();
                                    Console.Write(item.ToString());
                                    Console.ResetColor();
                                } else
                                {
                                    Console.Write(item.ToString());
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
                        case ConsoleKey.Escape:
                            Console.BackgroundColor = ConsoleColor.DarkBlue;
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.SetCursorPosition(10, 6);
                            Console.Write(":(");
                            Console.SetCursorPosition(10, 8);
                            Console.Write("Your PC ran into a problem and needs to restart. We're");
                            Console.SetCursorPosition(10, 9);
                            Console.Write("just collecting some error info, and then we'll restart for");
                            Console.SetCursorPosition(10, 10);
                            Console.Write("you.");
                            Console.SetCursorPosition(10, 13);
                            Console.Write("20% Complete...");
                            Console.ReadKey();
                            Environment.Exit(0);
                           
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

            } else if (currentMenu.Equals("RedigerEjer") || currentMenu.Equals("RedigerSommerhus") || currentMenu.Equals("RedigerReservation") ||
                        currentMenu.Equals("RedigerKonsulent") || currentMenu.Equals("RedigerOmråde") || currentMenu.Equals("RedigerSæson"))
            {
                int menuIDIList = 1;
                if (currentMenu.Equals("RedigerReservation"))
                {
                    menuIDIList = 2;
                }else if (currentMenu.Equals("RedigerOmråde") || currentMenu.Equals("RedigerSæson"))
                {
                    menuIDIList = 0;
                }
                do {
                    var ch = Console.ReadKey().Key;
                    switch (ch)
                    {

                        case ConsoleKey.UpArrow:
                            if (menuCounter == 1)
                            {
                                menuCounter = menu.Count() - menuIDIList;
                                DynamicChoosing(firstWrite, menu, menuCounter, currentMenu);
                            }
                            else 
                            {
                                menuCounter--;
                                DynamicChoosing(firstWrite, menu, menuCounter, currentMenu);
                            }
                            break;

                        case ConsoleKey.DownArrow:
                            if (menuCounter == menu.Count() - menuIDIList)
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
                            switch (currentMenu)
                            {
                                case "RedigerEjer":
                                    currentMenu = "SommerhusEjer";
                                    CreateSommerhusEjerScreen(currentMenu);
                                    break;
                                case "RedigerSommerhus":
                                    currentMenu = "Sommerhus";
                                    CreateSommerhusScreen(currentMenu);
                                    break;
                                case "RedigerReservation":
                                    currentMenu = "Reservation";
                                    CreateReservationScreen(currentMenu);
                                    break;
                                case "RedigerKonsulent":
                                    currentMenu = "Konsulent";
                                    CreateKonsulentScreen(currentMenu);
                                    break;
                                case "RedigerOmråde":
                                    currentMenu = "Område";
                                    createOmrådeScreen(currentMenu);
                                    break;
                                case "RedigerSæson":
                                    currentMenu = "Sæson";
                                    createSæsonScreen(currentMenu);
                                    break;
                            }
                            
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
                            currentMenu = "Main";
                            createMainScreen(currentMenu);
	                        
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
                                Console.SetCursorPosition(1, 22);
                                Console.Write("INSERT for at bekræfte ændringer");
                                Console.SetCursorPosition(1, 23);
                                Console.Write("DELETE for at slette Ejer");
                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                Console.SetCursorPosition(60, 23);
                                Console.WriteLine("ESC for at fortryde og gå tilbage");
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
                                Console.SetCursorPosition(1, 22);
                                Console.Write("INSERT for at bekræfte ændringer");
                                Console.SetCursorPosition(1, 23);
                                Console.Write("DELETE for at slette Sommerhus");
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
                                        newSommerhus.Add(item.SommerHusID.ToString());

                                    }
                                    i++;
	                            }

                                currentMenu = "RedigerSommerhus";
                                DynamicChoosing(firstWrite, newSommerhus, 1, currentMenu);
                                MenuOptions(newSommerhus, currentMenu);

                            }else if (currentMenu.Equals("Reservation"))
                            {

                                Console.Clear();

                                Console.SetCursorPosition(1, 1);
                                Console.WriteLine("Reservation oplysninger:");
                                Console.SetCursorPosition(1, 3);
                                Console.WriteLine($"Brug piletasterne, og Enter, for at vælge et felt, indtast i \n feltet, og tryk enter igen for at bekræfte.");
                                Console.SetCursorPosition(1, 22);
                                Console.Write("INSERT for at bekræfte ændringer");
                                Console.SetCursorPosition(1, 23);
                                Console.Write("DELETE for at slette Reservation");
                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                Console.SetCursorPosition(70, 23);
                                Console.WriteLine("ESC for at gå tilbage");
                                Console.ResetColor();

                                List<Reservation> reservationList = new List<Reservation>();
                                reservationList = Reservation.CreateReservationList();
                                List<string> newReservation = new List<string>();
                                
                                int i = 1;
                                foreach (var item in reservationList)
	                            {
                                    if (i == menuCounter)
	                                {
                                        newReservation.Add(item.SommerhusAddresse);
                                        newReservation.Add(ugeNumre(item.StartDato, item.Dage));
                                        newReservation.Add(item.Sæson);
                                        newReservation.Add(item.KundeNavn);
                                        newReservation.Add(item.MyKundeTlf.ToString());
                                        //newReservation.Add(PrisUdregner(item.Dage, item.Salgspris));
                                        newReservation.Add(item.MySommerhusID.ToString());
                                        newReservation.Add(item.MyReservationID.ToString());
                                    }
                                    i++;
	                            }

                                currentMenu = "RedigerReservation";
                                DynamicChoosing(firstWrite, newReservation, 1, currentMenu);
                                MenuOptions(newReservation, currentMenu);

                            }else if (currentMenu.Equals("Konsulent"))
                            {

                                Console.Clear();

                                Console.SetCursorPosition(1, 1);
                                Console.WriteLine("Udlejningskonsulent oplysninger:");
                                Console.SetCursorPosition(1, 3);
                                Console.WriteLine($"Brug piletasterne, og Enter, for at vælge et felt, indtast i \n feltet, og tryk enter igen for at bekræfte.");
                                Console.SetCursorPosition(1, 22);
                                Console.Write("INSERT for at bekræfte ændringer");
                                Console.SetCursorPosition(1, 23);
                                Console.Write("DELETE for at slette Konsulent");
                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                Console.SetCursorPosition(70, 23);
                                Console.WriteLine("ESC for at gå tilbage");
                                Console.ResetColor();

                                List<Konsulent> konsulentList = new List<Konsulent>();
                                konsulentList = Konsulent.CreateKonsulentList();
                                List<string> newKonsulent = new List<string>();
                                int i = 1;
                                foreach (var item in konsulentList)
	                            {
                                    if (i == menuCounter)
	                                {
                                        newKonsulent.Add(item.Fornavn);
                                        newKonsulent.Add(item.Efternavn);
                                        newKonsulent.Add(item.Addresse);
                                        newKonsulent.Add(item.MyPostNr.ToString());
                                        newKonsulent.Add(item.MykonsulentTlf.ToString());
                                        newKonsulent.Add(item.MyOmråde.ToString());
                                        newKonsulent.Add(item.MyKonsulentID.ToString());
                                    }
                                    i++;
	                            }

                                currentMenu = "RedigerKonsulent";
                                DynamicChoosing(firstWrite, newKonsulent, 1, currentMenu);
                                MenuOptions(newKonsulent, currentMenu);

                            }else if (currentMenu.Equals("Område"))
                            {
                                Console.Clear();

                                Console.SetCursorPosition(1, 1);
                                Console.WriteLine("Område oplysninger:");
                                Console.SetCursorPosition(1, 3);
                                Console.WriteLine($"Brug piletasterne, og Enter, for at vælge et felt, indtast i \n feltet, og tryk enter igen for at bekræfte.");
                                Console.SetCursorPosition(1, 23);
                                Console.Write("INSERT for at bekræfte ændringer");
                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                Console.SetCursorPosition(70, 23);
                                Console.WriteLine("ESC for at gå tilbage");
                                Console.ResetColor();

                                List<Område> områdeList = new List<Område>();
                                områdeList = Område.createOmrådeList();
                                List<string> newOmråde = new List<string>();
                                int i = 1;
                                foreach (var item in områdeList)
	                            {
                                    if (i == menuCounter)
	                                {
                                        
                                        newOmråde.Add(item.postNr.ToString());
                                        newOmråde.Add(item.områdeBy);
                                    }
                                    i++;
	                            }

                                currentMenu = "RedigerOmråde";
                                DynamicChoosing(firstWrite, newOmråde, 1, currentMenu);
                                MenuOptions(newOmråde, currentMenu);
                            }else if (currentMenu.Equals("Sæson"))
                            {
                                Console.Clear();

                                Console.SetCursorPosition(1, 1);
                                Console.WriteLine("Sæson oplysninger:");
                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                Console.SetCursorPosition(70, 23);
                                Console.WriteLine("ESC for at gå tilbage");
                                Console.ResetColor();
                                List<string> newSæson = new List<string>();
                                if (menuCounter == 1)
                                {

                                    newSæson.Add("Lav");
                                    newSæson.Add("0.9");
                                    newSæson.Add("2, 3, 4, 5, 6, 7, 8, 9, 10, 11");

                                } else if (menuCounter == 2)
                                {
                                    newSæson.Add("Mellem");
                                    newSæson.Add("1.0");
                                    newSæson.Add("1, 23, 24, 25, 26, 27, 48, 49, 50, 51");

                                } else if (menuCounter == 3)
                                {
                                    newSæson.Add("Høj");
                                    newSæson.Add("1.6");
                                    newSæson.Add("12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22");
                                } else if (menuCounter == 4)
                                {
                                    newSæson.Add("Super");
                                    newSæson.Add("2.0");
                                    newSæson.Add("28, 29, 30, 52");
                                }
                                
                                currentMenu = "RedigerSæson";
                                DynamicChoosing(firstWrite, newSæson, 1, currentMenu);
                                MenuOptions(newSæson, currentMenu);
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

        public static string PrisUdregner(string ugenummer, double SommerhusUgepris)
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

            return resultat.ToString();


        }



        
    }
}
