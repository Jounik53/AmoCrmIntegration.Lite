using Newtonsoft.Json;
using System.Collections.Generic;

namespace AmoCrmIntegration.Lite.Models
{
    /// <summary>
    /// Type of class response in CRM
    /// </summary>
    public class ResponseAmoCrm
    {
        [JsonProperty("_embedded")]
        public ResponseAmoCrmValue Embedded { get; set; }

        [JsonProperty("_links")]
        public List<AmoCrmCommonFieldsLinkFields> Links { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("detail")]
        public string Detail { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }

    /// <summary>
    /// Type of class response value in CRM
    /// </summary>
    public class ResponseAmoCrmValue
    {
        [JsonProperty("items")]
        public List<AmoCrmResponseObject> Items { get; set; }
    }

    /// <summary>
    /// Type of class extension fields (response) for Common fields in CRM
    /// </summary>
    public class AmoCrmResponseObject : AmoCrmCommonFields
    {
        [JsonProperty("is_deleted")]
        public bool IsDeleted { get; set; }

        [JsonProperty("main_contact")]
        public List<AmoCrmCommonCustomFields> MainContact { get; set; }

        [JsonProperty("group_id")]
        public string GroupId { get; set; }

        [JsonProperty("company")]
        public List<AmoCrmCommonCustomFields> Company { get; set; }

        [JsonProperty("leads")]
        public List<AmoCrmCommonCustomFields> Leads { get; set; }

        [JsonProperty("closed_at")]
        public string ClosedAt { get; set; }

        [JsonProperty("closest_task_at")]
        public string ClosestTaskAt { get; set; }

        [JsonProperty("tags")]
        public List<AmoCrmResponseTagsValue> TagsResponse { get; set; }

        [JsonProperty("custom_fields")]
        public List<AmoCrmCommonCustomFields> CustomFields { get; set; }

        [JsonProperty("contacts")]
        public List<AmoCrmCommonCustomFields> Contacts { get; set; }

        [JsonProperty("pipeline")]
        public List<AmoCrmCommonCustomFields> Pipeline { get; set; }

        [JsonProperty("customers")]
        public List<AmoCrmCommonCustomFields> Customers { get; set; }

        [JsonProperty("request_id")]
        public string RequestId { get; set; }

        [JsonProperty("status_id")]
        public string StatusId { get; set; }

        [JsonProperty("sale")]
        public string Sale { get; set; }
    }

    /// <summary>
    /// Type of class extension tags fields for response in CRM
    /// </summary>
    public class AmoCrmResponseTagsValue
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
