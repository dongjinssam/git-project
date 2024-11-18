using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxInteraction : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Box: " + collision.gameObject.name);

        // 추가로 Box와 Player가 충돌했을 때 실행할 동작 작성
        // 예를 들어, Box가 파괴되거나 위치 변경, 효과 발생 등을 추가할 수 있음.
    }
}
