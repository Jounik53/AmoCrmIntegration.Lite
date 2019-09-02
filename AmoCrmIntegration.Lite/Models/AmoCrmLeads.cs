using Newtonsoft.Json;
using System.Collections.Generic;

namespace AmoCrmIntegration.Lite.Models
{
    /// <summary>
    /// Type of class extension fields (lead) for Common fields in CRM
    /// </summary>
    public class AmoCrmLead : CommonFields
    {
        [JsonProperty("status_id")]
        public int? StatusId { get; set; }

        [JsonProperty("contacts_id")]
        public long? ContactsId { get; set; }

        [JsonProperty("pipeline_id")]
        public int? PipelineId { get; set; }

        [JsonProperty("custom_fields")]
        public List<LeadCustomField> CustomFields { get; set; }
    }

    /// <summary>
    /// Type of class extension custom fields (lead) for Common fields in CRM
    /// </summary>
    public class LeadCustomField : CommonCustomFields
    {
    }

}
