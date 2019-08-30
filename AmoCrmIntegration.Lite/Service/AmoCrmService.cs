using AmoCrmIntegration.Lite.Interface;
using AmoCrmIntegration.Lite.Methods;
using AmoCrmIntegration.Lite.Models;
using AmoCrmIntegration.Lite.Utils;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Net;
using System.Threading.Tasks;

namespace AmoCrmIntegration.Lite.Service
{
    public class AmoCrmService : IAmoCrmService
    {
        private readonly AmoCrmConfig _crmConfig;

        public AmoCrmService(AmoCrmConfig crmConfig)
        {
            _crmConfig = crmConfig;
        }

        #region Methods

        #region GetAccountInfo

        /// <summary>
        /// Account information method
        /// </summary>
        /// <typeparam name="T">class to serialize</typeparam>
        /// <exception cref="AmoCrmException">Return error from server</exception>
        /// <returns>Deserialize the response to the specified class (CrmAccountInfo)</returns>
        public async Task<T> GetAccountInfoAsync<T>() where T : class
        {
            var parameterId = new Parameter[]
                {new Parameter {Name = "", Value = "", Type = ParameterType.QueryString}};
            var accountInfo =
                await Requests.GetAsync<AmoCrmResult>(_crmConfig.AccountCurrentUrl, parameterId, _crmConfig);
            if (!accountInfo.Success)
            {
                throw new AmoCrmException(accountInfo.ErrorMessage, accountInfo.ErrorCode);
            }

            return accountInfo.Content.DeserializeTo<T>();
        }

        /// <summary>
        /// Account information method
        /// </summary>
        /// <typeparam name="T">class to serialize</typeparam>
        /// <param name="url">URL request</param>
        /// <param name="cookies">Cookies container</param>
        /// <param name="limitRows">Receive limit (default is 500)</param>
        /// <param name="limitOffSet">String Shift (default 0)</param>
        /// <param name="modifiedSince">Modification date (default is null)</param>
        /// <exception cref="AmoCrmException">Return error from server</exception>
        /// <returns>Deserialize the response to the specified class (CrmAccountInfo)</returns>
        public async Task<T> GetAccountInfoAsync<T>(string url, CookieContainer cookies, int? limitRows = 500,
            int? limitOffSet = 0, DateTime? modifiedSince = null) where T : class
        {
            var parameterId = new Parameter[]
                {new Parameter {Name = "", Value = "", Type = ParameterType.QueryString}};
            var accountInfo =
                await Requests.GetAsync<AmoCrmResult>(url, parameterId, cookies, limitRows, limitOffSet, modifiedSince);
            if (!accountInfo.Success)
            {
                throw new AmoCrmException(accountInfo.ErrorMessage, accountInfo.ErrorCode);
            }

            return accountInfo.Content.DeserializeTo<T>();
        }

        /// <summary>
        /// Account information method
        /// </summary>
        /// <typeparam name="T">class to serialize</typeparam>
        /// <param name="url">URL request</param>
        /// <param name="credential">Used By: UserName, Password, Domain</param>
        /// <param name="limitRows">Receive limit (default is 500)</param>
        /// <param name="limitOffSet">String Shift (default 0)</param>
        /// <param name="modifiedSince">Modification date (default is null)</param>
        /// <exception cref="AmoCrmException">Return error from server</exception>
        /// <returns>Deserialize the response to the specified class (CrmAccountInfo)</returns>
        public async Task<T> GetAccountInfoAsync<T>(string url, NetworkCredential credential, int? limitRows = 500,
            int? limitOffSet = 0, DateTime? modifiedSince = null) where T : class
        {
            var parameterId = new Parameter[]
                {new Parameter {Name = "", Value = "", Type = ParameterType.QueryString}};
            var accountInfo = await Requests.GetAsync<AmoCrmResult>(url, parameterId, credential, limitRows,
                limitOffSet, modifiedSince);
            if (!accountInfo.Success)
            {
                throw new AmoCrmException(accountInfo.ErrorMessage, accountInfo.ErrorCode);
            }

            return accountInfo.Content.DeserializeTo<T>();
        }

        #endregion

        #region Method get contacts

        /// <summary>
        /// Get contact id method
        /// </summary>
        /// <typeparam name="T">class to serialize</typeparam>
        /// <param name="contactId">id contact</param>
        /// <exception cref="AmoCrmException">Return error from server</exception>
        /// <returns>Deserialize the response to the specified class (ResponseAmoCrm)</returns>
        public async Task<T> GetContactByIdAsync<T>(long contactId) where T : class
        {
            var parameterId = new Parameter[]
                {new Parameter {Name = "id", Value = contactId, Type = ParameterType.QueryString}};
            var contact = await Requests.GetAsync<AmoCrmResult>(_crmConfig.ContactUrl, parameterId, _crmConfig);
            if (!contact.Success)
            {
                throw new AmoCrmException(contact.ErrorMessage, contact.ErrorCode);
            }

            return contact.Content.DeserializeTo<T>();
        }

