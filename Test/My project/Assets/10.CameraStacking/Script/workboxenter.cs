using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxInteraction : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Box: " + collision.gameObject.name);

        // �߰��� Box�� Player�� �浹���� �� ������ ���� �ۼ�
        // ���� ���, Box�� �ı��ǰų� ��ġ ����, ȿ�� �߻� ���� �߰��� �� ����.
    }
}
