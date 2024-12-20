using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection : MonoBehaviour
{

    public EnemySlime slime; 
    public float pauseDuration = 2f;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            slime.PauseSpawning(pauseDuration);
        }
    }

}
