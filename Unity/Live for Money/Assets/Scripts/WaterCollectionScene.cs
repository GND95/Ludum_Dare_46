using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class WaterCollectionScene : MonoBehaviour
{
    public Texture2D cursorIcon;

    public GameObject rainDrop;
    public float spawnFrequency;
    public float rainDuration; //could problably use a timer for the duration of the rain interval.

    void Start()
    {
        Cursor.SetCursor(cursorIcon, Vector2.zero, CursorMode.ForceSoftware);
        StartCoroutine(rainShower(spawnFrequency, rainDuration));
        //TODO: Make random chance event of the above coroutine happening
    }

    private void spawnRainDrop()
    {
        Vector3 rainSpawnPoint = new Vector3(Random.Range(-8, 8), 6, 0);
        GameObject rain = GameObject.Instantiate(rainDrop, rainSpawnPoint, Quaternion.identity);
        Debug.Log("Spawning rain drop");              
        Destroy(rain, 2);
    }

    IEnumerator rainShower(float spawnFrequency, float rainDuration)
    {
        while (true)
        {
            spawnRainDrop();
            yield return new WaitForSeconds(spawnFrequency);                   
        }
    }

    void Update()
    {
        
    }
}
