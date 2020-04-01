using UnityEngine;

public class DestructibleWall : MonoBehaviour
{
    Transform arriba, abajo;

    // Los trozos de la pared que quedan cuando se rompe se asignan a las variables arriba y abajo
    private void Start()
    {
        arriba = transform.GetChild(0); 
        abajo = transform.GetChild(1);
    }

    // Cuando la pared se rompa libera a sus hijos y se destruye la parte entera
    public void Break()
    {
        arriba.SetParent(null);
        abajo.SetParent(null);
        Destroy(this.gameObject);
    }
}
