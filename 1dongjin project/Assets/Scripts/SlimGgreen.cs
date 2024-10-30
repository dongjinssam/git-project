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
        // 체력 초기화 및 HP 바 설정
        curHp = maxHp;
        UpdateHealthBar();
    }

    public void Damage()
    {
        curHp--;
        UpdateHealthBar(); // HP 바 업데이트

        if (curHp <= 0)
        {
            Caught();
        }
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
}