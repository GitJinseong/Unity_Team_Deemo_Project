using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Park_OnClickSettingBackground : MonoBehaviour
{
    public Park_OnClickSettingUi onClickSettingUi;

    // �ڷ�ƾ�� ���������� Ȯ��
    public bool isCoroutine = false;

    // ��ư�� ������ �ִ��� Ȯ��
    private bool isPressed = false;

    // OnMouseUp ���� Ȯ��
    public bool isCheck = false;

    private void OnMouseDown()
    {
        if (onClickSettingUi.isCoroutine == false)
        {
            isPressed = true;
        }
    }
    private void OnMouseUp()
    {
        if (isPressed == true)
        {
            isPressed = false;

            isCheck = true;
        }
    }
}
