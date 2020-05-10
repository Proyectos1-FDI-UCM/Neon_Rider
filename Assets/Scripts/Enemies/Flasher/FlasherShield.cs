using UnityEngine;
public class FlasherShield : MonoBehaviour
{
    void Update()
    {
        //Si el flasher tiene sólo una vida, desaparece el escudo
        if (GetComponentInParent<Enemy_Death>().hitsToDeath == 1) 
            Destroy(this.gameObject);             
    }
}
