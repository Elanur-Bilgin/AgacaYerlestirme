using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
           
            int[] nüfuslar = { 127350000, 316418000, 65707000, 1359250000, 1232320000, 59704082, 143400000, 80493000, 75627384, 47059533 };
            string[] ülke_adları = { "Japonya", "ABD", "Fransa", "Çin", "Hindistan", "İtalya", "Rusya", "Almanya", "Türkiye", "İspanya" };
            int[] sıra = { 10, 3, 21, 1, 2, 23, 9, 16, 18, 28 };  //en kalabalık ülkeler arasında dünyadaki sırasını belirtir 
            Heap heap = new Heap(nüfuslar.Length);
            Ülke ülk = new Ülke();
            //int değer;

            for (int i = 0; i < ülke_adları.Length; i++) //10 tane ülke nesnesi oluşturulup heap'e yerleştirilirler...
            {
                Ülke nesne = new Ülke();
                nesne.ülke_adı = ülke_adları[i];
                nesne.ülke_sırası = sıra[i];
                nesne.nüfus =nüfuslar[i];
                heap.insert(nesne);
            }
            Console.WriteLine("Dünyada ki en kalabalık on ülke içerisinde yer alanlar :");

            if (!heap.isEmpty())   // heap'in boş olup olmadıgını kontrol ediyor...

            {
                for (int i = 0; i < 10; i++)
                {
                    ülk = heap.remove().getKey();
                    if (ülk.ülke_sırası <= 10)    // Dünyada en kalabalık 10 ülke içerisinde olanları heap'den çekip yazdırdım...
                    {
                        Console.WriteLine("********    ********    *************");
                        Console.WriteLine("{0,-15}{1,-10}{2,-10}",ülk.ülke_adı,ülk.ülke_sırası,ülk.nüfus);
                    }
                }
            }

                    Console.ReadLine();
        }
        
    }
    class Ülke    // Ülke sınıfı oluşturulur...
    {
        public string ülke_adı;
        public int ülke_sırası;
        public int nüfus;
    }
    class Node
    {
        private Ülke iData;// data item (key)
        // -------------------------------------------------------------
        public Node(Ülke key) // constructor
        { iData = key; }
        // -------------------------------------------------------------
        public Ülke getKey()
        { return iData; }
        // -------------------------------------------------------------
        public void setKey(Ülke id)
        { iData = id; }
        // -------------------------------------------------------------
    }
    class Heap
    {
        private Node[] heapArray;
        private int maxSize; // size of array
        private int currentSize; // number of nodes in array
        public Heap(int mx) // constructor
        {
            maxSize = mx;
            currentSize = 0;
            heapArray = new Node[maxSize];
        }
        public bool isEmpty()
        {
            return currentSize == 0;
        }
        // -------------------------------------------------------------
        public bool insert(Ülke key)
        {
            if (currentSize == maxSize)
                return false;
            Node newNode = new Node(key);
            heapArray[currentSize] = newNode;
            trickleUp(currentSize++);
            return true;
        }
        //// -------------------------------------------------------------
      
        public void trickleUp(int index)
        {
            int parent = (index - 1) / 2;
            Node bottom = heapArray[index];
            while (index > 0 && heapArray[parent].getKey().nüfus < bottom.getKey().nüfus)
            {
                heapArray[index] = heapArray[parent]; // move it down
                index = parent;
                parent = (parent - 1) / 2;
            } // end while
            heapArray[index] = bottom;
        } // end trickleUp()
        // -------------------------------------------------------------
        public Node remove() // delete item with max key
        { // (assumes non-empty list)
            Node root = heapArray[0];
            heapArray[0] = heapArray[--currentSize];
            trickleDown(0);
            return root;
        }
      
        public void trickleDown(int index)
        {
            int largerChild;
            Node top = heapArray[index]; // save root
            while (index < currentSize / 2) // while node has at
            { // least one child,
                int leftChild = 2 * index + 1;
                int rightChild = leftChild + 1;
              
                if (rightChild < currentSize &&  heapArray[leftChild].getKey().nüfus < heapArray[rightChild].getKey().nüfus)
                    largerChild = rightChild;
                else
                    largerChild = leftChild;
               
                if (top.getKey().nüfus >= heapArray[largerChild].getKey().nüfus)
                    break;
               
                heapArray[index] = heapArray[largerChild];
                index = largerChild; 
            } // end while
            heapArray[index] = top; // root to index
        }
       
    }
}