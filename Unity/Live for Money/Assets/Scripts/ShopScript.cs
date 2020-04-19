using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopScript : MonoBehaviour
{
    public Text shopText, shopButtonText;
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
        double RNGCalculate = Random.Range(0.87f, 4f);
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
            shopButtonText.text = "Leave Water Shop";
        }
        else
        {
            shopPanel.SetActive(false);
            shopButtonText.text = "Visit Water Shop";
        }
    }

    void Start()
    {

    }
    
    void Update()
    {
      
    }
}
