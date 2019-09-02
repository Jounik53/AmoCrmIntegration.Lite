using Newtonsoft.Json;
using System.Collections.Generic;

namespace AmoCrmIntegration.Lite.Models
{
    /// <summary>
    /// Type of class extension fields (contact) for Common fields in CRM
    /// </summary>
    public class AmoCrmContact : CommonFields
    {
        [JsonProperty("request_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public long RequestId { get; set; }

        [JsonProperty("linked_leads_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public List<long> LinkedLeadsIds { get; set; }

        [JsonProperty("company_name", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string CompanyName { get; set; }

        [JsonProperty("custom_fields")]
        public List<ContactCustomField> CustomFields { get; set; }
    }

    /// <summary>
    /// Type of class extension custom fields (contact) for Common fields in CRM
    /// </summary>
    public class ContactCustomField : CommonCustomFields
    {
        [JsonProperty("code")]
        public string Code { get; set; }
    }

}
