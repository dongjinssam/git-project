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
    public int gold = 100;         // 게임 골드
                                  
    //public int curHp;
                                   //  public int maxHp;
                                   //  public int moneyToGive;

    public Transform healthBarFill;

    public Scanner scanner;


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




    void Awake()
    {
        scanner = GetComponent<Scanner>();    
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

    public void Caught()
    {
        // MONEY 추가 기능 구현 예정
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