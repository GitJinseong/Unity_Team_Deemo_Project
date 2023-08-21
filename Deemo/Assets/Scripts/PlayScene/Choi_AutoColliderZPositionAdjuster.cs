using UnityEngine;

public class Choi_AutoColliderZPositionAdjuster : MonoBehaviour
{
    public float originalZPosition = -647f; // �⺻ z ��ǥ ��

    private void Start()
    {
        // ���� ȭ���� �ػ󵵸� ������
        int screenWidth = Screen.width;
        int screenHeight = Screen.height;

        // ��⸶�� �ٸ� z ��ǥ �������� ���
        float zAdjustment = CalculateZAdjustment(screenWidth, screenHeight);

        // ���� ������ z ��ǥ�� �ݶ��̴��� z ��ǥ�� ����
        BoxCollider boxCollider = GetComponent<BoxCollider>();
        if (boxCollider != null)
        {
            Vector3 newColliderPosition = boxCollider.center;
            newColliderPosition.z = originalZPosition + zAdjustment;
            boxCollider.center = newColliderPosition;
        }
    }

    private float CalculateZAdjustment(int screenWidth, int screenHeight)
    {
        // ȭ�� �ػ󵵿� ���� z ��ǥ ������ ��� ������ �ۼ��ϼ���.
        // ���� ���, screenWidth�� screenHeight ���� ����ؼ� �������� ����� �� �ֽ��ϴ�.
        // �Ʒ��� �ӽ÷� ���÷� �ۼ��� �ڵ��Դϴ�. ���� ���� ������ �ʿ��� �� �ֽ��ϴ�.

        // ������ ��Ʈ 10�� �ػ��� 2280x1080�� �������� �������� ����մϴ�.
        int galaxyNote10Width = 2280;
        int galaxyNote10Height = 1080;
        float galaxyNote10ZAdjustment = -554f;

        // ������ ��Ʈ 10�� �ػ󵵿� �°� �������� ����մϴ�.
        if (screenWidth == galaxyNote10Width && screenHeight == galaxyNote10Height)
        {
            return galaxyNote10ZAdjustment;
        }
        else
        {
            // �ٸ� ����� ��쿡 ���� �������� �Ϲ������� �����Ͽ� ����մϴ�.
            // ���� ���, �Ϲ������� �ػ󵵰� 1920x1080�� ��쿡 ���� �������� ����� �� �ֽ��ϴ�.
            int commonWidth = 1920;
            int commonHeight = 1080;
            float commonZAdjustment = -500f; // ������ ��

            if (screenWidth == commonWidth && screenHeight == commonHeight)
            {
                return commonZAdjustment;
            }
            else
            {
                // ��Ÿ ��⿡ ���� �������� �߰��� �����Ͽ� ����մϴ�.
                return 0f; // �⺻���� 0���� ����
            }
        }
    }
}
