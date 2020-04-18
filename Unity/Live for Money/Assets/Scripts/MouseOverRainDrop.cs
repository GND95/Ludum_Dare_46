using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseOverRainDrop : MonoBehaviour
{    
    void Start()
    {
        
    }
  
    void OnMouseOver()
    {
        Debug.Log("destroying game object");
        Destroy(this.gameObject);
        WaterCollectionScene.IncrementWaterCount();
    }
}