        /// <summary>
        /// Get contacts list method
        /// </summary>
        /// <typeparam name="T">class to serialize</typeparam>
        /// <exception cref="AmoCrmException">Return error from server</exception>
        /// <returns>Deserialize the response to the specified class (ResponseAmoCrm)</returns>
        public async Task<T> GetContactsAsync<T>() where T : class
        {
            var parameterId = new Parameter[]
                {new Parameter {Name = "", Value = "", Type = ParameterType.QueryString}};
            var contact = await Requests.GetAsync<AmoCrmResult>(_crmConfig.ContactUrl, parameterId, _crmConfig);
            if (!contact.Success)
            {
                throw new AmoCrmException(contact.ErrorMessage, contact.ErrorCode);
            }

            return contact.Content.DeserializeTo<T>();
        }

        /// <summary>
        /// Get contact by query method
        /// </summary>
        /// <typeparam name="T">class to serialize</typeparam>
        /// <param name="query">query contact</param>
        /// <exception cref="AmoCrmException">Return error from server</exception>
        /// <returns>Deserialize the response to the specified class (ResponseAmoCrm)</returns>
        public async Task<T> GetContactByQueryAsync<T>(string query) where T : class
        {
            var parameterId = new Parameter[]
                {new Parameter {Name = "query", Value = query, Type = ParameterType.QueryString}};
            var contact = await Requests.GetAsync<AmoCrmResult>(_crmConfig.ContactUrl, parameterId, _crmConfig);
            if (!contact.Success)
            {
                throw new AmoCrmException(contact.ErrorMessage, contact.ErrorCode);
            }

            return contact.Content.DeserializeTo<T>();
        }

        /// <summary>
        /// Get contact by responsibleUserId method
        /// </summary>
        /// <typeparam name="T">class to serialize</typeparam>
        /// <param name="responsibleUserId">responsibleUserId contact</param>
        /// <exception cref="AmoCrmException">Return error from server</exception>
        /// <returns>Deserialize the response to the specified class (ResponseAmoCrm)</returns>
        public async Task<T> GetContactByResponsibleUserIdAsync<T>(long responsibleUserId) where T : class
        {
            var parameterId = new Parameter[]
            {
                new Parameter
                    {Name = "responsible_user_id", Value = responsibleUserId, Type = ParameterType.QueryString}
            };
            var contact = await Requests.GetAsync<AmoCrmResult>(_crmConfig.ContactUrl, parameterId, _crmConfig);
            if (!contact.Success)
            {
                throw new AmoCrmException(contact.ErrorMessage, contact.ErrorCode);
            }

            return contact.Content.DeserializeTo<T>();
        }

        #endregion

        #region Method add or update contact

        /// <summary>
        /// Method for adding or updating a contact
        /// </summary>
        /// <typeparam name="T">class to serialize</typeparam>
        /// <param name="contacts">The structure of the added / updated contact</param>
        /// <exception cref="AmoCrmException">Return error from server</exception>
        /// <returns>Deserialize the response to the specified class</returns>
        public async Task<T> AddOrUpdateContactAsync<T>(AddOrUpdateCommand<AmoCrmContact> contacts) where T : class
        {
            var response = await Requests.PostAsync<AmoCrmResult>(_crmConfig.ContactUrl,
                JsonConvert.SerializeObject(contacts), _crmConfig);
            if (!response.Success)
            {
                throw new ArgumentException(response.ErrorCode + ":" + response.ErrorMessage);
            }

            return response.Content.DeserializeTo<T>();
        }

        /// <summary>
        /// Method for adding or updating a contact
        /// </summary>
        /// <typeparam name="T">class to serialize</typeparam>
        /// <param name="contacts">The structure of the added / updated contact</param>
        /// <param name="url">URL request</param>
        /// <param name="cookies">Cookies container</param>
        /// <exception cref="AmoCrmException">Return error from server</exception>
        /// <returns>Deserialize the response to the specified class</returns>
        public async Task<T> AddOrUpdateContactAsync<T>(AddOrUpdateCommand<AmoCrmContact> contacts, string url,
            CookieContainer cookies) where T : class
        {
            var response = await Requests.PostAsync<AmoCrmResult>(url, JsonConvert.SerializeObject(contacts), cookies);
            if (!response.Success)
            {
                throw new ArgumentException(response.ErrorCode + ":" + response.ErrorMessage);
            }

            return response.Content.DeserializeTo<T>();
        }

