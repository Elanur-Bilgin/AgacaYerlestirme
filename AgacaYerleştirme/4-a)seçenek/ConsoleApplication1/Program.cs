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
            int maxSize = 100; // array size
            ArraySel arr; // reference to array
            arr = new ArraySel(maxSize); // create the array
            arr.insert(77); // insert 10 items
            arr.insert(99);
            arr.insert(44);
            arr.insert(55);
            arr.insert(22);
            arr.insert(88);
            arr.insert(11);
            arr.insert(00);
            arr.insert(66);
            arr.insert(33);
            arr.display(); // display items
            arr.selectionSort(); // selection-sort them
            arr.display(); // display them again
            Console.ReadLine();
        } 

    }

    class ArraySel
    {
        private long[] a; // ref to array a
        private int nElems;
        public ArraySel(int max) // constructor
        {
            a = new long[max]; // create the array
            nElems = 0;
        }
        //--------------------------------------------------------------
        public void insert(long value) // put element into array
        {
            a[nElems] = value; // insert it
            nElems++; // increment size
        }
        //--------------------------------------------------------------
        public void display() // displays array contents
        {
            for (int j = 0; j < nElems; j++) // for each element,
                Console.Write(a[j] + " "); // display it
            Console.WriteLine("");
        }
        //--------------------------------------------------------------
        public void selectionSort()
        {
            int cikan, giren, min;
            for (cikan = 0; cikan < nElems - 1; cikan++)
            {
                min = cikan;
                for (giren = cikan + 1; giren < nElems; giren++)
                    if (a[giren] < a[min])
                        min = giren;
                swap(cikan, min);
            }
        }
        //--------------------------------------------------------------
        private void swap(int one, int two)
        {
            long temp = a[one];
            a[one] = a[two];
            a[two] = temp;
        }
        //--------------------------------------------------------------
    }
}