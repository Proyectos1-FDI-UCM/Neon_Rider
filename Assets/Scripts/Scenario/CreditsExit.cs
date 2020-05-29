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
        {
            //GameManager.instance.OnSceneChange(0);
            SceneManager.LoadScene(0);
        }
    }
}
