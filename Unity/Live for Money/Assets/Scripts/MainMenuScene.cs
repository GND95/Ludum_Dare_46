using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuScene : MonoBehaviour
{
    public GameObject informationPanel;
    public Text informationText;
    public GameObject gitHubLinkButton;

    void Start()
    {
        Cursor.visible = true;
    }

    public void ShowCreditsInformation()
    {
        informationText.text = "Created entirely from scratch in 48 hours for Ludum Dare 46\n\nProgramming: Garrett DeBlois\nArt: Garrett DeBlois\nLevel Design: Garrett DeBlois\nConcept: Garrett DeBlois\n\nTools used:\nGame Engine: Unity\nArt: Adobe Illustrator\nArt Style: Pixel Art (16-bit)\nColor Palette: Dawnbringer 16\nIDE: Visual Studio\nLanguage: C#\nSource Control: Git - Sourcetree & GitHub\n\nSource code: https://github.com/GND95/Ludum_Dare_46 \n(GitHub Link below)";
        ShowHideInformationPanel();
        gitHubLinkButton.SetActive(true);
    }

    public void ShowHowToPlayInformation()
    {
        informationText.text = "There are two scenes:\n1. A scene for growing your money tree\n2. A scene for collecting water\n\nYou must water your trees before they produce money. It requires one water to water your tree and watering your tree one time produces one height.\n\nYour trees must grow to 5 height before they produce any money. Money in the game is represented as a small coin on the tree. Clicking on the coin harvests the money from the tree. Once reaching 10 height, money trees will produce maximum money. Once money trees reach full height and are harvested, they must be cut down and replanted to grow more money.\n\nWater collection is slow at first. Also, if you leave your tree before it reaches a height of 5 or 10, it will shrink back to the starting height and you will not get any money. Keep in consideration how much water you have before you begin watering your trees as they need to get to at least a height of 5 to produce money.\n\nOnce your trees begin to produce money, you can use that money to buy water from the Water Shop. You may need to make a few visits to the water shop to get the best price on water.";
        ShowHideInformationPanel();
    }

    public void ShowHideInformationPanel()
    {
        if (informationPanel.activeSelf == false)
        {
            informationPanel.SetActive(true);
        }
        else
        {
            informationPanel.SetActive(false);
            gitHubLinkButton.SetActive(false);
        }
    }

    public void OpenWebsite()
    {
        Application.OpenURL("https://github.com/GND95/Ludum_Dare_46");
    }
}
