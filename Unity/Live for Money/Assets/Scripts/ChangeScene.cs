using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public GameObject switchScenePanel;

    public void changeToSceneNumber(string sceneToChangeTo)
    {        
        SceneManager.LoadScene(sceneToChangeTo);        
    }

    public void changeSceneWarning()
    {
        switchScenePanel.SetActive(false);
    }

    public void openChangeScenePanel()
    {
        switchScenePanel.SetActive(true);
    }
}
