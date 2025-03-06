using System.ComponentModel.DataAnnotations.Schema;

namespace Wpf_Mvc_Proj.Models
{
    [Table("sales_point")]
    public class SalesPoint
    {
        [Column("sales_point_id")]
        public int SalesPointId { get; set; }

        [Column("region_id")]
        public int RegionId { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("address")]
        public string Address { get; set; }

        [Column("working_hours")]
        public string WorkingHours { get; set; }
    }

}