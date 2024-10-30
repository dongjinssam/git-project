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

    public int curHp;
    public int maxHp;
    public int moneyToGive;

    public Transform healthBarFill;

    void Start()
    {
        // ü�� �ʱ�ȭ �� HP �� ����
        curHp = maxHp;
        UpdateHealthBar();
    }

    public void Damage()
    {
        curHp--;
        UpdateHealthBar(); // HP �� ������Ʈ

        if (curHp <= 0)
        {
            Caught();
        }
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
}