using UnityEngine;

public class PositionAdjuster : MonoBehaviour
{
    public float spacing = 1.0f; // ������Ʈ ����
    public LayerMask collisionLayer; // �浹�� üũ�� ���̾�
    public float raycastDistance = 0.5f; // ����ĳ��Ʈ �Ÿ�

    private void Start()
    {
        Transform[] objectsToAdjust = GetComponentsInChildren<Transform>();

        foreach (Transform objTransform in objectsToAdjust)
        {
            Vector3 currentPosition = objTransform.position;
            Vector3 newPosition = currentPosition;

            Vector3 raycastDirection = Vector3.right; // �ʱ� ����ĳ��Ʈ ������ ���������� ����

            // ������Ʈ�� ��ġ�� ���� ����ĳ��Ʈ ������ �¿�� ����
            if (currentPosition.x > 0)
            {
                raycastDirection = Vector3.left; // �����ʿ� ��ġ�� ��� ����ĳ��Ʈ ������ �������� ����
            }

            RaycastHit hit;

            if (Physics.Raycast(currentPosition, raycastDirection, out hit, raycastDistance, collisionLayer))
            {
                Debug.Log("����ĳ��Ʈ");
                newPosition.x = hit.point.x + spacing;
                objTransform.position = newPosition;
            }
        }
    }
}
