//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyPortfolioProjectNigth.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Intern
    {
        public int internID { get; set; }
        public string CompanyName { get; set; }
        public string InternDescription { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public string Supervisor { get; set; }
        public string SupervisorMail { get; set; }
    }
}
