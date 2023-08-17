using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choi_ObjectFinder : MonoBehaviour
{
    public static Choi_ObjectFinder instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    // ������Ʈ�� �̸��� �޾� �ش� ������Ʈ�� ã�Ƽ� ��ȯ�Ѵ�.
    public GameObject FindObjectByName(string objectName)
    {
        foreach (GameObject obj in Resources.FindObjectsOfTypeAll<GameObject>())
        {
            if (obj.name == objectName)
                return obj;
        }

        return null;
    }
}