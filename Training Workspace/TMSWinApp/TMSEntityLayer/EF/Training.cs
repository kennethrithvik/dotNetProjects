//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TMSEntityLayer.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class Training
    {
        public short TrainingID { get; set; }
        public string Title { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime EndDate { get; set; }
        public byte DomainID { get; set; }
        public Nullable<byte> Credits { get; set; }
        public byte Status { get; set; }
    
        public virtual Domain Domain { get; set; }
    }
}
