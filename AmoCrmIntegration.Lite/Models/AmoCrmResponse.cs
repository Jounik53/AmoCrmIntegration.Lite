using Newtonsoft.Json;
using System.Collections.Generic;

namespace AmoCrmIntegration.Lite.Models
{
    /// <summary>
    /// Type of class response in CRM
    /// </summary>
    public class ResponseCrm
    {
        [JsonProperty("_embedded")]
        public ResponseCrmValue Embedded { get; set; }

        [JsonProperty("_links")]
        public List<CommonFieldsLinkFields> Links { get; set; }

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
    public class ResponseCrmValue
    {
        [JsonProperty("items")]
        public List<CrmResponseObject> Items { get; set; }
    }

    /// <summary>
    /// Type of class extension fields (response) for Common fields in CRM
    /// </summary>
    public class CrmResponseObject : CommonFields
    {
        [JsonProperty("is_deleted")]
        public bool IsDeleted { get; set; }

        [JsonProperty("main_contact")]
        public List<CommonCustomFields> MainContact { get; set; }

        [JsonProperty("group_id")]
        public string GroupId { get; set; }

        [JsonProperty("company")]
        public List<CommonCustomFields> Company { get; set; }

        [JsonProperty("leads")]
        public List<CommonCustomFields> Leads { get; set; }

        [JsonProperty("closed_at")]
        public string ClosedAt { get; set; }

        [JsonProperty("closest_task_at")]
        public string ClosestTaskAt { get; set; }

        [JsonProperty("tags")]
        public List<CrmResponseTagsValue> TagsResponse { get; set; }

        [JsonProperty("custom_fields")]
        public List<CommonCustomFields> CustomFields { get; set; }

        [JsonProperty("contacts")]
        public List<CommonCustomFields> Contacts { get; set; }

        [JsonProperty("pipeline")]
        public List<CommonCustomFields> Pipeline { get; set; }

        [JsonProperty("customers")]
        public List<CommonCustomFields> Customers { get; set; }

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
    public class CrmResponseTagsValue
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
