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
    }
}