        /// <summary>
        /// Method for adding or updating a contact
        /// </summary>
        /// <typeparam name="T">class to serialize</typeparam>
        /// <param name="contacts">The structure of the added / updated contact</param>
        /// <param name="url">URL request</param>
        /// <param name="credential">Used By: UserName, Password, Domain</param>
        /// <exception cref="AmoCrmException">Return error from server</exception>
        /// <returns>Deserialize the response to the specified class</returns>
        public async Task<T> AddOrUpdateContactAsync<T>(AddOrUpdateCommand<AmoCrmContact> contacts, string url,
            NetworkCredential credential) where T : class
        {
            var response =
                await Requests.PostAsync<AmoCrmResult>(url, JsonConvert.SerializeObject(contacts), credential);
            if (!response.Success)
            {
                throw new ArgumentException(response.ErrorCode + ":" + response.ErrorMessage);
            }

            return response.Content.DeserializeTo<T>();
        }

        #endregion

        #region Method get leads

        /// <summary>
        /// Get leads list method
        /// </summary>
        /// <typeparam name="T">class to serialize</typeparam>
        /// <exception cref="AmoCrmException">Return error from server</exception>
        /// <returns>Deserialize the response to the specified class (ResponseAmoCrm)</returns>
        public async Task<T> GetLeadsAsync<T>() where T : class
        {
            var parameterId = new Parameter[]
                {new Parameter {Name = "", Value = "", Type = ParameterType.QueryString}};
            var contact = await Requests.GetAsync<AmoCrmResult>(_crmConfig.LeadUrl, parameterId, _crmConfig);
            if (!contact.Success)
            {
                throw new AmoCrmException(contact.ErrorMessage, contact.ErrorCode);
            }

            return contact.Content.DeserializeTo<T>();
        }

        /// <summary>
        /// Get leads list method
        /// </summary>
        /// <typeparam name="T">class to serialize</typeparam>
        /// <param name="url">URL request</param>
        /// <param name="cookies">Cookies container</param>
        /// <param name="limitRows">Receive limit (default is 500)</param>
        /// <param name="limitOffSet">String Shift (default 0)</param>
        /// <param name="modifiedSince">Modification date (default is null)</param>
        /// <exception cref="AmoCrmException">Return error from server</exception>
        /// <returns>Deserialize the response to the specified class (ResponseAmoCrm)</returns>
        public async Task<T> GetLeadsAsync<T>(string url, CookieContainer cookies, int? limitRows = 500,
            int? limitOffSet = 0, DateTime? modifiedSince = null) where T : class
        {
            var parameterId = new Parameter[]
                {new Parameter {Name = "", Value = "", Type = ParameterType.QueryString}};
            var contact = await Requests.GetAsync<AmoCrmResult>(url, parameterId, cookies);
            if (!contact.Success)
            {
                throw new AmoCrmException(contact.ErrorMessage, contact.ErrorCode);
            }

            return contact.Content.DeserializeTo<T>();
        }

        /// <summary>
        /// Get leads list method
        /// </summary>
        /// <typeparam name="T">class to serialize</typeparam>
        /// <param name="url">URL request</param>
        /// <param name="credential">Used By: UserName, Password, Domain</param>
        /// <param name="limitRows">Receive limit (default is 500)</param>
        /// <param name="limitOffSet">String Shift (default 0)</param>
        /// <param name="modifiedSince">Modification date (default is null)</param>
        /// <exception cref="AmoCrmException">Return error from server</exception>
        /// <returns>Deserialize the response to the specified class (ResponseAmoCrm)</returns>
        public async Task<T> GetLeadsAsync<T>(string url, NetworkCredential credential, int? limitRows = 500,
            int? limitOffSet = 0, DateTime? modifiedSince = null) where T : class
        {
            var parameterId = new Parameter[]
                {new Parameter {Name = "", Value = "", Type = ParameterType.QueryString}};
            var contact = await Requests.GetAsync<AmoCrmResult>(url, parameterId, credential);
            if (!contact.Success)
            {
                throw new AmoCrmException(contact.ErrorMessage, contact.ErrorCode);
            }

            return contact.Content.DeserializeTo<T>();
        }

        /// <summary>
        /// Get leads list method
        /// Authorization is obtained through an instance of the AmoCrmConfig class specified in the constructor
        /// </summary>
        /// <typeparam name="T">class to serialize</typeparam>
        /// <param name="url">URL request</param>
        /// <exception cref="AmoCrmException">Return error from server</exception>
        /// <returns>Deserialize the response to the specified class (ResponseAmoCrm)</returns>
        public async Task<T> GetLeadsAsync<T>(string url) where T : class
        {
            var parameterId = new Parameter[]
                {new Parameter {Name = "", Value = "", Type = ParameterType.QueryString}};
            var contact = await Requests.GetAsync<AmoCrmResult>(url, parameterId, _crmConfig);
            if (!contact.Success)
            {
                throw new AmoCrmException(contact.ErrorMessage, contact.ErrorCode);
            }

            return contact.Content.DeserializeTo<T>();
        }

        #endregion

        #region Method add leads

