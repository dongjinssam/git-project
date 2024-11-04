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
    public float health = 100f;   // �⺻ ü��
    public float damage = 10f;    // �⺻ ���ݷ�
    public float attackSpeed = 1f; // �⺻ ���� �ӵ�
    public int gold = 100;         // ���� ���
                                  
    //public int curHp;
                                   //  public int maxHp;
                                   //  public int moneyToGive;

    public Transform healthBarFill;

    public Scanner scanner;


    // ü��, ���ݷ�, ���ݼӵ��� ������Ű�� ���� �Լ���
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
        // ü�� �ʱ�ȭ �� HP �� ����
 //       curHp = maxHp;
        UpdateHealthBar();

    }

    public void Damage()
    {
   //     curHp--;
        UpdateHealthBar(); // HP �� ������Ʈ

   //     if (curHp <= 0)
   //     {
   //        Caught();
   //     }
    }

    void UpdateHealthBar()
    {
        // ���� ü���� �ִ� ü������ ���� ������ HP ���� �ʺ� ����
        //float healthRatio = (float)curHp / (float)maxHp;
        //healthBarFill.localScale = new Vector3(healthRatio, healthBarFill.localScale.y, healthBarFill.localScale.z);
    }

    public void Caught()
    {
        // MONEY �߰� ��� ���� ����
    }


    public void UpgradeHealth()
    {
        int cost = 20; // ��: ü�� ��ȭ�� �ʿ��� ���

        if (gold >= cost)
        {
            gold -= cost;
            IncreaseHealth(10f); // ü�� 10 ����
        }
        else
        {
            Debug.Log("��尡 �����մϴ�!");
        }
    }

    public void UpgradeDamage()
    {
        int cost = 30; // ��: ���ݷ� ��ȭ�� �ʿ��� ���

        if (gold >= cost)
        {
            gold -= cost;
            IncreaseDamage(5f); // ���ݷ� 5 ����
        }
        else
        {
            Debug.Log("��尡 �����մϴ�!");
        }
    }

    public void UpgradeAttackSpeed()
    {
        int cost = 50; // ��: ���ݼӵ� ��ȭ�� �ʿ��� ���

        if (gold >= cost)
        {
            gold -= cost;
            IncreaseAttackSpeed(0.1f); // ���ݼӵ� 0.1 ����
        }
        else
        {
            Debug.Log("��尡 �����մϴ�!");
        }
    }

}