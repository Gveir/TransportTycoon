using System.Collections.Generic;
using System.Linq;

namespace TransportTycoon
{
    public class Container
    {
        public IReadOnlyList<Route> Routes { get; }

        public Place CurrentPlace { get; private set; }
        public Route CurrentRoute => Routes.Single(r => r.From.Equals(CurrentPlace));

        public Container(IReadOnlyList<Route> routes)
        {
            Routes = routes;
            CurrentPlace = routes[0].From;
        }

        public void MoveTo(Place place)
        {
            CurrentPlace = place;
        }

        public bool IsDeliveredToDestination => CurrentPlace.Equals(Routes.Last().To);
    }
}