        /// <summary>
        /// Method for adding a lead
        /// </summary>
        /// <param name="leads">The structure of the added lead</param>
        /// <exception cref="AmoCrmException">Return error from server</exception>
        /// <returns>Deserialize the response to the specified class</returns>
        public async Task<T> AddLeadAsync<T>(AddOrUpdateCommand<AmoCrmLead> leads) where T : class
        {
            var response =
                await Requests.PostAsync<AmoCrmResult>(_crmConfig.LeadUrl, JsonConvert.SerializeObject(leads),
                    _crmConfig);
            if (!response.Success)
                throw new ArgumentException(response.ErrorCode + ":" + response.ErrorMessage);
            return response.Content.DeserializeTo<T>();
        }

        /// <summary>
        /// Method for adding a lead
        /// </summary>
        /// <param name="leads">The structure of the added lead</param>
        /// <param name="url">URL request</param>
        /// <param name="cookies">Cookies container</param>
        /// <exception cref="AmoCrmException">Return error from server</exception>
        /// <returns>Deserialize the response to the specified class</returns>
        public async Task<T> AddLeadAsync<T>(AddOrUpdateCommand<AmoCrmLead> leads, string url, CookieContainer cookies)
            where T : class
        {
            var response = await Requests.PostAsync<AmoCrmResult>(url, JsonConvert.SerializeObject(leads), cookies);
            if (!response.Success)
                throw new ArgumentException(response.ErrorCode + ":" + response.ErrorMessage);
            return response.Content.DeserializeTo<T>();
        }

        /// <summary>
        /// Method for adding a lead
        /// </summary>
        /// <param name="leads">The structure of the added lead</param>
        /// <param name="url">URL request</param>
        /// <param name="credential">Used By: UserName, Password, Domain</param>
        /// <exception cref="AmoCrmException">Return error from server</exception>
        /// <returns>Deserialize the response to the specified class</returns>
        public async Task<T> AddLeadAsync<T>(AddOrUpdateCommand<AmoCrmLead> leads, string url,
            NetworkCredential credential) where T : class
        {
            var response = await Requests.PostAsync<AmoCrmResult>(url, JsonConvert.SerializeObject(leads), credential);
            if (!response.Success)
                throw new ArgumentException(response.ErrorCode + ":" + response.ErrorMessage);
            return response.Content.DeserializeTo<T>();
        }

        #endregion

        #region Method get company 

        /// <summary>
        /// Get company by id method
        /// </summary>
        /// <typeparam name="T">class to serialize</typeparam>
        /// <param name="companyId">id company</param>
        /// <exception cref="AmoCrmException">Return error from server</exception>
        /// <returns>Deserialize the response to the specified class (ResponseAmoCrm)</returns>
        public async Task<T> GetCompanyByIdAsync<T>(long companyId) where T : class
        {
            var parameterId = new Parameter[]
                {new Parameter {Name = "id", Value = companyId, Type = ParameterType.QueryString}};
            var contact = await Requests.GetAsync<AmoCrmResult>(_crmConfig.CompanyUrl, parameterId, _crmConfig);
            if (!contact.Success)
            {
                throw new AmoCrmException(contact.ErrorMessage, contact.ErrorCode);
            }

            return contact.Content.DeserializeTo<T>();
        }

        /// <summary>
        /// Get company list method
        /// </summary>
        /// <typeparam name="T">class to serialize</typeparam>
        /// <exception cref="AmoCrmException">Return error from server</exception>
        /// <returns>Deserialize the response to the specified class (ResponseAmoCrm)</returns>
        public async Task<T> GetCompanyAsync<T>() where T : class
        {
            var parameterId = new Parameter[]
                {new Parameter {Name = "", Value = "", Type = ParameterType.QueryString}};
            var contact = await Requests.GetAsync<AmoCrmResult>(_crmConfig.CompanyUrl, parameterId, _crmConfig);
            if (!contact.Success)
            {
                throw new AmoCrmException(contact.ErrorMessage, contact.ErrorCode);
            }

            return contact.Content.DeserializeTo<T>();
        }

        /// <summary>
        /// Get company by query method
        /// </summary>
        /// <typeparam name="T">class to serialize</typeparam>
        /// <param name="query">query company</param>
        /// <exception cref="AmoCrmException">Return error from server</exception>
        /// <returns>Deserialize the response to the specified class (ResponseAmoCrm)</returns>
        public async Task<T> GetCompanyByQueryAsync<T>(string query) where T : class
        {
            var parameterId = new Parameter[]
                {new Parameter {Name = "query", Value = query, Type = ParameterType.QueryString}};
            var contact = await Requests.GetAsync<AmoCrmResult>(_crmConfig.CompanyUrl, parameterId, _crmConfig);
            if (!contact.Success)
            {
                throw new AmoCrmException(contact.ErrorMessage, contact.ErrorCode);
            }

            return contact.Content.DeserializeTo<T>();
        }

