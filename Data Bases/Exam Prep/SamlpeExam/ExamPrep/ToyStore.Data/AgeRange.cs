//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ToyStore.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class AgeRange
    {
        public AgeRange()
        {
            this.Toys = new HashSet<Toy>();
        }
    
        public int id { get; set; }
        public int MinAge { get; set; }
        public Nullable<int> MaxAge { get; set; }
    
        public virtual ICollection<Toy> Toys { get; set; }
    }
}
