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
            Debug.Log("스킬은 쿨타임 중입니다!");
        }
    }
    private IEnumerator SkillEffect()
    {
        isCooldown = true;
        slime.attackSpeed *= attackSpeedMultiplier;
        Debug.Log("스킬 활성화: 고격 속도가 증가합니다!");

        yield return new WaitForSeconds(activeDuration);

        slime.attackSpeed /= attackSpeedMultiplier;
        Debug.Log("스킬 종료: 공격속도가 정상으로 돌아옵니다.");

        yield return new WaitForSeconds(cooldown);
        isCooldown = false;
        Debug.Log("스킬 재사용 가능");
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ActivateSkill();
        }
    }
}
