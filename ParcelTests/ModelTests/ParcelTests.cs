using MySql.Data.MySqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Parcel.Models;
using System;
using Parcel;


namespace Parcel.Tests
{

  [TestClass]
  public class ParcelTest : IDisposable
  {
    
    public void Dispose()
    {
      ParcelVariable.ClearAll();
    }
    
    public ParcelTest()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=epicodus;port=3306;database=parcel_test;";
    }

    [TestMethod]
    public void Equals_ReturnsTrueIfPropertiesAreTheSame_Parcel()
    {
      // Arrange, Act
      ParcelVariable firstParcel = new ParcelVariable(1,2,3,4,"string");
      ParcelVariable secondParcel = new ParcelVariable(1,2,3,4,"string");

      // Assert
      Assert.AreEqual(firstParcel, secondParcel);
    }
    [TestMethod]
       public void Find_ReturnsCorrectItemFromDatabase_Parcel()
    {
      //Arrange
      ParcelVariable newParcel = new ParcelVariable(1,2,3,4,"string");
      newParcel.Save();
      ParcelVariable newParcel2 = new ParcelVariable(1,2,3,4,"string");
      newParcel2.Save();

      //Act
      ParcelVariable parcelFound = ParcelVariable.Find(newParcel.ID);
      //Assert
      Assert.AreEqual(newParcel, parcelFound);
    }
  }
}