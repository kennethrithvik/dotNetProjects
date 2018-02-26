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
    
    public partial class Employee
    {
        public Employee()
        {
            this.Employees = new HashSet<Employee>();
        }
    
        public int EmployeeID { get; set; }
        public string Name { get; set; }
        public System.DateTime DOB { get; set; }
        public Nullable<System.DateTime> DOJ { get; set; }
        public byte DepartmentID { get; set; }
        public byte RoleID { get; set; }
        public Nullable<int> MGRID { get; set; }
        public Nullable<byte> EmpStatus { get; set; }
    
        public virtual Department Department { get; set; }
        public virtual Login Login { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual Employee Manager { get; set; }
        public virtual Role Role { get; set; }
    }
}