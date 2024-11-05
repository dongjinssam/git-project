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

            Debug.Log("스킬은 쿨타임 중입니다!");
                
        }
    }

    private IEnumerator SkillEffect()
    {
        isCooldown = true;
        slime.defense *= defenseMultiplier;
        Debug.Log("보라스킬 활성화 : 방어력이 증가합니다!");

        yield return new WaitForSeconds(activeDuration);

        slime.defense /= defenseMultiplier;
        Debug.Log("보라스킬 종료 : 방어력이 정상으로 돌아옵니다.");

        yield return new WaitForSeconds(cooldown);
        isCooldown = false;
        Debug.Log("보라스킬 재사용 가능");


    }

}
