using UnityEngine;

public class PowerUpPurple : MonoBehaviour
{
    //No necesita ningun componente extra
    //Bullet redBulletComponent;
    PrestBullet purpleBulletComponent;
    Bullet redBulletComponent;
    TurretBullet turretBulletComponent;
    Bloqueo parry;
    Rigidbody2D rbBullet;
    GameObject bullet;
    //[SerializeField] float speed = 0;
    //[SerializeField] GameObject purpleBulletback = null;
    //Transform purpleBulletTrans;
    //[SerializeField]  Rigidbody2D purpleRb = null;
    Vector2 auxVel=new Vector2(2,0);
    GameObject chid;
    bool activo;
    void OnEnable()
    {
        activo = true;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        parry = GetComponent<Bloqueo>();
        purpleBulletComponent = collision.gameObject.GetComponent<PrestBullet>();
        redBulletComponent = collision.gameObject.GetComponent<Bullet>();
        turretBulletComponent = collision.gameObject.GetComponent<TurretBullet>();
        bullet = collision.gameObject;
        rbBullet = collision.gameObject.GetComponent<Rigidbody2D>();
        if (rbBullet != null)
        {
            auxVel = rbBullet.velocity;
            Debug.Log("AUXVEL= " + auxVel);
        }

        if (activo)
        {
            if ((purpleBulletComponent != null|| redBulletComponent != null || turretBulletComponent != null) && parry.enabled )
            {
                rbBullet.velocity = -rbBullet.velocity;
                bullet.layer = 13;               
            }
        }                   
    }
    void OnDisable()
    {
        activo = false;
    }
}
