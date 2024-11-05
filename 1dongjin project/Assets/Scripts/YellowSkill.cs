using System.Collections;
using UnityEngine;

public class YellowSkill : MonoBehaviour
{
    public float cooldown = 10f;       // 쿨타임 10초
    private bool isCooldown = false;   // 쿨타임 상태 확인

    private SlimGgreen slime;         // 플레이어 참조

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
            Debug.Log("노랑스킬은 쿨타임 중입니다!");
        }
    }

    private IEnumerator SkillEffect()
    {
        isCooldown = true;
        Debug.Log("노랑스킬 사용: 체력 30% 회복!");

        // 체력 30% 회복
        float healAmount = slime.maxHealth * 0.3f;
        slime.health = Mathf.Min(slime.health + healAmount, slime.maxHealth); // 최대 체력 초과하지 않도록 제한

        yield return new WaitForSeconds(cooldown); // 쿨타임 동안 대기
        isCooldown = false; // 쿨타임 해제
        Debug.Log("노랑스킬 재사용 가능");
    }
}
