using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayManager : MonoBehaviour
{
    // �����̿� �Բ� ����� �۾����� ���� Ŭ����
    private class DelayedAction
    {
        public float Delay { get; } // ������ �ð�
        public System.Action Action { get; } // ����� �۾�

        public DelayedAction(float delay, System.Action action)
        {
            Delay = delay;
            Action = action;
        }
    }

    // ��⿭�� ����� ����Ʈ
    private readonly Queue<DelayedAction> actionQueue = new Queue<DelayedAction>();

    // ��⿭�� �۾� �߰�
    public void AddDelayedAction(float delay, System.Action action)
    {
        actionQueue.Enqueue(new DelayedAction(delay, action));
    }

    // �ڷ�ƾ���� ��⿭�� �۾� ����
    private IEnumerator RunDelayedActions()
    {
        while (actionQueue.Count > 0)
        {
            DelayedAction delayedAction = actionQueue.Dequeue();
            yield return new WaitForSeconds(delayedAction.Delay);
            delayedAction.Action?.Invoke();
        }
    }

    // DelayManager ��ü�� ������ �� �ڷ�ƾ ����
    private void Start()
    {
        StartCoroutine(RunDelayedActions());
    }
}