using UnityEngine;

namespace tls.managers
{
    public class GameManager : MonoBehaviour
    {

        #region Singleton
        public static GameManager Instance { get; private set; }
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else if (Instance != this)
            {
                Destroy(gameObject);
            }
            Initialize();
        }
        #endregion

        public void Initialize()
        {


            LevelManager.Instance.Initialize();
            UnitManager.Instance.InitializePlayer();
        }

    }
}