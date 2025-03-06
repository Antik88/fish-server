using System.ComponentModel.DataAnnotations.Schema;

namespace Wpf_Mvc_Proj.Models
{
    [Table("Region")]
    public class Region
    {
        [Column("region_id")]
        public int RegionId { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("Area")]
        public string Area { get; set; }

        [Column("City")]
        public string City { get; set; }

        [Column("latitude")]
        public float? Latitude { get; set; }

        [Column("longitude")]
        public float? Longitude { get; set; }

        [Column("habitat_info")]
        public string HabitatInfo { get; set; }

        [Column("environmental_quality_id")]
        public int? EnvironmentalQualityId { get; set; }
    }

}