//Author: Evashna Pillay

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audio : MonoBehaviour
{
    void Awake (){
        
        DontDestroyOnLoad(transform.gameObject);
    }
}
