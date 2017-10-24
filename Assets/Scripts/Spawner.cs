using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject enemyPrefab;
    public GameObject playArea;

    private Renderer rend;

    Vector3 SpawnPos;

    // Use this for initialization
    void Start()
    {
        rend = playArea.GetComponent<SpriteRenderer>();
        InvokeRepeating("RandomSpawn", 1f, 2f);
        //RandomSpawn();
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    void RandomSpawn()
    {
        //Creates variables for the edge values of the play area
        float minX = rend.bounds.min.x;
        float minY = rend.bounds.min.y;
        float maxX = rend.bounds.max.x;
        float maxY = rend.bounds.max.y;

        //Random returns a float but since we need an int between 1 and 4 this works just fine
        int spawnRegion = Random.Range(1, 5);

        //Creates random values within the bounds of the x and y axis of the play area
        float x = Random.Range(minX, maxX);
        float y = Random.Range(minY, maxY);

        //Depending on the spawn region this sets the spawn position to somewhere along the edge of the play area of that region
        if (spawnRegion == 1)
        {
            SpawnPos = new Vector3(x, maxY, -1f);
        }
        if (spawnRegion == 2)
        {
            SpawnPos = new Vector3(maxX, y, -1f);
        }
        if (spawnRegion == 3)
        {
            SpawnPos = new Vector3(x, minY, -1f);
        }
        if (spawnRegion == 4)
        {
            SpawnPos = new Vector3(minX, y, -1f);
        }

        Instantiate(enemyPrefab, SpawnPos, Quaternion.identity);

    }

}
