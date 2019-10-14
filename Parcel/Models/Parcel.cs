using System.Collections.Generic;
using MySql.Data.MySqlClient;
namespace Parcel.Models
{
    public class ParcelVariable
    {
        public int SideA { get; set; }
        public int SideB { get; set; }
        public int SideC { get; set; }
        public int Weight {get; set; }
        public string Note { get; set; }
        public int ID {get;set;}

       
       
        public ParcelVariable(int parcelID, int sideA, int sideB, int sideC, int weight, string note)
        {
            SideA = sideA;
            SideB = sideB;
            SideC = sideC;
            Weight = weight;
            Note = note;
            ID = parcelID;
        }
        public ParcelVariable(int sideA, int sideB, int sideC, int weight, string note)
        {
            SideA = sideA;
            SideB = sideB;
            SideC = sideC;
            Weight = weight;
            Note = note;
            Save();



        }

        public void Save()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;

            cmd.CommandText = @"INSERT INTO parcel_table (sideA, sideB, sideC, weight, note) VALUES (@sideA, @sideB, @sideC, @weight, @note)";
            MySqlParameter sideA = new MySqlParameter();
            sideA.ParameterName = "@sideA";
            sideA.Value = this.SideA;
            MySqlParameter sideB = new MySqlParameter();
            sideB.ParameterName = "@sideB";
            sideB.Value = this.SideB;
            MySqlParameter sideC = new MySqlParameter();
            sideC.ParameterName = "@sideC";
            sideC.Value = this.SideC;
            MySqlParameter weight = new MySqlParameter();
            weight.ParameterName = "@weight";
            weight.Value = this.Weight;
            MySqlParameter note = new MySqlParameter();
            note.ParameterName = "@note";
            note.Value = this.Note;
            cmd.Parameters.Add(sideA);
            cmd.Parameters.Add(sideB);
            cmd.Parameters.Add(sideC);
            cmd.Parameters.Add(weight);
            cmd.Parameters.Add(note);
            cmd.ExecuteNonQuery();
            ID = (int) cmd.LastInsertedId;

            conn.Close();
            if(conn!= null)
            {
                conn.Dispose();
            }

        }

        public static List<ParcelVariable> GetAll()
        {
            List<ParcelVariable> allParcels = new List<ParcelVariable>{ };
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"Select * FROM parcel_table;";
            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            while(rdr.Read())
            {
                int parcelID = rdr.GetInt32(0);
                int sideA = rdr.GetInt32(1);
                int sideB = rdr.GetInt32(2);
                int sideC = rdr.GetInt32(3);
                int weight = rdr.GetInt32(4);
                string description = rdr.GetString(5);
                ParcelVariable newParcel = new ParcelVariable(parcelID, sideA, sideB, sideC, weight, description);
                allParcels.Add(newParcel);
            }
            conn.Close();
            if(conn != null)
            {
                conn.Dispose();
            }
            return allParcels;

        }

        public int Volume()
        {
            return SideA * SideB * SideC; ;
        }

        public int CostToShip()
        {
            return Volume() * Weight;
        }

        public static ParcelVariable Find(int searchId)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"Select * from parcel_table WHERE ID = @thisID";

            MySqlParameter thisID = new MySqlParameter();
            thisID.ParameterName = "@thisID";
            thisID.Value = searchId;
            cmd.Parameters.Add(thisID);

            var rdr = cmd.ExecuteReader() as MySqlDataReader;
            int parcelID = 0;
            int sideA = 0;
            int sideB = 0;
            int sideC = 0;
            int weight = 0;
            string description = "";
            while(rdr.Read())
            {
                parcelID = rdr.GetInt32(0);
                sideA = rdr.GetInt32(1);
                sideB = rdr.GetInt32(2);
                sideC = rdr.GetInt32(3);
                weight = rdr.GetInt32(4);
                description = rdr.GetString(5);
            }
            ParcelVariable foundParcel = new ParcelVariable(parcelID, sideA, sideB, sideC, weight, description);
            if (conn != null)
            {
                conn.Dispose();
            }
            return foundParcel;
        }
        public static void ClearAll()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"TRUNCATE FROM items;";
            cmd.ExecuteNonQuery();
            conn.Close();
            if(conn!= null)
            {
                conn.Dispose();
            }
        }
    }
}