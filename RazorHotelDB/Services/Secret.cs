namespace RazorHotelDB.Services
{
    public static class Secret
    {
        private static string _connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=HotelDbtest2;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        //Dette er en test af secret...
        public static string ConnectionString
        {
            get { return _connectionString; }

        }
    }

}