        /// <summary>
        /// Get company by responsibleUserId method
        /// </summary>
        /// <typeparam name="T">class to serialize</typeparam>
        /// <param name="responsibleUserId">responsibleUserId company</param>
        /// <exception cref="AmoCrmException">Return error from server</exception>
        /// <returns>Deserialize the response to the specified class (ResponseAmoCrm)</returns>
        public async Task<T> GetCompanyByResponsibleUserIdAsync<T>(long responsibleUserId) where T : class
        {
            var parameterId = new Parameter[]
            {
                new Parameter
                    {Name = "responsible_user_id", Value = responsibleUserId, Type = ParameterType.QueryString}
            };
            var contact = await Requests.GetAsync<AmoCrmResult>(_crmConfig.CompanyUrl, parameterId, _crmConfig);
            if (!contact.Success)
            {
                throw new AmoCrmException(contact.ErrorMessage, contact.ErrorCode);
            }

            return contact.Content.DeserializeTo<T>();
        }

        #endregion

        #region Methods add company

        /// <summary>
        /// Method for adding a company
        /// </summary>
        /// <param name="company">The structure of the added company</param>
        /// <exception cref="AmoCrmException">Return error from server</exception>
        /// <returns>Deserialize the response to the specified class</returns>
        public async Task<T> AddCompanyAsync<T>(AddOrUpdateCommand<AmoCrmCompany> company) where T : class
        {
            var response = await Requests.PostAsync<AmoCrmResult>(_crmConfig.CompanyUrl,
                JsonConvert.SerializeObject(company), _crmConfig);
            if (!response.Success)
                throw new ArgumentException(response.ErrorCode + ":" + response.ErrorMessage);
            return response.Content.DeserializeTo<T>();
        }

        /// <summary>
        /// Method for adding a company
        /// </summary>
        /// <param name="company">The structure of the added company</param>
        /// <param name="url">URL request</param>
        /// <param name="cookies">Cookies container</param>
        /// <exception cref="AmoCrmException">Return error from server</exception>
        /// <returns>Deserialize the response to the specified class</returns>
        public async Task<T> AddCompanyAsync<T>(AddOrUpdateCommand<AmoCrmCompany> company, string url,
            CookieContainer cookies) where T : class
        {
            var response = await Requests.PostAsync<AmoCrmResult>(url, JsonConvert.SerializeObject(company), cookies);
            if (!response.Success)
                throw new ArgumentException(response.ErrorCode + ":" + response.ErrorMessage);
            return response.Content.DeserializeTo<T>();
        }

        /// <summary>
        /// Method for adding a company
        /// </summary>
        /// <param name="company">The structure of the added company</param>
        /// <param name="url">URL request</param>
        /// <param name = "credential" > Used By: UserName, Password, Domain</param>
        /// <exception cref="AmoCrmException">Return error from server</exception>
        /// <returns>Deserialize the response to the specified class</returns>
        public async Task<T> AddCompanyAsync<T>(AddOrUpdateCommand<AmoCrmCompany> company, string url,
            NetworkCredential credential) where T : class
        {
            var response =
                await Requests.PostAsync<AmoCrmResult>(url, JsonConvert.SerializeObject(company), credential);
            if (!response.Success)
                throw new ArgumentException(response.ErrorCode + ":" + response.ErrorMessage);
            return response.Content.DeserializeTo<T>();
        }

        #endregion

        #region Method universal for adding

        /// <summary>
        /// A universal method for adding an object passed in an instance of a class
        /// </summary>
        /// <param name="obj">The structure of the added object</param>
        /// <param name="url">URL request</param>
        /// <exception cref="AmoCrmException">Return error from server</exception>
        /// <returns>Deserialize the response to the specified class</returns>
        public async Task<T> AddObjAsync<T>(AddOrUpdateCommand<T> obj, string url) where T : class
        {
            var response = await Requests.PostAsync<AmoCrmResult>(url, JsonConvert.SerializeObject(obj), _crmConfig);
            if (!response.Success)
                throw new ArgumentException(response.ErrorCode + ":" + response.ErrorMessage);
            return response.Content.DeserializeTo<T>();
        }

        /// <summary>
        /// A universal method for adding an object passed in an instance of a class
        /// </summary>
        /// <param name="obj">The structure of the added object</param>
        /// <param name="url">URL request</param>
        /// <param name="cookies">Cookies container</param>
        /// <exception cref="AmoCrmException">Return error from server</exception>
        /// <returns>Deserialize the response to the specified class</returns>
        public async Task<T> AddObjAsync<T>(AddOrUpdateCommand<T> obj, string url, CookieContainer cookies) where T : class
        {
            var response = await Requests.PostAsync<AmoCrmResult>(url, JsonConvert.SerializeObject(obj), cookies);
            if (!response.Success)
                throw new ArgumentException(response.ErrorCode + ":" + response.ErrorMessage);
            return response.Content.DeserializeTo<T>();
        }

