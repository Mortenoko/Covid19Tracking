using System;

namespace Covid19Tracking
{
    class Program
    {
        static CovidDbContext db = new CovidDbContext();

        static void Main(string[] args)
        {
            var cd = new CreateDummy();

            //cd.DummyCitizen(db);
            //cd.DummyTestCenter(db);
            //cd.DummyManagement(db);
            cd.DummyTestCase(db, "80085123", "Ghetto");
            cd.DummyLocation(db);
        }
    }
}
