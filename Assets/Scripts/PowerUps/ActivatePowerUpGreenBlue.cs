using UnityEngine;

// <summary>
// Componente utilizado para activar power-up's del jugador


public class ActivatePowerUpGreenBlue : MonoBehaviour 
{
    [SerializeField] GameObject player = null;
    PowerUpManager pum;

    // Variable de los PowerUps Verde y Azul
    Ralentizador ralentizador;

    void Start()
    {
        //Inicializa el PowerUpManager
        if (player != null)
            pum = player.GetComponent<PowerUpManager>();
        //Proteccion contra no inicializacion de PowerUpManager
        if (pum == null)
        {
            Debug.Log("Jugador sin gestor de power-ups." + " Se ignora el power-up conseguido.");
        }

        ralentizador = GetComponent<Ralentizador>();

    }

    void OnDestroy()
    {
        if (pum != null)
        {

            //Si se destruye con la espada activa el azul
            if (ralentizador.time > 0)
            {
                pum.ActivatePowerUp("PowerUpBlue");
            }
            //Si explota activa el v erde
            else
            {
                pum.ActivatePowerUp("PowerUpGreen");
            }
            
        }
        
    }
}
