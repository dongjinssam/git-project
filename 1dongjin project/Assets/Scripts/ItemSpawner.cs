using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ItemSpawner : MonoBehaviour
{

    [SerializeField] GameObject item;
    Vector2 itemSpawnPos;

     void Start()
    {
        InvokeRepeating("SpawnItem", 2f, 4f);    
    }


    void SpawnItem()
    {
        int randomValue = (int)Random.Range(0f, 2f);

        switch (randomValue)
        {
            case 0:
                itemSpawnPos = new Vector2(transform.position.x, -25f);
                break;

            
        }
        Instantiate(item, itemSpawnPos, Quaternion.identity);
    }
}
