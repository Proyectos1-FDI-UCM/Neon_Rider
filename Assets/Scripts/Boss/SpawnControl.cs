using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnControl : MonoBehaviour
{
    // Script auxiliar a BossBehaviour colocado en los enemigos a invocar
    // Al morir, notifica de su muerte al Boss


    [SerializeField]
    BossBehaviour fatherBoss = null;

    private void OnDisable()
    {
        if (fatherBoss != null)
        {
            fatherBoss.UpdateEnemies();
        }
    }
}
