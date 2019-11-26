using System.Collections.Generic;
using System.Linq;

namespace TransportTycoon
{
    public class Map
    {
        public uint ElapsedTime { get; private set; }

        private readonly Place _factory;
        private readonly Router _router;
        private readonly IEnumerable<Vehicle> _vehicles;

        public Map()
        {
            _factory = new Place("Factory");
            Place port = new Place("Port");
            Place destinationA = new Place("Destination A");
            Place destinationB = new Place("Destination B");

            var routes = new List<Route>
            {
                new Route(_factory, port, 1),
                new Route(port, destinationA, 4),
                new Route(_factory, destinationB, 5)
            };

            _router = new Router(routes);

            _vehicles = new List<Vehicle>
            {
                new Vehicle(_factory),
                new Vehicle(_factory),
                new Vehicle(port)
            };
        }

        public void ProcessDelivery(string input)
        {
            var containers = input.Select(destinationId => _router.RouteContainer(destinationId)).ToList();

            _factory.Store(containers);

            while (containers.Any(c => !c.IsDeliveredToDestination))
            {
                ProcessTimeTick();
            }
        }

        private void ProcessTimeTick()
        {
            foreach (var vehicle in _vehicles)
            {
                vehicle.Load();
            }

            foreach (var vehicle in _vehicles)
            {
                vehicle.Move();
            }

            ElapsedTime++;

            foreach (var vehicle in _vehicles)
            {
                vehicle.Unload();
            }
        }
    }
}
