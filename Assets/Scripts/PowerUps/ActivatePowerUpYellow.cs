using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatePowerUpYellow : MonoBehaviour
{
    PowerUpManager pum;
    void Start()
    {
        //Inicializa el PowerUpManager
        pum = GetComponentInParent<PowerUpManager>();
        //Proteccion contra no inicializacion de PowerUpManager
        if (pum == null)
        {
            Debug.Log("Jugador sin gestor de power-ups." + " Se ignora el power-up conseguido.");
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {       
        if(pum != null && other.GetComponent<FlasherRay>() != null)
        {
            pum.ActivatePowerUp("PowerUpYellow");
            Debug.Log("Amarillito entró");
        }
    }
}
