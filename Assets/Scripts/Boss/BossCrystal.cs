using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BossCrystal : MonoBehaviour
{
    [SerializeField] BossBehaviour boss = null;
    bool active = false;
    public void Break()
    {
        if (active && boss != null)
        {
            active = false;

            boss.UpdateCrystal();

            Destroy(this.gameObject);
        }
    }

    public void SetActive()
    {
        active = true;
    }

}
