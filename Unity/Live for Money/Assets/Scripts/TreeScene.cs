using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

public class TreeScene : MonoBehaviour
{
    public Text waterQuantityText;

    public Tile treeBase;
    public Tilemap tileMap;

    public GameObject waterErrorMessage;

    Vector3Int CenterOfMap = new Vector3Int(9, -4, 0);
    Vector3Int BottomCenterOfMap = new Vector3Int(9, -14, 0);

    IEnumerator GrowTree()
    {
        yield return new WaitForSeconds(20);
        tileMap.SetTile(BottomCenterOfMap, treeBase);
        BottomCenterOfMap.y++;        
    }

    IEnumerator ErrorMessagePopup()
    {        
        waterErrorMessage.gameObject.SetActive(true);
        yield return new WaitForSeconds(5);
        waterErrorMessage.gameObject.SetActive(false);
    }

    public void WaterTree()
    {
        if (PlayerScript.waterQuantity >= 1)
        {            
            PlayerScript.waterQuantity--;
            StartCoroutine(GrowTree());            
        }
        else
        {            
            StartCoroutine(ErrorMessagePopup());
        }        
    }   

    void Start()
    {
        
    }
   
    void Update()
    {
        waterQuantityText.text = PlayerScript.waterQuantity.ToString();
    }
}
