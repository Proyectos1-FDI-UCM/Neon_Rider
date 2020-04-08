using System.Threading;
using UnityEngine;

// <summary>
// Componente utilizado para activar power-up's del jugador


public class ActivatePowerUpGreenBlue : MonoBehaviour
{
    GameObject player;
    PowerUpManager pum;
    float delay = 0.1f;

    // Variable de los PowerUps Verde y Azul
    Ralentizador ralentizador;

    void Start()
    {
        player = GameManager.instance.GetPlayer();
        
        // Se crea un delay mínimo para que no se active al reiniciar 
        // escena si se destuyen por checkpoint
        delay += Time.time;

       
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
        if (pum != null && Time.time > delay)
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