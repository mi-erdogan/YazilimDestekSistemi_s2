using Microsoft.AspNetCore.Mvc;
using YazilimDestekSistemi.WebServis.Models;

namespace YazilimDestekSistemi.WebServis.Controllers
{
	[ApiController]
	[Route("api/validasyon")]
	public class ValidasyonController : ControllerBase
	{
		[HttpPost("BaglantiBilgileri")]
		public IActionResult SomeActionMethod([FromBody] BaglantiBilgileri baglantiBilgileri)
		{
			string mesaj = "";

			if (baglantiBilgileri == null)
			{
				return BadRequest(new
				{
					Durum = 400,
					Baslik = "Kontrol - 00000",
					Aciklama = "Geçersiz istek",
					Mesaj = "İçerik boş olamaz."
				});
			}

			if (string.IsNullOrWhiteSpace(baglantiBilgileri.ConnectionId) || baglantiBilgileri.ConnectionId == "string")
			{
				mesaj = (baglantiBilgileri.ConnectionId == "string")
					? "ConnectionId bilgisi 'string' olamaz. Lütfen geçerli bir ConnectionId giriniz."
					: "Lütfen geçerli bir ConnectionId giriniz.";

				var errorResponse = new
				{
					Durum = 400,
					Baslik = "Kontrol - 00001",
					Aciklama = "ConnectionId alanı zorunludur.",
					Mesaj = mesaj
				};

				return BadRequest(errorResponse);
			}

			if (string.IsNullOrWhiteSpace(baglantiBilgileri.ConnectionAdı) || baglantiBilgileri.ConnectionAdı == "string")
			{
				mesaj = (baglantiBilgileri.ConnectionAdı == "string")
					? "ConnectionAdı bilgisi 'string' olamaz. Lütfen geçerli bir ConnectionAdı giriniz."
					: "Lütfen geçerli bir ConnectionAdı giriniz.";

				var errorResponse = new
				{
					Durum = 400,
					Baslik = "Kontrol - 00002",
					Aciklama = "ConnectionAdı alanı zorunludur.",
					Mesaj = mesaj
				};

				return BadRequest(errorResponse);
			}

			if (string.IsNullOrWhiteSpace(baglantiBilgileri.SpId) || baglantiBilgileri.SpId == "string")
			{
				mesaj = (baglantiBilgileri.SpId == "string")
					? "SpId bilgisi 'string' olamaz. Lütfen geçerli bir SpId giriniz."
					: "Lütfen geçerli bir SpId giriniz.";

				var errorResponse = new
				{
					Durum = 400,
					Baslik = "Kontrol - 00003",
					Aciklama = "SpId alanı zorunludur.",
					Mesaj = mesaj
				};

				return BadRequest(errorResponse);
			}

			if (string.IsNullOrWhiteSpace(baglantiBilgileri.MevcutSurum) || baglantiBilgileri.MevcutSurum == "string")
			{
				mesaj = (baglantiBilgileri.MevcutSurum == "string")
					? "MevcutSurum bilgisi 'string' olamaz. Lütfen geçerli bir MevcutSurum giriniz."
					: "Lütfen geçerli bir MevcutSurum giriniz.";

				var errorResponse = new
				{
					Durum = 400,
					Baslik = "Kontrol - 00004",
					Aciklama = "MevcutSurum alanı zorunludur.",
					Mesaj = mesaj
				};

				return BadRequest(errorResponse);
			}

			return Ok(new
			{
				Durum = 200,
				Baslik = "Başarılı",
				Mesaj = "Zorunlu Validasyon Kontrolünden geçildi."
			});
		}
	}
}

