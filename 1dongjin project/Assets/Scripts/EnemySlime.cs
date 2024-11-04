using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySlime : MonoBehaviour
{
    public float health = 50f;

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            StartCoroutine(DestroySlowly());
        }
    }

    private IEnumerator DestroySlowly()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }

}
