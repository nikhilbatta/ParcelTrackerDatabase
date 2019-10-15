using System.Collections.Generic;

namespace Parcel.Models
{
    public class Category
    {
        public Category()
        {
            this.AllParcels = new HashSet<ParcelVariable>();
        }

        public int CategoryId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<ParcelVariable> AllParcels{ get; set; }
    }
}