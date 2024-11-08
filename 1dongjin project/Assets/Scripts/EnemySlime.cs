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

    private StageManager stageManager;


    // public float spawnInterval = 5f;     // ���� ����
    private bool isSpawningPaused = false; // ���� ���� ���� Ȯ��

    void Start()
    {
        maxHealth = health;
        healthBar.maxValue = maxHealth;
        healthBar.value = health;

        slime = FindObjectOfType<SlimGgreen>();

        stageManager = FindObjectOfType<StageManager>();
        //StartCoroutine(SpawnEnemies());
    }
    //    private IEnumerator SpawnEnemies()
    //  {
    //while (true)
    //{
    //if (!isSpawningPaused)  // ���� ���� ���°� �ƴ� ���� ����
    //{
    //      Instantiate(slime, transform.position, Quaternion.identity);
    //}
    //  yield return new WaitForSeconds(spawnInterval);
    //}
    // }
    private void Die()
    {
        stageManager.EnemyDefeated(); // �� �������� ���� �� �������� �Ŵ����� �˸�
        Destroy(gameObject);
    }

    public void PauseSpawning(float pauseDuration)
    {
        StartCoroutine(PauseSpawningCoroutine(pauseDuration));
    }

    private IEnumerator PauseSpawningCoroutine(float pauseDuration)
    {
        isSpawningPaused = true;            // ���� ����
        yield return new WaitForSeconds(pauseDuration); // ������ �ð� ���� ���
        isSpawningPaused = false;           // ���� �簳
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

        for (float alpha = 0.3f; alpha > 0; alpha -= 0.05f)
        {
            Color color = renderer.color;
            color.a = alpha;
            renderer.color = color;
            yield return new WaitForSeconds(0.05f);
        }
        Destroy(gameObject);
    
    }

}
