# AmoCrmIntegration.Lite
# Author:  Evgeny  Polyakov
# Version: 1.0.0.0

## Library for integration with AmoSrm service

To work with the library, you must be authorized on your data, for this you can use the provided AmoCrmConfig class, and then you do not have to transfer authorization data with each request
or cookie containers, also this class already contains the necessary api access addresses. You can not use this class, since there are overridable methods to which you can pass your data
for authorization, in the form of a container of cookies, or an instance of NetworkCredential, as well as your url address for calls.

### Functional support:
	1. Getting account information: "Task <T> GetAccountInfoAsync <T> ()"
	2. Work with contacts in the service, includes methods:
	2.1. Receiving:
	  1. Getting a contact by its ID - "Task <T> GetContactByIdAsync <T> (long contactId)"
      2. Getting a list of all contacts - "Task <T> GetContactsAsync <T> ()"
      3. Getting contact by query string (query) - "Task <T> GetContactByQueryAsync <T> (string query)"
      4. Getting the contact by the responsible user ID - "Task <T> GetContactByResponsibleUserIdAsync <T> (long responsibleUserId)"
    2.2. Add or update:
      1. Adding or updating a contact by passing the contact structure to the method - "Task <T> AddOrUpdateContactAsync <T> (AddOrUpdateCommand <AmoCrmContact> contacts)"
	3. Work with transactions in the service includes methods:
    3.1. Receiving:
      1. Getting all trades - "Task <T> GetLeadsAsync <T> ()"
    3.2. Addendum:
      1. Adding a deal by passing the deal structure to the method - "Task <T> AddLeadAsync <T> (AddOrUpdateCommand <AmoCrmLead> leads)"
    4. Work with companies in the service includes methods:
    4.1. Receiving:
      1. Getting a company by its ID - "Task <T> GetCompanyByIdAsync <T> (long companyId)"
      2. Getting the company by query line (query) - "Task <T> GetCompanyByQueryAsync <T> (string query)"
      3. Getting the company by the responsible user ID - "Task <T> GetCompanyByResponsibleUserIdAsync <T> (long responsibleUserId)"
    4.2. Addendum:
      1. Adding or updating a company by passing the company structure to the method - "Task <T> AddCompanyAsync <T> (AddOrUpdateCommand <AmoCrmCompany> company)"
    5. Universal methods for obtaining or adding something according to the structure of the transferred class, having several overloads in terms of the transmitted parameters:
    5.1. Options:
      1. "Task <T> AddObjAsync <T> (AddOrUpdateCommand <T> obj, string url)", add or update, where T is the structure to be transmitted or updated, url is the api address in the service to which the request will go
    5.2. Overloads may contain the following fields:
      1. CookieContainer cookies - cookie container for authorization
      2. NetworkCredential credential - container for authorization (Fields: UserName, Password, Domain)
      3. "Task <T> GetObjByIdAsync <T> (string id, string url)", receiving, where T is the structure to be transmitted or updated, ID is the id of the received object, url is the api address in the service the request will be sent to
### There are also methods for obtaining:
1. The query string (query) - Task <T> GetObjByQueryAsync <T> (string query, string url)
2. Id of the responsible user (responsibleUserId) - Task <T> GetObjByResponsibleUserIdAsync <T> (long responsibleUserId, string url)
3. Obtaining a list without parameters - Task <T> GetObjListAsync <T> (string url)

### Overloads may include the following fields:
1. CookieContainer cookies - cookie container for authorization
2. NetworkCredential credential - container for authorization (Fields: UserName, Password, Domain)
3. int? limitRows - limit for receiving fields (by default - 500)
4. int? limitOffSet - shift of the received fields (used for transmission - limitRows, default - 0)
5. DateTime? modifiedSince - time and date of modification (default is null)
#### Example:
1. "Task <T> GetObjListAsync <T> (string url, NetworkCredential credential, int? LimitRows = 500,
            int? limitOffSet = 0, DateTime? modifiedSince = null) "
2. "Task <T> GetObjListAsync <T> (string url, CookieContainer cookies, int? LimitRows = 500,
            int? limitOffSet = 0, DateTime? modifiedSince = null) "

### The service contains ready-made structures for:
1. Contacts - "AmoCrmContact" - Includes a complete contact structure
2. Account - "CrmAccountInfo" - Includes all account fields
3. Transactions - "AmoCrmLead" - Includes all transaction fields
4. Companies - "AmoCrmCompany" - Includes all fields of the company

## To send a request for addition or update to the selected method, you must use the ready-made structure: - "AddOrUpdateCommand", the data structure for the request is passed to it
### Examples:
#### Creating a service instance:

public class ExampleClass1
{
  private AmoCrmService _service;

  private static readonly string _userHash = "123123123123123sdf123daf123sdgf123";
  private static readonly string _userLogin = "Test@mail.ru";
  private static readonly string _subDomen = "test";

  public ExampleClass1 ()
  {
    var crmConfig = new AmoCrmConfig (_subDomen, _userLogin, _userHash);
    _service = new AmoCrmService (crmConfig);
  }
}

#### To add a contact:

public Task <ResponseAmoCrm> AddContact (AmoCrmContact contact)
{
  var response = _service.AddOrUpdateContactAsync <ResponseAmoCrm> (new AddOrUpdateCommand <AmoCrmContact>
  {
    ItemAdd = new List <AmoCrmContact>
    {
      contact
    }
  });
  return response;
}

#### To update a contact:

public Task <ResponseAmoCrm> AddContact (AmoCrmContact contact)
{
  var response = _service.AddOrUpdateContactAsync <ResponseAmoCrm> (new AddOrUpdateCommand <AmoCrmContact>
  {
    ItemUpdate = new List <AmoCrmContact>
    {
      contact
    }
  });
  return response;
}

#### To get contact by id

public Task <ResponseAmoCrm> GetContact (long id)
{
  var response = _service.GetContactByIdAsync <ResponseAmoCrm> (id);
  return response;
}

#### For account information

public Task <ResponseAmoCrm> GetAccountInfo ()
{
  var response = _service.GetAccountInfoAsync <ResponseAmoCrm> ();
  return response;
}
		 