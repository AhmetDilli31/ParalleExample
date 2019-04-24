using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelThreadExample
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> fruits = new List<string>();
            fruits.Add("Apple");
            fruits.Add("Banana");
            fruits.Add("Bilberry");
            fruits.Add("Blackberry");
            fruits.Add("Blackcurrant");
            fruits.Add("Blueberry");
            fruits.Add("Cherry");
            fruits.Add("Coconut");
            fruits.Add("Cranberry");
            fruits.Add("Date");
            fruits.Add("Fig");
            fruits.Add("Grape");
            fruits.Add("Guava");
            fruits.Add("Jack-fruit");
            fruits.Add("Kiwi fruit");
            fruits.Add("Lemon");
            fruits.Add("Lime");
            fruits.Add("Lychee");
            fruits.Add("Mango");
            fruits.Add("Melon");
            fruits.Add("Olive");
            fruits.Add("Orange");
            fruits.Add("Papaya");
            fruits.Add("Plum");
            fruits.Add("Pineapple");
            fruits.Add("Pomegranate");

            //Ex:1
            /*
            Parallel.ForEach(fruits, fruit =>
                {
                    Console.WriteLine("Fruit Name: {0}, Thread Id= {1}", fruit, Thread.CurrentThread.ManagedThreadId);

                }
            );
            */

            //Ex:2
            SwitchCase(fruits);            
        }

        private static void SwitchCase(List<string> fruits)
        {
            Console.Write("Lütfen Yapmak istediðiniz iþlemi seçiniz!");
            Console.WriteLine("Ýþlem Yapmak için: 'E', Ýþlemi Kapatmak için: 'Q' , Konsolu temizlemek için 'C' tuþlarýna basýnýz!");
            string veri = Console.ReadLine();

            switch (veri)
            {
                case "E":
                    ParalelThread(fruits);
                    break;
                case "Q":
                    Environment.Exit(2);
                    break;
                case "C":
                    break;
                default:
                    return;
            }

        }

        private static void ParalelThread(List<string> fruList)
        {
            var stopWatch = Stopwatch.StartNew();
            stopWatch = Stopwatch.StartNew();

            Parallel.ForEach(fruList, new ParallelOptions() { MaxDegreeOfParallelism = 20 }, genel);

            Console.WriteLine("Parallel.ForEach() execution time = {0} seconds", stopWatch.Elapsed.TotalSeconds);
            Console.WriteLine("Devam etmek için lütfen enter a basýnýz! Baþka bir tuþa basarsanýz iþlem sonlanacaktýr!");

            if (Console.ReadKey().Key == ConsoleKey.Enter)
                SwitchCase(fruList);
            else
                Environment.Exit(2);
        }
        private static void genel(string fruit)
        {

            Console.WriteLine("Fruit Name: {0}, Thread Id= {1}", fruit, Thread.CurrentThread.ManagedThreadId);

        }

    }
}
