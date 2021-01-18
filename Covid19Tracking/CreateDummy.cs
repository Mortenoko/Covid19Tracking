using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Linq;
using ConsoleTables;

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
            int DoWhileFlag = 0;

            do
            {

                if (TestResult == "P")
                {
                    CitizenTestedAt.result = "Positiv";

                    DoWhileFlag = 1;

                    using (var DbContext = new CovidDbContext())
                        {
                        var ViewTestResult = DbContext.citizenLocations.Where(c => c.SSN == ssn).ToList();


                            foreach(CitizenLocation CitLoc in ViewTestResult)
                            {
                            var Adr = CitLoc.Addr;
                            var ViewTestResult2 = DbContext.citizenLocations.Where(c => c.Addr == Adr).ToList();
                            var InfTable = new ConsoleTable();
                            

                            foreach(CitizenLocation CitLoc2 in ViewTestResult2 )
                            {
                                if(CitLoc2.SSN == CitLoc.SSN)
                                {
                                    //Samme
                                }
                                else
                                {
                                    var DummyCitizenInf = DbContext.citizenLocations.Where(c => c.SSN == CitLoc2.SSN && c.date == CitLoc.date && CitizenTestedAt.date == CitLoc2.date);
                                    foreach(var item in DummyCitizenInf)
                                    {
                                        InfTable.AddRow(item.SSN);
                                    }
                                }
                            }
                            InfTable.Write();
                            }   


                        }

                }
                else if (TestResult == "N")
                {
                    CitizenTestedAt.result = "Negativ";
                    DoWhileFlag = 1;
                }
            } while (DoWhileFlag == 0);





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

        public void ViewDummyCitizen(CovidDbContext db)
        {
            using (var DbContext = new CovidDbContext())
            {
                Console.WriteLine("Søg efter navn - indtast fornavn her:");
                string ViewCitizen = Console.ReadLine();

                var dummyCitizen = DbContext.citizens.Where(c => c.FirstName.Contains(ViewCitizen)).ToList();

                var VDCTable = new ConsoleTable("Fornavn", "Efternavn", "Alder", "SSN", "Køn");


                foreach (Citizen DC in dummyCitizen)
                {
                    VDCTable.AddRow(DC.FirstName, DC.LastName, DC.age, DC.SSN, DC.Sex);
                }

                VDCTable.Write();
            }
            Thread.Sleep(5000);
            Console.Clear();
        }

        public void ViewDummyByAge(CovidDbContext db)
        {
            using (var DbContext = new CovidDbContext())
            {
                List<TestedAt> temp_ = new List<TestedAt>();

                Console.WriteLine("Vælg aldersgruppe. Vi diskriminerer og anerkender ikke mennesker over 50 år.\n" +
                    " Aldersgruppe 1: 1-10\n" +
                    " Aldersgruppe 2: 11-20\n" +
                    " OSV - you get the drill");

                int AgeGrp = int.Parse(Console.ReadLine());



                switch (AgeGrp)
                {
                    case 1:
                        var temp = DbContext.testedAts.Where(c => c.citizen.age >= 0 && c.citizen.age <= 10).ToList();
                        temp_ = temp;
                        break;

                    case 2:
                        temp = DbContext.testedAts.Where(c => c.citizen.age >= 11 && c.citizen.age <= 20).ToList();
                        temp_ = temp;
                        break;
                    case 3:
                        temp = DbContext.testedAts.Where(c => c.citizen.age >= 21 && c.citizen.age <= 30).ToList();
                        temp_ = temp;
                        break;
                    case 4:
                        temp = DbContext.testedAts.Where(c => c.citizen.age >= 31 && c.citizen.age <= 40).ToList();
                        temp_ = temp;
                        break;
                    case 5:
                        temp = DbContext.testedAts.Where(c => c.citizen.age >= 41 && c.citizen.age <= 50).ToList();
                        temp_ = temp;
                        break;
                }

                int cases = 0;

                foreach (TestedAt TA in temp_)
                {
                    if (TA.result == "Positiv")
                        cases++;
                }

                var ageTable = new ConsoleTable("Positive");
                ageTable.AddRow(cases);
                ageTable.Write();
            }
            Thread.Sleep(5000);
            Console.Clear();
        }

        public void ViewDummyByMunicipality(CovidDbContext db)
        {
            List<TestedAt> temp_ = new List<TestedAt>();
            int cases = 0;
            DateTime dt = DateTime.Now;
            using (var DbContext = new CovidDbContext())
            {
                Console.WriteLine("Indtast Municipality ID");
                int munId = int.Parse(Console.ReadLine());

                var temp = DbContext.testedAts.Where(c => c.citizen.MunicipalityID == munId).ToList();
                temp_ = temp;

                dt = dt.AddDays(-14);


                foreach(TestedAt TA in temp_)
                {
                    float compare = dt.CompareTo(TA.date);

                    if (TA.result == "Positiv" && compare <= 0)
                        cases++;
                }

                var munTable = new ConsoleTable("Positive per municipality ID");
                munTable.AddRow(cases);
                munTable.Write();
            }
            Thread.Sleep(5000);
            Console.Clear();
        }


    }
}
