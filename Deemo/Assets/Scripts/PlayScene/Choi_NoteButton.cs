using TMPro;
using UnityEngine;

public class Choi_NoteButton : MonoBehaviour
{
    private Choi_CollisionDetection script_CollisionDetection;
    private float judge_Charming = -1.2f;
    private float judge_Normal = -1.4f;

    private bool isPressed = false; // ��Ʈ�� ���ȴ��� ���θ� �����ϴ� ����

    private void Awake()
    {
        script_CollisionDetection = GetComponent<Choi_CollisionDetection>();
    }
    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                Vector3 touchPosition = new Vector3(touch.position.x, touch.position.y, 10); // z���� ȭ�鿡 ����� ������ ����
                touchPosition = Camera.main.ScreenToWorldPoint(touchPosition);

                Debug.Log(touchPosition);
                Collider collider = GetComponent<Collider>();

                // ��ġ �Է� ��ġ�� ��Ʈ�� Ŭ�� ���� ��
                if (!isPressed && script_CollisionDetection.isHide == false && collider.bounds.Contains(touchPosition))
                {
                    HandleButtonPress();
                }
            }
        }
    }

    private void HandleButtonPress()
    {
        isPressed = true; // ��Ʈ�� �������� ǥ��

        Debug.Log($"Ŭ���� ��Ʈ�� y��ǥ : {transform.position.y}");
        if (transform.position.y < judge_Charming)
        {
<<<<<<< HEAD
            Choi_GameManager.instance.AddCharming();
        }
        else if (transform.position.y < judge_Normal)
        {
            Choi_GameManager.instance.AddNormal();
        }
        else
        {
            Choi_GameManager.instance.AddMiss();
=======
            Choi_GameManager.instance.AddCombo();
            Choi_GameManager.instance.ChangeJudgeText("CHARMING!");
        }
        else if (transform.position.y < judge_Normal)
        {
            Choi_GameManager.instance.AddCombo();
            Choi_GameManager.instance.ChangeJudgeText("NORMAL!");
        }
        else
        {
            Choi_GameManager.instance.ResetCombo();
            Choi_GameManager.instance.ChangeJudgeText("MISS!");
>>>>>>> origin/Park
        }
        script_CollisionDetection.Hide();
    }
}
