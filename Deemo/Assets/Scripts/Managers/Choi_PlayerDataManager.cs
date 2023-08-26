using UnityEngine;

public class Choi_PlayerDataManager : MonoBehaviour
{
    // ���ھ� �����ϴ� �Լ�
    public static void SaveScore(int index, string key, float score)
    {
        string tempKey = key + "_" + index; // EasyBestScore_1 �� ���� ������ Ű ������ ����
        // ���ο� ���ھ ���� ���ھ� ���� ���� ��� ����
        Debug.Log($"����: {GetScore(tempKey)}, ����: {score}");
        if (GetScore(tempKey) < score)
        {
            Debug.Log("���ھ����");
            Park_GameManager.isNewRecord = true;
            PlayerPrefs.SetFloat(tempKey, score); // PlayerPrefab�� �� ����
            PlayerPrefs.Save(); // ���� ���� ����
        }
    }

    // ���ھ� ȣ�� �� ��ȯ�ϴ� �Լ�
    public static float GetScore(string key)
    {
        return PlayerPrefs.GetFloat(key); // PlayerPrefab�� ����� ���� ȣ�� �� ��ȯ
    }

    // �迭 ���·� ���ھ� �޾ƿ��� �Լ�
    public static float[] GetScoreForAll(string type)
    {
        int totalIndex = Park_GameManager.instance.musicInformation["List"].Count - 1;
        float[] tempScores = new float[totalIndex];
        string tempKey = "";
        for (int i = 0; i < totalIndex; i++)
        {
            tempKey = type + "_" + i; // EasyBestScore_1 �� ���� ������ Ű ������ ����
            tempScores[i] = GetScore(tempKey);
        }

        return tempScores;
    }
}
