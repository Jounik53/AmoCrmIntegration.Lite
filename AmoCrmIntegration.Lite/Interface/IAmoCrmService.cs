using AmoCrmIntegration.Lite.Models;
using System;
using System.Net;
using System.Threading.Tasks;

namespace AmoCrmIntegration.Lite.Interface
{
    public interface IAmoCrmService
    {
        #region AccountInfo

        /// <summary>
        /// Account information method
        /// </summary>
        /// <typeparam name="T">class to serialize</typeparam>
        /// <exception cref="AmoCrmException">Return error from server</exception>
        /// <returns>Deserialize the response to the specified class (CrmAccountInfo)</returns>
        Task<T> GetAccountInfoAsync<T>() where T : class;

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
        Task<T> GetAccountInfoAsync<T>(string url, CookieContainer cookies, int? limitRows = 500, int? limitOffSet = 0,
            DateTime? modifiedSince = null) where T : class;

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
        Task<T> GetAccountInfoAsync<T>(string url, NetworkCredential credential, int? limitRows = 500,
            int? limitOffSet = 0, DateTime? modifiedSince = null) where T : class;

        #endregion

        #region Contacts

        #region Get contacts

        /// <summary>
        /// Get contact id method
        /// </summary>
        /// <typeparam name="T">class to serialize</typeparam>
        /// <param name="contactId">id contact</param>
        /// <exception cref="AmoCrmException">Return error from server</exception>
        /// <returns>Deserialize the response to the specified class (ResponseAmoCrm)</returns>
        Task<T> GetContactByIdAsync<T>(long contactId) where T : class;

        /// <summary>
        /// Get contacts list method
        /// </summary>
        /// <typeparam name="T">class to serialize</typeparam>
        /// <exception cref="AmoCrmException">Return error from server</exception>
        /// <returns>Deserialize the response to the specified class (ResponseAmoCrm)</returns>
        Task<T> GetContactsAsync<T>() where T : class;

        /// <summary>
        /// Get contact by query method
        /// </summary>
        /// <typeparam name="T">class to serialize</typeparam>
        /// <param name="query">query contact</param>
        /// <exception cref="AmoCrmException">Return error from server</exception>
        /// <returns>Deserialize the response to the specified class (ResponseAmoCrm)</returns>
        Task<T> GetContactByQueryAsync<T>(string query) where T : class;

        /// <summary>
        /// Get contact by responsibleUserId method
        /// </summary>
        /// <typeparam name="T">class to serialize</typeparam>
        /// <param name="responsibleUserId">responsibleUserId contact</param>
        /// <exception cref="AmoCrmException">Return error from server</exception>
        /// <returns>Deserialize the response to the specified class (ResponseAmoCrm)</returns>
        Task<T> GetContactByResponsibleUserIdAsync<T>(long responsibleUserId) where T : class;

        #endregion

        #region Add or update contact

        /// <summary>
        /// Method for adding or updating a contact
        /// </summary>
        /// <typeparam name="T">class to serialize</typeparam>
        /// <param name="contacts">The structure of the added / updated contact</param>
        /// <exception cref="AmoCrmException">Return error from server</exception>
        /// <returns>Deserialize the response to the specified class</returns>
        Task<T> AddOrUpdateContactAsync<T>(AddOrUpdateCommand<AmoCrmContact> contacts) where T : class;

        /// <summary>
        /// Method for adding or updating a contact
        /// </summary>
        /// <typeparam name="T">class to serialize</typeparam>
        /// <param name="contacts">The structure of the added / updated contact</param>
        /// <param name="url">URL request</param>
        /// <param name="cookies">Cookies container</param>
        /// <exception cref="AmoCrmException">Return error from server</exception>
        /// <returns>Deserialize the response to the specified class</returns>
        Task<T> AddOrUpdateContactAsync<T>(AddOrUpdateCommand<AmoCrmContact> contacts, string url,
            CookieContainer cookies) where T : class;

