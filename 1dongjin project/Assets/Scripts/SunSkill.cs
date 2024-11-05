using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunSkill : MonoBehaviour
{
    public float cooldown = 12f;           // 쿨타임 12초
    public float damageAmount = 50f;       // 광역 데미지 양
    private bool isCooldown = false;       // 쿨타임 상태 확인

    public void ActivateSkill()
    {
        if (!isCooldown)
        {
            StartCoroutine(SkillEffect());
        }
        else
        {
            Debug.Log("태양스킬은 쿨타임 중입니다!");
        }
    }

    private IEnumerator SkillEffect()
    {
        isCooldown = true;
        Debug.Log("태양스킬 사용: 태양 폭발!");

        // 범위 내 모든 적에게 데미지 주기
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, 20f); // 반경 (20)내의 모든 적
        foreach (var enemy in enemies)
        {
            EnemySlime enemySlime = enemy.GetComponent<EnemySlime>();
            if (enemySlime != null)
            {
                enemySlime.TakeDamage(damageAmount);
            }
        }

        yield return new WaitForSeconds(cooldown); // 쿨타임 동안 대기
        isCooldown = false; // 쿨타임 해제
        Debug.Log("태양스킬 재사용 가능");
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, 20f); // 범위 표시용
    }
}
