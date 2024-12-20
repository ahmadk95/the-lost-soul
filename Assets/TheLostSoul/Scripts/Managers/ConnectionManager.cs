using UnityEngine;

namespace tls.managers
{
    public class ConnectionManager
    {

        #region Singleton
        private static ConnectionManager _instance;
        public static ConnectionManager Instance
        {
            get
            {
                if (_instance == null) _instance = new ConnectionManager();
                return _instance;
            }
        }
        #endregion


    }
}