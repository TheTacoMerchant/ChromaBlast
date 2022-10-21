using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopButton : MonoBehaviour
{
    // Start is called before the first frame update
    public void OpenShop(){
        GameObject.Find("ShopPanel").SetActive(true);
    }

    public void CloseShop(){
        GameObject.Find("ShopPanel").SetActive(false);
    }
}
