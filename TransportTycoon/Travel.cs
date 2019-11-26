namespace TransportTycoon
{
    public class Travel
    {
        public Route Route { get; }

        private uint _timeElapsed;

        public Travel(Route route)
        {
            Route = route;
        }

        public Place Continue()
        {
            _timeElapsed++;

            return ArrivedAtDestination ? Route.To : Route.From;
        }

        public bool ArrivedAtDestination => _timeElapsed == Route.Length;

        public bool GotBackToTheBeginning => _timeElapsed >= 2 * Route.Length;
    }
}