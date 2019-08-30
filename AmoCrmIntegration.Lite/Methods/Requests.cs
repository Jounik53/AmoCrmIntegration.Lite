using AmoCrmIntegration.Lite.Models;
using AmoCrmIntegration.Lite.Utils;
using RestSharp;
using System;
using System.Net;
using System.Threading.Tasks;
using RestClient = RestSharp.RestClient;

namespace AmoCrmIntegration.Lite.Methods
{
    public class Requests
    {
        private static CookieContainer _cookies;
        private static DateTime _lastSessionStarted;
        private const int AuthSessionLimit = 15;

        #region Methods sending requests

        #region PostRequest

        /// <summary>
        /// Asynchronous method of transmitting data to the server (POST)
        /// </summary>
        /// <typeparam name="T">class to serialize</typeparam>
        /// <param name="url">URL request</param>
        /// <param name="data">String in json format</param>
        /// <param name="cookies">Cookies container</param>
        /// <returns>Id of added item</returns>
        /// <exception cref="ArgumentNullException">Argument is null</exception>
        /// <exception cref="AmoCrmException">Return error from server</exception>
        /// <returns></returns>
        public static async Task<T> PostAsync<T>(string url, string data, CookieContainer cookies) where T : class
        {
            if (cookies == null)
            {
                throw new ArgumentNullException(nameof(cookies));
            }

            RestClient client;

            try
            {
                client = new RestClient(url)
                {
                    CookieContainer = cookies
                };
            }
            catch (Exception e)
            {
                throw new AmoCrmException(e.Message, errorCode: "401");
            }

            var request = new RestRequest(Method.POST);
            request.AddParameter(new Parameter
            {
                Name = "text/json",
                Value = data,
                Type = ParameterType.RequestBody
            });

            var response = await client.ExecuteTaskAsync(request);

            var obj = response.Content.DeserializeTo<T>();

            return obj;
        }

        /// <summary>
        /// Asynchronous method of transmitting data to the server (POST)
        /// </summary>
        /// <typeparam name="T">class to serialize</typeparam>
        /// <param name="url">URL request</param>
        /// <param name="data">String in json format</param>
        /// <param name="config">Configuration Class Instance</param>
        /// <returns>Id of added item</returns>
        /// <exception cref="ArgumentNullException">Argument is null</exception>
        /// <exception cref="AmoCrmException">Return error from server</exception>
        /// <returns></returns>
        public static Task<T> PostAsync<T>(string url, string data, AmoCrmConfig config) where T : class
        {
            return PostAsync<T>(url, data,
                GetCookies(new NetworkCredential(config.UserLogin, config.UserHash, config.AuthUrl)));
        }

        /// <summary>
        /// Asynchronous method of transmitting data to the server (POST)
        /// </summary>
        /// <typeparam name="T">class to serialize</typeparam>
        /// <param name="url">URL request</param>
        /// <param name="data">String in json format</param>
        /// <param name="credentials">Used By: UserName, Password, Domain</param>
        /// <returns>Id of added item</returns>
        /// <exception cref="ArgumentNullException">Argument is null</exception>
        /// <exception cref="AmoCrmException">Return error from server</exception>
        /// <returns></returns>
        public static Task<T> PostAsync<T>(string url, string data, NetworkCredential credentials) where T : class
        {
            return PostAsync<T>(url, data, GetCookies(credentials));
        }

        #endregion

        #region Get request

        /// <summary>
        /// Asynchronous method of transmitting data to the server (GET)
        /// </summary>
        /// <typeparam name="T">class to serialize</typeparam>
        /// <param name="url">URL request</param>
        /// <param name="parameters">Query Parameters: Name, Value</param>
        /// <param name="cookies">Cookies container</param>
        /// <param name="limitRows">Receive limit (default is 500)</param>
        /// <param name="limitOffSet">String Shift (default 0)</param>
        /// <param name="modifiedSince">Modification date (default is null)</param>
        /// <exception cref="ArgumentNullException">Argument is null</exception>
        /// <exception cref="AmoCrmException">Return error from server</exception>
        /// <returns></returns>
        public static async Task<T> GetAsync<T>(string url, Parameter[] parameters, CookieContainer cookies,
            int? limitRows = 500, int? limitOffSet = 0, DateTime? modifiedSince = null) where T : class
        {
            if (cookies == null)
            {
                throw new ArgumentNullException(nameof(cookies));
            }

            RestClient client;

            try
            {
                client = new RestClient(url)
                {
                    CookieContainer = cookies
                };
            }
            catch (Exception e)
            {
                throw new AmoCrmException(e.Message, errorCode: "401");
            }

            var request = new RestRequest(Method.GET);
            request.AddParameter("limit_rows", limitRows);
            request.AddParameter("limit_offset", limitOffSet);
            foreach (var parameter in parameters)
            {
                request.AddParameter(parameter);
            }

            if (modifiedSince.HasValue)
                request.AddHeader("If-Modified-Since", modifiedSince.Value.ToString("u"));

            var response = await client.ExecuteTaskAsync(request);

            var obj = response.Content.DeserializeTo<T>();
            return obj;
        }

