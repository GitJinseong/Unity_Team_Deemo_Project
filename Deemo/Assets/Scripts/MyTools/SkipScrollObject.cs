using UnityEngine;

public class SkipScrollObject : MonoBehaviour
{
    public GameObject obj_Bg;
    public Vector2 targetPosition = Vector2.zero; // ��ǥ ����
    private RectTransform rectTransform;

    // Start is called before the first frame update
    void Start()
    {
        rectTransform = obj_Bg.GetComponent<RectTransform>();
    }

    // ��ũ���� ��� ��ǥ �������� �̵���Ű�� �Լ�
    public void SkipScroll()
    {
        obj_Bg.SetActive(false);
        obj_Bg.SetActive(true);
        rectTransform.anchoredPosition = targetPosition;
    }
}
