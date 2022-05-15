using System;
using System.Collections.Generic;

namespace NewspaperSimulation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] Demand = new int[10];
            int[] Shortage = new int[10];
            int[] Scraps = new int[10];
            int[] NetProfitPerDay = new int[10];
            int NetProfit =0;

            string[] Days = new string[] { "Good", "Fair" , "Fair" ,"Good","Poor", "Fair" ,"Fair","Poor","Poor","Good"};
            int CostPerDay = 4000;
            int price = 60;
            int Scrap = 10;
            int Receive = 100;

            Queue<int> Good = new Queue<int>();
            Good.Enqueue(90);
            Good.Enqueue(80);
            Good.Enqueue(110);
            Good.Enqueue(105);
            Good.Enqueue(95);
            Good.Enqueue(70);
            Good.Enqueue(85);
            Good.Enqueue(90);
            Good.Enqueue(90);
            Good.Enqueue(60);

            Queue<int> Fair = new Queue<int>();
            Fair.Enqueue(70);
            Fair.Enqueue(85);
            Fair.Enqueue(90);
            Fair.Enqueue(80);
            Fair.Enqueue(65);
            Fair.Enqueue(88);
            Fair.Enqueue(100);
            Fair.Enqueue(75);
            Fair.Enqueue(95);
            Fair.Enqueue(75);

            Queue<int> Poor = new Queue<int>();
            Poor.Enqueue(45);
            Poor.Enqueue(75);
            Poor.Enqueue(50);
            Poor.Enqueue(60);
            Poor.Enqueue(65);
            Poor.Enqueue(40);
            Poor.Enqueue(50);
            Poor.Enqueue(55);
            Poor.Enqueue(65);
            Poor.Enqueue(90);


            Console.WriteLine("Day\tDayType\tDemand\tShortage\tScraps\tNetProfitPerDay ");


            for (int i = 0; i < 10; i++)
            {
                int DayDemand = 0;                
                if(Days[i] == "Good")
                {
                    DayDemand = Good.Dequeue();
                }
                if (Days[i] == "Fair")
                {
                    DayDemand = Fair.Dequeue();
                }
                if (Days[i] == "Poor")
                {
                    DayDemand = Poor.Dequeue();
                }
                Demand[i]= DayDemand;
                if (DayDemand > Receive)
                    Shortage[i] = DayDemand - Receive;
                else
                    Shortage[i] = 0;
                if (DayDemand < Receive)
                    Scraps[i] = Receive - DayDemand ;
                else
                    Scraps[i] = 0;
                if (DayDemand > Receive)
                    NetProfitPerDay[i] = 2000;
                else
                    NetProfitPerDay[i] = ( DayDemand*price + (Scraps[i]*Scrap) ) - CostPerDay;
                Console.WriteLine($"{i+1}\t{Days[i]}\t{Demand[i]}\t{Shortage[i]}\t\t{Scraps[i]}\t{NetProfitPerDay[i]} ");
            }

            for (int i = 0; i < 10; i++)
            {
                NetProfit += NetProfitPerDay[i];
            }

            Console.WriteLine($"\nNet Profit = {NetProfit}");
           

        }
    }
}
