using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

public class TreeScene : MonoBehaviour
{
    public Text saturationLevelText, waterQuantityText, moneyQuantityText, nextGrowthText;
    public Button waterTreeButton;

    public GameObject errorMessage, exitGamePanel;
    public Text errorMessageText;

    public Tile treeBase, treeTop, treeTopMoneyStar;
    public Tilemap tileMap;
    Vector3Int CenterOfMap = new Vector3Int(9, -4, 0);
    Vector3Int treeBaseBottomCenterOfMap = new Vector3Int(9, -13, 0);
    Vector3Int[] treeTopBottomCenterOfMap = { new Vector3Int(7, -12, 0), new Vector3Int(8, -12, 0), new Vector3Int(9, -12, 0), new Vector3Int(10, -12, 0), new Vector3Int(11, -12, 0), new Vector3Int(8, -11, 0), new Vector3Int(9, -11, 0), new Vector3Int(10, -11, 0), new Vector3Int(9, -10, 0) };
    //Vector3Int[] previousTreeTopBottomCenterOfMap = { new Vector3Int(7, -12, 0), new Vector3Int(8, -12, 0), new Vector3Int(9, -12, 0), new Vector3Int(10, -12, 0), new Vector3Int(11, -12, 0), new Vector3Int(8, -11, 0), new Vector3Int(9, -11, 0), new Vector3Int(10, -11, 0), new Vector3Int(9, -10, 0) };

    private int treeSizeLimit = 10;
    private int futureTreeSize = 0;
    private int currentTreeSize = 0;
    private float treeGrowthTime;

    public GameObject coin1, coin2, coin3, coin4, coin5, coin6;


    IEnumerator GrowTree()
    {
        for (treeGrowthTime = (Random.Range(1, 3)); treeGrowthTime > 0; treeGrowthTime -= Time.deltaTime) //to be able to keep track of the remaining growth time
        {
            waterTreeButton.interactable = false;
            yield return null;
        }
        waterTreeButton.interactable = true;

        tileMap.SetTile(treeBaseBottomCenterOfMap, treeBase);
        tileMap.SetTile(treeTopBottomCenterOfMap[0], treeTop);
        tileMap.SetTile(treeTopBottomCenterOfMap[1], treeTop);
        tileMap.SetTile(treeTopBottomCenterOfMap[2], treeTop);
        tileMap.SetTile(treeTopBottomCenterOfMap[3], treeTop);
        tileMap.SetTile(treeTopBottomCenterOfMap[4], treeTop);
        tileMap.SetTile(treeTopBottomCenterOfMap[5], treeTop);
        tileMap.SetTile(treeTopBottomCenterOfMap[6], treeTop);
        tileMap.SetTile(treeTopBottomCenterOfMap[7], treeTop);
        tileMap.SetTile(treeTopBottomCenterOfMap[8], treeTopMoneyStar);

        //tileMap.SetTile(previousTreeTopBottomCenterOfMap[0], null);
        //tileMap.SetTile(previousTreeTopBottomCenterOfMap[1], null);
        //tileMap.SetTile(previousTreeTopBottomCenterOfMap[3], null);
        //tileMap.SetTile(previousTreeTopBottomCenterOfMap[4], null);
        //tileMap.SetTile(previousTreeTopBottomCenterOfMap[5], null);
        //tileMap.SetTile(previousTreeTopBottomCenterOfMap[7], null);

        //previousTreeTopBottomCenterOfMap[0].y++;
        //previousTreeTopBottomCenterOfMap[1].y++;
        //previousTreeTopBottomCenterOfMap[2].y++;
        //previousTreeTopBottomCenterOfMap[3].y++;
        //previousTreeTopBottomCenterOfMap[4].y++;
        //previousTreeTopBottomCenterOfMap[5].y++;
        //previousTreeTopBottomCenterOfMap[6].y++;
        //previousTreeTopBottomCenterOfMap[7].y++;
        //previousTreeTopBottomCenterOfMap[8].y++;

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
        currentTreeSize++;

        if (currentTreeSize == 5)
        {
            coin1.SetActive(true);
            coin2.SetActive(true);
        }

        else if (currentTreeSize == 10)
        {
            coin3.SetActive(true);
            coin4.SetActive(true);
            coin5.SetActive(true);
            coin6.SetActive(true);
        }
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
        if (PlayerScript.waterQuantity >= 1 && futureTreeSize < treeSizeLimit)
        {
            PlayerScript.waterQuantity -= 1;
            futureTreeSize++;
            StartCoroutine(GrowTree());
        }
        else if (PlayerScript.waterQuantity < 1)
        {
            StartCoroutine(ErrorMessagePopup("You don't have enough water!"));
        }
        else if (futureTreeSize >= treeSizeLimit)
        {
            StartCoroutine(ErrorMessagePopup("Your tree can't absorb any more water!"));
        }
    }

    public void PickMoney(int coinNumber)
    {
        switch (coinNumber)
        {
            case 1:
                if (coin1.activeSelf == true)
                {
                    coin1.SetActive(false);
                    PlayerScript.moneyQuantity += System.Math.Round(Random.Range(1f, 3f), 2);
                }
                break;
            case 2:
                if (coin2.activeSelf == true)
                {
                    coin2.SetActive(false);
                    PlayerScript.moneyQuantity += System.Math.Round(Random.Range(1f, 3f), 2);
                }
                break;
            case 3:
                if (coin3.activeSelf == true)
                {
                    coin3.SetActive(false);
                    PlayerScript.moneyQuantity += System.Math.Round(Random.Range(1f, 3f), 2);
                }
                break;
            case 4:
                if (coin4.activeSelf == true)
                {
                    coin4.SetActive(false);
                    PlayerScript.moneyQuantity += System.Math.Round(Random.Range(1f, 3f), 2);
                }
                break;
            case 5:
                if (coin5.activeSelf == true)
                {
                    coin5.SetActive(false);
                    PlayerScript.moneyQuantity += System.Math.Round(Random.Range(1f, 3f), 2);
                }
                break;
            case 6:
                if (coin6.activeSelf == true)
                {
                    coin6.SetActive(false);
                    PlayerScript.moneyQuantity += System.Math.Round(Random.Range(1f, 3f), 2);
                }
                break;
        }
    }

    public void SpawnMoney()
    {
        coin1.SetActive(true);
    }

    void Start()
    {
        Cursor.visible = true;
        exitGamePanel.SetActive(false);
    }

    public void ShowHideExitMenu()
    {
        if (exitGamePanel.activeSelf == false)
        {
            exitGamePanel.SetActive(true);
        }
        else
        {
            exitGamePanel.SetActive(false);
        }
    }

    void Update()
    {
        saturationLevelText.text = futureTreeSize.ToString() + "/10";
        waterQuantityText.text = System.Math.Round(PlayerScript.waterQuantity, 2).ToString();
        moneyQuantityText.text = System.Math.Round(PlayerScript.moneyQuantity, 2).ToString("N2");
        if (treeGrowthTime > 0)
        {
            nextGrowthText.text = treeGrowthTime.ToString("N2");
        }
        else
        {
            nextGrowthText.text = "0";
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ShowHideExitMenu();
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            WaterTree();
        }
    }
}
