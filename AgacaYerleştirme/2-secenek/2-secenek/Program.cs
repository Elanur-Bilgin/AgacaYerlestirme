using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace _2_secenek
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] ülke_adları = { "Japonya", "ABD", "Fransa", "Çin", "Hindistan", "İtalya", "Rusya", "Almanya", "Türkiye", "İspanya" };
            int[] sıra = { 10, 3, 21, 1, 2, 23, 9, 16, 18, 28 };  //en kalabalık ülkeler arasında dünyadaki sırasını belirtir 
            int[] nüfuslar = { 127350000,316418000, 65707000, 1359250000, 1232320000, 59704082, 143400000, 80493000, 75627384,47059533};
            Hashtable tablo = new Hashtable();   // Hashtablo tipinde tablo oluşturulur...
          

                for (int i = 0; i < 10; i++)  //10 tane nesne oluşturulur ve bu nesneler tablo ya eklenir...
                {
                    Ülke ülkeler = new Ülke();
                    ülkeler.ülke_adı = ülke_adları[i];
                    ülkeler.ülke_sırası = sıra[i];
                    ülkeler.nüfus = nüfuslar[i];
                    tablo.Add(ülkeler.ülke_adı,ülkeler);
                }
                Console.WriteLine("Üzerinde işlem yapılmadan önceki ülkelerin bilgileri...");
                yazdır(tablo);
                Console.WriteLine("Ülkelerin nüfusları %10 arttırılmış ülkelerin bilgileri... ");
                hashtable_hesapla(tablo);
                yazdır(tablo);
               
                    Console.ReadLine();
        }
        static public void hashtable_hesapla(Hashtable tablo)  // Ülkelerin nüfuslarını %10 oranında arttıran fonksiyon...
        {
            foreach (DictionaryEntry entry in tablo)
            {
                ((Ülke)entry.Value).nüfus =(int) Math.Floor((double)((Ülke)entry.Value).nüfus * 11 / 10); 
            }
        }
       static public void yazdır(Hashtable tablo )   //Tablodan çekerek nesneleri yazdıran fonksiyon...
        {
            Ülke ülkeler = new Ülke();
            foreach (DictionaryEntry entry in tablo)
            {
                ülkeler = (Ülke)entry.Value;   // Value tipinin ülke olduğunu beli ettim çünkü diger türlü tek birşey gibi algılıyor...
                Console.WriteLine("********    ********    *************");
                Console.WriteLine("{0,-15}{1,-10}{2,-10}", entry.Key, ülkeler.ülke_sırası, ülkeler.nüfus);
            }
        }
       
    }
    //******************************************************
    class Ülke   // Ülke sınıfı oluşturulur...
    {
        public string ülke_adı;
        public int ülke_sırası;
        public int nüfus;
    }
}
