using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AchievementSystemScript : MonoBehaviour
{
    public Text achievementText;
    public GameObject achievementPanel;
    private static bool unlocked_1, unlocked_5, unlocked_10, unlocked_25, unlocked_50, unlocked_100, unlocked_250, unlocked_500, unlocked_1000;

    public void CheckAchievementStatus()
    {
        if (PlayerScript.moneyQuantity >= 1000 && unlocked_1000 == false)
        {
            unlocked_1000 = true;
            achievementText.text = "No Life";
            StartCoroutine(ShowAchievement());            
        }
        else if (PlayerScript.moneyQuantity >= 500 && unlocked_500 == false)
        {
            unlocked_500 = true;
            achievementText.text = "Seek Help";
            StartCoroutine(ShowAchievement());
        }
        else if (PlayerScript.moneyQuantity >= 250 && unlocked_250 == false)
        {
            unlocked_250 = true;
            achievementText.text = "Seriously. Stop.";
            StartCoroutine(ShowAchievement());
        }
        else if (PlayerScript.moneyQuantity >= 100 && unlocked_100 == false)
        {
            unlocked_100 = true;
            achievementText.text = "Why are you still playing this?";
            StartCoroutine(ShowAchievement());
        }
        else if (PlayerScript.moneyQuantity >= 50 && unlocked_50 == false)
        {
            unlocked_50 = true;
            achievementText.text = "The Businessman";
            StartCoroutine(ShowAchievement());
        }
        else if (PlayerScript.moneyQuantity >= 25 && unlocked_25 == false)
        {
            unlocked_25 = true;
            achievementText.text = "Big Bucks";
            StartCoroutine(ShowAchievement());
        }
        else if (PlayerScript.moneyQuantity >= 10 && unlocked_10 == false)
        {
            unlocked_10 = true;
            achievementText.text = "Double Digits";
            StartCoroutine(ShowAchievement());
        }
        else if (PlayerScript.moneyQuantity >= 5 && unlocked_5 == false)
        {
            unlocked_5 = true;
            achievementText.text = "Minimum Wage";
            StartCoroutine(ShowAchievement());
        }
        else if (PlayerScript.moneyQuantity >= 1 && unlocked_1 == false)
        {
            unlocked_1 = true;
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
