using System;
using System.Collections;

namespace _211229024_alisahin_asya_vize
{
	public class TekSayilariBul:IThread
	{
		private ArrayList[] parcalar;

	    public TekSayilariBul(ArrayList[] parcalar)
		{
			this.parcalar = parcalar;
		}

		public void Run()
		{
			try
			{
				ArrayList tekSayilar = new ArrayList(); // Önce koleksiyonu oluştur

				foreach (var parca in parcalar)
				{
					foreach (int sayi in parca)
					{
						if (sayi % 2 != 0)
						{
							lock (Program.sayiListesi.SyncRoot) // Senkronize etmek için lock kullan
							{
								tekSayilar.Add(sayi);
							}
						}
					}
				}

				// Sonuçları yazdır
				lock (Program.sayiListesi.SyncRoot) // Senkronize etmek için lock kullan
				{
					Console.WriteLine("\nTek Sayılar: ");
					foreach (int tekSayi in tekSayilar)
					{
						Console.Write(tekSayi + " ");
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Hata: {ex.Message}");
			}
		}
	}
}
