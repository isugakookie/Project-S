using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;
        private const string Main = "PlayDemo";
        public GameObject currCharacter;

        private bool notSpawned;

        private void Awake()
        {
            if(instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
            
        }

        private void Update()
        {
            if (SceneManager.GetActiveScene () == SceneManager.GetSceneByName (Main) && !notSpawned)
            {
                GetComponent<PlayerSpawner>().Spawn(currCharacter.GameObject());
                notSpawned = !notSpawned;
            }
        }

        public void SetCharacter(GameObject character)
        {
            currCharacter = character;
        }
        
        public void PlayGame()
        {
            SceneManager.LoadScene("GameSetup");
        }
        public void HowTo()
        {
            ///load overlay canvas with simple instructions
        }
        public void Solo()
        {
            SceneManager.LoadScene("ChooseCharacter");
        }
        /*
        public void Multi()
        {
            SceneManager.LoadScene("Starting");
        }
        */
        
        public void Play()
        {
            DontDestroyOnLoad(gameObject);
            SceneManager.LoadSceneAsync("PlayDemo");
        }
    }
}