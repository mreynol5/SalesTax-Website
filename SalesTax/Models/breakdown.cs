using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace SalesTax.Models
{
	public class breakdown
	{
        [JsonPropertyName("taxable_amount")]
        public float TaxableAmount { get; set; }

        [JsonPropertyName("tax_collectable")]
        public float TaxCollectable { get; set; }

        [JsonPropertyName("combined_tax_rate")]
        public float CombinedTaxRate { get; set; }

        [JsonPropertyName("state_taxable_amount")]
        public float StateTaxableAmount { get; set; }

        [JsonPropertyName("state_tax_collectable")]
        public float StateTaxCollectable { get; set; }

        [JsonPropertyName("county_taxable_amount")]
        public float CountyTaxableAmount { get; set; }

        [JsonPropertyName("county_tax_rate")]
        public float CountyTaxRate { get; set; }

        [JsonPropertyName("county_tax_collectable")]
        public float CountyTaxCollectable { get; set; }

        [JsonPropertyName("taxable_city_taxable_amountamount")]
        public float CityTaxableAmount { get; set; }

        [JsonPropertyName("city_tax_rate")]
        public float CityTaxRate { get; set; }

        [JsonPropertyName("city_tax_collectable")]
        public float CityTaxCollectable { get; set; }

        [JsonPropertyName("special_district_taxable_amount")]
        public float SpecialDistrictTaxableAmount { get; set; }

        [JsonPropertyName("special_tax_rate")]
        public float SpecialTaxRate { get; set; }

        [JsonPropertyName("special_district_tax_collectable")]
        public float SpecialDistrictTaxCollectable { get; set; }
    }
}
