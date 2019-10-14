using MySql.Data.MySqlClient;


namespace Parcel.Tests
{

  [TestClass]
  public class ParcelTest : IDisposable
  {

    public void Dispose()
    {
      Parcel.ClearAll();
    }

    public ParcelTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=epicodus;port=3306;database=parcel_table_test;";
    }


  }
}