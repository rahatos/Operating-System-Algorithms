using System.Linq;
using System;
using Processes;
using System.Collections.Generic;

namespace OSLab
{
    class Program
    {
        static void Main(string[] args)
        {
            // Process process = new Process();
            Console.WriteLine("How many processes?: ");
            int totalProcess = Convert.ToInt32(Console.ReadLine());
            
            List<Process> ProcessList = new List<Process>(); 
            

            for(int i=0; i < totalProcess; i++)
            {
                Console.WriteLine("Arrival Time and CPU Time: ");
                var inputLine = Console.ReadLine().Split(' ');
                ProcessList.Add(new Process(int.Parse(inputLine[0]), int.Parse(inputLine[1])));
            }

            int it =1;
            foreach(var processess in ProcessList)
            {
                Console.WriteLine($"Process {it}: Arrival TIme: {processess.arrivalTime}, CPU TIme: {processess.cpuTime}");
                it++;
            }

            //FCFS
            ProcessList = ProcessList.OrderBy(x => x.arrivalTime).ToList();
            //SJF
            // ProcessList = ProcessList.OrderBy(x => x.cpuTime).ToList();


            Console.WriteLine("After sorting: ");
            it =1;
            foreach(var processess in ProcessList)
            {
                Console.WriteLine($"Process {it}: Arrival TIme: {processess.arrivalTime}, CPU TIme: {processess.cpuTime}");
                it++;
            }

            //Waiting Time
            ProcessList[0].waitingTime = 0;
            for(int i=1; i < ProcessList.Count; i++)
            {
                ProcessList[i].waitingTime = ProcessList[i-1].waitingTime + ProcessList[i-1].cpuTime - ProcessList[i].arrivalTime;  
            }

            //Average Waiting Time
            double avgWaitingTime = 0;
            foreach(var p in ProcessList)
            {
                avgWaitingTime += p.waitingTime;
            }
            avgWaitingTime = avgWaitingTime/totalProcess;
            Console.WriteLine($"Average Waiting Time: {avgWaitingTime}");

            //Turn Around Time
            for(int i=0; i < ProcessList.Count; i++)
            {
                ProcessList[i].turnAroundTime = ProcessList[i].waitingTime + ProcessList[i].cpuTime;
            }


            //Average Turnaround Time
            double avgturnAroundTime = 0;
            foreach(var p in ProcessList)
            {
                avgturnAroundTime += p.turnAroundTime;
            }
            avgturnAroundTime = avgturnAroundTime/totalProcess;
            Console.WriteLine($"Average TurnAround Time: {avgturnAroundTime}");
            

        }
    }
}
