namespace tls.managers
{
    public class LevelManager
    {

        #region Singleton
        private static LevelManager _instance;
        public static LevelManager Instance
        {
            get
            {
                if (_instance == null) _instance = new LevelManager();
                return _instance;
            }
        }
        public LevelManager() { }

        #endregion


        public void Initialize()
        {

        }

    }
}