using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatCam : MonoBehaviour
{
    private Camera cam;
    public void panCamera(float x, float y){
        cam.transform.position = new Vector3(x,y,10f);
    }
}
