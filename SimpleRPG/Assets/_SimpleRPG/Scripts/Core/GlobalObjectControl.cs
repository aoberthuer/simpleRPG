using UnityEngine;

using RPG.Weapons;


namespace RPG.Core
{
    public class GlobalObjectControl : MonoBehaviour
    {

        private static GlobalObjectControl instance;
        public static GlobalObjectControl Instance { get { return instance; } }


        [SerializeField] WeaponConfig currentWeaponConfig;
        public WeaponConfig CurrentWeaponConfig
        {
            get { return currentWeaponConfig; }
            set { currentWeaponConfig = value; }
        }

        

        protected void Awake()
        {
            if (instance != null)
            {
                Destroy(gameObject);
            }
            else
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
        }

        protected virtual void OnDestroy()
        {
            instance = null;
        }
    }
}
