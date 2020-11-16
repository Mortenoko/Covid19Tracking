using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Covid19Tracking
{
    class CreateDummy
    {
        public void DummyCitizen(CovidDbContext db)
        {
            Console.WriteLine("Indtast fornavn\n");
            string Fornavn = Console.ReadLine();

            Console.WriteLine("Indtast efternavn\n");
            string Efternavn = Console.ReadLine();

            Console.WriteLine("Indtast alder\n");
            int Alder = int.Parse(Console.ReadLine());

            Console.WriteLine("Indtast køn\n");
            string Sex = Console.ReadLine();

            Console.WriteLine("Indtast personnummer som 10 tal\n");
            string PersonNr = Console.ReadLine();

            Console.WriteLine("Indtast regions ID 1-7. Du trækker i så fald en tilfældig region. Undgå Sjælland ");
            int PostNr = int.Parse(Console.ReadLine());

            var DummyCit = new Citizen();
            DummyCit.FirstName = Fornavn;
            DummyCit.LastName = Efternavn;
            DummyCit.age = Alder;
            DummyCit.Sex = Sex;
            DummyCit.SSN = PersonNr;
            DummyCit.MunicipalityID = PostNr;
               
            db.Add(DummyCit);
            db.SaveChanges();

            Console.WriteLine("Dummy citizen er oprettet nu\n");
            Thread.Sleep(5000);
            Console.Clear();
        }

        public void DummyTestCenter(CovidDbContext db)
        {
            Console.WriteLine("Indtast center navn\n");
            string CenterNavn = Console.ReadLine();

            Console.WriteLine("Indtast åbningstider\n");
            string Hours = (Console.ReadLine());

            Console.WriteLine("Indtast regions ID for testcentret\n");
            int TCPostNr = int.Parse(Console.ReadLine());

            var DummyTC = new TestCenter()
            {
                centerName = CenterNavn,
                Hours = Hours,
                MunicipalityID = TCPostNr
            };

            db.Add(DummyTC);
            db.SaveChanges();

            Console.WriteLine("Dummy test center er oprettet nu\n");
            Thread.Sleep(5000);
            Console.Clear();
        }


        public void DummyManagement(CovidDbContext db)
        {
            Console.WriteLine("Indtast testcenter telefonnummer 8 tal\n");
            int ManageNr = int.Parse(Console.ReadLine());

            Console.WriteLine("Indtast testcentres email\n");
            string ManageMail = Console.ReadLine();

            Console.WriteLine("Indtast navn for management\n");
            string ManageName = Console.ReadLine();

            var DummyMan = new TestCenterManagement
            {
                phoneNum = ManageNr,
                email = ManageMail,
                centerName = ManageName
            };

            db.Add(DummyMan);
            db.SaveChanges();

            Console.WriteLine("Dummy management er oprettet nu\n");
            Thread.Sleep(5000);
            Console.Clear();

        }

        public void DummyTestCase(CovidDbContext db, string ssn, string centerName)
        {
            var FindCit = db.citizens.Find(ssn);
            var FindTestCenter = db.testCenters.Find(centerName);
            var CitizenTestedAt = new TestedAt();
            CitizenTestedAt.SSN = FindCit.SSN;
            CitizenTestedAt.centerName = FindTestCenter.centerName;

            Console.WriteLine("Indtast Dato for test (Format: mm/dd/yyyy\n");
            DateTime DummyDate = DateTime.Parse(Console.ReadLine());
            CitizenTestedAt.date = DummyDate;

            Console.WriteLine("Indtast teststatus, enten Done eller Not Done\n");
            string DummyStatus = Console.ReadLine();
            CitizenTestedAt.status = DummyStatus;



            Console.WriteLine("Indtast testresultat. P for påvist, N for negativ\n");

            string TestResult = Console.ReadLine();

            if (TestResult == "P")
            {
                CitizenTestedAt.result = "Positiv";
            }
            else if (TestResult =="N")
            {
                CitizenTestedAt.result = "Negativ";
            }


            db.Add(CitizenTestedAt);
            db.SaveChanges();

            Console.WriteLine("Dummy testcase er oprettet nu\n");
            Thread.Sleep(5000);
            Console.Clear();
        }

        public void DummyLocation(CovidDbContext db)
        {
            Console.WriteLine("Indtast adresse\n");
            string DummyAddr = Console.ReadLine();

            Console.WriteLine("Indtast regions ID for nuværende adresse\n");
            int DummyLocPostNr = int.Parse(Console.ReadLine());

            var DummyLoc = new Location()
            {
                Addr = DummyAddr,
                MunicipalityID = DummyLocPostNr
            };

            db.Add(DummyLoc);
            db.SaveChanges();

            Console.WriteLine("Dummy location er oprettet nu\n");
            Thread.Sleep(5000);
            Console.Clear();


        }



    }
}
