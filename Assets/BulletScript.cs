using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Rigidbody2D rb;
    Vector3 lastVelocity;
    public float bulletTime = 3f;
    public AudioSource shotSound;
    public AudioSource ricochetSound;

    void Awake(){
        shotSound.Play();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update(){
        lastVelocity = rb.velocity/1.25f;
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

        ricochetSound.time = 0.5f;
        ricochetSound.Play();
        var speed = lastVelocity.magnitude;
        var direction = Vector3.Reflect(lastVelocity, collision.contacts[0].normal).normalized;
        transform.rotation = Quaternion.Euler(0f,0f,direction.z);
        rb.velocity = direction * speed;
    }

}
