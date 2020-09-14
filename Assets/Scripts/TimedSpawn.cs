using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    public Flock Flock;
    public float spawnTime = 10;
    public float spawncooldown = 10;
    public void Update()
    {
     /*   spawnTime -= Time.deltaTime;
        if (spawnTime <= 0)
        {
            SpawnObject();
            spawnTime = spawncooldown;
        }*/
    }

    public void SpawnObject()
    {
        Flock.addmember();
    }
}
    // Update is called once per frame


