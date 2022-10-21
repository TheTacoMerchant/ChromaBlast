using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Rigidbody2D rb;
    //public GameObject bullet;
    Vector3 lastVelocity;
    public float bulletTime = 5f;

    void Awake(){
        rb = GetComponent<Rigidbody2D>();
    }

    void Update(){
        lastVelocity = rb.velocity/2;
    }

    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("Blue")){
            Destroy(gameObject, 1f);
            Debug.Log("Blue hit!!");
            CombatManager.Instance.SwitchStates("pink");
        }

        if(collision.gameObject.CompareTag("Pink")){
            Destroy(gameObject, 1f);
            Debug.Log("Pink hit!!");
            CombatManager.Instance.SwitchStates("blue");
        }

        Destroy(gameObject, bulletTime);

        var speed = lastVelocity.magnitude;
        var direction = Vector3.Reflect(lastVelocity, collision.contacts[0].normal).normalized;
        transform.rotation = Quaternion.Euler(0f,0f,direction.z);
        rb.velocity = direction * speed;
    }

}
