using Newtonsoft.Json;
using System.Collections.Generic;

namespace TinyAsp.App
{

	/*
	 *  Liskov Substitution Principle
	 *  ------------------------------
	 *  
	 *  INotificationSender:
	 *		// ExternalApiUnavailableException
	 *		// InvalidOperationException
	 *		// ArgumentNullException
	 *		void SendNotification(string phoneNumber, string message)
	 *  
	 *  PhoneCallNotificationSender : INotificationSender
	 *		void SendNotification():
	 *			
	 *			
	 *  SmsNotificationSender : INotificationSender
	 *		// SmsNotSupportedInClientCountryException -> InvalidOperationException
	 *		// ClientDisabledSmsRecievingException -> InvalidOperationException
	 *		void SendNotification():
	 *			
	 *  
	 *  Interface/Contract Segregation Principle
	 *  -----------------------------------------
	 *  
	 *  IRepository:
	 *		AddEntityToDb(object input)
	 *		UpdateEntityInDb(object key, object updatedInput)
	 *		DeleteEntityFromDb(object key)
	 *		
	 *	ITransactionSupported : IRepository
	 *		BeginTransactionScope()
	 *		CommitTransactionScope()
	 *		RollbackTransactionScope()
	 *	
	 *	MsSqlProductsRepository : ITransactionSupported => IRepository
	 *	PostgreSqlProductsRepository : ITransactionSupported => IRepository
	 *	RedisProductsRepository : IRepository
	 *	{
	 *		BeginTransactionScope() { }
	 *		CommitTransactionScope() { }
	 *		
	 *		BeginTransactionScope() -> JUST OK
	 *		AddEntityToDb() ADDED
	 *		AddEntityToDb() ADDED
	 *		AddEntityToDb() ADDED
	 *		RollbackTransactionScope() -> {}
	 *	}
	 *	
	 *  
	 *  foreach        add/remove     access by index
	 *  IEnumerable -> ICollection -> IList:
	 *  
	 *  T MoveNext()   Add
	 *				   Remove
	 *								GetByIndex
	 *		
	 *	Graph 
	 *	LinkedList [V1|NP] => [V|NP] => [V|NP] => [V|NP] => [V|NP] => [V|NP] 
	 *	Stack
	 *	Array
	 *	List
	 *  
	 */



	public abstract class Controller
	{
		public Dictionary<string, string> _currentRequestHeaders;
        public Controller()
        {
			_currentRequestHeaders = new Dictionary<string, string>();
        }
		public void AddCurrentRequestHeader(string headerName, string headerValue)
        {
			_currentRequestHeaders[headerName] = headerValue;
		} 

		protected ActionResult Ok(object content)
		{
			return ActionResultFactory.GetActionResult(
				_currentRequestHeaders["Accept"], content);
		}
	}
}
