using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    GameObject pauseMenuUI;

    public GameObject pauseFirstButton;
    
    void Update()
    {
        if (Input.GetKeyDown("joystick button 7"))
        {
            if (GameManager.instance.gameIsPaused)
                Resume();
            else
                Pause();
        }    
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        GameManager.instance.gameIsPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        GameManager.instance.gameIsPaused = true;
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(pauseFirstButton);
    }

    public void Options()
    {
        Debug.Log("El rap de las opciones.mp3");
    }

    public void Exit()
    {
        Time.timeScale = 1;
        GameManager.instance.gameIsPaused = false;
        SceneManager.LoadScene(0);
    }
}
