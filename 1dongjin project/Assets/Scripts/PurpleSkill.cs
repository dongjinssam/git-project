using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleSkill : MonoBehaviour
{
    public float cooldown = 5f;
    public float activeDuration = 5f;
    public float defenseMultiplier = 1.1f;
    private bool isCooldown = false;


    private SlimGgreen slime;

    void Start()
    {
        slime = GetComponent<SlimGgreen>();    
    }

    public void activateSkill()
    {
        if (!isCooldown)
        {
            StartCoroutine(SkillEffect());
        }

        else {

            Debug.Log("��ų�� ��Ÿ�� ���Դϴ�!");
                
        }
    }

    private IEnumerator SkillEffect()
    {
        isCooldown = true;
        slime.defense *= defenseMultiplier;
        Debug.Log("����ų Ȱ��ȭ : ������ �����մϴ�!");

        yield return new WaitForSeconds(activeDuration);

        slime.defense /= defenseMultiplier;
        Debug.Log("����ų ���� : ������ �������� ���ƿɴϴ�.");

        yield return new WaitForSeconds(cooldown);
        isCooldown = false;
        Debug.Log("����ų ���� ����");


    }

}
