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
        Damage pr;
        if(collision.gameObject.CompareTag("Blue")){
            Destroy(gameObject);
            Debug.Log("Blue hit!!");
            CombatManager.Instance.SwitchStates("pink");
        }

        if(collision.gameObject.CompareTag("Pink")){
            Destroy(gameObject);
            Debug.Log("Pink hit!!");
            CombatManager.Instance.SwitchStates("blue");
        }

        Destroy(gameObject,10f);

        var speed = lastVelocity.magnitude;
        var direction = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);

        rb.velocity = direction * Mathf.Max(speed, 0f);
    }

}
