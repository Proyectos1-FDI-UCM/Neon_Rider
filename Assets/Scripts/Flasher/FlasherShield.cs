using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlasherShield : MonoBehaviour
{
    void Update()
    {
        Enemy_Death death = GetComponentInParent<Enemy_Death>();    //Si el flasher tiene solo una vida desaparece el escudo
        if (death.hitsToDeath == 1) Destroy(this.gameObject);             
    }
}
