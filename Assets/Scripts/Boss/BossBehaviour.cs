using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviour : MonoBehaviour
{
    [System.Serializable]
    public struct spawnPoint
    {
        public GameObject enemy;
        public Vector2 pos;
    }

    [System.Serializable]
    public struct spawnPhase
    {
        public spawnPoint[] spawnPoints;
    }

    private enum temp { wait, act }
    private int wave = 0;
    private int killCount = 0;
    temp phase;
  

    [SerializeField] private spawnPhase[] phase1;

    private void Start()
    {
        
        Instance();
        phase = temp.wait;
    }

    private void Update()
    {
        if (killCount >= phase1[wave].spawnPoints.Length)
        {
            killCount = 0;
            phase = temp.act;
        }

        if (phase == temp.wait)
        {
            //Algo podría hacer

        }
        else //Le toca actuar
        {
            if (wave < phase1.Length)
            {
                wave++;
                Debug.Log("Estamos en la wave: " + wave);
                //Instance();
                phase = temp.wait;
            }
        }


    }

    private void Instance()
    {
        Vector2 relativePos;
        for (int i = 0; i < phase1[wave].spawnPoints.Length; i++)
        {
            relativePos.x = phase1[wave].spawnPoints[i].pos.x + this.transform.position.x;
            relativePos.y = phase1[wave].spawnPoints[i].pos.y + this.transform.position.y;

            Instantiate(phase1[wave].spawnPoints[i].enemy, relativePos, Quaternion.identity);
        }
    }

    public void KillCount()
    {
        killCount++;

    }

}
