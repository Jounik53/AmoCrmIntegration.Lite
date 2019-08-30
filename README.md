# AmoCrmIntegration.Lite
# Author:  Evgeny  Polyakov
# Version: 1.0.0.0

Библиотека для интеграции с сервисом АмоСрм

Для работы с библиотекой необходимо пройти авторизацию на своих данных, для этого вы можете использовать предусмотренный класс AmoCrmConfig, и тогда вам не придется с каждым запросом передавать авторизационные данные
или контейнеры cookies, так же в этом классе уже содержатся необходимые адреса обращений по api. Вы можете не использовать данный класс, так как имеются переопределяемые методы, в который вы можете передать свои данные
для авторизации, в виде контейнера cookies, или экземпляра NetworkCredential, а  так же свой url адресс для обращений.

Поддержка функционала: 
	1. Получение информации об аккаунте : "Task<T> GetAccountInfoAsync<T>()"
	2. Работа с контактами в сервисе, включает методы: 
		Получение:
		1. Получение контакта по его ID - "Task<T> GetContactByIdAsync<T>(long contactId)"
		2. Получение списка всех контактов - "Task<T> GetContactsAsync<T>()"
		3. Получения контакта по строке запроса (query) - "Task<T> GetContactByQueryAsync<T>(string query)"
		4. Получение контака по ID ответственного пользователя - "Task<T> GetContactByResponsibleUserIdAsync<T>(long responsibleUserId)"
		Добавление или обновление:
		1. Добавление или обновление контакта путём передачи  структуры контакта в метод - "Task<T> AddOrUpdateContactAsync<T>(AddOrUpdateCommand<AmoCrmContact> contacts)"
		
	3. Работа с сделками в сервисе включает методы:
		Получение:
		1. Получение всех сделок - "Task<T> GetLeadsAsync<T>()"
		Добавление:
		1. Добавление сделки путём передачи структуры сделки в метод - "Task<T> AddLeadAsync<T>(AddOrUpdateCommand<AmoCrmLead> leads)"
		
	4. Работа с компаниями в сервисе включает методы:
		Получение:
		1. Получение компании по её ID - "Task<T> GetCompanyByIdAsync<T>(long companyId)"
		2. Получение компании по строке  запроса (query) - "Task<T> GetCompanyByQueryAsync<T>(string query)"
		3. Получение компании по ID ответственного пользователя - "Task<T> GetCompanyByResponsibleUserIdAsync<T>(long responsibleUserId)"
		Добавление:
		1. Добавление или обновление компании путём передачи структуры компании в метод - "Task<T> AddCompanyAsync<T>(AddOrUpdateCommand<AmoCrmCompany> company)"
		
	5. Универсальные методы получения или добавления чего либо по структуре переданного класса,  имеющие  несколько перегрузок по передаваемым параметрам:
		Параметры:
		1. "Task<T> AddObjAsync<T>(AddOrUpdateCommand<T> obj, string url)", добавление или обновление, где T - структура которую необходимо передать или  обновить, url - адрес api в сервисе на который уйдет запрос
		В перегрузках могут присутствовать поля: 
			1. CookieContainer cookies - контейнер для печенек, необходимый для авторизации
			2. NetworkCredential credential - контейнер для авторизации (Поля: UserName, Password, Domain)
		
		4. "Task<T> GetObjByIdAsync<T>(string id, string url)", получение, где T - структура которую необходимо передать или  обновить, ID - id получаемого объекта ,url - адрес api в сервисе на который уйдет запрос
		Так же присутствуют методы получения по:
			1. Строке запроса (query) - Task<T> GetObjByQueryAsync<T>(string query, string url)
			2. Id ответственного пользователя (responsibleUserId) - Task<T> GetObjByResponsibleUserIdAsync<T>(long responsibleUserId, string url)
			3. Получения списка без параметров - Task<T> GetObjListAsync<T>(string url)
		
		В перегрузках могут присутсвовать поля:
			1. CookieContainer cookies - контейнер для печенек, необходимый для авторизации
			2. NetworkCredential credential - контейнер для авторизации (Поля: UserName, Password, Domain)
			3. int? limitRows - лимит получения полей (по умолчанию - 500)
			4. int? limitOffSet - сдвиг получаемых полей (используется при передачи - limitRows, по умолчанию - 0)
			5. DateTime? modifiedSince - время и дата модификации (по умолчанию - null) 			
		Пример:
			1. "Task<T> GetObjListAsync<T>(string url, NetworkCredential credential, int? limitRows = 500,
            int? limitOffSet = 0, DateTime? modifiedSince = null)"
			2. "Task<T> GetObjListAsync<T>(string url, CookieContainer cookies, int? limitRows = 500,
            int? limitOffSet = 0, DateTime? modifiedSince = null)"		
			
		В сервисе присутствуют готовые структуры для:
				1. Контактов - "AmoCrmContact" - Включает в себя полную структуру контакта
				2. Аккаунта - "CrmAccountInfo" - Включает в себя все поля аккаунта
				3. Сделки - "AmoCrmLead" - Включает в себя все поля сделок
				4. Компании - "AmoCrmCompany"  - Включает в себя все поля компании
		
		Для отправки запроса на  добавление или  обновление, в выбранный метод, необходимо использовать готовую структуру: - "AddOrUpdateCommand"  ,в него передается структура данных для запроса
		Примеры: 
			Создание экземпляра сервиса:
			
				public class ExampleClass1
				{
					private AmoCrmService _service;

					private static readonly string _userHash = "123123123123123sdf123daf123sdgf123";
					private static readonly string _userLogin = "Test@mail.ru";
					private static readonly string _subDomen = "test";

					public ExampleClass1()
					{
						var crmConfig = new AmoCrmConfig(_subDomen, _userLogin, _userHash);
						_service = new AmoCrmService(crmConfig);
					}
				}
			
			Для добавления контакта:
			
				public Task<ResponseAmoCrm> AddContact(AmoCrmContact contact)
				{
					var response = _service.AddOrUpdateContactAsync<ResponseAmoCrm>(new AddOrUpdateCommand<AmoCrmContact>
					{
						ItemAdd = new List<AmoCrmContact>
						{
							contact
						}
					});
					return response;
				}
				
			Для обновления контакта:
			
				public Task<ResponseAmoCrm> AddContact(AmoCrmContact contact)
				{
					var response = _service.AddOrUpdateContactAsync<ResponseAmoCrm>(new AddOrUpdateCommand<AmoCrmContact>
					{
						ItemUpdate = new List<AmoCrmContact>
						{
							contact
						}
					});
					return response;
				}
			
			Для получения контакта по id
			
				public Task<ResponseAmoCrm> GetContact(long id)
				{
					var response = _service.GetContactByIdAsync<ResponseAmoCrm>(id);
					return response;
				}	
				
			 Для получения информации об аккаунте
			 
				public Task<ResponseAmoCrm> GetAccountInfo()
				{
					var response = _service.GetAccountInfoAsync<ResponseAmoCrm>();
					return response;
				}
			 