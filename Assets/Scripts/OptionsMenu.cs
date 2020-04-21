using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.EventSystems;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField]
    AudioMixer master; // Utilizamos el mixer para controlar el volumen
    
    [SerializeField]
    GameObject pauseMenuUI, optionsMenuUI, pauseFirstButton, mainFirstButton; // Referencian los demás menus y que botón debería estar seleccionado al volver a ellos

    public void SetMasterVolume(float volume) // Slider del volumen general
    {
        master.SetFloat("masterVolume", Mathf.Log10 (volume) * 20);
    }

    public void SetMusicVolume(float volume) // Slider del volumen de la música
    {
        master.SetFloat("musicVolume", Mathf.Log10(volume) * 20);
    }

    public void SetSFXVolume (float volume) // Slider del volumen de los efectos
    {
        master.SetFloat("sfxVolume", Mathf.Log10(volume) * 20);
    }

    public void SetFullScreen(bool isFullscreen) // Controla si el juego debe estar a pantalla completa o no
    {
        Screen.fullScreen = isFullscreen;
    }

    public void Back() // Es llamado al salir del menú de opciones
    {
        if (pauseMenuUI != null)
        {
            pauseMenuUI.SetActive(true);
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(pauseFirstButton);
        }
        else if (mainFirstButton != null)
            EventSystem.current.SetSelectedGameObject(mainFirstButton);
       optionsMenuUI.SetActive(false);
    }
}
