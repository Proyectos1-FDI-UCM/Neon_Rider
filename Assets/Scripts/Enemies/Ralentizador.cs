using UnityEngine;
// *ENEMIGO*
// Una vez entra en el rango de visión del jugador, se activa la cuenta atrás
// Este script únicamente destruye el gameObject, los powerups se llaman desde sus respectivos scripts


public class Ralentizador : MonoBehaviour
{

    public float time;
    private bool visto;
    //private Animator animator = GetComponentInChildren<Animator>();

    private void Awake()
    {
        visto = false;
    }
    void Update()
    {
        GetComponentInChildren<Animator>().SetBool("Visto", visto);
        Vector2 pos = new Vector2(Camera.main.WorldToViewportPoint(transform.position).x, 
                                  Camera.main.WorldToViewportPoint(transform.position).y);  // Coordenadas en cámara

        if (visto || pos.x <= 1 && pos.x >= 0 && pos.y <= 1 && pos.y >= 0) // Condición para que esté dentro de la cámara (visto para evitar parar contador)
        { 
            visto = true;
            time -= Time.deltaTime;
            if (time <= 0){ // Explosión
                Debug.Log("Exploto");
                Destroy(this.gameObject);
            }
        }
    }
}
