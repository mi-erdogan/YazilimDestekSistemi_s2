using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Options;
using YazilimDestekSistemi.WebServis.Common.Helpers;
using YazilimDestekSistemi.WebServis.Services.Interfaces;

namespace YazilimDestekSistemi.WebServis.Services.Implementations
{
	public class AesHmacService : IAesHmacService
	{
		private readonly byte[] _keyBytes;
		private readonly byte[] _ivBytes;

		public AesHmacService(IOptions<EncryptionSettings> options)
		{
			var settings = options.Value;
			_keyBytes = string.IsNullOrWhiteSpace(settings.AesKey) ? Array.Empty<byte>() : Convert.FromBase64String(settings.AesKey);
			_ivBytes = string.IsNullOrWhiteSpace(settings.AesIV) ? Array.Empty<byte>() : Convert.FromBase64String(settings.AesIV);
		}

		public string Sifrele(string plainText)
		{
			if (string.IsNullOrEmpty(plainText)) return string.Empty;
			if (_keyBytes.Length == 0 || _ivBytes.Length == 0) return plainText;

			using var aes = Aes.Create();
			aes.Key = _keyBytes;
			aes.IV = _ivBytes;
			aes.Mode = CipherMode.CBC;
			aes.Padding = PaddingMode.PKCS7;

			using var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
			var inputBytes = Encoding.UTF8.GetBytes(plainText);
			var cipherBytes = encryptor.TransformFinalBlock(inputBytes, 0, inputBytes.Length);
			return Convert.ToBase64String(cipherBytes);
		}

		public string SifreCoz(string cipherText)
		{
			if (string.IsNullOrEmpty(cipherText)) return string.Empty;
			if (_keyBytes.Length == 0 || _ivBytes.Length == 0) return cipherText;

			using var aes = Aes.Create();
			aes.Key = _keyBytes;
			aes.IV = _ivBytes;
			aes.Mode = CipherMode.CBC;
			aes.Padding = PaddingMode.PKCS7;

			using var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
			var cipherBytes = Convert.FromBase64String(cipherText);
			var plainBytes = decryptor.TransformFinalBlock(cipherBytes, 0, cipherBytes.Length);
			return Encoding.UTF8.GetString(plainBytes);
		}
	}
}

