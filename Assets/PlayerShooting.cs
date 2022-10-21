using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public Transform PlayerShootPoint;
    public GameObject Bullet;
    public KeyCode Shoot = KeyCode.Space;

    public float bulletForce = 0.00001f;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(Shoot)){
            Shooting();
        }
    }

    void Shooting(){
        GameObject bullet = Instantiate(Bullet, PlayerShootPoint.position, PlayerShootPoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(PlayerShootPoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
