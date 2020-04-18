using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreeScene : MonoBehaviour
{
    public Text waterQuantityText;
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        waterQuantityText.text = PlayerScript.waterQuantity.ToString();
    }
}
