using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//public class SlimGgreen : MonoBehaviour
//{

//    public int curHp;
//    public int maxHp;
//    public int moneyToGive;

//    public SpriteRenderer healthBarFill;

//    public void Damage()
//    {
//        curHp--;
//        healthBarFill.fillAmount = (float)curHp / (float)maxHp;

//        if (curHp <= 0) 
//        {
//            Caught();
//        }

//    }

//    public void Caught()
//    { 
//    //add money

//    }

//}

public class SlimGgreen : MonoBehaviour
{
    public float health = 100f;   // 기본 체력
    public float damage = 10f;    // 기본 공격력
    public float attackSpeed = 1f; // 기본 공격 속도
    public static int gold = 500;         // 게임 골드

    public float maxHealth = 100;

    public float defense = 1.0f;

    //public int curHp;
                                   //  public int maxHp;
                                   //  public int moneyToGive;

    public Transform healthBarFill;

    public Scanner scanner;


    public GameObject projectilePrefab;
    public Transform firePoint;

    public bool isPlayer;

    public void AddGold(int amount)
    {
        gold += amount;
        Debug.Log("골드 획득 : " + amount + " | 현재 골드: " + gold);
    }

    public void FireProjectile()
    {
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        Projectile projScript = projectile.GetComponent<Projectile>();
       projScript.damage = damage;

    }

    void Update()
    {
        if (isPlayer && Input.GetKeyDown(KeyCode.Space))
        {
            FireProjectile();
            
        }
    }


    // 체력, 공격력, 공격속도를 증가시키기 위한 함수들
    public void IncreaseHealth(float amount)
    {
        health += amount;
    }

    public void IncreaseDamage(float amount)
    {
        damage += amount;
    }

    public void IncreaseAttackSpeed(float amount)
    {
        attackSpeed += amount;
    }


    public float GetPowerLevel()
    {
        return health * 0.5f + damage * 3f + attackSpeed * 5f + defense*5f;
    }


    void Awake()
    {
        scanner = GetComponent<Scanner>();
        if (firePoint == null) firePoint = transform;
    }


    void Start()
    {
        // 체력 초기화 및 HP 바 설정
 //       curHp = maxHp;
        UpdateHealthBar();

    }

    public void Damage()
    {
   //     curHp--;
        UpdateHealthBar(); // HP 바 업데이트

   //     if (curHp <= 0)
   //     {
   //        Caught();
   //     }
    }

    void UpdateHealthBar()
    {
        // 현재 체력을 최대 체력으로 나눈 비율로 HP 바의 너비 설정
        //float healthRatio = (float)curHp / (float)maxHp;
        //healthBarFill.localScale = new Vector3(healthRatio, healthBarFill.localScale.y, healthBarFill.localScale.z);
    }

  


    public void UpgradeHealth()
    {
        int cost = 20; // 예: 체력 강화에 필요한 골드

        if (gold >= cost)
        {
            gold -= cost;
            IncreaseHealth(10f); // 체력 10 증가
        }
        else
        {
            Debug.Log("골드가 부족합니다!");
        }
    }

    public void UpgradeDamage()
    {
        int cost = 30; // 예: 공격력 강화에 필요한 골드

        if (gold >= cost)
        {
            gold -= cost;
            IncreaseDamage(5f); // 공격력 5 증가
        }
        else
        {
            Debug.Log("골드가 부족합니다!");
        }
    }

    public void UpgradeAttackSpeed()
    {
        int cost = 50; // 예: 공격속도 강화에 필요한 골드

        if (gold >= cost)
        {
            gold -= cost;
            IncreaseAttackSpeed(0.1f); // 공격속도 0.1 증가
        }
        else
        {
            Debug.Log("골드가 부족합니다!");
        }
    }

}