        /// <summary>
        /// A universal method for adding an object passed in an instance of a class
        /// </summary>
        /// <param name="obj">The structure of the added object</param>
        /// <param name="url">URL request</param>
        /// <param name="credential">Used By: UserName, Password, Domain</param>
        /// <exception cref="AmoCrmException">Return error from server</exception>
        /// <returns>Deserialize the response to the specified class</returns>
        public async Task<T> AddObjAsync<T>(AddOrUpdateCommand<T> obj, string url, NetworkCredential credential)
            where T : class
        {
            var response = await Requests.PostAsync<AmoCrmResult>(url, JsonConvert.SerializeObject(obj), credential);
            if (!response.Success)
                throw new ArgumentException(response.ErrorCode + ":" + response.ErrorMessage);
            return response.Content.DeserializeTo<T>();
        }

        #endregion

        #region Methods universal for get

        #region Get by id

        /// <summary>
        /// Get obj by id method
        /// </summary>
        /// <typeparam name="T">class to serialize</typeparam>
        /// <param name="id">id obj</param>
        /// <param name="url">URL request</param>
        /// <param name="cookies">Cookies container</param>
        /// <param name="limitRows">Receive limit (default is 500)</param>
        /// <param name="limitOffSet">String Shift (default 0)</param>
        /// <param name="modifiedSince">Modification date (default is null)</param>
        /// <exception cref="AmoCrmException">Return error from server</exception>
        /// <returns>Deserialize the response to the specified class (ResponseAmoCrm)</returns>
        public async Task<T> GetObjByIdAsync<T>(string id, string url, CookieContainer cookies, int? limitRows = 500,
            int? limitOffSet = 0, DateTime? modifiedSince = null) where T : class
        {
            var parameterId = new Parameter[]
                {new Parameter {Name = "id", Value = id, Type = ParameterType.QueryString}};
            var contact = await Requests.GetAsync<AmoCrmResult>(url, parameterId, cookies);
            if (!contact.Success)
            {
                throw new AmoCrmException(contact.ErrorMessage, contact.ErrorCode);
            }

            return contact.Content.DeserializeTo<T>();
        }

        /// <summary>
        /// Get obj by id method
        /// </summary>
        /// <typeparam name="T">class to serialize</typeparam>
        /// <param name="id">query id</param>
        /// <param name="url">URL request</param>
        /// <param name="credential">Used By: UserName, Password, Domain</param>
        /// <param name="limitRows">Receive limit (default is 500)</param>
        /// <param name="limitOffSet">String Shift (default 0)</param>
        /// <param name="modifiedSince">Modification date (default is null)</param>
        /// <exception cref="AmoCrmException">Return error from server</exception>
        /// <returns>Deserialize the response to the specified class (ResponseAmoCrm)</returns>
        public async Task<T> GetObjByIdAsync<T>(string id, string url, NetworkCredential credential,
            int? limitRows = 500, int? limitOffSet = 0, DateTime? modifiedSince = null) where T : class
        {
            var parameterId = new Parameter[]
                {new Parameter {Name = "id", Value = id, Type = ParameterType.QueryString}};
            var contact = await Requests.GetAsync<AmoCrmResult>(url, parameterId, credential);
            if (!contact.Success)
            {
                throw new AmoCrmException(contact.ErrorMessage, contact.ErrorCode);
            }

            return contact.Content.DeserializeTo<T>();
        }

        /// <summary>
        /// Get obj by id method
        /// Authorization is obtained through an instance of the AmoCrmConfig class specified in the constructor
        /// </summary>
        /// <typeparam name="T">class to serialize</typeparam>
        /// <param name="id">query id</param>
        /// <param name="url">URL request</param>
        /// <exception cref="AmoCrmException">Return error from server</exception>
        /// <returns>Deserialize the response to the specified class (ResponseAmoCrm)</returns>
        public async Task<T> GetObjByIdAsync<T>(string id, string url) where T : class
        {
            var parameterId = new Parameter[]
                {new Parameter {Name = "id", Value = id, Type = ParameterType.QueryString}};
            var contact = await Requests.GetAsync<AmoCrmResult>(url, parameterId, _crmConfig);
            if (!contact.Success)
            {
                throw new AmoCrmException(contact.ErrorMessage, contact.ErrorCode);
            }

            return contact.Content.DeserializeTo<T>();
        }

        #endregion

        #region Get by query

        /// <summary>
        /// Get obj by query method
        /// </summary>
        /// <typeparam name="T">class to serialize</typeparam>
        /// <param name="query">query obj</param>
        /// <param name="url">URL request</param>
        /// <param name="cookies">Cookies container</param>
        /// <param name="limitRows">Receive limit (default is 500)</param>
        /// <param name="limitOffSet">String Shift (default 0)</param>
        /// <param name="modifiedSince">Modification date (default is null)</param>
        /// <exception cref="AmoCrmException">Return error from server</exception>
        /// <returns>Deserialize the response to the specified class (ResponseAmoCrm)</returns>
        public async Task<T> GetObjByQueryAsync<T>(string query, string url, CookieContainer cookies,
            int? limitRows = 500, int? limitOffSet = 0, DateTime? modifiedSince = null) where T : class
        {
            var parameterId = new Parameter[]
                {new Parameter {Name = "query", Value = query, Type = ParameterType.QueryString}};
            var contact = await Requests.GetAsync<AmoCrmResult>(url, parameterId, cookies);
            if (!contact.Success)
            {
                throw new AmoCrmException(contact.ErrorMessage, contact.ErrorCode);
            }

            return contact.Content.DeserializeTo<T>();
        }

