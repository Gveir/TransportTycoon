namespace TransportTycoon
{
    public class Destination
    {
        public static Destination A = new Destination('A');
        public static Destination B = new Destination('B');

        public char Id { get; }

        private Destination(char destinationId)
        {
            Id = destinationId;
        }

        public static implicit operator Destination(char d)
        {
            return new Destination(d);
        }

        protected bool Equals(Destination other)
        {
            return Id == other.Id;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Destination) obj);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}