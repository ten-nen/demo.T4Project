using System;
 
namespace T4Project.Models
{
    /// <summary>
    /// Represents a Template.
    /// NOTE: This class is generated from a T4 template - you should not modify it manually.
    /// </summary>
    public partial class Template 
    {
        public Int64? Id { get; set; }
 
        public string Name { get; set; }
 
        public int? FreightType { get; set; }
 
        public int? PricingType { get; set; }
 
        public int? ExpressType { get; set; }
 
        public bool? IsCondition { get; set; }
    }
}      
