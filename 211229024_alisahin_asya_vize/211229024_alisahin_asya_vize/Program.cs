using System;
using System.Collections;
using System.Threading;

namespace _211229024_alisahin_asya_vize
{
	public class Program
	{
		public static ArrayList sayiListesi = new ArrayList();
		public static ArrayList[] parcalar = new ArrayList[4];
		static void Main(string[] args)
		{
			listeyidoldur();
			listeyiparcala();
			threadleriayarla();
			Console.ReadLine();

		}

		static void listeyidoldur()
		{
			for (int i = 1; i <= 1000000; i++)
			{
				sayiListesi.Add(i);
			}
		}

		static void listeyiparcala()
		{
			int parcaBoyutu = sayiListesi.Count / 4;
			

			for (int i = 0; i < 4; i++)
			{
				parcalar[i] = new ArrayList(sayiListesi.GetRange(i * parcaBoyutu, parcaBoyutu));
			} 
		}

		static void threadleriayarla()
		{
		     Thread thread1 = new Thread(() => new TekSayilariBul(parcalar).Run());
			 Thread thread2 = new Thread(() => new CiftSayilariBul(parcalar).Run());
			 Thread thread3 = new Thread(() => new AsalSayilariBul(parcalar).Run());
             Thread thread4 = new Thread(() => new AsalSayilariBul(parcalar).Run());

			 thread1.Start();
             thread2.Start();
             thread3.Start();
             thread4.Start();

			//asalsayı foknisyonnun da sayı listede var mı yok mu kontrlü yap
		     
			 thread1.Join();
             thread2.Join();
             thread3.Join();
             thread4.Join();
 
		}
	}
}
