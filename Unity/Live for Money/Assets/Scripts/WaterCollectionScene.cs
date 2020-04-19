using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class WaterCollectionScene : MonoBehaviour
{
    public GameObject tutorialMessage, exitGamePanel;
    public GameObject rainDrop;
    public float spawnFrequency;
    public float rainDuration; //could problably use a timer for the duration of the rain interval.  
    public Text waterQuantityText, moneyQuantityText;


    void Start()
    {
        StartCoroutine(rainShower(spawnFrequency, rainDuration));
        exitGamePanel.SetActive(false);
    }

    private void spawnRainDrop()
    {
        Vector3 rainSpawnPoint = new Vector3(Random.Range(-8, 8), 6, 0);
        GameObject rain = GameObject.Instantiate(rainDrop, rainSpawnPoint, Quaternion.identity);
        Destroy(rain, 8);
    }

    IEnumerator rainShower(float spawnFrequency, float rainDuration)
    {
        while (true)
        {
            spawnRainDrop();
            yield return new WaitForSeconds(spawnFrequency);
        }
    }

    public static void IncrementWaterCount()
    {
        PlayerScript.waterQuantity += System.Math.Round(Random.Range(.05f, .5f), 2);
    }

    public void TutorialePopup()
    {
        if (tutorialMessage.gameObject.activeSelf == false)
        {
            tutorialMessage.gameObject.SetActive(true);
        }
        else
        {
            tutorialMessage.gameObject.SetActive(false);
        }
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
        waterQuantityText.text = System.Math.Round(PlayerScript.waterQuantity, 2).ToString();
        moneyQuantityText.text = System.Math.Round(PlayerScript.moneyQuantity, 2).ToString("N2");

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ShowHideExitMenu();
        }
    }
}
