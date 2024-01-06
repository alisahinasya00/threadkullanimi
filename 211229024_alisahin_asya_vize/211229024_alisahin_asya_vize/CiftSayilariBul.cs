using System;
using System.Collections;
using System.Threading;

namespace _211229024_alisahin_asya_vize
{
	public class CiftSayilariBul:IThread
	{
		private ArrayList[] parcalar;

		public CiftSayilariBul(ArrayList[] parcalar)
		{
			this.parcalar = parcalar;
		}

		public void Run()
		{
			try
			{
				ArrayList ciftSayilar = new ArrayList(); 

				foreach (var parca in parcalar)
				{
					foreach (int sayi in parca)
					{
						if (sayi % 2 == 0)
						{
							lock (Program.sayiListesi.SyncRoot)
							{
								ciftSayilar.Add(sayi);
							}
						}
					}
				}

				// Sonuçları yazdır
				lock (Program.sayiListesi.SyncRoot) 
				{
					Console.WriteLine("\nÇift Sayılar: ");
					foreach (int ciftSayi in ciftSayilar)
					{
						Console.Write(ciftSayi + " ");
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
