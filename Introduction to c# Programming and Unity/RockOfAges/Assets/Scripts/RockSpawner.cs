using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSpawner : MonoBehaviour {

    Timer timer;
    int rockCounter;

    [SerializeField]
    GameObject rock;

    [SerializeField]
    Sprite[] rocks = new Sprite[3];

    [SerializeField]
    float minSpawnTime, maxSpawnTime;

    const int SpawnBorderSize = 100;
    int minSpawnX;
    int maxSpawnX;
    int minSpawnY;
    int maxSpawnY;
    
    void Start()
    {
        timer = gameObject.AddComponent<Timer>();
        timer.Duration = Random.Range(minSpawnTime, maxSpawnTime);
        timer.Run();

        minSpawnX = SpawnBorderSize;
        maxSpawnX = Screen.width - SpawnBorderSize;
        minSpawnY = SpawnBorderSize;
        maxSpawnY = Screen.height - SpawnBorderSize;

        SpawnRock();
    }

    void Update()
    {
        rockCounter = GameObject.FindGameObjectsWithTag("Rock").Length;
        
        if (timer.Finished && rockCounter < 3)
        {
            SpawnRock();

            timer.Duration = Random.Range(minSpawnTime, maxSpawnTime);
            timer.Run();
        }
    }

    void SpawnRock()
    {
        Vector3 location = new Vector3(Random.Range(minSpawnX, maxSpawnX), Random.Range(minSpawnY, maxSpawnY), -Camera.main.transform.position.z);

        Vector3 worldLocation = Camera.main.ScreenToWorldPoint(location);

        GameObject obj = Instantiate(rock);
        obj.transform.position = worldLocation;
        obj.GetComponent<SpriteRenderer>().sprite = rocks[Random.Range(0, 3)];

        if (GameObject.FindGameObjectsWithTag("Rock").Length < 3)
        {
            GameObject obj2 = Instantiate(rock);
            obj2.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, -Camera.main.transform.position.z));
            obj2.GetComponent<SpriteRenderer>().sprite = rocks[Random.Range(0, 3)];
        }
    }
}
