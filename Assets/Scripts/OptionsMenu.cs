using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.EventSystems;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer master;

    public GameObject pauseMenuUI, optionsMenuUI;

    public GameObject pauseFirstButton;

    public void SetMasterVolume(float volume)
    {
        master.SetFloat("masterVolume", Mathf.Log10 (volume) * 20);
    }

    public void SetMusicVolume(float volume)
    {
        master.SetFloat("musicVolume", Mathf.Log10(volume) * 20);
    }

    public void SetSFXVolume (float volume)
    {
        master.SetFloat("sfxVolume", Mathf.Log10(volume) * 20);
    }

    public void SetFullScreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void Back()
    {
        pauseMenuUI.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(pauseFirstButton);
        optionsMenuUI.SetActive(false);
    }
}
