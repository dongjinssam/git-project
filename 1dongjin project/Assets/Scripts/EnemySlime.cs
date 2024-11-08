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


    // public float spawnInterval = 5f;     // 스폰 간격
    private bool isSpawningPaused = false; // 스폰 중지 상태 확인

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
    //if (!isSpawningPaused)  // 스폰 중지 상태가 아닐 때만 스폰
    //{
    //      Instantiate(slime, transform.position, Quaternion.identity);
    //}
    //  yield return new WaitForSeconds(spawnInterval);
    //}
    // }
    private void Die()
    {
        stageManager.EnemyDefeated(); // 적 슬라임이 죽을 때 스테이지 매니저에 알림
        Destroy(gameObject);
    }

    public void PauseSpawning(float pauseDuration)
    {
        StartCoroutine(PauseSpawningCoroutine(pauseDuration));
    }

    private IEnumerator PauseSpawningCoroutine(float pauseDuration)
    {
        isSpawningPaused = true;            // 스폰 중지
        yield return new WaitForSeconds(pauseDuration); // 지정된 시간 동안 대기
        isSpawningPaused = false;           // 스폰 재개
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
