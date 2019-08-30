using System;

namespace AmoCrmIntegration.Lite
{
    public class AmoCrmConfig
    {
        /// <summary>
        /// Constructor for instance AmoCrmConfig class
        /// </summary>
        /// <param name="subdomain">SubDomain if Crm</param>
        /// <param name="userLogin">User login if Crm</param>
        /// <param name="userHash">User hash if Crm</param>
        /// <param name="limitRows">Receive limit (default is 500) in Crm</param>
        /// <param name="limitOffset">String Shift (default 0) in Crm</param>
        /// <param name="modifiedSince">Modification date (default is null) iin Crm</param>
        public AmoCrmConfig(string subdomain, string userLogin, string userHash, int? limitRows = 500, int? limitOffset = 0, DateTime? modifiedSince = null)
        {
            Subdomain = subdomain;
            UserLogin = userLogin;
            UserHash = userHash;
            LimitRows = limitRows;
            LimitOffset = limitOffset;
            ModifiedSince = modifiedSince;
        }

        public string Subdomain { get; set; }

        public string UserLogin { get; set; }

        public string UserHash { get; set; }

        /// <summary>
        /// Url for authentication
        /// </summary>
        public string AuthUrl => $"https://{Subdomain}.amocrm.ru/private/api/auth.php?type=json";

        /// <summary>
        /// Url for api contacts
        /// </summary>
        public string ContactUrl => $"https://{Subdomain}.amocrm.ru/api/v2/contacts";

        /// <summary>
        /// Url for api leads
        /// </summary>
        public string LeadUrl => $"https://{Subdomain}.amocrm.ru/api/v2/leads";

        /// <summary>
        /// Url for api account
        /// </summary>
        public string AccountCurrentUrl => $"https://{Subdomain}.amocrm.ru/api/v2/account";

        /// <summary>
        /// Url for api company
        /// </summary>
        public string CompanyUrl => $"https://{Subdomain}.amocrm.ru/api/v2/companies";

        /// <summary>
        /// Receive limit (default is 500) in Crm
        /// </summary>
        public int? LimitRows { get; set; }

        /// <summary>
        /// String Shift (default 0) in Crm
        /// </summary>
        public int? LimitOffset { get; set; }

        /// <summary>
        /// Modification date (default is null) iin Crm
        /// </summary>
        public DateTime? ModifiedSince { get; set; }
    }
}
