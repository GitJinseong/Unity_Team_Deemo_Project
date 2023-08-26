using UnityEngine;

public class Choi_TimeLineController : MonoBehaviour
{
    public GameObject[] notes;
    public Park_MainSceneOpacity mainSceneOpacity;
    public RectTransform movingObject;
    public Choi_LoadScene loadScene;
    public float duration = 30f;
    private float startDelay = 6.0f;
    private float startTime;
    private float startX = 16f;
    private float endX = 1264f;
    private string sceneName = "ResultScene";
    private bool isStarted = false;

    private void Awake()
    {
        int index = Park_GameManager.index;
        duration = float.Parse(Park_GameManager.instance.musicInformation["Time"][index]) - 3.0f;
    }

    private void Start()
    {
        Invoke("StartMoving", 3f); // 3�� �Ŀ� StartMoving �Լ� ȣ��
    }

    private void Update()
    {
        if (!isStarted)
            return;

        float t = (Time.time - startTime) / duration;
        float newX = Mathf.Lerp(startX, endX, t);

        Vector3 newPosition = movingObject.anchoredPosition;
        newPosition.x = newX;
        movingObject.anchoredPosition = newPosition;

        if (t >= 1f)
        {
            SetAllNoteActiveForFalse(); // ��� ��Ʈ�� ��Ȱ��ȭ�Ǿ����� Ȯ��
        }
    }

    private void StartMoving()
    {
        isStarted = true;
        startTime = Time.time;
    }

    private void SetAllNoteActiveForFalse()
    {
        foreach (GameObject note in notes)
        {
            note.SetActive(false); // �� ��Ʈ�� ��Ȱ��ȭ�մϴ�.
        }

        // ��� ��Ʈ�� ��Ȱ��ȭ�Ǿ��� ���� ó��
        enabled = false; // �� ��ũ��Ʈ�� ��Ȱ��ȭ�Ͽ� ������Ʈ ����
        StartCoroutine(mainSceneOpacity.EndOpacity());
        loadScene.Run(1f, sceneName);
    }

}
