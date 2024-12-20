using UnityEngine;

namespace tls.managers
{
    public class AssetsManager
    {

        #region Singleton
        private static AssetsManager _instance;
        public static AssetsManager Instance
        {
            get
            {
                if (_instance == null) _instance = new AssetsManager();
                return _instance;
            }
        }
        #endregion

    }
}