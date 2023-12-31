﻿using System.Security.Cryptography.X509Certificates;
using System.Xml.Serialization;

namespace MemoryManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            //STRATEGY
            Console.WriteLine("choose one of these strategies :");
            Console.WriteLine("1. Fisrt Fit   2. Best Fit   3. Worst Fit ");
            Console.WriteLine("type 1, 2 or 3");
            string choiceInput = Console.ReadLine();
            int[] choiceArray = choiceInput.Split(',').Select(int.Parse).ToArray();
            int choice = choiceArray[0];


            if (choice == 1)
            {
                FirstFit();
            }

            else if (choice == 2)
            {
                BestFit();
            }
            else if (choice == 3)
            {
                WorstFit();
            }
            else { Console.WriteLine("invalid input(only 1, 2 or 3 are acceptable)"); }
        }

        static void FirstFit()
        {

            ///GETTING INPUTS
            //MEMORY
            Console.WriteLine("Enter memory");
            string memoryInput = Console.ReadLine();
            int[] memoryArray = memoryInput.Split(',').Select(int.Parse).ToArray();
            int memory = memoryArray[0];


            //PAGES
            Console.WriteLine("Enter the size of each page(seperate with , )");
            string pagesInput = Console.ReadLine();
            int[] pages = pagesInput.Split(',').Select(int.Parse).ToArray();

            int[] availibility = new int[pages.Length];
            for (int i = 0; i < availibility.Length; i++)
                availibility[i] = 0;

            int[] fragmentation = new int[pages.Length];
            for (int i = 0; i < fragmentation.Length; i++)
                fragmentation[i] = 0;

            //PROCESSES
            Console.WriteLine("Enter the required space(number of blocks) for each process (seperate with ,)");
            string processInput = Console.ReadLine();
            int[] process = processInput.Split(',').Select(int.Parse).ToArray();


            for (int i = 0; i < process.Length; i++)
            {
                for (int j = 0; j < pages.Length; j++)
                {
                    if (pages[j] > process[i] && availibility[j]==0)
                    {
                        availibility[j] = 1;
                        Console.WriteLine("page " + j + " is allocated to process " + i);
                        fragmentation[j] = pages[j] - process[i];
                        break;
                    }
                  
                }
            }

            //INTERNAL FRAGMENTATION
            int internalFragmentation = 0;
            for (int i = 0;i < fragmentation.Length; i++)
            { 
               internalFragmentation=internalFragmentation+ fragmentation[i];
            }
            Console.WriteLine("Internal Fragmentation is " + internalFragmentation);

            //EXTERNAL FRAGMENTATION
            int externalFragmentation = 0;
            for (int i = 0; i < availibility.Length; i++)
            {
                if (availibility[i] == 0)
                {
                    externalFragmentation = externalFragmentation + pages[i];
                }
            }
            Console.WriteLine("External Fragmentation is " + externalFragmentation);

        }

        static void BestFit()
        {

            ///GETTING INPUTS
            //MEMORY
            Console.WriteLine("Enter memory");
            string memoryInput = Console.ReadLine();
            int[] memoryArray = memoryInput.Split(',').Select(int.Parse).ToArray();
            int memory = memoryArray[0];


            //PAGES
            Console.WriteLine("Enter the size of each page(seperate with , )");
            string pagesInput = Console.ReadLine();
            int[] pages = pagesInput.Split(',').Select(int.Parse).ToArray();

            int[] availibility = new int[pages.Length];
            for (int i = 0; i < availibility.Length; i++)
                availibility[i] = 0;

            int[] fragmentation = new int[pages.Length];
            for (int i = 0; i < fragmentation.Length; i++)
                fragmentation[i] = 0;

            //PROCESSES
            Console.WriteLine("Enter the required space(number of blocks) for each process (seperate with ,)");
            string processInput = Console.ReadLine();
            int[] process = processInput.Split(',').Select(int.Parse).ToArray();


            for (int i = 0; i < process.Length; i++)
            {
                int x = 30;
                int set = memory;
                for (int j = 0; j < pages.Length; j++)
                {
                    if (pages[j] > process[i] && availibility[j] == 0)
                    {
                        if (pages[j] < set)
                        {
                            set = pages[j];
                            x = j;
                        }
                    }
                }
                if (x != 30)
                {
                    Console.WriteLine("page " + x + " is now allocated to process " + i);
                    availibility[x] = 1;
                    fragmentation[x] = pages[x] - process[i];
                }
            }

            //INTERNAL FRAGMENTATION
            int internalFragmentation = 0;
            for (int i = 0; i < fragmentation.Length; i++)
            {
                internalFragmentation = internalFragmentation + fragmentation[i];
            }
            Console.WriteLine("Internal Fragmentation is " + internalFragmentation );

            //EXTERNAL FRAGMENTATION
            int externalFragmentation = 0;
            for (int i = 0; i < availibility.Length; i++)
            {
                if (availibility[i] == 0)
                {
                    externalFragmentation = externalFragmentation + pages[i];
                }
            }
            Console.WriteLine("External Fragmentation is " + externalFragmentation);
        }

        static void WorstFit()
        {

            ///GETTING INPUTS
            //MEMORY
            Console.WriteLine("Enter memory");
            string memoryInput = Console.ReadLine();
            int[] memoryArray = memoryInput.Split(',').Select(int.Parse).ToArray();
            int memory = memoryArray[0];


            //PAGES
            Console.WriteLine("Enter the size of each page(seperate with , )");
            string pagesInput = Console.ReadLine();
            int[] pages = pagesInput.Split(',').Select(int.Parse).ToArray();

            int[] availibility = new int[pages.Length];
            for (int i = 0; i < availibility.Length; i++)
                availibility[i] = 0;

            int[] fragmentation = new int[pages.Length];
            for (int i = 0; i < fragmentation.Length; i++)
                fragmentation[i] = 0;

            //PROCESSES
            Console.WriteLine("Enter the required space(number of blocks) for each process (seperate with ,)");
            string processInput = Console.ReadLine();
            int[] process = processInput.Split(',').Select(int.Parse).ToArray();


            for (int i = 0; i < process.Length; i++)
            {
                int x = 30;
                int set = 0;
                for (int j = 0; j < pages.Length; j++)
                {
                    if (pages[j] > process[i] && availibility[j] == 0)
                    {
                        if (pages[j] > set)
                        {
                            set = pages[j];
                            x = j;
                        }
                    }
                }
                if (x != 30)   //just some shitty way to avoide unassigned variable bug
                {
                    Console.WriteLine("page " + x + " is now allocated to process " + i);
                    availibility[x] = 1;
                    fragmentation[x] = pages[x] - process[i];
                }
            }

            //INTERNAL FRAGMENTATION
            int internalFragmentation = 0;
            for (int i = 0; i < fragmentation.Length; i++)
            {
                internalFragmentation = internalFragmentation + fragmentation[i];
            }
            Console.WriteLine("Internal Fragmentation is " + internalFragmentation);

            //EXTERNAL FRAGMENTATION
            int externalFragmentation = 0;
            for (int i = 0; i < availibility.Length; i++)
            {
                if (availibility[i] == 0)
                {
                    externalFragmentation = externalFragmentation + pages[i];
                }
            }
            Console.WriteLine("External Fragmentation is " + externalFragmentation);
        }

    }
}
