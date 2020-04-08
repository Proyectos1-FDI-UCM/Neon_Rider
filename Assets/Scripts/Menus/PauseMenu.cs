using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    public GameObject pauseMenuUI, optionsMenuUI;

    public GameObject pauseFirstButton, optionsFirstButton;
    
    void Update()
    {
        if (Input.GetKeyDown("joystick button 7"))
        {
            if (GameManager.instance.gameIsPaused)
            {
                Resume();
                if (optionsMenuUI.activeSelf)
                    optionsMenuUI.SetActive(false);
            }
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
        pauseMenuUI.SetActive(false);
        optionsMenuUI.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(optionsFirstButton);
    }

    public void Exit()
    {
        Time.timeScale = 1;
        GameManager.instance.gameIsPaused = false;
        SceneManager.LoadScene(0);
    }
}
