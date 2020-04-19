using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopScript : MonoBehaviour
{
    public Text shopText, shopButtonText;
    public GameObject shopPanel;
    public Button shopBuyButton;
    private double priceRNG, quantityRNG, finalPrice;

    private void CheckFunds()
    {
        if (PlayerScript.moneyQuantity >= finalPrice)
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
        double priceRNGCalculate = Random.Range(0.87f, 4f);
        double quantityRNGCalculate = Random.Range(1f, 10f);
        priceRNG = System.Math.Round(priceRNGCalculate, 2);
        quantityRNG = System.Math.Round(quantityRNGCalculate, 0);
        finalPrice = System.Math.Round((quantityRNG * priceRNG), 2);
        shopText.text = quantityRNG + " Water will cost you $" + finalPrice.ToString("N2") + ". Are you interested?";
        CheckFunds();
    }

    public void BuyWater()
    {
        PlayerScript.moneyQuantity -= finalPrice;
        PlayerScript.waterQuantity += quantityRNG;
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
        CheckFunds(); //if player has Water Shop open and collect coins that puts them over the threshold to buy, re-enable the buy button
    }
}
