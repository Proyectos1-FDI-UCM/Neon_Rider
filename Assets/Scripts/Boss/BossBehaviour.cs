using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviour : MonoBehaviour
{
    TransformList enemiesOnScreen = new TransformList();
    
    private int actualWave;
   
    [System.Serializable]
    private struct Wave{
        public Enemy[] enemyRound;
    }

    [System.Serializable]   
    private struct Enemy{
        public Vector2 relativePos;
        public GameObject enemyRef;
    }

    [SerializeField]
    Wave[] waves = null;

    private void Start()
    {
        actualWave = 0;
        Instance();
    }

    private void Instance()
    {
        if(waves != null)

            for (int i = 0; i < waves[actualWave].enemyRound.Length; i++){
                waves[actualWave].enemyRound[i].enemyRef.transform.position = GetRelativePos(i);
                enemiesOnScreen.InsertInEnd(waves[actualWave].enemyRound[i].enemyRef.transform);
            }
    }

    private Vector2 GetRelativePos(int i)
    {
        Vector2 newRelativePos;
        newRelativePos.x = waves[actualWave].enemyRound[i].relativePos.x + this.transform.position.x;
        newRelativePos.y = waves[actualWave].enemyRound[i].relativePos.y + this.transform.position.y;
        return newRelativePos;
    }

    public void UpdateEnemies()
    {
        if (enemiesOnScreen.CheckNullNodes() <= 1)
        {
            actualWave++;
            Instance();
        }
    }
    
}
