namespace YazilimDestekSistemi.WebServis.Services.Interfaces
{
	public interface IAesHmacService
	{
		string Sifrele(string plainText);
		string SifreCoz(string cipherText);
	}
}

