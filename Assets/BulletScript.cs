using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Rigidbody2D rb;
    Vector3 lastVelocity;

    void Awake(){
        rb = GetComponent<Rigidbody2D>();
    }

    void Update(){
        lastVelocity = rb.velocity;
    }

    void OnCollisionEnter2D(Collision2D collision){
        Destroy(gameObject,10f);

        var speed = lastVelocity.magnitude;
        var direction = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);

        rb.velocity = direction * Mathf.Max(speed, 0f);
    }

    void OnTriggerEnter2D (Collider2D hitInformation){
        Damage pr;
        if(hitInformation.tag == "Blue" || hitInformation.tag == "Pink"){
            pr = hitInformation.GetComponent<Damage>();
        }
        else{
            pr = null;
        }

        if(pr != null){
            pr.Die();
            Destroy(gameObject);
        }
        
    }
}
