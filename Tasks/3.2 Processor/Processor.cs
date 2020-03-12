using DataStructures.PriorityQueues;

namespace Tasks._3._2_Processor
{
    public class Processor
    {
        IPriorityQueue<Core> cores;

        public Processor(int coreCount)
        {
            cores = new MinBinaryHeap<Core>(coreCount);
            for (int i = 0; i < coreCount; i++)
                cores.Enqueue(new Core(i, 0));
        }

        public Core Process(int task)
        {
            var min = cores.Peek();
            cores.ChangePriority(0, new Core(min.Id, min.Time + task));
            return min;
        }
    }
}
