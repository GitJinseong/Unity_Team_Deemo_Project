using UnityEditor;
using UnityEngine;

public class TitleScene_ExampleUsage : MonoBehaviour
{
    private DelayManager delayManager = default;
    private void Start()
    {
        delayManager = GetComponent<DelayManager>();
        RegisterDelayedActions();
    }

    // �پ��� �۾��� ����ϰ� ���� �ٸ� �����̸� �����ϴ� �Լ�
    // ���� �׼��� �����̰� ���� �� ���� �׼��� �����̸� �����Ѵ�.
    private void RegisterDelayedActions()
    {
        // �⺻ �ΰ� ����
        delayManager.AddDelayedAction(2.0f, () => TitleSceneTasks.instance.StartRayarkLogo());

        // ��� ����
        delayManager.AddDelayedAction(4.0f, () => TitleSceneTasks.instance.StartBackgrounds());

        // ��� �ΰ� ����
        delayManager.AddDelayedAction(8.0f, () => TitleSceneTasks.instance.StartDeemoLogo());

        // ��ġ �� ��ŸƮ ���� ����
        delayManager.AddDelayedAction(3.0f, () => TitleSceneTasks.instance.StartTouchToStart());

    }
}