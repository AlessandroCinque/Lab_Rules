using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnerLocations;
    public GameObject[] prefabToSpawn;
    private GameObject[] prefabsToClone;
    // Start is called before the first frame update
    void Start()
    {
        prefabsToClone = new GameObject[prefabToSpawn.Length];
        Spawn();
    }
    void Spawn()
    {
        for (int i = 0; i < prefabToSpawn.Length; i++)
        {
            prefabsToClone[i] = Instantiate(prefabToSpawn[i],spawnerLocations[i].transform.position, Quaternion.Euler(0,90,0)) as GameObject;
        }
    }
    void DestroyClonedGameObjects()
    {
        for (int i = 0; i < prefabsToClone.Length; i++)
        {
            Destroy(prefabsToClone[i]);
        }
    }
    void Respawn()
    {
        DestroyClonedGameObjects();
        Spawn();
    }
    public void Respawn1(int ID)
    {
        prefabsToClone[0] = Instantiate(prefabToSpawn[ID], spawnerLocations[Random.Range(0, spawnerLocations.Length)].transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
    }
}
