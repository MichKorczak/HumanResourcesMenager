namespace HumanResourcesManager.Core.Exceptions
{
	public class ErrorsMessage
	{
		public const string RegistrationErrorMessage = "Cannot create new user before register employee.";

		public const string ContentSaveError = "Cannot save changes in database.";

		public const string LoginError = "Login or password is incorrect.";

		public const string WrongId = "Employee with this Id doesn't exist.";
	}
}