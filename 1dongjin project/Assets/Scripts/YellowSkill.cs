using System.Collections;
using UnityEngine;

public class YellowSkill : MonoBehaviour
{
    public float cooldown = 10f;       // ��Ÿ�� 10��
    private bool isCooldown = false;   // ��Ÿ�� ���� Ȯ��

    private SlimGgreen slime;         // �÷��̾� ����

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
            Debug.Log("�����ų�� ��Ÿ�� ���Դϴ�!");
        }
    }

    private IEnumerator SkillEffect()
    {
        isCooldown = true;
        Debug.Log("�����ų ���: ü�� 30% ȸ��!");

        // ü�� 30% ȸ��
        float healAmount = slime.maxHealth * 0.3f;
        slime.health = Mathf.Min(slime.health + healAmount, slime.maxHealth); // �ִ� ü�� �ʰ����� �ʵ��� ����

        yield return new WaitForSeconds(cooldown); // ��Ÿ�� ���� ���
        isCooldown = false; // ��Ÿ�� ����
        Debug.Log("�����ų ���� ����");
    }
}
