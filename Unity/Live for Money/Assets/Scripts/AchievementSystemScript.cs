using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AchievementSystemScript : MonoBehaviour
{
    public Text achievementText;
    public GameObject achievementPanel;    

    public void CheckAchievementStatus()
    {
        if (PlayerScript.moneyQuantity >= 1000 && PlayerScript.unlocked_1000 == false)
        {
            PlayerScript.unlocked_1000 = true;
            achievementText.text = "No Life";
            StartCoroutine(ShowAchievement());            
        }
        else if (PlayerScript.moneyQuantity >= 500 && PlayerScript.unlocked_500 == false)
        {
            PlayerScript.unlocked_500 = true;
            achievementText.text = "Seek Help";
            StartCoroutine(ShowAchievement());
        }
        else if (PlayerScript.moneyQuantity >= 250 && PlayerScript.unlocked_250 == false)
        {
            PlayerScript.unlocked_250 = true;
            achievementText.text = "Seriously. Stop.";
            StartCoroutine(ShowAchievement());
        }
        else if (PlayerScript.moneyQuantity >= 100 && PlayerScript.unlocked_100 == false)
        {
            PlayerScript.unlocked_100 = true;
            achievementText.text = "Why are you still playing this?";
            StartCoroutine(ShowAchievement());
        }
        else if (PlayerScript.moneyQuantity >= 50 && PlayerScript.unlocked_50 == false)
        {
            PlayerScript.unlocked_50 = true;
            achievementText.text = "The Businessman";
            StartCoroutine(ShowAchievement());
        }
        else if (PlayerScript.moneyQuantity >= 25 && PlayerScript.unlocked_25 == false)
        {
            PlayerScript.unlocked_25 = true;
            achievementText.text = "Big Bucks";
            StartCoroutine(ShowAchievement());
        }
        else if (PlayerScript.moneyQuantity >= 10 && PlayerScript.unlocked_10 == false)
        {
            PlayerScript.unlocked_10 = true;
            achievementText.text = "Double Digits";
            StartCoroutine(ShowAchievement());
        }
        else if (PlayerScript.moneyQuantity >= 5 && PlayerScript.unlocked_5 == false)
        {
            PlayerScript.unlocked_5 = true;
            achievementText.text = "Minimum Wage";
            StartCoroutine(ShowAchievement());
        }
        else if (PlayerScript.moneyQuantity >= 1 && PlayerScript.unlocked_1 == false)
        {
            PlayerScript.unlocked_1 = true;
            achievementText.text = "First Dollar";
            StartCoroutine(ShowAchievement());
        }       
    }

    IEnumerator ShowAchievement()
    {
        achievementPanel.SetActive(true);
        yield return new WaitForSeconds(10);
        achievementPanel.SetActive(false);
    }
  
    void Update()
    {
        CheckAchievementStatus();
    }
}
