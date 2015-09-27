namespace HomeCinema.Services
{
	public interface IEncryptionService
	{
		/// <summary>
		/// Creates a random salt
		/// </summary>
		string CreateSalt();

		/// <summary>
		/// Generates a Hashed password
		/// </summary>
		string EncryptPassword(string password, string salt);
	}
}