        /// <summary>
        /// Asynchronous method of transmitting data to the server (GET)
        /// </summary>
        /// <typeparam name="T">class to serialize</typeparam>
        /// <param name="url">URL request</param>
        /// <param name="parameters">Query Parameters: Name, Value</param>
        /// <param name="credential">Used By: UserName, Password, Domain</param>
        /// <param name="limitRows">Receive limit (default is 500)</param>
        /// <param name="limitOffSet">String Shift (default 0)</param>
        /// <param name="modifiedSince">Modification date (default is null)</param>
        /// <exception cref="ArgumentNullException">Argument is null</exception>
        /// <exception cref="AmoCrmException">Return error from server</exception>
        /// <returns></returns>
        public static Task<T> GetAsync<T>(string url, Parameter[] parameters, NetworkCredential credential,
            int? limitRows = 500, int? limitOffSet = 0, DateTime? modifiedSince = null) where T : class
        {
            return GetAsync<T>(url, parameters, GetCookies(credential), limitRows, limitOffSet, modifiedSince);
        }

        /// <summary>
        /// Asynchronous method of transmitting data to the server (GET)
        /// </summary>
        /// <typeparam name="T">class to serialize</typeparam>
        /// <param name="url">URL request</param>
        /// <param name="parameters">Query Parameters: Name, Value</param>
        /// <param name="config">Class instance AmoCrmConfig</param>
        /// <exception cref="ArgumentNullException">Argument is null</exception>
        /// <exception cref="AmoCrmException">Return error from server</exception>
        /// <returns></returns>
        public static Task<T> GetAsync<T>(string url, Parameter[] parameters, AmoCrmConfig config) where T : class
        {
            return GetAsync<T>(url, parameters, GetCookies(config), config.LimitRows, config.LimitOffset,
                config.ModifiedSince);
        }

        #endregion

        #endregion

        #region Methods work with cookies

        /// <summary>
        /// Method for obtaining cookies for authorization
        /// </summary>
        /// <param name="config">Instance of the library configuration class</param>
        /// <exception cref="AmoCrmException">Return error from server</exception>
        /// <returns></returns>
        public static CookieContainer GetCookies(AmoCrmConfig config)
        {
            return GetCookies(new NetworkCredential(config.UserLogin, config.UserHash, config.AuthUrl));
        }

        /// <summary>
        /// Method for obtaining cookies for authorization
        /// </summary>
        /// <param name="authUrl">Url address for authorization</param>
        /// <param name="login">User login</param>
        /// <param name="hash">User hash</param>
        /// <exception cref="AmoCrmException">Return error from server</exception>
        /// <returns></returns>
        public static CookieContainer GetCookies(string authUrl, string login, string hash)
        {
            return GetCookies(new NetworkCredential(login, hash, authUrl));
        }

        /// <summary>
        /// Method for obtaining cookies for authorization
        /// </summary>
        /// <param name="credentials">An instance of the credentials class used fields: UserName, Password, Domain</param>
        /// <exception cref="AmoCrmException">Return error from server</exception>
        /// <returns></returns>
        public static CookieContainer GetCookies(NetworkCredential credentials)
        {
            var sessionLimitIsExceeded = DateTime.Now - new TimeSpan(0, 0, AuthSessionLimit, 0) > _lastSessionStarted;
            if (_cookies == null || sessionLimitIsExceeded)
            {
                var request = new RestRequest(Method.POST);
                request.AddParameter("USER_LOGIN", credentials.UserName);
                request.AddParameter("USER_HASH", credentials.Password);

                var response = new RestClient(credentials.Domain).Execute(request);
                var responseContent = response.Content.DeserializeTo<AmoCrmResponseAuth>();
                if (!responseContent.Response.Auth)
                {
                    throw new AmoCrmException(responseContent.Response.ErrorMessage,
                        responseContent.Response.ErrorCode);
                }

                var newCookieContainer = new CookieContainer();
                foreach (var cookie in response.Cookies)
                {
                    newCookieContainer.Add(new Cookie(cookie.Name, cookie.Value, cookie.Path, cookie.Domain));
                }

                _lastSessionStarted = DateTime.Now;
                _cookies = newCookieContainer;
            }

            return _cookies;
        }

        #endregion
    }
}