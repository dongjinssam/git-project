using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySlime : MonoBehaviour
{
    public float health = 50f;
    private float maxHealth;

    public Slider healthBar;


    public int goldReward = 10;

    private SlimGgreen slime;

    void Start()
    {
        maxHealth = health;
        healthBar.maxValue = maxHealth;
        healthBar.value = health;

        slime = FindObjectOfType<SlimGgreen>();
    }


    public void TakeDamage(float damage)
    {
        health -= damage;
        healthBar.value = health;

        if (health <= 0)
        {
            slime.AddGold(goldReward);
            StartCoroutine(DestroySlowly());
        }
    }

    private IEnumerator DestroySlowly()
    {
        //    yield return new WaitForSeconds(1f);
        //    Destroy(gameObject);
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();

        for (float alpha = 1f; alpha > 0; alpha -= 0.05f)
        {
            Color color = renderer.color;
            color.a = alpha;
            renderer.color = color;
            yield return new WaitForSeconds(0.05f);
        }
        Destroy(gameObject);
    
    }

}
