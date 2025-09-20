using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using YazilimDestekSistemi.WebServis.Services.Interfaces;
using YazilimDestekSistemi.WebServis.Models;

namespace YazilimDestekSistemi.WebServis.Controllers
{
	[ApiController]
	[Route("api/auth")]
	public class AuthController : ControllerBase
	{
		private readonly IAesHmacService _crypto;
		private readonly IConfiguration _configuration;

		public AuthController(IAesHmacService crypto, IConfiguration configuration)
		{
			_crypto = crypto;
			_configuration = configuration;
		}

		[HttpPost("token-al")]
		public IActionResult GetToken([FromBody] LoginRequest request)
		{
			if (request == null)
				return BadRequest(new { Durum = 400, Baslik = "Hata", Mesaj = "Geçersiz istek" });

			if (request.Username == "belemir" && request.Password == "demir")
			{
				var token = GenerateJwtToken(request.BaglantiBilgileri);
				return Ok(new
				{
					Durum = 200,
					Baslik = "Başarılı",
					Aciklama = "Token bilgisini Giriş işleminde kullanınız",
					Mesaj = "Token oluşturuldu",
					Token = token
				});
			}

			return BadRequest(new
			{
				Durum = 400,
				Baslik = "Hata - 00001",
				Aciklama = "Kullanıcı adı veya şifre hatalı",
				Mesaj = "Lütfen geçerli bir kullanıcı adı ve şifre giriniz"
			});
		}

		private string GenerateJwtToken(BaglantiBilgileri baglantiBilgileri)
		{
			var tokenHandler = new JwtSecurityTokenHandler();
			var secretFromConfig = _configuration["Jwt:SecretKey"];
			if (string.IsNullOrWhiteSpace(secretFromConfig))
				throw new ArgumentNullException("Jwt:SecretKey yapılandırması eksik veya boş.");
			var key = Encoding.UTF8.GetBytes(secretFromConfig);

			var claims = new List<Claim>
			{
				new Claim("ConnectionId", _crypto.Sifrele(baglantiBilgileri?.ConnectionId ?? string.Empty)),
				new Claim("ConnectionAdı", _crypto.Sifrele(baglantiBilgileri?.ConnectionAdı ?? string.Empty)),
				new Claim("SpId", _crypto.Sifrele(baglantiBilgileri?.SpId ?? string.Empty)),
				new Claim("MevcutSurum", _crypto.Sifrele(baglantiBilgileri?.MevcutSurum ?? string.Empty)),
				new Claim("SurumTarihi", _crypto.Sifrele(baglantiBilgileri?.SurumTarihi ?? string.Empty)),
				new Claim("PcAdi", _crypto.Sifrele(baglantiBilgileri?.PcAdi ?? string.Empty)),
				new Claim("IpAdresi", _crypto.Sifrele(baglantiBilgileri?.IpAdresi ?? string.Empty)),
				new Claim("MacAdresi", _crypto.Sifrele(baglantiBilgileri?.MacAdresi ?? string.Empty)),
				new Claim("IsletimSistemi", _crypto.Sifrele(baglantiBilgileri?.IsletimSistemi ?? string.Empty)),
				new Claim("IsletimSistemiSurum", _crypto.Sifrele(baglantiBilgileri?.IsletimSistemiSurum ?? string.Empty))
			};

			claims.Add(new Claim("Username", "belemir"));
			claims.Add(new Claim("Role", "Admin"));

			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(claims),
				Expires = DateTime.UtcNow.AddDays(1),
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
			};

			var token = tokenHandler.CreateToken(tokenDescriptor);
			return tokenHandler.WriteToken(token);
		}
	}
}

