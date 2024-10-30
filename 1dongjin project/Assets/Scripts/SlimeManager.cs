using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlimeManager : MonoBehaviour
{

    public GameObject SlimeGreenPrefabs;

//    public SlimeGreen curslimegreen;
    public int Length;
    public Transform canvas;

    public static SlimeManager instance;

    private void Awake()
    {
        instance = this;
    }

    //Spawn Slimegreen

    public void SpawnSlimeGreen()
    {
        

      //  GameObject SlimeGreenToSpawn = SlimeGreenPrefabs[Random.Range(0, SlimeGreenPrefabs.Length)];
      //  GameObject obj = Instantiate(SlimeGreenToSpawn, canvas);

       // curslimegreen = obj.GetComponent<SlimGgreen>();
    }

    public void Replaceslimegreen(GameObject SlimeGreen)
    {
        Destroy(SlimeGreen);
        SpawnSlimeGreen();
    }

}
