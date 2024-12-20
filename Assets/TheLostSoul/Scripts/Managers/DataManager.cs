using UnityEngine;

namespace tls.managers
{
    public class DataManager
    {

        #region Singleton
        private static DataManager _instance;
        public static DataManager Instance
        {
            get
            {
                if (_instance == null) _instance = new DataManager();
                return _instance;
            }
        }
        #endregion



    }

    public enum UnitType
    {
        Player = 0,
        Monster = 1,
    }
}