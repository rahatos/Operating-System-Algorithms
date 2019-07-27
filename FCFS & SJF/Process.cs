namespace Processes
{
    public class Process
    {
        public int arrivalTime;
        public int cpuTime;
        public int waitingTime;
        public int turnAroundTime;


        public Process()
        {

        }

        public Process(int arrivalTime, int cpuTime)
        {
            this.arrivalTime = arrivalTime;
            this.cpuTime = cpuTime;
        }
    }
}