        /// <summary>
        /// Method for adding or updating a contact
        /// </summary>
        /// <typeparam name="T">class to serialize</typeparam>
        /// <param name="contacts">The structure of the added / updated contact</param>
        /// <param name="url">URL request</param>
        /// <param name="credential">Used By: UserName, Password, Domain</param>
        /// <exception cref="AmoCrmException">Return error from server</exception>
        /// <returns>Deserialize the response to the specified class</returns>
        Task<T> AddOrUpdateContactAsync<T>(AddOrUpdateCommand<AmoCrmContact> contacts, string url,
            NetworkCredential credential) where T : class;

        #endregion

        #endregion

        #region Leads

        #region Get leads list

        /// <summary>
        /// Get leads list method
        /// </summary>
        /// <typeparam name="T">class to serialize</typeparam>
        /// <exception cref="AmoCrmException">Return error from server</exception>
        /// <returns>Deserialize the response to the specified class (ResponseAmoCrm)</returns>
        Task<T> GetLeadsAsync<T>() where T : class;

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
        Task<T> GetLeadsAsync<T>(string url, CookieContainer cookies, int? limitRows = 500,
            int? limitOffSet = 0, DateTime? modifiedSince = null) where T : class;

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
        Task<T> GetLeadsAsync<T>(string url, NetworkCredential credential, int? limitRows = 500,
            int? limitOffSet = 0, DateTime? modifiedSince = null) where T : class;

        /// <summary>
        /// Get leads list method
        /// Authorization is obtained through an instance of the AmoCrmConfig class specified in the constructor
        /// </summary>
        /// <typeparam name="T">class to serialize</typeparam>
        /// <param name="url">URL request</param>
        /// <exception cref="AmoCrmException">Return error from server</exception>
        /// <returns>Deserialize the response to the specified class (ResponseAmoCrm)</returns>
        Task<T> GetLeadsAsync<T>(string url) where T : class;

        #endregion

        #region Add leads

        /// <summary>
        /// Method for adding a lead
        /// </summary>
        /// <param name="leads">The structure of the added lead</param>
        /// <exception cref="AmoCrmException">Return error from server</exception>
        /// <returns>Deserialize the response to the specified class</returns>
        Task<T> AddLeadAsync<T>(AddOrUpdateCommand<AmoCrmLead> leads) where T : class;

        /// <summary>
        /// Method for adding a lead
        /// </summary>
        /// <param name="leads">The structure of the added lead</param>
        /// <param name="url">URL request</param>
        /// <param name="cookies">Cookies container</param>
        /// <exception cref="AmoCrmException">Return error from server</exception>
        /// <returns>Deserialize the response to the specified class</returns>
        Task<T> AddLeadAsync<T>(AddOrUpdateCommand<AmoCrmLead> leads, string url, CookieContainer cookies) where T : class;

        /// <summary>
        /// Method for adding a lead
        /// </summary>
        /// <param name="leads">The structure of the added lead</param>
        /// <param name="url">URL request</param>
        /// <param name="credential">Used By: UserName, Password, Domain</param>
        /// <exception cref="AmoCrmException">Return error from server</exception>
        /// <returns>Deserialize the response to the specified class</returns>
        Task<T> AddLeadAsync<T>(AddOrUpdateCommand<AmoCrmLead> leads, string url,
            NetworkCredential credential) where T : class;

        #endregion

        #endregion

        #region Company

        #region Get company

        /// <summary>
        /// Get company by id method
        /// </summary>
        /// <typeparam name="T">class to serialize</typeparam>
        /// <param name="companyId">id company</param>
        /// <exception cref="AmoCrmException">Return error from server</exception>
        /// <returns>Deserialize the response to the specified class (ResponseAmoCrm)</returns>
        Task<T> GetCompanyByIdAsync<T>(long companyId) where T : class;

