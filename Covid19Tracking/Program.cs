using System;

namespace Covid19Tracking
{
    class Program
    {
        static CovidDbContext db = new CovidDbContext();

        static void Main(string[] args)
        {
            var cd = new CreateDummy();


            do
            {
                Console.WriteLine("Nu kommer dit valg \n"
                    + "Indtast 'B' for at oprette en borger\n"
                    + "Indtast 'T' hvis du er oprettet som borger i systemet, så du kan oprette Test Center og Test Management\n"
                    + "Indtast 'L' for at oprette lokation\n"
                    + "Indtast 'C' hvis du er blevet testet\n"
                    + "Indtast 'E' for at lukke\n");


                string valg = Console.ReadLine();

                switch (valg)
                {
                    case "B":
                        cd.DummyCitizen(db);
                        break;

                    case "T":
                        cd.DummyTestCenter(db);
                        cd.DummyManagement(db);
                        break;

                    case "L":
                        cd.DummyLocation(db);
                        break;

                    case "C":
                        Console.WriteLine("Indtast CPR nummer oplyst ved oprettelse af borger");
                        string CPR = Console.ReadLine();
                        Console.WriteLine("Indtast Testcenter du blev testet ved");
                        string TestetVed = Console.ReadLine();


                        cd.DummyTestCase(db, CPR, TestetVed);
                        break;

                    case "E":
                        Environment.Exit(0);
                        break;
                }
            } while (true);
        }
    }
}
