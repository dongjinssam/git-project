using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueSkill : MonoBehaviour
{
    public float cooldown = 7f;              // ��Ÿ�� 7��
    public float damageAmount = 20f;         // ���� ������ ��
    private bool isCooldown = false;         // ��Ÿ�� ���� Ȯ��

    public void ActivateSkill()
    {
        if (!isCooldown)
        {
            StartCoroutine(SkillEffect());
        }
        else
        {
            Debug.Log("�Ķ���ų�� ��Ÿ�� ���Դϴ�!");
        }
    }

    private IEnumerator SkillEffect()
    {
        isCooldown = true;
        Debug.Log("�Ķ���ų ���: ������ �ߵ�!");

        // ���� �� ��� ������ ������ �ֱ�
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, 5f); // �ݰ� 5 ���� ��� ��
        foreach (var enemy in enemies)
        {
            EnemySlime Slimebule = enemy.GetComponent<EnemySlime>();
            if (Slimebule != null)
            {
                Slimebule.TakeDamage(damageAmount);
            }
        }

        yield return new WaitForSeconds(cooldown); // ��Ÿ�� ���� ���
        isCooldown = false; // ��Ÿ�� ����
        Debug.Log("�Ķ���ų ���� ����");
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, 20f); // ���� ǥ�ÿ�
    }
}