        /// <summary>
        /// Get company by query method
        /// </summary>
        /// <typeparam name="T">class to serialize</typeparam>
        /// <param name="query">query company</param>
        /// <exception cref="AmoCrmException">Return error from server</exception>
        /// <returns>Deserialize the response to the specified class (ResponseAmoCrm)</returns>
        Task<T> GetCompanyByQueryAsync<T>(string query) where T : class;

        /// <summary>
        /// Get company by responsibleUserId method
        /// </summary>
        /// <typeparam name="T">class to serialize</typeparam>
        /// <param name="responsibleUserId">responsibleUserId company</param>
        /// <exception cref="AmoCrmException">Return error from server</exception>
        /// <returns>Deserialize the response to the specified class (ResponseAmoCrm)</returns>
        Task<T> GetCompanyByResponsibleUserIdAsync<T>(long responsibleUserId) where T : class;

        #endregion

        #region Add company

        /// <summary>
        /// Method for adding a company
        /// </summary>
        /// <param name="company">The structure of the added company</param>
        /// <exception cref="AmoCrmException">Return error from server</exception>
        /// <returns>Deserialize the response to the specified class</returns>
        Task<T> AddCompanyAsync<T>(AddOrUpdateCommand<AmoCrmCompany> company) where T : class;

        /// <summary>
        /// Method for adding a company
        /// </summary>
        /// <param name="company">The structure of the added company</param>
        /// <param name="url">URL request</param>
        /// <param name="cookies">Cookies container</param>
        /// <exception cref="AmoCrmException">Return error from server</exception>
        /// <returns>Deserialize the response to the specified class</returns>
        Task<T> AddCompanyAsync<T>(AddOrUpdateCommand<AmoCrmCompany> company, string url,
            CookieContainer cookies) where T : class;

        /// <summary>
        /// Method for adding a company
        /// </summary>
        /// <param name="company">The structure of the added company</param>
        /// <param name="url">URL request</param>
        /// <param name = "credential" > Used By: UserName, Password, Domain</param>
        /// <exception cref="AmoCrmException">Return error from server</exception>
        /// <returns>Deserialize the response to the specified class</returns>
        Task<T> AddCompanyAsync<T>(AddOrUpdateCommand<AmoCrmCompany> company, string url,
            NetworkCredential credential) where T : class;

        #endregion

        #endregion

        #region Universal method for add

        /// <summary>
        /// A universal method for adding an object passed in an instance of a class
        /// </summary>
        /// <param name="obj">The structure of the added object</param>
        /// <param name="url">URL request</param>
        /// <exception cref="AmoCrmException">Return error from server</exception>
        /// <returns>Deserialize the response to the specified class</returns>
        Task<T> AddObjAsync<T>(AddOrUpdateCommand<T> obj, string url) where T : class;

        /// <summary>
        /// A universal method for adding an object passed in an instance of a class
        /// </summary>
        /// <param name="obj">The structure of the added object</param>
        /// <param name="url">URL request</param>
        /// <param name="cookies">Cookies container</param>
        /// <exception cref="AmoCrmException">Return error from server</exception>
        /// <returns>Deserialize the response to the specified class</returns>
        Task<T> AddObjAsync<T>(AddOrUpdateCommand<T> obj, string url, CookieContainer cookies) where T : class;

        /// <summary>
        /// A universal method for adding an object passed in an instance of a class
        /// </summary>
        /// <param name="obj">The structure of the added object</param>
        /// <param name="url">URL request</param>
        /// <param name="credential">Used By: UserName, Password, Domain</param>
        /// <exception cref="AmoCrmException">Return error from server</exception>
        /// <returns>Deserialize the response to the specified class</returns>
        Task<T> AddObjAsync<T>(AddOrUpdateCommand<T> obj, string url,
            NetworkCredential credential) where T : class;

        #endregion

