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

    public void GrowTree()
    {
        tileMap.SetTile(BottomCenterOfMap, treeBase);
        BottomCenterOfMap.y++;
    }

    void Start()
    {
        
    }
   
    void Update()
    {
        waterQuantityText.text = PlayerScript.waterQuantity.ToString();
    }
}
