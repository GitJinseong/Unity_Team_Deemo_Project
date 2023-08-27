using UnityEngine;

public class Choi_JudgeManager : MonoBehaviour
{
    public static Choi_JudgeManager instance;
    private Choi_CollisionDetection note_CollisionDetection;
    private Choi_Note note_Note;
    private SpriteRenderer note_SpriteRenderer;
    private float judge_CharmingTime;
    private float judge_NormalTime;
    private float judge_MissTime;
    private float speed;
    private float moveDuration;
    private const float DEFAULT_MOVE_DURATION = 4.0f;
    private Color charming_Color = new Color(1f, 0.9647f, 0.8549f); // RGB: FFF6DA
    private Color normal_Color = new Color(0.7686f, 0.8392f, 1f);  // RGB: C4D6FF
    private Color miss_Color = new Color(1f, 1f, 1f); // RGB: FFFFFF

    private void Awake()
    {
        speed = Park_GameManager.instance.speed;
        AdjustMoveDuration();
        instance = this;
    }

    public void CheckJudge(GameObject note)
    {
        note_CollisionDetection = note.GetComponent<Choi_CollisionDetection>();
        note_SpriteRenderer = note_CollisionDetection.obj_LightEffect.GetComponent<SpriteRenderer>();

        if (note_CollisionDetection.isHide == false)
        {
            note_Note = note.GetComponent<Choi_Note>();

            Debug.Log($"��ƮŸ�̹�: {note_Note.runTime}");

            // í�� ����
            if (note_Note.runTime > judge_CharmingTime && note_CollisionDetection.isJudgeHide == false)
            {
                note_CollisionDetection.Hide();
                ChangeColor(note_SpriteRenderer, charming_Color);
                Choi_GameManager.instance.AddCharming();
            }
            // �븻 ����
            else if (note_Note.runTime > judge_NormalTime && note_CollisionDetection.isJudgeHide == false)
            {
                note_CollisionDetection.Hide();
                ChangeColor(note_SpriteRenderer, normal_Color);
                Choi_GameManager.instance.AddNormal();
            }
            // �̽� ����
            else
            {
                note_CollisionDetection.Hide();
                ChangeColor(note_SpriteRenderer, miss_Color);
                Choi_GameManager.instance.AddMiss();
            }
        }
    }

    public void ChangeColor(SpriteRenderer sprite, Color _color)
    {
        sprite.color = _color;
    }

    private void AdjustMoveDuration()
    {
        if (speed == 5.0f)
        {
            moveDuration = 4.0f;
        }
        else if (speed == 1.0f)
        {
            moveDuration = 10.0f;
        }
        else if (speed == 9.0f)
        {
            moveDuration = 1.0f;
        }
        else if (speed > 1.0f && speed < 9.0f)
        {
            // speed�� 1.5���� ũ�� 8.5���� ���� ��
            // speed�� 1.5���� 8.5 ���̿� �ִ� ��쿡 ����Ͽ� moveDuration ���� ����
            float normalizedSpeed = (speed - 1.0f) / 9.0f; // 1.0���� 9.0������ ������ 0���� 1 ������ ������ ����ȭ
            moveDuration = Mathf.Lerp(10.0f, 1.0f, normalizedSpeed); // 1.0���� 10.0 ���̷� �����Ͽ� moveDuration ����
        }

        SetJudgeDuration();
    }

    public void SetJudgeDuration()
    {
        //float difference = 0.0f;

        // ���ǵ尡 �⺻ ���ǵ� ���� ���ų� ���� ���
        if (moveDuration <= DEFAULT_MOVE_DURATION)
        {
            //difference = 0.025f * moveDuration;
            judge_CharmingTime = moveDuration - (0.025f * moveDuration);
            judge_NormalTime = moveDuration - (0.05f * moveDuration);
        }
        // ���ǵ尡 �⺻ ���ǵ� ���� ���� ���
        else if (moveDuration > DEFAULT_MOVE_DURATION)
        {
            //difference = 0.019f * moveDuration;
            judge_CharmingTime = moveDuration - (0.019f * moveDuration);
            judge_NormalTime = moveDuration - (0.038f * moveDuration);
        }

        //judge_CharmingTime = moveDuration - 0.1f;
        //judge_NormalTime = moveDuration - 0.2f;
    }
}
