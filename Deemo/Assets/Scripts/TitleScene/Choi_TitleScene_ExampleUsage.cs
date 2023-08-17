using UnityEditor;
using UnityEngine;

public class Choi_TitleScene_ExampleUsage : MonoBehaviour
{
    private Choi_DelayManager delayManager = default;
    private void Start()
    {
        delayManager = GetComponent<Choi_DelayManager>();
        RegisterDelayedActions();
    }

    // �پ��� �۾��� ����ϰ� ���� �ٸ� �����̸� �����ϴ� �Լ�
    // ���� �׼��� �����̰� ���� �� ���� �׼��� �����̸� �����Ѵ�.
    private void RegisterDelayedActions()
    {
        // �⺻ �ΰ� ����
        delayManager.AddDelayedAction(2.0f, () => Choi_TitleSceneTasks.instance.StartRayarkLogo());

        // ��� ����
        delayManager.AddDelayedAction(4.0f, () => Choi_TitleSceneTasks.instance.StartBackgrounds());

        // ��� �ΰ� ����
        delayManager.AddDelayedAction(8.0f, () => Choi_TitleSceneTasks.instance.StartDeemoLogo());

        // ��ġ �� ��ŸƮ ���� ����
        delayManager.AddDelayedAction(3.0f, () => Choi_TitleSceneTasks.instance.StartTouchToStart());

    }
}