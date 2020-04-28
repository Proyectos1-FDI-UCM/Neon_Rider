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
    public bool fullScreenToggle = true, mando=true;
    public float mainVolSlider = 0.2f,
                 SFXVolSlider = 0.2f,
                 musicVolSlider = 0.2f; 



    // En el método Awake comprueba si hay otro GameManger
    // y si no lo hay se inicializa como GameManager. En el caso
    // que hubiera otro se autodestruye
    void Awake()
    {
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


    public void FullscreenToggleState(bool isFullscreen)
    {
        if (isFullscreen)
            fullScreenToggle = true;
        else
            fullScreenToggle = false;
    }
    public void ControlToggle(bool mando)
    {
        if (mando)
            mando = true;
        else
            mando = false;
    }

    public void MainSliderState (float volume)
    {
        mainVolSlider = volume;
    }

    public void MusicSliderState(float volume)
    {
        musicVolSlider = volume;
    }

    public void SFXSliderState(float volume)
    {
        SFXVolSlider = volume;
    }

    //reinicia la escena cuando muere (lo llama desde el script Death)
    public void Dead(PowerUpManager power)
    {
        //reinicia los power ups desde el power up manager.
        //no es necesario con el load scene, pero por si sirve con los checkpoints.
        power.Reset();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ChangeScene()
    {
        checkpoint = new Vector2(0, 0);
        deadVal = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
