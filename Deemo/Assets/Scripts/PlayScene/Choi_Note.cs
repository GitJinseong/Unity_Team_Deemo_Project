using UnityEngine;

public class Choi_Note : MonoBehaviour
{
    public Choi_CollisionDetection collisionDetection;
    public int noteId;
    public float time;
    public float runTime;
    public float duration = 0.0f;
    public float durtationDifference = 0.0f;
    private bool isEnabled = false;

    private void Update()
    {
        if (isEnabled)
        {
            runTime += Time.deltaTime;

            if (runTime >= duration - durtationDifference)
            {
                isEnabled = false;
                collisionDetection.JudgeLineRemoveNote();
            }
        }
    }

    private void OnEnable()
    {
        isEnabled = true;
        runTime = 0f;
    }

    private void OnDisable()
    {
        isEnabled = false;
        // ��Ȱ��ȭ�� �� ��� �ð��� ����Ͽ� ���
        Debug.Log($"{runTime} seconds.");
    }
}
