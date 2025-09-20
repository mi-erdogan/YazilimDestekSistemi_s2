using YazilimDestekSistemi.WebServis.Models;

namespace YazilimDestekSistemi.WebServis.Models
{
	public class LoginRequest
	{
		public string Username { get; set; }
		public string Password { get; set; }
		public BaglantiBilgileri BaglantiBilgileri { get; set; }
	}
}

