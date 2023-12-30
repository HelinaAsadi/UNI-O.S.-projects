namespace FragmentationMFT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //MEMORY
            Console.WriteLine("Memory consists of 1000 Blocks");
            int[] pages = { 200, 200, 200, 200, 200 };
            int availablepages = 5;
           

            //PROCESSES
            Console.WriteLine("Enter the required space(number of blocks) for each process (seperate with ,)");
            string blocksInput = Console.ReadLine();
            int[] blocks = blocksInput.Split(',').Select(int.Parse).ToArray();

           int j = 0;

            for (int i = 0; i < blocks.Length; i++)
            {
                if (blocks[i] <= 200 && availablepages>0)
                {
                    Console.WriteLine("page " + j + " is now allocated to process " + i);
                    pages[j] -= blocks[i];
                    j++;
                    availablepages--;
                }

                else if (blocks[i] <= 400 && availablepages >= 2)
                {
                    Console.WriteLine("page " + j + " & " + (j+1) + " is now allocated to process " + i);
                    pages[j] = 0;
                    j++;
                    blocks[i] = blocks[i] - 200;
                    pages[j] -= blocks[i];
                    j++;
                    availablepages--; availablepages--;
                }


                else if (blocks[i] <= 600 && availablepages >= 3)
                {
                    Console.WriteLine("page " + j + " & " + (j+1)  + " & " + (j+2) + " is now allocated to process " + i);
                    pages[j] = 0;
                    j++;
                    pages[j] = 0;
                    j++;
                    blocks[i] = blocks[i] - 400;
                    pages[j] -= blocks[i];
                    j++;
                    availablepages--; availablepages--; availablepages--;
                }

                else if (blocks[i] <= 800 && availablepages >= 4)
                {
                    Console.WriteLine("page " + j + " & " + (j+1) + " & " + (j+2) + " & " + (j+3) + " is now allocated to process " + i);
                    pages[j] = 0;
                    j++;
                    pages[j] = 0;
                    j++;
                    pages[j] = 0;
                    j++;
                    blocks[i] = blocks[i] - 600;
                    pages[j] -= blocks[i];
                    j++;
                    availablepages--; availablepages--; availablepages--; availablepages--;
                }

                else if (blocks[i] <= 1000 && availablepages == 5)
                {
                    Console.WriteLine("page " + j + " & " + (j+1) + " & " + (j+2) + " & " + (j+3) + " & " + (j+4) + " is now allocated to process " + i);
                    pages[j] = 0;
                    j++;
                    pages[j] = 0;
                    j++;
                    pages[j] = 0;
                    j++;
                    pages[j] = 0;
                    j++;
                    blocks[i] = blocks[i] - 800;
                    pages[j] -= blocks[i];
                    j++;
                    availablepages--; availablepages--; availablepages--; availablepages--; availablepages--;
                }

                else{
                    Console.WriteLine("not enough memory for process " + i);
                }

            }

            //FRAGMENTATION  INTERNAL 
                int internalFragmentation = 0;

                for (int k = 0; k < 5; k++)
                {
                if (pages[k] != 200)
                {
                    internalFragmentation += pages[k];
                }
            }
                Console.WriteLine("Internal Fragmentation is " + internalFragmentation);

            //FRAGMENTATION  EXTERNAL
                int externalFragmentation = 0;

                for (int k = 0; (k < 5); k++)
                {
                   if (pages[k] == 200) {
                    externalFragmentation += pages[k];
                   }
                }
                Console.WriteLine("External Fragmentation is " + externalFragmentation);
         
        }
    }
}