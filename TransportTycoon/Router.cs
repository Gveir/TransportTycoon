using System;
using System.Collections.Generic;

namespace TransportTycoon
{
    public class Router
    {
        private readonly IReadOnlyList<Route> _routes;

        public Router(IReadOnlyList<Route> routes)
        {
            _routes = routes;
        }

        public Container RouteContainer(Destination destination)
        {
            if (destination.Equals(Destination.A))
            {
                return new Container(new List<Route>
                {
                    _routes[0], _routes[1]
                });
            }

            if (destination.Equals(Destination.B))
            {
                return new Container(new List<Route>
                {
                    _routes[2]
                });
            }

            throw new ArgumentException($"Unrecognized destination: {destination}");
        }
    }
}