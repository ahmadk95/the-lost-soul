using System.Collections.Generic;
using tls.units;

namespace tls.managers
{
    public class UnitManager
    {

        #region Singleton
        private static UnitManager _instance;
        public static UnitManager Instance
        {
            get
            {
                if (_instance == null) _instance = new UnitManager();
                return _instance;
            }
        }
        #endregion

        public Player Player { get; private set; }
        public List<Unit> Monsters { get; private set; } = new();


        public UnitManager()
        {

        }

        public void InitializePlayer()
        {
            Player = new Player("Player", UnitType.Player);
        }



    }
}