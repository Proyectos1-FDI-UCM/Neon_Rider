using UnityEngine;

public class EnemyCounter : MonoBehaviour
{
    [SerializeField] BossBehaviour boss = null;

    private void OnDestroy()
    {
        if (boss != null)
            boss.KillCount();
    }
}
