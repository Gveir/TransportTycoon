namespace TransportTycoon
{
    public class Route
    {
        public Place From { get; }
        public Place To { get; }
        public uint Length { get; }

        public Route(Place from, Place to, uint length)
        {
            From = from;
            To = to;
            Length = length;
        }

        public override string ToString() => $"{From} => {Length} => {To}";
    }
}