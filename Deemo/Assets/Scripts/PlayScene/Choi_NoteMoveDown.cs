using UnityEngine;

public class Choi_NoteMoveDown : MonoBehaviour
{
    public float moveSpeed = 2.0f; // �̵� �ӵ�

    private void Update()
    {
        // ��ü�� �Ʒ��� �̵���Ŵ
        transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
    }
}