        /// <summary>
        /// Get obj by query method
        /// </summary>
        /// <typeparam name="T">class to serialize</typeparam>
        /// <param name="query">query obj</param>
        /// <param name="url">URL request</param>
        /// <param name="credential">Used By: UserName, Password, Domain</param>
        /// <param name="limitRows">Receive limit (default is 500)</param>
        /// <param name="limitOffSet">String Shift (default 0)</param>
        /// <param name="modifiedSince">Modification date (default is null)</param>
        /// <exception cref="AmoCrmException">Return error from server</exception>
        /// <returns>Deserialize the response to the specified class (ResponseAmoCrm)</returns>
        public async Task<T> GetObjByQueryAsync<T>(string query, string url, NetworkCredential credential,
            int? limitRows = 500, int? limitOffSet = 0, DateTime? modifiedSince = null) where T : class
        {
            var parameterId = new Parameter[]
                {new Parameter {Name = "query", Value = query, Type = ParameterType.QueryString}};
            var contact = await Requests.GetAsync<AmoCrmResult>(url, parameterId, credential);
            if (!contact.Success)
            {
                throw new AmoCrmException(contact.ErrorMessage, contact.ErrorCode);
            }

            return contact.Content.DeserializeTo<T>();
        }

        /// <summary>
        /// Get obj by query method
        /// Authorization is obtained through an instance of the AmoCrmConfig class specified in the constructor
        /// </summary>
        /// <typeparam name="T">class to serialize</typeparam>
        /// <param name="query">query obj</param>
        /// <param name="url">URL request</param>
        /// <exception cref="AmoCrmException">Return error from server</exception>
        /// <returns>Deserialize the response to the specified class (ResponseAmoCrm)</returns>
        public async Task<T> GetObjByQueryAsync<T>(string query, string url) where T : class
        {
            var parameterId = new Parameter[]
                {new Parameter {Name = "query", Value = query, Type = ParameterType.QueryString}};
            var contact = await Requests.GetAsync<AmoCrmResult>(url, parameterId, _crmConfig);
            if (!contact.Success)
            {
                throw new AmoCrmException(contact.ErrorMessage, contact.ErrorCode);
            }

            return contact.Content.DeserializeTo<T>();
        }

        #endregion

        #region Get by responsible User Id

        /// <summary>
        /// Get obj by responsibleUserId method
        /// </summary>
        /// <typeparam name="T">class to serialize</typeparam>
        /// <param name="responsibleUserId">responsibleUserId obj</param>
        /// <param name="url">URL request</param>
        /// <param name="cookies">Cookies container</param>
        /// <param name="limitRows">Receive limit (default is 500)</param>
        /// <param name="limitOffSet">String Shift (default 0)</param>
        /// <param name="modifiedSince">Modification date (default is null)</param>
        /// <exception cref="AmoCrmException">Return error from server</exception>
        /// <returns>Deserialize the response to the specified class (ResponseAmoCrm)</returns>
        public async Task<T> GetObjByResponsibleUserIdAsync<T>(long responsibleUserId, string url,
            CookieContainer cookies, int? limitRows = 500, int? limitOffSet = 0, DateTime? modifiedSince = null)
            where T : class
        {
            var parameterId = new Parameter[]
            {
                new Parameter {Name = "responsibleUserId", Value = responsibleUserId, Type = ParameterType.QueryString}
            };
            var contact = await Requests.GetAsync<AmoCrmResult>(url, parameterId, cookies);
            if (!contact.Success)
            {
                throw new AmoCrmException(contact.ErrorMessage, contact.ErrorCode);
            }

            return contact.Content.DeserializeTo<T>();
        }

        /// <summary>
        /// Get obj by responsibleUserId method
        /// </summary>
        /// <typeparam name="T">class to serialize</typeparam>
        /// <param name="responsibleUserId">query responsibleUserId</param>
        /// <param name="url">URL request</param>
        /// <param name="credential">Used By: UserName, Password, Domain</param>
        /// <param name="limitRows">Receive limit (default is 500)</param>
        /// <param name="limitOffSet">String Shift (default 0)</param>
        /// <param name="modifiedSince">Modification date (default is null)</param>
        /// <exception cref="AmoCrmException">Return error from server</exception>
        /// <returns>Deserialize the response to the specified class (ResponseAmoCrm)</returns>
        public async Task<T> GetObjByResponsibleUserIdAsync<T>(long responsibleUserId, string url,
            NetworkCredential credential, int? limitRows = 500, int? limitOffSet = 0, DateTime? modifiedSince = null)
            where T : class
        {
            var parameterId = new Parameter[]
            {
                new Parameter {Name = "responsibleUserId", Value = responsibleUserId, Type = ParameterType.QueryString}
            };
            var contact = await Requests.GetAsync<AmoCrmResult>(url, parameterId, credential);
            if (!contact.Success)
            {
                throw new AmoCrmException(contact.ErrorMessage, contact.ErrorCode);
            }

            return contact.Content.DeserializeTo<T>();
        }

