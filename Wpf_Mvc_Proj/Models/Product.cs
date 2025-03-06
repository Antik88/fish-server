using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wpf_Mvc_Proj.Models
{
    [Table("product")]
    public class Product
    {
        [Column("product_id")]
        public int ProductId { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("origin_region_id")]
        public int? OriginRegionId { get; set; }

        [Column("Selection_date")]
        public DateTime? SelectionDate { get; set; }

        [Column("Weight_product")]
        public float? WeightProduct { get; set; }

        [Column("Expiration_date")]
        public int? ExpirationDate { get; set; }

        [Column("Length_TL")]
        public float? LengthTL { get; set; }

        [Column("Lenth_Sl")]
        public float? LengthSl { get; set; }

        [Column("Lenth_Fl")]
        public float? LengthFl { get; set; }

        [Column("K")]
        public float? K { get; set; }

        [Column("Mn_ug_kg")]
        public float? MnUgKg { get; set; }

        [Column("Mn_ug_kg_sy")]
        public float? MnUgKgSy { get; set; }

        [Column("Co_ug_kg")]
        public float? CoUgKg { get; set; }

        [Column("Co_ug_kg_sy")]
        public float? CoUgKgSy { get; set; }

        [Column("Ni_ug_kg")]
        public float? NiUgKg { get; set; }

        [Column("Ni_ug_kg_sy")]
        public float? NiUgKgSy { get; set; }

        [Column("Cu_mg_kg")]
        public float? CuMgKg { get; set; }

        [Column("Cu_mg_kg_sy")]
        public float? CuMgKgSy { get; set; }

        [Column("Zn_mg_kg")]
        public float? ZnMgKg { get; set; }

        [Column("Zn_mg_kg_sy")]
        public float? ZnMgKgSy { get; set; }

        [Column("As_mg_kg")]
        public float? AsMgKg { get; set; }

        [Column("As_mg_kg_sy")]
        public float? AsMgKgSy { get; set; }

        [Column("Se_ug_kg")]
        public float? SeUgKg { get; set; }

        [Column("Se_ug_kg_sy")]
        public float? SeUgKgSy { get; set; }

        [Column("Cd_ug_kg")]
        public float? CdUgKg { get; set; }

        [Column("Cd_ug_kg_sy")]
        public float? CdUgKgSy { get; set; }

        [Column("Hg_ug_kg")]
        public float? HgUgKg { get; set; }

        [Column("Hg_ug_kg_sy")]
        public float? HgUgKgSy { get; set; }

        [Column("Pb_ug_kg")]
        public float? PbUgKg { get; set; }

        [Column("Pb_ug_kg_sy")]
        public float? PbUgKgSy { get; set; }

        [Column("safety_score")]
        public float? SafetyScore { get; set; }

        [Column("origin_info")]
        public string OriginInfo { get; set; }
    }

}