using UnityEngine;

public class Choi_Note : MonoBehaviour
{
    public int noteId;
    public float time;
    public float startTime;
    public string stringJudge;

    private void Start()
    {
        Initialize();
    }

    private void Update()
    {
        // �� �����Ӹ��� gameObject�� transform.position.y ���� ���� ��ǥ�� ��ȯ�Ͽ� ����� ���
        //Vector3 worldPosition = transform.TransformPoint(new Vector3(0, 0, transform.position.z));
        //Debug.Log($"World Y Position: {worldPosition.z}");
    }

    public void Initialize()
    {
        startTime = Time.realtimeSinceStartup;
        // �� �� �ʱ�ȭ ����...
    }
}