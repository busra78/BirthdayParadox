using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJE
{

    class Sinif                                //İnsanların doğum günlerini tutmak için oluşturduk..
    {
        public int dogum_gunu;                  //Belli olan public üyeler tanımladık..
        public int dogum_ayi;
        public string dogum_yeri;
        public int dogum_yeri_kod;              //Dogum yerinin string olmasından dolayı bunu integer şeklinde ayrı bir üyeyle tanımladık.
        static Random r = new Random();         //Random oluşturmayı ayrı ayrı methodlarda yaptığımızdan dolayı CLASS'ta methodların en üstünde random sınıfı kullandık..


        public void rastgele_dogum_tarihi()     //Random doğum tarihi atayan method oluşturduk.
        {

            dogum_ayi = r.Next(1, 13);          //12 ay olduğundan dogum ayına 1-13(1 dahil 13 dahil değil)arasında random sayı atar.

            switch (dogum_ayi)                  //Doğum aylarının herbiri 31 gün olmadığından switch case yapısı kullandık..
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    dogum_gunu = r.Next(1, 32);

                    break;
                case 2:
                    dogum_gunu = r.Next(1, 29);
                    break;
                case 4:
                case 6:
                case 9:
                case 11:
                    dogum_gunu = r.Next(1, 31);
                    break;

            }



        }

        public void rastgele_dogum_yeri()           //Seçtiğimiz 3 şehri switch case yapısı ile doğum yerine random atar ve aynı zamanda bu şehirler için integer kodlar oluşturur.
        {

            int i;

            i = r.Next(0, 3);

            switch (i)
            {
                case 0:
                    dogum_yeri = "IZMIR";           //Doğum yerinin kodu 0'sa İzmir,1'se Manchester,2'yse Roma yapar.
                    dogum_yeri_kod = 0;
                    break;
                case 1:
                    dogum_yeri = "MANCHESTER";
                    dogum_yeri_kod = 1;
                    break;
                case 2:
                    dogum_yeri = "ROMA";
                    dogum_yeri_kod = 2;
                    break;

            }

        }




    }
    class Program
    {
        static void Main(string[] args)
        {
            int secim;



            Menu();                 
            secim = Convert.ToInt16(Console.ReadLine()); //Kullanıcının  menüdeki girdiği seçeneği switch-case ve do-while yapısı ile kontrol eder.

            do
            {

                switch (secim)
                {
                    case 1:         //Şehirsiz Doğum Günü Paradoksu Çakışmaları ve İstatistiksel Değerleri Gösterir.

                        Ogrenci_yarat(secim);
                        menu_sayac++;

                        Menu();
                        secim = Convert.ToInt16(Console.ReadLine());

                        break;

                    case 2:         //Şehirli Doğum Günü Paradoksu Çakışmaları ve İstatistiksel Değerleri Gösterir.

                        Ogrenci_yarat(secim);
                        sehirli_menu_sayac++;
                        Menu();
                        secim = Convert.ToInt16(Console.ReadLine());

                        break;
                    case 3:         //Kullanıcı 3 sayısını girdiğinde program sonlanır.
                        Console.WriteLine("\n Program sonlandı..!");
                        Console.ReadLine();
                        break;
                    default:        //Kullanıcının 1-3 arasında sayı girip girmedğini kontrol eder.
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.WriteLine("\nLütfen 1-3 arasında uygun bir seçenek giriniz:");
                        Console.ForegroundColor = ConsoleColor.White;
                        secim = Convert.ToInt16(Console.ReadLine());

                        break;




                }


            } while (!(secim == 3));





        }

        static void Menu()

        {

            Console.Clear();        //Menüden önceki işlem karmaşasını önler ve ekranı temizler.

            Console.WriteLine("\n\n***************************************** MENÜ *******************************************************\n");
            Console.WriteLine("1.Doğum Günü Paradoksu Testi ve bu teste ilişkin bazı İstatistiksel Değerler.\n");
            Console.WriteLine("2.Doğum Günü ve aynı zamanda Doğum Yeri Paradoksu Testi ve bu teste ilişkin bazı İstatistiksel Değerler.\n");
            Console.WriteLine("3.Programı Sonlandır..\n");



        }






        static void Ogrenci_yarat(int secim)
        {

            int sayac = 0;

            Console.WriteLine("\nKullanıcı sayısı giriniz: \n"); //Kullanıcıdan sayı girmesini ister.
            int ogrenci_sayisi = Convert.ToInt16(Console.ReadLine());

            Sinif[] ogrenciler = new Sinif[ogrenci_sayisi];//ogrenciler adında Sinif Class'ı nesne dizisi oluşturur.
            ogrenci_sayilari[menu_sayac] = ogrenci_sayisi;
            sehirli_ogrenci_sayilari[sehirli_menu_sayac] = ogrenci_sayisi;

            for (int i = 0; i < ogrenciler.Length; ++i)//Nesne dizisinin her bir elemanını girilen kullanıcı sayısı kadar oluşturur.
            {
                ogrenciler[i] = new Sinif();
            }

            for (int i = 0; i < 10; i++)
            {
                int[,,] tablo = new int[3, 13, 32];      //3(Doğum Yeri),13(Ay),32(Max Gün)'lük bir üçlük tablo matrisi oluşturur ve Class'ta oluşturulan random methodlarını çağırır.
                for (int j = 0; j < ogrenci_sayisi; j++)
                {
                    ogrenciler[j].rastgele_dogum_tarihi();
                    ogrenciler[j].rastgele_dogum_yeri();
                    tablo[ogrenciler[j].dogum_yeri_kod, ogrenciler[j].dogum_ayi, ogrenciler[j].dogum_gunu]++;

                }
                sayac++;

                if (secim == 1)//Eğer menüdeki seçeneklerden kullanıcı 1'i seçerse her bir 10 deney için ayrı ayrı toplamda 10 şehirsiz çakışma tablosu oluşturur..
                               //ve bunlara ilişkin istatistiksel değerler gösterir.
                {


                    yazdir(tablo, sayac);



                }
                else if (secim == 2)//Eğer menüdeki seçeneklerden kullanıcı 2'yi seçerse  her üç şehir için ve her bir 10 deney için ayrı ayrı
                                    // toplamda 30 şehirli çakışma tablosu oluşturur ve bunlara ilişkin istatistiksel değerler gösterir.

                {


                    yazdir_sehir(tablo, sayac);



                }


            }




        }

        static double[,] tablo_ortalama = new double[13, 32];//Ortalama tablosu için tablodaki her ayın her günü için ayrı ayrı ortalaması alınmak üzere toplam çakışma değeri tutar.
        static int[,] toplam = new int[3, 11]; //Her bir deney için tüm yılın toplam çakışma değerini tutar ve her üç kullanıcı sayısında bu üç kullanıcı sayısının tüm istatiksel değerlerini tutar. 
        static double[] toplam_ortalama = new double[3];//Ortalamasını almak üzere her 10 deneyin çakışma toplamlarını tutar.
        static int menu_sayac = 0;//Kullanıcının her 3 sayı girdiğinde üçününde toplam istatistiksel bilgilerini ekranda göstermek için kontrol eder.
        static int[] ogrenci_sayilari = new int[3];//Kullanıcının girdiği her üç sayıyıda tutmasını sağlar.

        public static void yazdir(int[,,] tablo, int sayac)//Şehirsiz Doğum Günü Paradoksunun Çakışma Tablolarını yazdırır.
        {

            string[] aylar = { " ", "Ocak   ", "Şubat  ", "Mart   ", "Nisan  ", "Mayıs  ", "Haziran", "Temmuz ", "Ağustos", "Eylül  ", "Ekim   ", "Kasım  ", "Aralık " };

            for (int i = 1; i < 32; i++)//Gün sayılarını yazdırır.
            {

                Console.ForegroundColor = ConsoleColor.White;
                if (i == 1)
                {
                    Console.Write("{0,17}", i);

                }
                else
                {
                    Console.Write("{0,3}", i);

                }

            }
            Console.WriteLine("");
            Console.WriteLine("{0,108}", "_____________________________________________________________________________________________");
            Console.WriteLine("");
            Console.WriteLine("");

            for (int i = 1; i < 13; i++) //Ayları yazdırır.
            {

                for (int j = 1; j < 32; j++)//Ayların Günlerinin Çakışma Sayılarını yazdırır.
                {

                    if (j == 1)//Sadece tablonun düzeni açısında her ayın 1.gününde bir kaydırma mevcut.
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(aylar[i]);


                        if (tablo[0, i, j] + (tablo[1, i, j] + tablo[2, i, j]) == 1)//O gün  sadece 1 kişinin doğum günü varsa çakışma olmadığı için rengi kırmızı(RED) yapar..
                        {                                                              //Ve çakışma olmadığından sadece 1 yazdırır..
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("{0,10}", tablo[0, i, j] + tablo[1, i, j] + tablo[2, i, j]);

                        }

                        else if (tablo[0, i, j] + (tablo[1, i, j] + tablo[2, i, j]) >= 2)//O gün  sadece 2 kişinin veya daha fazla kişinin
                                                                                           //doğum günü varsa çakışma rengini Turkuaz(CYAN) yapar..
                                                                                           //Ve çakışma sayısı n-1 olur.
                                                                                           //Ve çakışmayı yazdırır.

                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write("{0,10}", tablo[0, i, j] + tablo[1, i, j] + tablo[2, i, j] - 1);
                            toplam[menu_sayac, sayac] += tablo[0, i, j] + tablo[1, i, j] + tablo[2, i, j] - 1;
                            toplam_ortalama[menu_sayac] += tablo[0, i, j] + tablo[1, i, j] + tablo[2, i, j] - 1;
                            tablo_ortalama[i, j] += tablo[0, i, j] + tablo[1, i, j] + tablo[2, i, j] - 1;

                        }
                        else                                    //O gün doğan yoksa rengi beyaz yapar ve 0 yazdırır.
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("{0,10}", tablo[0, i, j] + tablo[1, i, j] + tablo[2, i, j]);

                        }

                    }
                    else                                        //Ve her ayın ilk günleri hariç olanları yukardaki gibi oluşturur.
                    {

                        if (tablo[0, i, j] + (tablo[1, i, j] + tablo[2, i, j]) == 1)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("{0,3}", tablo[0, i, j] + tablo[1, i, j] + tablo[2, i, j]);
                        }
                        else if (tablo[0, i, j] + (tablo[1, i, j] + tablo[2, i, j]) >= 2)
                        {

                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write("{0,3}", tablo[0, i, j] + tablo[1, i, j] + tablo[2, i, j] - 1);
                            toplam[menu_sayac, sayac] += tablo[0, i, j] + tablo[1, i, j] + tablo[2, i, j] - 1;
                            toplam_ortalama[menu_sayac] += tablo[0, i, j] + tablo[1, i, j] + tablo[2, i, j] - 1;
                            tablo_ortalama[i, j] += tablo[0, i, j] + tablo[1, i, j] + tablo[2, i, j] - 1;

                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("{0,3}", tablo[0, i, j] + tablo[1, i, j] + tablo[2, i, j]);

                        }
                    }
                }
                Console.WriteLine("");

            }
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\n" + sayac + ". Denemenin sonuçları");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("\n\n Kırmızı(1):");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" O gün doğan tek kişi varsa,çakışma yok.");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("\n Cyan:");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("       O gün n doğan kişinin (n-1) çakışma sayısı.\n");
            Console.Write(" DEVAM ETMEK İÇİN HERHANGİ BİR TUŞA BASINIZ...\n\n\n\n");
            Console.ReadLine();




            if (sayac == 10)//10 deneyin sonunda ortalama çakışma tablosu bastırılır.
            {

                for (int i = 1; i < 13; i++)
                {
                    for (int j = 1; j < 32; j++)

                    {

                        tablo_ortalama[i, j] /= 10;

                    }

                }



                for (int k = 1; k < 32; k++)
                {

                    Console.ForegroundColor = ConsoleColor.White;
                    if (k == 1)
                    {
                        Console.Write("{0,16}", k);

                    }
                    else
                    {
                        Console.Write("{0,4}", k);

                    }

                }
                Console.WriteLine("");
                Console.WriteLine("{0,138}", "______________________________________________________________________________________________________________________________");
                Console.WriteLine("");
                Console.WriteLine("");

                for (int i = 1; i < 13; i++)
                {

                    for (int j = 1; j < 32; j++)
                    {

                        if (j == 1)
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("\n" + aylar[i]);
                            if (tablo_ortalama[i, j] > 0)

                            {
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.Write("{0,9} ", tablo_ortalama[i, j]);



                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write("{0,9} ", tablo_ortalama[i, j]);

                            }
                        }

                        else
                        {

                            if (tablo_ortalama[i, j] > 0)
                            {

                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.Write("{0,3} ", tablo_ortalama[i, j]);


                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write("{0,3} ", tablo_ortalama[i, j]);

                            }
                        }


                    }
                    Console.WriteLine("");
                }
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\n\n{0} Denemenin sonunda oluşan ortalamalar. ", sayac);
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadLine();
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("\n\tİSTATİSTİKSEL SONUÇLAR\n");
                Console.Write("----------------------------------------\n");
                Console.ForegroundColor = ConsoleColor.White;
                for (int i = 1; i < 11; i++)                                    //Her deneyin bir yılının toplam çakışma ortalamasını yazdırır.
                {
                    Console.WriteLine(i + ". Deney için toplam çakışma sayısı: " + toplam[menu_sayac, i]);
                }
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nTOPLAM ÇAKIŞMA ORTALAMASI: " + toplam_ortalama[menu_sayac] / 10);//Her deneyin ve  bir yılının otalama çakışma ortalamasını yazdırır.
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadLine();
                if (menu_sayac == 2)//Kullanıcı 3 KERE 1'i seçtiğinde ve  kullanıcı sayısı girdiğinde bu istatistiksel değerleri(toplam ve toplam ortalama) bir daha ekrana bastırır. 
                {
                    Console.Clear();
                    Console.Write("KULLANICI SAYILARI:\t  " + "n=" + ogrenci_sayilari[0] + "\t\t  n=" + ogrenci_sayilari[1] + "\t\t  n=" + ogrenci_sayilari[2] + "\n");
                    Console.WriteLine("-------------------\t -------\t -------\t -------");

                    for (int i = 1; i < 11; i++)
                    {
                        Console.WriteLine(i + ".DENEY İÇİN:\t\t    " + toplam[0, i] + "\t\t " + toplam[1, i] + "\t\t  " + toplam[2, i]);
                    }
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("ORTALAMA:\t\t  " + toplam_ortalama[0] / 10 + "\t\t " + toplam_ortalama[1] / 10 + "\t\t " + toplam_ortalama[2] / 10);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadLine();
                    for (int i = 0; i < 3; i++)
                    {
                        toplam_ortalama[i] = 0;

                        for (int j = 1; j < 11; j++)
                        {
                            toplam[i, j] = 0;
                        }
                    }
                    menu_sayac = 0;


                }

            }




        }

        //YUKARIDA YAPILAN İŞLEMLERİN ŞEHİRLİ OLARAK YAPILMIŞ METHODU VE DEĞİŞKENLERİ

        static int[,,] sehirli_toplam = new int[3, 3, 11];
        static double[,] sehirli_toplam_ortalama = new double[3, 3];
        static int sehirli_menu_sayac = 0;
        static int[] sehirli_ogrenci_sayilari = new int[3];


        static double[,,] sehir_tablo_ortalama = new double[3, 13, 32];
        public static void yazdir_sehir(int[,,] tablo, int sayac)
        {


            string[] aylar = { " ", "Ocak   ", "Şubat  ", "Mart   ", "Nisan  ", "Mayıs  ", "Haziran", "Temmuz ", "Ağustos", "Eylül  ", "Ekim   ", "Kasım  ", "Aralık " };
            string sehir = "";
            int k = 0;



            for (k = 0; k < 3; k++)
            {
                for (int i = 1; i < 32; i++)
                {

                    Console.ForegroundColor = ConsoleColor.White;
                    if (i == 1)
                    {
                        Console.Write("{0,17}", i);

                    }
                    else
                    {
                        Console.Write("{0,3}", i);

                    }

                }
                Console.WriteLine("");
                Console.WriteLine("{0,108}", "_____________________________________________________________________________________________");
                Console.WriteLine("");
                Console.WriteLine("");

                for (int i = 1; i < 13; i++)
                {

                    for (int j = 1; j < 32; j++)
                    {


                        if (j == 1)
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write(aylar[i]);



                            if (tablo[k, i, j] == 1)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("{0,10}", tablo[k, i, j]);

                            }

                            else if (tablo[k, i, j] >= 2)

                            {
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.Write("{0,10}", tablo[k, i, j] - 1);
                                sehirli_toplam[k, sehirli_menu_sayac, sayac] += tablo[k, i, j] - 1;
                                sehirli_toplam_ortalama[k, sehirli_menu_sayac] += tablo[k, i, j] - 1;
                                sehir_tablo_ortalama[k, i, j] += tablo[k, i, j] - 1;

                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write("{0,10}", tablo[k, i, j]);

                            }
                        }

                        else
                        {

                            if (tablo[k, i, j] == 1)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("{0,3}", tablo[k, i, j]);
                            }
                            else if (tablo[k, i, j] >= 2)
                            {

                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.Write("{0,3}", tablo[0, i, j] + tablo[1, i, j] + tablo[2, i, j] - 1);
                                sehirli_toplam[k, sehirli_menu_sayac, sayac] += tablo[k, i, j] - 1;
                                sehir_tablo_ortalama[k, i, j] += tablo[k, i, j] - 1;
                                sehirli_toplam_ortalama[k, sehirli_menu_sayac] += tablo[k, i, j] - 1;

                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write("{0,3}", tablo[k, i, j]);

                            }
                        }
                    }
                    Console.WriteLine("");

                }

                switch (k)
                {
                    case 0:
                        sehir = "İZMİR";
                        break;
                    case 1:
                        sehir = "MANCHESTER";
                        break;
                    case 2:
                        sehir = "ROMA";
                        break;
                }


                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\n " + sehir + " için " + sayac + ". Denemenin sonuçları");

                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\n\n Kırmızı(1):");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" O gün doğan tek kişi varsa,çakışma yok.");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("\n Cyan:");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("       O gün n doğan kişi varsa (n-1) çakışma sayısı.\n");
                Console.Write(" DEVAM ETMEK İÇİN HERHANGİ BİR TUŞA BASINIZ...\n\n\n\n");
                Console.ReadLine();


            }
            if (sayac == 10)
            {
                for (k = 0; k < 3; ++k)
                {
                    for (int i = 0; i < 12; i++)
                    {
                        for (int j = 0; j < 31; j++)

                        {
                            sehir_tablo_ortalama[k, i, j] /= 10;

                        }

                    }

                }


                for (k = 0; k < 3; k++)
                {

                    switch (k)
                    {
                        case 0:
                            sehir = "İZMİR";
                            break;
                        case 1:
                            sehir = "MANCHESTER";
                            break;
                        case 2:
                            sehir = "ROMA";
                            break;
                    }

                    for (int j = 1; j < 32; j++)
                    {

                        Console.ForegroundColor = ConsoleColor.White;
                        if (j == 1)
                        {
                            Console.Write("{0,16}", j);

                        }
                        else
                        {
                            Console.Write("{0,4}", j);

                        }

                    }
                    Console.WriteLine("");
                    Console.WriteLine("{0,138}", "______________________________________________________________________________________________________________________________");
                    Console.WriteLine("");
                    Console.WriteLine("");


                    for (int i = 1; i < 13; i++)
                    {

                        for (int j = 1; j < 32; j++)
                        {

                            if (j == 1)
                            {
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write("\n " + aylar[i]);
                                if (sehir_tablo_ortalama[k, i, j] > 0)

                                {
                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    Console.Write("{0,9} ", sehir_tablo_ortalama[k, i, j]);
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write("{0,9} ", sehir_tablo_ortalama[k, i, j]);

                                }
                            }

                            else
                            {

                                if (sehir_tablo_ortalama[k, i, j] > 0)
                                {

                                    Console.ForegroundColor = ConsoleColor.Cyan;
                                    Console.Write("{0,3} ", sehir_tablo_ortalama[k, i, j]);


                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Write("{0,3} ", sehir_tablo_ortalama[k, i, j]);

                                }
                            }
                        }


                    }
                    Console.WriteLine("\n\n");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("" + sehir + " için çakışma ortalamaları\n\n");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.ReadLine();
                
                Console.Clear();
                for (
                    int m = 0; m < 3; m++)
                {

                    switch (m)
                    {
                        case 0:
                            sehir = "İZMİR";
                            break;
                        case 1:
                            sehir = "MANCHESTER";
                            break;
                        case 2:
                            sehir = "ROMA";
                            break;
                    }
                    Console.ForegroundColor=ConsoleColor.Cyan;
                    Console.Write("\n" + sehir + " İÇİN " + "İSTATİSTİKSEL SONUÇLAR\n");
                    Console.Write("------------------------------------------------\n");


                    Console.ForegroundColor=ConsoleColor.White;

                    for (int i = 1; i < 11; i++)
                    {
                        Console.WriteLine(i + ". Deney için toplam çakışma sayısı: " + sehirli_toplam[m,sehirli_menu_sayac, i]);
                    }
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\nTOPLAM ÇAKIŞMA ORTALAMASI: " + sehirli_toplam_ortalama[m, sehirli_menu_sayac] / 10);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadLine();
                }

                Console.Clear();
                if (sehirli_menu_sayac == 2)
                {
                    for (int m = 0; m < 3; m++)
                {
                    switch (m)
                    {
                        case 0:
                            sehir = "İZMİR";
                            break;
                        case 1:
                            sehir = "MANCHESTER";
                            break;
                        case 2:
                            sehir = "ROMA";
                            break;
                    }

                    

                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine(sehir + " İÇİN \n");
                        Console.Write("KULLANICI SAYISI:\t  " + "n=" + sehirli_ogrenci_sayilari[0] + "\t\t  n=" + sehirli_ogrenci_sayilari[1] + "\t\t  n=" + sehirli_ogrenci_sayilari[2] + "\n");
                        Console.WriteLine("-------------------\t -------\t -------\t -------");
                        Console.ForegroundColor = ConsoleColor.White;
                        for (int i = 1; i < 11; i++)
                        {
                            Console.WriteLine(i + ".Deney için:\t\t   " + sehirli_toplam[m, 0, i] + "\t\t  " + sehirli_toplam[m, 1, i] + "\t\t  " + sehirli_toplam[m, 2, i]);
                        }
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("ORTALAMA:\t\t  " + sehirli_toplam_ortalama[m, 0] / 10 + "\t\t  " + sehirli_toplam_ortalama[m, 1] / 10 + "\t\t  " + sehirli_toplam_ortalama[m, 2] / 10);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.ReadLine();
                        
                    }
                    for (int s = 0; s < 3; s++)
                    {

                        for (int i = 0; i < 3; i++)
                        {
                            sehirli_toplam_ortalama[s, i] = 0;


                            for (int j = 1; j < 11; j++)
                            {
                                sehirli_toplam[s, i, j] = 0;
                            }
                        }
                    }
                    sehirli_menu_sayac = 0;
                }
               
            }


        }

    }


}
