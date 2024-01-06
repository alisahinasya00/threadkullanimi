using System;
using System.Collections;

namespace _211229024_alisahin_asya_vize
{
	public class AsalSayilariBul : IThread
	{
		private ArrayList[] parcalar;
		private static bool AsalSayilarYazildi = false;
		public AsalSayilariBul(ArrayList[] parcalar)
		{
			this.parcalar = parcalar;
		}

		public void Run()
		{
			try
			{
				ArrayList asalSayilar = new ArrayList(); 


				foreach (var parca in parcalar)
				{
					foreach (int sayi in parca)
					{
						if (IsAsal(sayi))
						{
							lock (Program.sayiListesi.SyncRoot) 
							{
								
									asalSayilar.Add(sayi);
							
							}
						}
					}
				}

				lock (Program.sayiListesi.SyncRoot)
				{
					if (!AsalSayilarYazildi)
					{
						Console.WriteLine("\nAsal Sayılar: ");
						foreach (int asalSayi in asalSayilar)
						{
							Console.Write(asalSayi + " ");
						}

						AsalSayilarYazildi = true;
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Hata: {ex.Message}");
			}
		}

		private bool IsAsal(int sayi)
		{
			if (sayi < 2)
				return false;

			for (int i = 2; i <=sayi/2; i++)
			{
				if (sayi % i == 0)
					return false;
			}

			return true;
		}
	}
}
