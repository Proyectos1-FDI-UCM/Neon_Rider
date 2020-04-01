using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Caiste en el viejo truco de usar application.quit en el editor");
    }

    public void Options()
    {
        Debug.Log("El rap de las opciones.mp3");
    }
}
