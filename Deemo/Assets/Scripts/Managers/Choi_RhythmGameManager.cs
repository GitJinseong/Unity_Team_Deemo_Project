using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Choi_RhythmGameManager : MonoBehaviour
{
    public List<GameObject> noteList = new List<GameObject>();
    public Button button;

    private void Start()
    {
        // ��Ʈ ���� �� ����Ʈ�� �߰��ϴ� ������ �����մϴ�.
        // ���÷� ��Ʈ�� �����ϰ� noteList�� �߰��ϴ� ������ �ۼ��մϴ�.

        // ��ư Ŭ�� �̺�Ʈ�� ����մϴ�.
        button.onClick.AddListener(OnButtonClicked);
    }

    private void OnButtonClicked()
    {
        // ��ư�� ������ �� ���� ����� ��Ʈ�� ã�Ƽ� �����մϴ�.
        float closestDistance = float.MaxValue;
        GameObject closestNote = null;

        foreach (GameObject note in noteList)
        {
            float distance = Vector3.Distance(note.transform.position, button.transform.position);

            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestNote = note;
            }
        }

        // closestNote�� null�� �ƴ϶�� ���� ����� ��Ʈ�� ������ �ǹ��մϴ�.
        if (closestNote != null)
        {
            // ���� ������ �����մϴ�.
            PerformJudgment(closestNote);
        }
    }

    private void PerformJudgment(GameObject note)
    {
        // ���� ������ �����մϴ�.
        // ���� ���, closestNote�� �ش��ϴ� ��Ʈ�� �����ϰų� ������ ������Ű�� ���� ������ ������ �� �ֽ��ϴ�.
    }
}