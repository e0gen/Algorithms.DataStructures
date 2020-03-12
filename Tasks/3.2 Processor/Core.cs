using System;

namespace Tasks._3._2_Processor
{
    public struct Core : IComparable<Core>
    {
        public Core(int id, long time)
        {
            Id = id;
            Time = time;
        }
        public readonly int Id;
        public readonly long Time;

        public int CompareTo(Core other)
        {
            var timeRelation = this.Time.CompareTo(other.Time);

            if (timeRelation == 0)
                return this.Id.CompareTo(other.Id);
            else
                return timeRelation;
        }

        public override string ToString()
        {
            return $"{Id} {Time}";
        }
    }
}
