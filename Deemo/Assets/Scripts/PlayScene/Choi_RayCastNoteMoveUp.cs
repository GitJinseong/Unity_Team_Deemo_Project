using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choi_RayCastNoteMoveUp : MonoBehaviour
{
    public float moveSpeed = 2.0f; // �̵� �ӵ�

    private void Update()
    {
        // ��ü�� �Ʒ��� �̵���Ŵ
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
    }
}
