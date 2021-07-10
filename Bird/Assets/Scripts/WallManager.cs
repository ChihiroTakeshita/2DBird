using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallManager : MonoBehaviour
{
    [SerializeField] private float interval = 1;
    [SerializeField] GameObject[] walls;
    [SerializeField] GameObject spawner;

    float nextSpawnTime = 0;

    // Update is called once per frame
    void Update()
    {
        if(nextSpawnTime < Time.timeSinceLevelLoad)
        {
            nextSpawnTime = Time.realtimeSinceStartup + interval;
            int id = Random.Range(0, walls.Length);
            GameObject obj = (GameObject)Instantiate(walls[id], spawner.transform.position, spawner.transform.rotation);
        }
    }
}