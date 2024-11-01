using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    [SerializeField]
    private Slider hpbar;

    private float maxHp = 100;
    private float curHp = 100;

    void Start()
    {
        //hpbar.value = (float)curHp / (float)maxHp;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            curHp -= 10;
        }
    }

    private void HandleHp()
    {
        hpbar.value = (float)curHp / (float)maxHp;
    }

}