        /// <summary>
        /// Get obj by responsibleUserId method
        /// Authorization is obtained through an instance of the AmoCrmConfig class specified in the constructor
        /// </summary>
        /// <typeparam name="T">class to serialize</typeparam>
        /// <param name="responsibleUserId">query responsibleUserId</param>
        /// <param name="url">URL request</param>
        /// <exception cref="AmoCrmException">Return error from server</exception>
        /// <returns>Deserialize the response to the specified class (ResponseAmoCrm)</returns>
        public async Task<T> GetObjByResponsibleUserIdAsync<T>(long responsibleUserId, string url) where T : class
        {
            var parameterId = new Parameter[]
            {
                new Parameter {Name = "responsibleUserId", Value = responsibleUserId, Type = ParameterType.QueryString}
            };
            var contact = await Requests.GetAsync<AmoCrmResult>(url, parameterId, _crmConfig);
            if (!contact.Success)
            {
                throw new AmoCrmException(contact.ErrorMessage, contact.ErrorCode);
            }

            return contact.Content.DeserializeTo<T>();
        }

        #endregion

        #region Get list obj

        /// <summary>
        /// Get obj list method
        /// </summary>
        /// <typeparam name="T">class to serialize</typeparam>
        /// <param name="url">URL request</param>
        /// <param name="cookies">Cookies container</param>
        /// <param name="limitRows">Receive limit (default is 500)</param>
        /// <param name="limitOffSet">String Shift (default 0)</param>
        /// <param name="modifiedSince">Modification date (default is null)</param>
        /// <exception cref="AmoCrmException">Return error from server</exception>
        /// <returns>Deserialize the response to the specified class (ResponseAmoCrm)</returns>
        public async Task<T> GetObjListAsync<T>(string url, CookieContainer cookies, int? limitRows = 500,
            int? limitOffSet = 0, DateTime? modifiedSince = null) where T : class
        {
            var parameterId = new Parameter[]
                {new Parameter {Name = "", Value = "", Type = ParameterType.QueryString}};
            var contact = await Requests.GetAsync<AmoCrmResult>(url, parameterId, cookies);
            if (!contact.Success)
            {
                throw new AmoCrmException(contact.ErrorMessage, contact.ErrorCode);
            }

            return contact.Content.DeserializeTo<T>();
        }

        /// <summary>
        /// Get obj list method
        /// </summary>
        /// <typeparam name="T">class to serialize</typeparam>
        /// <param name="url">URL request</param>
        /// <param name="credential">Used By: UserName, Password, Domain</param>
        /// <param name="limitRows">Receive limit (default is 500)</param>
        /// <param name="limitOffSet">String Shift (default 0)</param>
        /// <param name="modifiedSince">Modification date (default is null)</param>
        /// <exception cref="AmoCrmException">Return error from server</exception>
        /// <returns>Deserialize the response to the specified class (ResponseAmoCrm)</returns>
        public async Task<T> GetObjListAsync<T>(string url, NetworkCredential credential, int? limitRows = 500,
            int? limitOffSet = 0, DateTime? modifiedSince = null) where T : class
        {
            var parameterId = new Parameter[]
                {new Parameter {Name = "", Value = "", Type = ParameterType.QueryString}};
            var contact = await Requests.GetAsync<AmoCrmResult>(url, parameterId, credential);
            if (!contact.Success)
            {
                throw new AmoCrmException(contact.ErrorMessage, contact.ErrorCode);
            }

            return contact.Content.DeserializeTo<T>();
        }

        /// <summary>
        /// Get obj list method
        /// Authorization is obtained through an instance of the AmoCrmConfig class specified in the constructor
        /// </summary>
        /// <typeparam name="T">class to serialize</typeparam>
        /// <param name="url">URL request</param>
        /// <exception cref="AmoCrmException">Return error from server</exception>
        /// <returns>Deserialize the response to the specified class (ResponseAmoCrm)</returns>
        public async Task<T> GetObjListAsync<T>(string url) where T : class
        {
            var parameterId = new Parameter[]
                {new Parameter {Name = "", Value = "", Type = ParameterType.QueryString}};
            var contact = await Requests.GetAsync<AmoCrmResult>(url, parameterId, _crmConfig);
            if (!contact.Success)
            {
                throw new AmoCrmException(contact.ErrorMessage, contact.ErrorCode);
            }

            return contact.Content.DeserializeTo<T>();
        }

        #endregion

        #endregion

        #endregion
    }
}