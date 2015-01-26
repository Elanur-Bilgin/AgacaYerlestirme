using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _4_b_
{
    class Program
    {
        static void Main(String[] args)
        {   
            long[] sayı={77 , 99 ,44 ,55 ,22 ,88 ,11 ,0 ,66 ,33};
            ArrayIns arr;
            arr = new ArrayIns(10); // create array
            for (int j = 0; j < 10; j++) // fill array with
            { 
                arr.insert(sayı[j]);
            }
            arr.display(); // display items
            arr.quickSort(); // quicksort them
            arr.display(); // display them again
            Console.ReadLine();
        } // end main()
    }

    class ArrayIns
    {
        private long[] array;
        private int index;

        public ArrayIns(int max)
        {
            array = new long[max];
            index = 0;
        }
        public void insert(long value)
        {
            array[index] = value;
            index++;
        }
        public void yazdir()
        {
            Console.WriteLine("A=");
            for (int i = 0; i < index; i++)
                Console.WriteLine(array[i] + " ");
            Console.WriteLine("");
        }
        public void quickSort()
        {
            recQuickSort(0, index - 1);
        }
        public void recQuickSort(int sol, int sag)
        {
            if (sag - sol <= 0)
                return;
            else
            {
                long on = array[sag];
                int parcalama;

                parcalama = bolme(sol, sag, (int)on);
                recQuickSort(sol, parcalama - 1);
                recQuickSort(parcalama + 1, sag);
            }

        }
        public int bolme(int sol, int sag, int on)
        {
            int solPtr = sol - 1;
            int sagPtr = sag;
            while (true)
            {
                while (array[++solPtr] < on)
                    ;
                while (sagPtr > 0 && array[--sagPtr] > on)
                    ;
                if (solPtr >= sagPtr)
                    break;
                else swap(solPtr, sagPtr);
            }
            swap(solPtr, sag);
            return solPtr;
        }
        public void swap(int deger1, int deger2)
        {
            long gecici = array[deger1];
            array[deger1] = array[deger2];
            array[deger2] = gecici;
        }
        public void display() // displays array contents
        {
            Console.Write("A=");
            for (int j = 0; j < index; j++) // for each element,
                Console.Write(array[j] + " "); // display it
            Console.WriteLine("");
        }
    }
}
