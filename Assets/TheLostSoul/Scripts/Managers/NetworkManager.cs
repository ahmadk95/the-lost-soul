using UnityEngine;

namespace tls.managers
{
    public class NetworkManager
    {

        #region Singleton
        private static NetworkManager _instance;
        public static NetworkManager Instance
        {
            get
            {
                if (_instance == null) _instance = new NetworkManager();
                return _instance;
            }
        }
        #endregion



    }
}