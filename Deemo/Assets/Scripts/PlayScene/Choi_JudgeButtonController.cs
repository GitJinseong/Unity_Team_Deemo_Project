using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class Choi_JudgeButtonController : MonoBehaviour, IPointerClickHandler
{
    public GameObject obj_Notes; // ��ư�� Ŭ���ϸ� Y���� ���� ���� �ڽ� ������Ʈ�� ã�� �θ� ������Ʈ
    private float min_SearchPosY = 2.0f; // ã�� ��Ʈ�� �ּ� y ��
    // ��ư Ŭ�� �� ����Ǵ� �Լ�
    public void OnPointerClick(PointerEventData eventData)
    {
        // Y���� ���� ���� �ڽ� ������Ʈ�� ã�Ƽ� ����
        GameObject lowestYObject = GetLowestYObject(obj_Notes.transform);
        if (lowestYObject != null)
        {
            Debug.Log($"����y: {lowestYObject.transform.position.y}");
            // Y���� ���� ���� ������Ʈ�� �Ű������� �Ͽ� ���� �Լ� ȣ��
            Choi_JudgeManager.instance.CheckJudge(lowestYObject);
        }
    }

    // Y���� ���� ���� �ڽ� ������Ʈ�� ã�Ƽ� ��ȯ
    GameObject GetLowestYObject(Transform parentTransform)
    {
        GameObject lowestYObject = null;
        float lowestY = float.MaxValue;

        foreach (Transform child in parentTransform)
        {
            GameObject note = child.transform.Find("Note").gameObject;
            if (note.gameObject.activeSelf && note.transform.position.y < lowestY && note.transform.position.y < min_SearchPosY)
            {
                lowestY = note.transform.position.y;
                lowestYObject = note.transform.gameObject;
            }
        }

        return lowestYObject;
    }
}
