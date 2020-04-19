using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopScript : MonoBehaviour
{
    public Text shopText;
    public GameObject shopPanel;
    public Button shopBuyButton;
    private double RNG;

    private void CheckFunds()
    {
        if (PlayerScript.moneyQuantity >= RNG)
        {
            shopBuyButton.interactable = true;
        }
        else
        {
            shopBuyButton.interactable = false;
        }
    }

    public void GenerateText()
    {
        double RNGCalculate = Random.Range(0.87f, 1.13f);
        RNG = System.Math.Round(RNGCalculate, 2);
        shopText.text = "1 Water will cost you $" + RNG + ". Are you interested?";
        CheckFunds();
    }

    public void BuyWater()
    {
        PlayerScript.moneyQuantity -= RNG;
        PlayerScript.waterQuantity += 1;
        GenerateText();        
    }

    public void OpenShopPanel()
    {
        if (shopPanel.activeSelf == false)
        {
            GenerateText();
            shopPanel.SetActive(true);
        }
        else
        {
            shopPanel.SetActive(false);
        }
    }

    void Start()
    {

    }
    
    void Update()
    {
      
    }
}
