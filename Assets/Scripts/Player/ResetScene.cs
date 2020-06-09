
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetScene : MonoBehaviour
{
    private void Update()
    {
        if (GetComponent<SpriteRenderer>().sprite.name == "EndDeath")
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
