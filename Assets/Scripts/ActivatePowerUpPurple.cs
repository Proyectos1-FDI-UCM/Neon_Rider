using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatePowerUpPurple : MonoBehaviour
{
    PowerUpManager pum;
    Bloqueo parry;
    void Start()
    {
        pum = GetComponent<PowerUpManager>();
        if (pum == null)
        {
            Debug.Log("Jugador sin gestor de power-ups." + " Se ignora el power-up conseguido.");
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        parry = GetComponent<Bloqueo>();
        if (collision.gameObject.GetComponent<PrestBullet>()!=null && parry.enabled)
        {
            pum.ActivatePowerUp("PowerUpPurple");
            this.enabled = false;
        }
    }
}
