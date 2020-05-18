﻿using UnityEngine;

public class Enemy_Death : MonoBehaviour
{
    public int hitsToDeath; // Golpes que aguanta el enemigo
    [SerializeField] int deadVal = 0;
    Transform child;
    EnemyVision enemy;
    Drone drone;
    Turret turret;
    PrestEnemyAttack prest;
    Ralentizador ralen;


    private void Start()
    {
        // Si se reanuda desde un checkpoint posicionado después del enemigo,
        // éste es destruido
        if (GameManager.instance.deadVal >= deadVal){
            Destroy(this.gameObject);
        }

        prest = GetComponent<PrestEnemyAttack>();
        enemy = GetComponent<EnemyVision>();
        drone = GetComponent<Drone>();
        turret = GetComponent<Turret>();
        ralen = GetComponent<Ralentizador>();

        // Si no es el ralentizador, drone o torreta, cogemos al hijo
        if ((enemy != null||ralen!=null) && drone == null && turret == null)
            child = transform.GetChild(0);
    }
    // Metodo llamado desde el componente Sword_Attack
    public void OnAttack()
    {
        hitsToDeath--; // Recibe daño
        AudioManager.instance.Play(AudioManager.ESounds.Hit); // Sonido de daño del matón
   
        if (hitsToDeath == 0)
        {
            if ((enemy != null || ralen != null) && turret == null && drone == null)
            {
                // Separamos al hijo del padre
                // Llamamos a Animation de "EnemyDeathAnim"
                if (child.GetComponent<Animator>() != null)
                {
                    child.GetComponent<Animator>().SetBool("Death", true);
                    if (prest == null && ralen == null)
                        child.GetChild(0).GetComponentInChildren<SpriteRenderer>().enabled = false;
                    child.SetParent(null);
                }
            }
            Destroy(this.gameObject);
        }
    }
}