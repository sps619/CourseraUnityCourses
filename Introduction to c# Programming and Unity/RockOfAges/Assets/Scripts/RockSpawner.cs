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

    
    void Start()
    {
        timer = gameObject.AddComponent<Timer>();
        timer.Duration = Random.Range(minSpawnTime, maxSpawnTime);
        timer.Run();


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

        GameObject obj = Instantiate(rock);
        
        obj.GetComponent<SpriteRenderer>().sprite = rocks[Random.Range(0, 3)];

        if (GameObject.FindGameObjectsWithTag("Rock").Length < 3)
        {
            GameObject obj2 = Instantiate(rock);
            obj2.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, -Camera.main.transform.position.z));
            obj2.GetComponent<SpriteRenderer>().sprite = rocks[Random.Range(0, 3)];
        }
    }
}
