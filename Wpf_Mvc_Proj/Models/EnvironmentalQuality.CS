using System.ComponentModel.DataAnnotations.Schema;

namespace Wpf_Mvc_Proj.Models
{
    [Table("EnvironmentalQuality")]
    public class EnvironmentalQuality
    {
        [Column("quality_id")]
        public int QualityId { get; set; }

        [Column("region_id")]
        public int? RegionId { get; set; }

        [Column("pollution_level")]
        public string PollutionLevel { get; set; }

        [Column("pollutants")]
        public string Pollutants { get; set; }

        [Column("assessment_date")]
        public DateTime? AssessmentDate { get; set; }
    }
}
