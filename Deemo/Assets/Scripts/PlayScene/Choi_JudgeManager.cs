using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choi_JudgeManager : MonoBehaviour
{
    public static Choi_JudgeManager instance;
    private float judge_Charming = -1.4f;
    private float judge_Normal = -0.5f;
    private float note_PosY;
    private Choi_CollisionDetection note_CollisionDetection;

    private void Awake()
    {
        instance = this;
    }

    public void CheckJudge(GameObject note)
    {
        note_PosY = note.transform.position.y;
        note_CollisionDetection = note.GetComponent<Choi_CollisionDetection>();
        if (note_CollisionDetection.isHide == false)
        {
            if (note_PosY < judge_Charming)
            {
                note_CollisionDetection.Hide();
<<<<<<< HEAD
                Choi_GameManager.instance.AddCharming();
=======
<<<<<<< HEAD
                Choi_GameManager.instance.AddCharming();
=======
                Choi_GameManager.instance.AddCombo();
                Choi_GameManager.instance.ChangeJudgeText("CHARMING!");
>>>>>>> origin/Park
>>>>>>> c013a51fda2e20590b6ee9a7fc0fd9e9ee1407dd
            }
            else if (note_PosY < judge_Normal)
            {
                note_CollisionDetection.Hide();
<<<<<<< HEAD
                Choi_GameManager.instance.AddNormal();
=======
<<<<<<< HEAD
                Choi_GameManager.instance.AddNormal();
=======
                Choi_GameManager.instance.AddCombo();
                Choi_GameManager.instance.ChangeJudgeText("NORMAL!");
>>>>>>> origin/Park
>>>>>>> c013a51fda2e20590b6ee9a7fc0fd9e9ee1407dd
            }
            else
            {
                note_CollisionDetection.Hide();
<<<<<<< HEAD
                Choi_GameManager.instance.AddMiss();
=======
<<<<<<< HEAD
                Choi_GameManager.instance.AddMiss();
=======
                Choi_GameManager.instance.ResetCombo();
                Choi_GameManager.instance.ChangeJudgeText("MISS!");
>>>>>>> origin/Park
>>>>>>> c013a51fda2e20590b6ee9a7fc0fd9e9ee1407dd
            }
        }
    }
}
