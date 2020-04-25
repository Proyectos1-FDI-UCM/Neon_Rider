using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnControl : MonoBehaviour
{

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
