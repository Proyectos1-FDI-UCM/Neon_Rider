using UnityEngine;

public class Ralentizador : MonoBehaviour
{

    public float time;
    private bool visto;

    private void Awake()
    {
        visto = false;
    }
    void Update()
    {   
        Vector2 pos = new Vector2(Camera.main.WorldToViewportPoint(transform.position).x, Camera.main.WorldToViewportPoint(transform.position).y);  //Coordenadas en cámara
        if (visto || pos.x <= 1 && pos.x >= 0 && pos.y <= 1 && pos.y >= 0)          //Condición para que esté dentro de la cámara (visto para evitar parar contador)
        {
            visto = true;
            time -= Time.deltaTime;

            if (time <= 0)          //Explosión
            {
                Debug.Log("Exploto");
                Destroy(this.gameObject);
            }
        }
    }
}
