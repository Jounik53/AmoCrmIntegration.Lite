using Newtonsoft.Json;
using System.Collections.Generic;

namespace AmoCrmIntegration.Lite.Models
{
    /// <summary>
    /// Type of class extension fields (company) for Common fields in CRM
    /// </summary>
    public class AmoCrmCompany : AmoCrmCommonFields
    {
        [JsonProperty("status_id")]
        public int? StatusId { get; set; }

        [JsonProperty("leads_id")]
        public string LeadsId { get; set; }

        [JsonProperty("custom_fields")]
        public List<AmoCrmCompanyCustomField> CustomFields { get; set; }
    }

    /// <summary>
    /// Type of class extension custom fields (company) for Common fields in CRM
    /// </summary>
    public class AmoCrmCompanyCustomField : AmoCrmCommonCustomFields
    {
    }
}
