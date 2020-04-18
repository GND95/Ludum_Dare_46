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
    Vector3Int CenterOfMap = new Vector3Int(9, -4, 0);
    Vector3Int BottomCenterOfMap = new Vector3Int(9, -14, 0);

    public GameObject errorMessage;
    public Text errorMessageText;
    private int treeSizeLimit = 10;
    private int currentTreeSize = 0;
    

    IEnumerator GrowTree()
    {
        yield return new WaitForSeconds(20);
        tileMap.SetTile(BottomCenterOfMap, treeBase);
        BottomCenterOfMap.y++;        
    }

    IEnumerator ErrorMessagePopup(string error)
    {
        errorMessageText.text = error;     
        errorMessage.gameObject.SetActive(true);
        yield return new WaitForSeconds(5);
        errorMessage.gameObject.SetActive(false);
    }

    public void WaterTree()
    {
        if (PlayerScript.waterQuantity >= 1 && currentTreeSize < treeSizeLimit)
        {            
            PlayerScript.waterQuantity--;
            currentTreeSize++;
            StartCoroutine(GrowTree());            
        }
        else if (PlayerScript.waterQuantity < 1)
        {            
            StartCoroutine(ErrorMessagePopup("You don't have any water!"));
        }        
        else if (currentTreeSize >= treeSizeLimit)
        {
            StartCoroutine(ErrorMessagePopup("Your tree can't absorb any more water!"));
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
