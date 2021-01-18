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
                    + "Indtast 'E' for at lukke\n"
                    + "Indtast 'S' for at søge\n");


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
                    case "S":
                        Console.Clear();

                        do
                        {
                            Console.WriteLine("Nu kommer dit valg \n"
                                            + "Indtast 'N' for at søge efter navn\n"
                                            + "Indtast 'A' for at søge efter aldersgruppe\n"
                                            + "Indtast 'K' for at søge efter køn\n"
                                            + "Indtast 'M' for at søge efter municipality\n"
                                            + "Indtast 'E' for at lukke\n");

                            string sValg = Console.ReadLine();

                            switch (sValg)
                            {
                                case "N":
                                    cd.ViewDummyCitizen(db);
                                    break;
                                case "A":
                                    cd.ViewDummyByAge(db);
                                    break;
                                case "M":
                                    cd.ViewDummyByMunicipality(db);
                                    break;
                            }
                        } while (true);
                } 
            } while (true);
        }
    }
}