        #region Universal methods for get

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
        Task<T> GetObjByIdAsync<T>(string id, string url, CookieContainer cookies, int? limitRows = 500,
            int? limitOffSet = 0, DateTime? modifiedSince = null) where T : class;

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
        Task<T> GetObjByIdAsync<T>(string id, string url, NetworkCredential credential,
            int? limitRows = 500, int? limitOffSet = 0, DateTime? modifiedSince = null) where T : class;

        /// <summary>
        /// Get obj by id method
        /// Authorization is obtained through an instance of the AmoCrmConfig class specified in the constructor
        /// </summary>
        /// <typeparam name="T">class to serialize</typeparam>
        /// <param name="id">query id</param>
        /// <param name="url">URL request</param>
        /// <exception cref="AmoCrmException">Return error from server</exception>
        /// <returns>Deserialize the response to the specified class (ResponseAmoCrm)</returns>
        Task<T> GetObjByIdAsync<T>(string id, string url) where T : class;

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
        Task<T> GetObjByQueryAsync<T>(string query, string url, CookieContainer cookies, int? limitRows = 500,
            int? limitOffSet = 0, DateTime? modifiedSince = null) where T : class;

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
        Task<T> GetObjByQueryAsync<T>(string query, string url, NetworkCredential credential,
            int? limitRows = 500, int? limitOffSet = 0, DateTime? modifiedSince = null) where T : class;

        /// <summary>
        /// Get obj by query method
        /// Authorization is obtained through an instance of the AmoCrmConfig class specified in the constructor
        /// </summary>
        /// <typeparam name="T">class to serialize</typeparam>
        /// <param name="query">query obj</param>
        /// <param name="url">URL request</param>
        /// <exception cref="AmoCrmException">Return error from server</exception>
        /// <returns>Deserialize the response to the specified class (ResponseAmoCrm)</returns>
        Task<T> GetObjByQueryAsync<T>(string query, string url) where T : class;

        #endregion

        #region Get by ResponsibleUserId

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
        Task<T> GetObjByResponsibleUserIdAsync<T>(long responsibleUserId, string url,
            CookieContainer cookies, int? limitRows = 500, int? limitOffSet = 0, DateTime? modifiedSince = null)
            where T : class;

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
        Task<T> GetObjByResponsibleUserIdAsync<T>(long responsibleUserId, string url,
            NetworkCredential credential, int? limitRows = 500, int? limitOffSet = 0, DateTime? modifiedSince = null)
            where T : class;

        /// <summary>
        /// Get obj by responsibleUserId method
        /// Authorization is obtained through an instance of the AmoCrmConfig class specified in the constructor
        /// </summary>
        /// <typeparam name="T">class to serialize</typeparam>
        /// <param name="responsibleUserId">query responsibleUserId</param>
        /// <param name="url">URL request</param>
        /// <exception cref="AmoCrmException">Return error from server</exception>
        /// <returns>Deserialize the response to the specified class (ResponseAmoCrm)</returns>
        Task<T> GetObjByResponsibleUserIdAsync<T>(long responsibleUserId, string url) where T : class;

        #endregion

        #region Get obj list

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
        Task<T> GetObjListAsync<T>(string url, CookieContainer cookies, int? limitRows = 500,
            int? limitOffSet = 0, DateTime? modifiedSince = null) where T : class;

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
        Task<T> GetObjListAsync<T>(string url, NetworkCredential credential, int? limitRows = 500,
            int? limitOffSet = 0, DateTime? modifiedSince = null) where T : class;

        /// <summary>
        /// Get obj list method
        /// Authorization is obtained through an instance of the AmoCrmConfig class specified in the constructor
        /// </summary>
        /// <typeparam name="T">class to serialize</typeparam>
        /// <param name="url">URL request</param>
        /// <exception cref="AmoCrmException">Return error from server</exception>
        /// <returns>Deserialize the response to the specified class (ResponseAmoCrm)</returns>
        Task<T> GetObjListAsync<T>(string url) where T : class;

        #endregion

        #endregion
    }
}