using Newtonsoft.Json;
using System.Collections.Generic;

namespace AmoCrmIntegration.Lite.Models
{
    /// <summary>
    /// CRM Account Information
    /// </summary>
    public class CrmAccountInfo
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("subdomain")]
        public string SubDomain { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("timezone")]
        public string Timezone { get; set; }

        [JsonProperty("timezone_offset")]
        public string TimezoneOffSet { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("date_pattern")]
        public AmoCroDataPatternEnum DatePattern { get; set; }

        [JsonProperty("current_user")]
        public string CurrentUser { get; set; }

        [JsonProperty("_embedded")]
        public AmoCrmAccountEmbedded Embedded { get; set; }
    }

    /// <summary>
    /// Type of Embedded in CRM
    /// </summary>
    public class AmoCrmAccountEmbedded
    {
        [JsonProperty("users")]
        public Dictionary<string, CrmUser> Users { get; set; }

        [JsonProperty("custom_fields")]
        public AccountInfoCustomFields CustomFields { get; set; }

        [JsonProperty("note_types")]
        public List<NoteType> NoteTypes { get; set; }

        [JsonProperty("task_types")]
        public List<TaskType> TaskTypes { get; set; }

        [JsonProperty("pipelines")]
        public Dictionary<string, CrmLeadPipelines> Pipelines { get; set; }
    }

    /// <summary>
    /// Type of Crm user in CRM
    /// </summary>
    public class CrmUser
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("login")]
        public string Login { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("group_id")]
        public string GroupId { get; set; }

        [JsonProperty("is_active")]
        public bool IsActive { get; set; }

        [JsonProperty("is_free")]
        public bool IsFree { get; set; }

        [JsonProperty("is_admin")]
        public bool IsAdmin { get; set; }

        [JsonProperty("rights")]
        public CrmContactRights Rights { get; set; }
    }

    /// <summary>
    /// Type of Contact rights in CRM
    /// </summary>
    public class CrmContactRights
    {
        [JsonProperty("mail")]
        public string Mail { get; set; }

        [JsonProperty("incoming_leads")]
        public string IncomingLeads { get; set; }

        [JsonProperty("catalogs")]
        public string Catalogs { get; set; }

        [JsonProperty("lead_add")]
        public string LeadAdd { get; set; }

        [JsonProperty("lead_view")]
        public string LeadView { get; set; }

        [JsonProperty("lead_edit")]
        public string LeadEdit { get; set; }

        [JsonProperty("lead_delete")]
        public string LeadDelete { get; set; }

        [JsonProperty("lead_export")]
        public string LeadExport { get; set; }

        [JsonProperty("contact_add")]
        public string ContactAdd { get; set; }

        [JsonProperty("contact_view")]
        public string ContactView { get; set; }

        [JsonProperty("contact_edit")]
        public string ContactEdit { get; set; }

        [JsonProperty("contact_delete")]
        public string ContactDelete { get; set; }

        [JsonProperty("contact_export")]
        public string ContactExport { get; set; }

        [JsonProperty("company_add")]
        public string CompanyAdd { get; set; }

        [JsonProperty("company_view")]
        public string CompanyView { get; set; }

        [JsonProperty("company_delete")]
        public string CompanyDelete { get; set; }

        [JsonProperty("company_export")]
        public string CompanyExport { get; set; }
    }

    /// <summary>
    /// Type of PipeLine in CRM
    /// </summary>
    public class CrmLeadPipelines
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("sort")]
        public string Sort { get; set; }

        [JsonProperty("is_main")]
        public bool IsMain { get; set; }

        [JsonProperty("statuses")]
        public Dictionary<string, CrmLeadStatus> Statuses { get; set; }
    }

    /// <summary>
    /// Type of LeadStatuses in CRM
    /// </summary>
    public class CrmLeadStatus
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("color")]
        public string Color { get; set; }

        [JsonProperty("editable")]
        public string Editable { get; set; }
    }

    /// <summary>
    /// Type of CustomFields in CRM
    /// </summary>
    public class AccountInfoCustomFields
    {
        [JsonProperty("contacts")]
        public List<CustomFieldAccountInfoEnums> Contacts { get; set; }

        [JsonProperty("leads")]
        public List<CustomFieldAccountInfoEnums> Leads { get; set; }

        [JsonProperty("companies")]
        public List<CustomFieldAccountInfoEnums> Companies { get; set; }

        [JsonProperty("customers")]
        public List<CustomFieldAccountInfoEnums> Customers { get; set; }
    }

    /// <summary>
    /// Type of Enums for CustomFields in CRM
    /// </summary>
    public class CustomFieldAccountInfoEnums
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("field_type")]
        public string FieldType { get; set; }

        [JsonProperty("sort")]
        public string Sort { get; set; }

        [JsonProperty("is_multiple")]
        public bool IsMultiple { get; set; }

        [JsonProperty("is_system")]
        public bool IsSystem { get; set; }

        [JsonProperty("is_editable")]
        public bool IdEditable { get; set; }

        [JsonProperty("enums")]
        public List<AmoCrmAccountInfoEnums> Enums { get; set; }
    }

    /// <summary>
    /// Type of enums for AccountInfo in CRM
    /// </summary>
    public class AmoCrmAccountInfoEnums
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }

    /// <summary>
    /// Type of note in CRM
    /// </summary>
    public class NoteType
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("editable")]
        public string Editable { get; set; }
    }

    /// <summary>
    /// Type of task in CRM
    /// </summary>
    public class TaskType
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    /// <summary>
    /// Type of Enums for DatePattern in CRM
    /// </summary>
    public class AmoCroDataPatternEnum
    {
        [JsonProperty("date")]
        public long Date { get; set; }

        [JsonProperty("time")]
        public string Time { get; set; }

        [JsonProperty("date_time")]
        public string DateTime { get; set; }

        [JsonProperty("time_full")]
        public string TimeFull { get; set; }
    }
}
