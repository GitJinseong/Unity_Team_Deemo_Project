using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Choi_GameManager : MonoBehaviour
{
    public static Choi_GameManager instance;
    public TMP_Text txt_Accuracy;
    public TMP_Text judgeText;
<<<<<<< HEAD
    public TMP_Text comboText;
    public TMP_Text comboText_Shadow;
    public string formattedAccuracy = "0.00";

=======
    public TMP_Text timingText;
    public string formattedAccuracy = "0.00";
>>>>>>> origin/Park
    private int total_Charming;
    private int total_Normal;
    private int total_Miss;
    private int total_Combo;

    public int activatedJudgeColliderCount = 0;

    private void Awake()
    {
        instance = this;
    }

    public void ChangeComboText()
    {
        comboText.text = total_Combo.ToString();
        comboText_Shadow.text = comboText.text;
    }

    public void AddCharming()
    {
        total_Charming++;
        AddCombo();
        judgeText.text = "(" + total_Combo.ToString() + ") " + "CHARMING!";
    }

    public void AddNormal()
    {
        total_Normal++;
        AddCombo();
        judgeText.text = "(" + total_Combo.ToString() + ") " + "NORMAL!";

    }

<<<<<<< HEAD
    public void AddMiss()
    {
=======
    public void AddCharming()
    {
        total_Charming++;
        AddCombo();
        judgeText.text = "(" + total_Combo.ToString() + ") " + "CHARMING!";
    }

    public void AddNormal()
    {
        total_Normal++;
        AddCombo();
        judgeText.text = "(" + total_Combo.ToString() + ") " + "NORMAL!";

    }

    public void AddMiss()
    {
>>>>>>> origin/Park
        total_Miss++;
        ResetCombo();
        judgeText.text = "(" + total_Combo.ToString() + ") " + "MISS!";
    }

    public void AddCombo()
    {
        total_Combo++;
<<<<<<< HEAD
        ChangeComboText();
=======
>>>>>>> origin/Park
        GetAccuracy();
    }

    public void ResetCombo()
    {
        total_Combo = 0;
<<<<<<< HEAD
        comboText.text = "";
        comboText_Shadow.text = "";
=======
>>>>>>> origin/Park
        GetAccuracy();
    }

    public void RemoveHistory()
    {
        formattedAccuracy = "0.00";
        total_Charming = 0;
        total_Normal = 0;
        total_Miss = 0;
        total_Combo = 0;
    }

    public int GetTrueNotes()
    {
        int truenotes = 0;
        truenotes = total_Charming + total_Normal;

        return truenotes;
    }

    public int GetTrueCharmingNotes()
    {
        return total_Charming;
    }

    // 정확도(%) 구하는 함수
    // ex) 전부 charming = 100% / 전부 normal = 90% / 전부 miss = 0%
    public void GetAccuracy()
    {
        int total_Notes = total_Charming + total_Normal + total_Miss;
        Debug.Log("Total Notes: " + total_Notes);

        float total_Accuracy;

<<<<<<< HEAD
        total_Accuracy = Mathf.Clamp(((total_Charming * 1.0f) + (total_Normal * 0.9f) - (total_Miss * 1.0f)) / total_Notes, 0f, 1f);
=======

            total_Accuracy = Mathf.Clamp(((total_Charming * 1.0f) + (total_Normal * 0.9f) - (total_Miss * 1.0f)) / total_Notes, 0f, 1f);
>>>>>>> origin/Park

        total_Accuracy *= 100f; // Convert to percentage
        Debug.Log("Total Accuracy: " + total_Accuracy);

        formattedAccuracy = total_Accuracy.ToString("F2"); // Format to 2 decimal places
        txt_Accuracy.text = formattedAccuracy + "%";
    }
}
