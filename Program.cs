namespace Otomat
{
    using System;
    using System.Data;
    using System.Linq;

    class Program
    {
        
        static void Main(string[] args)
        {
            string[] urunler = { "Kola", "Su", "Soda", "Meyveli Soda", "Meyve Suyu" };
            double[] fiyatlar = { 20.0, 10.0, 13.5, 17.5, 20.0 };
            double bakiye = 0;


            Console.WriteLine("Hoşgeldiniz!\nÜrün seçimi için tuşlayınız.");
            int giris = Convert.ToInt32(Console.ReadLine());


            if (giris == 0)
            {

                Console.WriteLine("Admin parolasını girin:");
                string parola = Console.ReadLine();

                if (parola == "123")
                {
                    Console.WriteLine("Admin Paneline Hoşgeldiniz!\nYapmak istediğiniz işlemi seçiniz.\n1-Urun Ekleme\n2-Urun Sil\n3-Fiyat Guncelleme\n4-Urun Guncelleme");
                    int secim = Convert.ToInt32(Console.ReadLine());

                    if (secim == 1)
                    {
                        Console.WriteLine("Yeni ürünün adını girin:");
                        string yeniUrunAd = Console.ReadLine();
                        Console.WriteLine("Yeni ürünün fiyatını girin:");
                        double yeniUrunFiyat = Convert.ToDouble(Console.ReadLine());

                        Array.Resize(ref urunler, urunler.Length + 1);
                        Array.Resize(ref fiyatlar, fiyatlar.Length + 1);

                        urunler[urunler.Length - 1] = yeniUrunAd;
                        fiyatlar[fiyatlar.Length - 1] = yeniUrunFiyat;

                        Console.WriteLine("Yeni ürün eklendi.");

                    }
                    else if (secim == 2)
                    {
                        Console.WriteLine("Silinecek ürünün numarasını girin:");
                        int urunNo = Convert.ToInt32(Console.ReadLine());

                        for (int i = urunNo - 1; i < urunler.Length - 1; i++)
                        {
                            urunler[i] = urunler[i + 1];
                            fiyatlar[i] = fiyatlar[i + 1];
                        }

                        Array.Resize(ref urunler, urunler.Length - 1);
                        Array.Resize(ref fiyatlar, fiyatlar.Length - 1);

                        Console.WriteLine("Ürün silindi.");

                    }

                    else if (secim == 3)
                    {
                        Console.WriteLine("Fiyatını güncellemek istediğiniz ürünün numarasını girin:");

                        for (int i = 0; i < urunler.Length; i++)
                        {
                            Console.WriteLine($"{i + 1}. {urunler[i]} - {fiyatlar[i]} TL");
                        }

                        int secimFiyat = Convert.ToInt32(Console.ReadLine());

                        if (secimFiyat < 1 || secimFiyat > urunler.Length)
                        {
                            Console.WriteLine("Geçersiz ürün numarası!");
                            return;
                        }

                        Console.WriteLine("Yeni fiyatı girin:");
                        fiyatlar[secimFiyat - 1] = Convert.ToDouble(Console.ReadLine());

                        Console.WriteLine("Fiyat güncellendi.");


                    }
                    else if (secim == 4)
                    {
                        Console.WriteLine("Güncellenecek ürünün numarasını girin:");
                        int urunNo = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Yeni ürün adını girin:");
                        string yeniUrunAdi = Console.ReadLine();
                        Console.WriteLine("Yeni ürün fiyatını girin:");
                        double yeniUrunFiyati = Convert.ToDouble(Console.ReadLine());

                        urunler[urunNo - 1] = yeniUrunAdi;
                        fiyatlar[urunNo - 1] = yeniUrunFiyati;

                        Console.WriteLine("Ürün güncellendi.");
                    }




                }
                else
                {
                    Console.WriteLine("Hatalı parola!");
                   
                }


            }
            else {
                while (true)
                {
                    Console.WriteLine("Lütfen bir ürün seçin:");
                    for (int i = 0; i < urunler.Length; i++)
                    {
                        Console.WriteLine($"{i + 1}. {urunler[i]} - {fiyatlar[i]} TL");
                    }

                    int secim = Convert.ToInt32(Console.ReadLine());

                    if (secim < 1 || secim > urunler.Length)
                    {
                        Console.WriteLine("Geçersiz ürün numarası!\n");

                        continue;

                    }

                    double urunFiyati = fiyatlar[secim - 1];
                    Console.WriteLine($"Seçilen Ürün: {urunler[secim - 1]}, Fiyat: {urunFiyati} TL");

                    if (urunFiyati <= bakiye)
                    {
                        bakiye -= urunFiyati;
                        Console.WriteLine("Ürün satın alındı.\n");
                        Console.WriteLine($"Kalan bakiye: {bakiye} TL\n");
                    }
                    else
                    {
                        Console.WriteLine("Yetersiz bakiye! Lütfen para ekleyin.\n");
                        Console.WriteLine("Para miktarını girin:\n");
                        double miktar = Convert.ToDouble(Console.ReadLine());
                        bakiye += miktar;
                        Console.WriteLine($"Hesabınıza {miktar} TL eklendi. Yeni bakiye: {bakiye} TL\n");
                    }
                }

            }



        }
    }
}
