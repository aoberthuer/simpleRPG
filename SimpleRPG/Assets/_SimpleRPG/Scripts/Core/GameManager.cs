using UnityEngine;
using UnityEngine.SceneManagement;

namespace RPG.Core
{
    public class GameManager : MonoBehaviour
    {

        public static GameManager instance = null;              //Static instance of GameManager which allows it to be accessed by any other script

        // Use this for initialization
        void Awake()
        {


            if (instance == null) // Check if instance already exists
            {
                instance = this; // if not, set instance to this
            }
            else if (instance != this) // If instance already exists and it's not this:
            {
                //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.          
                Destroy(gameObject);
            }



            //Sets this to not be destroyed when reloading scene
            DontDestroyOnLoad(gameObject);
            LoadLevel("Scene01");
        }

        private void LoadLevel(string levelName)
        {
            SceneManager.LoadScene(levelName, LoadSceneMode.Additive);
        }
    }
}

