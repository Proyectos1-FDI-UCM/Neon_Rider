using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Creas un object GameManager vacio (prefab para que sobreviva escenas) con este script.

    public static GameManager instance;
    public Vector2 checkpoint;
    public bool gameIsPaused;
    public int deadVal = 0;
    Vector2 ori;
    private GameObject player;

    private void OnLevelWasLoaded(int level)
    {
        //Busca al jugador al cargar la escena de nuevo
        player = GameObject.Find("Player");

    }

    // En el método Awake comprueba si hay otro GameManger
    // y si no lo hay se inicializa como GameManager. En el caso
    // que hubiera otro se autodestruye
    void Awake()
    {
        //Busca el jugador por primera vez
        player = GameObject.Find("Player");

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
        
    }

    

    //reinicia la escena cuando muere (lo llama desde el script Death)
    public void Dead(PowerUpManager power)
    {
        //reinicia los power ups desde el power up manager.
        //no es necesario con el load scene, pero por si sirve con los checkpoints.
        power.Reset();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public GameObject GetPlayer()
    {
        return player;
    }
}
