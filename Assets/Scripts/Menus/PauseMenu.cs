using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    GameObject pauseMenuUI = null, optionsMenuUI = null; // Referencias al menú de pausa y de opciones

    [SerializeField]
    GameObject pauseFirstButton = null, optionsFirstButton = null; // Botones que se seleccionan al abrir el menú correspondiente
    
    void Update()
    {
        if (Input.GetKeyDown("joystick button 7")||Input.GetKey(KeyCode.Escape)) // Al pulsar el botón de pausa para o continúa el juego y abre o cierra el menú de pausa según corresponda 
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

    public void Resume() // Continúa el juego y cierra el menú
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        GameManager.instance.gameIsPaused = false;
    }

    public void Pause() // Para el juego y abre el menú
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        GameManager.instance.gameIsPaused = true;
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(pauseFirstButton);
    }

    public void Options() // Abre el menú de opciones
    {
        pauseMenuUI.SetActive(false);
        optionsMenuUI.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(optionsFirstButton);
    }

    public void Exit() // Sale al menú principal
    {
        Time.timeScale = 1;
        GameManager.instance.gameIsPaused = false;
        AudioManager.instance.Stop(AudioManager.ESounds.LevelMusic);
        AudioManager.instance.Play(AudioManager.ESounds.Menu);
        SceneManager.LoadScene(0);
    }
}
