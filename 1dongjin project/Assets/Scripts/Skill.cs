using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{

    public float cooldown = 10f;
    public float activeDuration = 10f;
    public float attackSpeedMultiplier = 1.3f;
    private bool isCooldown = false;

    private SlimGgreen slime;

    void Start()
    {
        slime = GetComponent<SlimGgreen>();
    }

    public void ActivateSkill()
    {
        if (!isCooldown)
        {
            StartCoroutine(SkillEffect());
        }
        else
        {
            Debug.Log("��ų�� ��Ÿ�� ���Դϴ�!");
        }
    }
    private IEnumerator SkillEffect()
    {
        isCooldown = true;
        slime.attackSpeed *= attackSpeedMultiplier;
        Debug.Log("��ų Ȱ��ȭ: ��� �ӵ��� �����մϴ�!");

        yield return new WaitForSeconds(activeDuration);

        slime.attackSpeed /= attackSpeedMultiplier;
        Debug.Log("��ų ����: ���ݼӵ��� �������� ���ƿɴϴ�.");

        yield return new WaitForSeconds(cooldown);
        isCooldown = false;
        Debug.Log("��ų ���� ����");
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ActivateSkill();
        }
    }
}
