using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {   
        static void Main(string[] args)
        {
            string[] ülke_adları = { "Japonya", "ABD", "Fransa", "Çin", "Hindistan", "İtalya", "Rusya", "Almanya", "Türkiye", "İspanya"};
            int[] sıra = { 10, 3, 21, 1, 2, 23, 9, 16, 18, 28};  //en kalabalık ülkeler arasında dünyadaki sırasını belirtir 
           
            Tree agac = new Tree();
            
            for (int i = 0; i <ülke_adları.Length; i++) //10 tane ülke nesnesi oluşturulup ağaca yerleştirilirler...
            {
                Ülke nesne = new Ülke();
                nesne.ülke_adı = ülke_adları[i];
                nesne.ülke_sırası = sıra[i];
                nesne.nüfus = 0;
                nesne.sayı = i;
                agac.insert(nesne);
            }
           
            agac.bilgileri_yazdır(); //Agacın derinliğini, eleman sayısını, düğümlerin derinlik ortalamasını bulan fonfsiyon çağırılır...
           
            Console.ReadLine();
        }
    }
//******************************************************
   class Ülke    // Ülke sınıfı oluşturulur...
    {
       public  string ülke_adı;
       public int ülke_sırası;
       public int nüfus;
       public int sayı;  // 1-b için pratik yöntem olarak sayı değişkenini kullandım...
    }
//******************************************************
    class TreeNode    // Hazır TreeNode sınıfını kullandım...
    {
        public Ülke data;   // Data ülke tipinde yapıldı...
        public TreeNode leftChild;
        public TreeNode rightChild;
        public void displayNode()
        {
            Console.WriteLine("********    ********    *************");
            Console.WriteLine("{0,-15}{1,-10}{2,-10}", data.ülke_adı,data.ülke_sırası, data.nüfus);
        }
    } 
//******************************************************
    class Tree    // Hazır Tree sınıfı kullanıldı...
    {
        public TreeNode root;
        public int d=-1,toplam=0;
        public int sayac = 0, düzey;
        public Tree() { root = null; }   // Root yani köke null atadık...
        

        public void insert(Ülke newdata)   // Ağaca eleman ekleyen  hazır fonksiyon...
        {
            TreeNode newNode = new TreeNode();
            
            newNode.data = newdata; 
            if (root == null)
                root = newNode;
            else
            {
                TreeNode current = root;
                TreeNode parent;

                while (true)
                {
                    parent = current;
                    if (newdata.ülke_sırası < current.data.ülke_sırası)  // Burada ağaca ülke sırasına göre ekleme yaptım...
                    {
                        current = current.leftChild;
                        if (current == null)
                        {
                            parent.leftChild = newNode;
                            return;
                        }
                    }
                    else
                    {
                        current = current.rightChild;
                        if (current == null)
                        {
                            parent.rightChild = newNode;
                            return;
                        }
                    }
                } // end while
            }// end else not root
        }// end insert
       
        public void derinlik_ortalama_elemansay_bulma(TreeNode root ,int[] nüfus)   
        {   
            if ( root!= null)
            {
                d++;  
                derinlik_ortalama_elemansay_bulma(root.leftChild,nüfus);
                sayac++;   /// eleman sayısını arttırır..
                
                root.data.nüfus=nüfus[root.data.sayı];  // Başda nüfusu 0 olan ülkelerin nüfusları güncellenmiştir...
                toplam += d;   // her elemanın düzeyi toplanmıştır...

                if (düzey < d)
                {
                    düzey = d;    /// derinliği bulur...
                }
               
                derinlik_ortalama_elemansay_bulma(root.rightChild,nüfus);
                d--; 
            }
           
        }
        public void bilgileri_yazdır()   // Yukarıdaki fonksiyonu kullanabilmek için bu fonksiyonu çağıran ağaç sınıfı içerisinde bir metot yapıldı...
        {
            Console.WriteLine("Ükelerin nüfusları güncellenmeden önce :");
            yazdır(root);
            int[] nüfuslar = { 127350000, 316418000, 65707000, 1359250000, 1232320000, 59704082, 143400000, 80493000, 75627384, 47059533 };
            derinlik_ortalama_elemansay_bulma(root,nüfuslar);
            Console.WriteLine("Ülkelerin nüfusları güncellendikden sonra :");
            yazdır(root);
            Console.WriteLine("Bu ağacın derinliği = {0}",düzey);   // Ekrana ağacın düzeyini yazdırır...
            Console.WriteLine("Bu ağacın eleman sayısı= {0}", sayac);   // Ekrana ağacın eleman sayısını yazdırır...
            Console.WriteLine("Bu ağacın ortalama derinliği=" + (double)toplam / sayac); // Ekrana düğümlerin derinlik ortalamasını yazdırır...
           
        }
        public void yazdır(TreeNode root)
        {
            if (root != null)
            {
                root.displayNode();
                yazdır(root.leftChild);
                yazdır(root.rightChild);
            }
        }
    }
}
