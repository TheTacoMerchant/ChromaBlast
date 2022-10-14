using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    //public GameObject hitEffect;

    void OnCollisionEnter2D(Collision2D collision){
        Destroy(gameObject,10f);
    }
}
