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
        Destroy(this.gameObject);
        WaterCollectionScene.IncrementWaterCount();
    }
}
