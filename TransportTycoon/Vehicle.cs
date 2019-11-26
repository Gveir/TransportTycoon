namespace TransportTycoon
{
    public class Vehicle
    {
        private Place _currentPlace;
        private Container _container;
        private Travel _travel;

        public Vehicle(Place currentPlace)
        {
            _currentPlace = currentPlace;
        }

        public void Load()
        {
            if (_travel == null || _travel.GotBackToTheBeginning)
            {
                _container = _currentPlace.Retrieve();
                if (_container != null)
                {
                    _travel = new Travel(_container.CurrentRoute);
                }
            }
        }

        public void Unload()
        {
            if (_travel != null && _travel.ArrivedAtDestination)
            {
                _currentPlace.Store(_container);
                _container = null;
            }
        }

        public void Move()
        {
            if (_travel != null)
            {
                _currentPlace = _travel.Continue();
            }
        }
    }
}