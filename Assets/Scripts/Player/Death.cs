using UnityEngine;
using UnityEngine.SceneManagement;

// Script de muerte del jugador
// Al ser invocado el método Dead() se considera al jugador muerto,
// es eliminado y se invoca un "cadáver"

public class Death : MonoBehaviour
    // Meter al jugador para que muera
{
    [SerializeField] GameObject muerto = null;
    bool active = true;

    private void OnEnable()
    {
        active = true;    
    }
    private void OnDisable()
    {
        active = false;
    }
    public void Dead()
    {
        if (active && GameManager.instance.toggleDeath)
        {
            AudioManager.instance.StopAllSFX();
            Debug.Log("tusmuersibdnauodbouawdubawdhvakhdboad");
            Instantiate(muerto, transform.position, Quaternion.identity);
            Destroy(this.gameObject);  
        }
    }
}
