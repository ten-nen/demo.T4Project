using System;
 
namespace T4Project.Models
{
    /// <summary>
    /// Represents a FullCondition.
    /// NOTE: This class is generated from a T4 template - you should not modify it manually.
    /// </summary>
    public partial class FullCondition 
    {
        public Int64? Id { get; set; }
 
        public int? ExpressType { get; set; }
 
        public int? ConditionType { get; set; }
 
        public decimal? Val { get; set; }
 
        public Int64? AreaId { get; set; }
 
        public string GroupMark { get; set; }
 
        public bool? Enabled { get; set; }
    }
}      
