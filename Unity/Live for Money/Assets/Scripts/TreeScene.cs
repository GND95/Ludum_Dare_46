using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

public class TreeScene : MonoBehaviour
{
    public Text waterQuantityText;
    public Text moneyQuantityText;

    public GameObject errorMessage;
    public Text errorMessageText;

    public Tile treeBase, treeTop;    
    public Tilemap tileMap;
    Vector3Int CenterOfMap = new Vector3Int(9, -4, 0);
    Vector3Int treeBaseBottomCenterOfMap = new Vector3Int(9, -13, 0);
    Vector3Int[] treeTopBottomCenterOfMap = { new Vector3Int(7, -12, 0), new Vector3Int(8, -12, 0), new Vector3Int(9, -12, 0), new Vector3Int(10, -12, 0), new Vector3Int(11, -12, 0), new Vector3Int(8, -11, 0), new Vector3Int(9, -11, 0), new Vector3Int(10, -11, 0), new Vector3Int(9, -10, 0) };
    Vector3Int[] previousTreeTopBottomCenterOfMap = { new Vector3Int(7, -12, 0), new Vector3Int(8, -12, 0), new Vector3Int(9, -12, 0), new Vector3Int(10, -12, 0), new Vector3Int(11, -12, 0), new Vector3Int(8, -11, 0), new Vector3Int(9, -11, 0), new Vector3Int(10, -11, 0), new Vector3Int(9, -10, 0) };

    private int treeSizeLimit = 10;
    private int currentTreeSize = 0;

    public GameObject coin1;
    

    IEnumerator GrowTree()
    {
        yield return new WaitForSeconds(20);        

        tileMap.SetTile(treeBaseBottomCenterOfMap, treeBase);
        tileMap.SetTile(treeTopBottomCenterOfMap[0], treeTop);
        tileMap.SetTile(treeTopBottomCenterOfMap[1], treeTop);
        tileMap.SetTile(treeTopBottomCenterOfMap[2], treeTop);
        tileMap.SetTile(treeTopBottomCenterOfMap[3], treeTop);
        tileMap.SetTile(treeTopBottomCenterOfMap[4], treeTop);
        tileMap.SetTile(treeTopBottomCenterOfMap[5], treeTop);
        tileMap.SetTile(treeTopBottomCenterOfMap[6], treeTop);
        tileMap.SetTile(treeTopBottomCenterOfMap[7], treeTop);
        tileMap.SetTile(treeTopBottomCenterOfMap[8], treeTop);

        //tileMap.SetTile(previousTreeTopBottomCenterOfMap[0], null);
        //tileMap.SetTile(previousTreeTopBottomCenterOfMap[1], null);
        //tileMap.SetTile(previousTreeTopBottomCenterOfMap[3], null);
        //tileMap.SetTile(previousTreeTopBottomCenterOfMap[4], null);
        //tileMap.SetTile(previousTreeTopBottomCenterOfMap[5], null);
        //tileMap.SetTile(previousTreeTopBottomCenterOfMap[7], null);

        previousTreeTopBottomCenterOfMap[0].y++;
        previousTreeTopBottomCenterOfMap[1].y++;
        previousTreeTopBottomCenterOfMap[2].y++;
        previousTreeTopBottomCenterOfMap[3].y++;
        previousTreeTopBottomCenterOfMap[4].y++;
        previousTreeTopBottomCenterOfMap[5].y++;
        previousTreeTopBottomCenterOfMap[6].y++;
        previousTreeTopBottomCenterOfMap[7].y++;
        previousTreeTopBottomCenterOfMap[8].y++;

        treeTopBottomCenterOfMap[0].y++;
        treeTopBottomCenterOfMap[1].y++;
        treeTopBottomCenterOfMap[2].y++;
        treeTopBottomCenterOfMap[3].y++;
        treeTopBottomCenterOfMap[4].y++;
        treeTopBottomCenterOfMap[5].y++;
        treeTopBottomCenterOfMap[6].y++;
        treeTopBottomCenterOfMap[7].y++;
        treeTopBottomCenterOfMap[8].y++;
        treeBaseBottomCenterOfMap.y++;        
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

    public void PickMoney()
    {
        if (coin1.activeSelf == true)
        {
            coin1.SetActive(false);
            PlayerScript.moneyQuantity++;
        }        
    }

    public void SpawnMoney()
    {
        coin1.SetActive(true);
    }

    void Start()
    {
        Cursor.visible = true;
    }
   
    void Update()
    {
        waterQuantityText.text = PlayerScript.waterQuantity.ToString();
        moneyQuantityText.text = PlayerScript.moneyQuantity.ToString();
    }
}
