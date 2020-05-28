using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsExit : MonoBehaviour
{
    float time = 22f;

    void Update()
    {
        if (time > 0)
            time -= Time.deltaTime;
        else
            SceneManager.LoadScene(0);
    }
}
