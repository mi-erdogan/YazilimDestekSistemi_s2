namespace YazilimDestekSistemi.WebServis.Models
{
	public class BaglantiBilgileri
	{
		public string ConnectionId { get; set; }
		public string ConnectionAdı { get; set; }
		public string SpId { get; set; }
		public string MevcutSurum { get; set; }
		public string GuncelSurum { get; set; }
		public string SurumTarihi { get; set; }
		public string ExeYolu { get; set; }
		public string PcAdi { get; set; }
		public string IpAdresi { get; set; }
		public string MacAdresi { get; set; }
		public string IsletimSistemi { get; set; }
		public string IsletimSistemiSurum { get; set; }
		public string EPostaAdresi { get; set; }
		public string EPostaSifre { get; set; }

		public void Validate()
		{
			if (string.IsNullOrWhiteSpace(ConnectionId))
				throw new ArgumentException("ConnectionId zorunludur.");
			if (string.IsNullOrWhiteSpace(ConnectionAdı))
				throw new ArgumentException("ConnectionAdı zorunludur.");
			if (string.IsNullOrWhiteSpace(SpId))
				throw new ArgumentException("SpId zorunludur.");
			if (string.IsNullOrWhiteSpace(MevcutSurum))
				throw new ArgumentException("MevcutSurum zorunludur.");
		}
	}
}

