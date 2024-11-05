using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunSkill : MonoBehaviour
{
    public float cooldown = 12f;           // ��Ÿ�� 12��
    public float damageAmount = 50f;       // ���� ������ ��
    private bool isCooldown = false;       // ��Ÿ�� ���� Ȯ��

    public void ActivateSkill()
    {
        if (!isCooldown)
        {
            StartCoroutine(SkillEffect());
        }
        else
        {
            Debug.Log("�¾罺ų�� ��Ÿ�� ���Դϴ�!");
        }
    }

    private IEnumerator SkillEffect()
    {
        isCooldown = true;
        Debug.Log("�¾罺ų ���: �¾� ����!");

        // ���� �� ��� ������ ������ �ֱ�
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, 20f); // �ݰ� (20)���� ��� ��
        foreach (var enemy in enemies)
        {
            EnemySlime enemySlime = enemy.GetComponent<EnemySlime>();
            if (enemySlime != null)
            {
                enemySlime.TakeDamage(damageAmount);
            }
        }

        yield return new WaitForSeconds(cooldown); // ��Ÿ�� ���� ���
        isCooldown = false; // ��Ÿ�� ����
        Debug.Log("�¾罺ų ���� ����");
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, 20f); // ���� ǥ�ÿ�
    }
}
