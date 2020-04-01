﻿using UnityEngine;

// <summary>
// Componente utilizado para activar power-up's del jugador


public class ActivatePowerUpRed : MonoBehaviour 
{
    PowerUpManager pum;

    // Variables del PowerUp Rojo
    [SerializeField] float reset = 3f;
    [SerializeField] int numBlocks = 3;
    int cont = 0;
    float timeReset;
    int antcont = -1;

    void Start() 
    {
        //Inicializa el PowerUpManager   
        pum = GetComponent<PowerUpManager>();
        //Proteccion contra no inicializacion de PowerUpManager
        if (pum == null)
        {
            Debug.Log("Jugador sin gestor de power-ups." + " Se ignora el power-up conseguido.");
        } 
    }

    void Update()
    {
        if (pum != null)
        { 
            // Si contador llega al número necesario de bloqueos, se activa el PowerUp
            if (cont == numBlocks)
            {
                pum.ActivatePowerUp("PowerUpRed");
                cont = 0;
            }
            // Si has hecho un bloqueo y aun no es numBlocks, se aumenta el tiempo de reset
            if (cont > 0 && antcont != cont && cont < numBlocks)
            {
                antcont = cont;
                timeReset = reset + Time.time;
            }
            // Si no das nuevos bloqueos antes de que se acabe el tiempo, se resetea la cuenta
            if (timeReset <= Time.time && cont < numBlocks)
            {
                cont = 0;
                antcont = -1;
            }
            
        }
    }

    public void AddToCont()
    {
        cont++;
    }
}