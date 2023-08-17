using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Choi_SettingUICloseEffect : MonoBehaviour
{
    public GameObject obj_closeUI = default;
    public GameObject obj_BtnSetting = default;
    public GameObject obj_Btns = default;
    public GameObject obj_SettingUIPanel = default;

    public float waitForCloseTime = 1.2f;

    private Image img_BtnSetting = default;
    private Coroutine delayCoroutine; // Delay �ڷ�ƾ ������ �����ϴ� ����
    private Choi_FadeOutSettingObjects script_FadeOutSettingObjects = default;
    private Choi_FadeOutSettingPanel script_FadeOutSettingPanel = default;


    public void Awake()
    {
        img_BtnSetting = obj_BtnSetting.GetComponent<Image>();

        script_FadeOutSettingObjects = obj_Btns.GetComponent<Choi_FadeOutSettingObjects>();
        script_FadeOutSettingPanel = obj_SettingUIPanel.GetComponent<Choi_FadeOutSettingPanel>();
    }

    public void CloseUI()
    {
        if (delayCoroutine != null) // �̹� ���� ���� Delay �ڷ�ƾ�� �ִٸ� ������ŵ�ϴ�.
        {
            return;
        }
        else
        {
            // ������ ��ũ��Ʈ ������Ʈ ��� ����
            script_FadeOutSettingObjects.StartFadeOut();
            script_FadeOutSettingPanel.StartFadeOut();
            delayCoroutine = StartCoroutine(Delay());
        }
    }

    public IEnumerator Delay()
    {
        yield return new WaitForSeconds(waitForCloseTime);
        delayCoroutine = null; // �ڷ�ƾ ������ �������Ƿ� ������ �ʱ�ȭ�մϴ�.
        img_BtnSetting.raycastTarget = true;
        obj_closeUI.SetActive(false);
    }
}
