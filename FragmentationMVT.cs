using Microsoft.VisualBasic;
using System.Runtime.InteropServices;

namespace FragmenationMFT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //MEMORY
            int memory = 1000;
            Console.WriteLine("Memory consists of 1000 blocks");


            //PROCESSES
            Console.WriteLine("Enter the required space(number of blocks) for each process (seperate with ,)");
            string blocksInput = Console.ReadLine();
            int[] blocks = blocksInput.Split(',').Select(int.Parse).ToArray();

            int usedMemory = 0;

            for (int i = 0; i < blocks.Length; i++)
            {
                usedMemory += blocks[i];
                if (usedMemory <= memory)
                {
                    Console.WriteLine("required memory has allocated to process number" + i);
                }

                else
                {
                    Console.WriteLine("Due to memory lachake, required space can't be allocated to process number" + i);
                    usedMemory -= blocks[i];
                }


            }

            //FRAGMENTAtion
            int externalFragmentation = memory-usedMemory;
            Console.WriteLine("External Fragmentation is =" + externalFragmentation);


        }
    }
}
