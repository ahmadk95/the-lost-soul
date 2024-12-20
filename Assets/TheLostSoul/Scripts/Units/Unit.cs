using tls.managers;

namespace tls.units
{
    public class Unit
    {
        public string Name { get; private set; }
        public UnitType Type { get; private set; }

        public Unit(string name, UnitType type)
        {
            Name = name;
            Type = type;
        }






    }
}