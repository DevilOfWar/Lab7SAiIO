using System;

namespace Lab7SAiIO
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] workTime = new int[,]
            {
                {2, 4, 3, 2, 6, 3, 1, 2},
                {3, 6, 5, 5, 4, 1, 5, 7}
            };
            int[] workStartFirst = new int[8];
            int[] workEndFirst = new int[8];
            int[] workStartSecond = new int[8];
            int[] workEndSecond = new int[8];
            int[] workStartFirstEditted = new int[8];
            int[] workEndFirstEditted = new int[8];
            int[] workStartSecondEditted = new int[8];
            int[] workEndSecondEditted = new int[8];
            int[] order = new int[]
            {
                0, 1, 2, 3, 4, 5, 6, 7
            };
            workStartFirst[0] = 0;
            workEndFirst[0] = workTime[0, 0];
            workStartSecond[0] = workTime[0, 0];
            workEndSecond[0] = workTime[0, 0] + workTime[1, 0];
            for (int index = 1; index < 8; index++)
            {
                workStartFirst[index] = workEndFirst[index - 1];
                workEndFirst[index] = workStartFirst[index] + workTime[0, index];
                workStartSecond[index] = Math.Max(workEndFirst[index], workEndSecond[index - 1]);
                workEndSecond[index] = workStartSecond[index] + workTime[1, index];
            }
            Console.WriteLine("Work Time (start order):");
            Console.Write("N:\t");
            for (int index = 0; index < 8; index++)
            {
                Console.Write((order[index] + 1) + " ");
            }
            Console.WriteLine();
            Console.Write("T1:\t");
            for (int index = 0; index < 8; index++)
            {
                Console.Write(workTime[0, index] + " ");
            }
            Console.WriteLine();
            Console.Write("T2:\t");
            for (int index = 0; index < 8; index++)
            {
                Console.Write(workTime[1, index] + " ");
            }
            Console.WriteLine();
            Console.WriteLine("\tN\tT1s\tT1e\tT2s\tT2e");
            for (int index = 0; index < 8; index++)
            {
                Console.WriteLine("\t" + (index + 1) + "\t" + workStartFirst[index] + "\t" + workEndFirst[index] + "\t" + workStartSecond[index] + "\t" + workEndSecond[index]);
            }
            for (int index = 0; index < 8; index++)
            {
                Console.Write((index + 1) + "\t");
            }
            Console.WriteLine();
            for (int indexFirst = 0; indexFirst < workEndSecond[7]; indexFirst++)
            {
                for (int indexSecond = 0; indexSecond < 8; indexSecond++)
                {
                    if (indexFirst >= workStartFirst[indexSecond] && indexFirst < workEndFirst[indexSecond])
                    {
                        Console.Write("T1\t");
                    }
                    else if (indexFirst >= workStartSecond[indexSecond] && indexFirst < workEndSecond[indexSecond])
                    {
                        Console.Write("T2\t");
                    }
                    else if (indexFirst < workStartFirst[indexSecond] || (indexFirst >= workEndFirst[indexSecond] &&
                                                                          indexFirst < workStartSecond[indexSecond]))
                    {
                        Console.Write("Wait\t");
                    }
                    else
                    {
                        Console.Write("Done\t");
                    }
                }
                Console.WriteLine();
            }
            int k = 0;
            for (int indexFirst = 0; indexFirst < 7; indexFirst++)
            {
                int min = Int32.MaxValue;
                int index = 0;
                bool toEnd = false;
                for (int indexSecond = indexFirst - k; indexSecond < 8 - k; indexSecond++)
                {
                    if (workTime[0, indexSecond] < min)
                    {
                        min = workTime[0, indexSecond];
                        index = indexSecond;
                        toEnd = false;
                    }
                    if (workTime[1, indexSecond] < min)
                    {
                        min = workTime[0, indexSecond];
                        index = indexSecond;
                        toEnd = true;
                    }
                }
                if (!toEnd)
                {
                    int extravar = workTime[0, indexFirst - k];
                    workTime[0, indexFirst - k] = workTime[0, index];
                    workTime[0, index] = extravar;
                    extravar = workTime[1, indexFirst - k];
                    workTime[1, indexFirst - k] = workTime[1, index];
                    workTime[1, index] = extravar;
                    extravar = order[indexFirst - k];
                    order[indexFirst - k] = order[index];
                    order[index] = extravar;
                }
                else
                {
                    int extravar = workTime[0, 7 - k];
                    workTime[0, 7 - k] = workTime[0, index];
                    workTime[0, index] = extravar;
                    extravar = workTime[1, 7 - k];
                    workTime[1, 7 - k] = workTime[1, index];
                    workTime[1, index] = extravar;
                    extravar = order[7 - k];
                    order[7 - k] = order[index];
                    order[index] = extravar;
                    k++;
                }
            }
            workStartFirstEditted[0] = 0;
            workEndFirstEditted[0] = workTime[0, 0];
            workStartSecondEditted[0] = workTime[0, 0];
            workEndSecondEditted[0] = workTime[0, 0] + workTime[1, 0];
            for (int index = 1; index < 8; index++)
            {
                workStartFirstEditted[index] = workEndFirstEditted[index - 1];
                workEndFirstEditted[index] = workStartFirstEditted[index] + workTime[0, index];
                workStartSecondEditted[index] = Math.Max(workEndFirstEditted[index], workEndSecondEditted[index - 1]);
                workEndSecondEditted[index] = workStartSecondEditted[index] + workTime[1, index];
            }
            Console.WriteLine("Work Time (edited order):");
            Console.Write("N:\t");
            for (int index = 0; index < 8; index++)
            {
                Console.Write((order[index] + 1) + " ");
            }
            Console.WriteLine();
            Console.Write("T1:\t");
            for (int index = 0; index < 8; index++)
            {
                Console.Write(workTime[0, index] + " ");
            }
            Console.WriteLine();
            Console.Write("T2:\t");
            for (int index = 0; index < 8; index++)
            {
                Console.Write(workTime[1, index] + " ");
            }
            Console.WriteLine();
            Console.WriteLine("\tN\tT1s\tT1e\tT2s\tT2e");
            for (int index = 0; index < 8; index++)
            {
                Console.WriteLine("\t" + (order[index] + 1) + "\t" + workStartFirstEditted[index] + "\t" + workEndFirstEditted[index] + "\t" + workStartSecondEditted[index] + "\t" + workEndSecondEditted[index]);
            }
            for (int index = 0; index < 8; index++)
            {
                Console.Write((order[index] + 1) + "\t");
            }
            Console.WriteLine();
            for (int indexFirst = 0; indexFirst < workEndSecondEditted[7]; indexFirst++)
            {
                for (int indexSecond = 0; indexSecond < 8; indexSecond++)
                {
                    if (indexFirst >= workStartFirstEditted[indexSecond] && indexFirst < workEndFirstEditted[indexSecond])
                    {
                        Console.Write("T1\t");
                    }
                    else if (indexFirst >= workStartSecondEditted[indexSecond] && indexFirst < workEndSecondEditted[indexSecond])
                    {
                        Console.Write("T2\t");
                    }
                    else if (indexFirst < workStartFirstEditted[indexSecond] || (indexFirst >= workEndFirstEditted[indexSecond] &&
                                                                          indexFirst < workStartSecondEditted[indexSecond]))
                    {
                        Console.Write("Wait\t");
                    }
                    else
                    {
                        Console.Write("Done\t");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}