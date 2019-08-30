using AmoCrmIntegration.Lite.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace AmoCrmIntegration.Lite.Models
{
    /// <summary>
    /// Type of Common fields for requests in CRM
    /// </summary>
    public class AddOrUpdateCommand<T> where T : class
    {
        [JsonProperty("add", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public List<T> ItemAdd { get; set; }

        [JsonProperty("update", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public List<T> ItemUpdate { get; set; }
    }

    /// <summary>
    /// Type of Common fields in requests
    /// </summary>
    public class AmoCrmCommonFields
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("account_id")]
        public string AccountId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("tags")]
        public string Tags { get; set; }

        [JsonProperty("created_at")]
        public long? DateCreateTimestamp
        {
            get => DateCreate.GetTimestamp();
            set => DateCreate = value.GetDateTime();
        }

        [JsonIgnore]
        public DateTime? DateCreate { get; set; }

        [JsonProperty("updated_at")]
        public long? LastModifiedTimestamp
        {
            get => LastModified.GetTimestamp() ?? DateTime.Now.GetTimestamp();
            set => LastModified = value.GetDateTime();
        }

        [JsonIgnore]
        public DateTime? LastModified { get; set; }

        [JsonProperty("responsible_user_id", DefaultValueHandling = DefaultValueHandling.Ignore)]
        public long ResponsibleUserId { get; set; }

        [JsonProperty("_links")]
        public List<AmoCrmCommonFieldsLinkFields> Links { get; set; }
    }

    /// <summary>
    /// Type of Custom fields in Common fields
    /// </summary>
    public class AmoCrmCommonCustomFields
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("is_system")]
        public bool IsSystem { get; set; }

        [JsonProperty("values")]
        public List<AmoCrmCommonCustomFieldValues> Values { get; set; }

        [JsonProperty("_links")]
        public List<AmoCrmCommonFieldsLinkFields> Links { get; set; }
    }

    /// <summary>
    /// Type of Custom fields values in Common fields
    /// </summary>
    public class AmoCrmCommonCustomFieldValues
    {
        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("enum")]
        public string Enum { get; set; }

        [JsonProperty("subtype")]
        public string Subtype { get; set; }
    }

    /// <summary>
    /// Type of Link fields in Common fields
    /// </summary>
    public class AmoCrmCommonFieldsLinkFields
    {
        [JsonProperty("self")]
        public List<AmoCrmCommonFieldsLinkFieldsValue> Self { get; set; }
    }

    /// <summary>
    /// Type of Link fields value in Common fields
    /// </summary>
    public class AmoCrmCommonFieldsLinkFieldsValue
    {
        [JsonProperty("href")]
        public string Href { get; set; }

        [JsonProperty("method")]
        public string Method { get; set; }
    }
}
