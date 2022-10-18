using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public void Die (){
        Destroy(gameObject);
    }
}
