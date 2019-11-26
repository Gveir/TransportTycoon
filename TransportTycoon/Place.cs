using System.Collections.Generic;

namespace TransportTycoon
{
    public class Place
    {
        public string Name { get; }

        private readonly Queue<Container> _store = new Queue<Container>();

        public Place(string name)
        {
            Name = name;
        }

        public override string ToString() => Name;

        public void Store(IEnumerable<Container> containers)
        {
            foreach (var container in containers)
            {
                Store(container);
            }
        }

        public void Store(Container container)
        {
            container.MoveTo(this);
            _store.Enqueue(container);
        }

        public Container Retrieve()
        {
            return _store.TryDequeue(out var container) ? container : null;
        }
    }
}