using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopButton : MonoBehaviour
{

    public GameObject panel;
    public GameObject battleModePanel;

    public void OpenShop(){
        panel.SetActive(true);
        battleModePanel.SetActive(false);
    }

    public void CloseShop(){
        panel.SetActive(false);
        battleModePanel.SetActive(true);
    }
}
