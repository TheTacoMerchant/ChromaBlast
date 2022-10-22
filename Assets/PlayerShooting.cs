using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public Transform PlayerShootPoint;
    public GameObject Bullet;
    public KeyCode Shoot = KeyCode.Space;

    public float bulletForce = 0.00001f;

    public float fireRate = 1f;
    public float nextFire = 0f;

    void Update()
    {
        if(Input.GetKeyDown(Shoot) && Time.time > nextFire){
            nextFire = Time.time + fireRate;
            Shooting();
        }
    }

    void Shooting(){
        GameObject bullet = Instantiate(Bullet, PlayerShootPoint.position, PlayerShootPoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(PlayerShootPoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
